using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace ConsoleApplication2
{

    class Person
    {

        public static void SavePersons(Person[] array, string fich)
        {
            int contador = 0;

            foreach (Person p in array)
            {
                if (p != null)
                {

                    contador++;

                }

            }




            var save = new StreamWriter (fich);

            save.WriteLine(contador);

            foreach (Person p in array)
            {
                if (p != null)
                {
                    save.WriteLine(p.GetType().FullName);
                    p.SaveFile(save);
                    
                }

            }
           
 
            save.Close();

        }



        public static Person[] ReadFilePersons(string fich)
        {

            var sr = new StreamReader(fich);

            string linha1;
            linha1= sr.ReadLine();
            int contador;
            contador = int.Parse(linha1);

            Person[] persons = new Person[contador];

            string linha;
            int i;
            try
            {
                for (i = 0; i < contador; i++)
                {

                    Person p;
                    linha = sr.ReadLine();
                    var tipo = Type.GetType(linha);

                    //ConstructorInfo[] info_const1 = tipo.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                    //p= info_const1[0].Invoke(new object[0]) as Person;

                    p= Activator.CreateInstance(tipo, true) as Person;

                    
                    var infocampos = tipo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

                    p.Read(sr);


                    if (infocampos[0].FieldType == typeof(string))
                        infocampos[0].SetValue(p, "xpto");

                    persons[i] = p;
                }
            }

            catch (Exception erro)
            {
                Console.WriteLine("erro {0} na leitura", erro); 
            }
            sr.Close();

            



            return persons;
        }


        protected virtual void Read(StreamReader s)

        {
        string linha;
        linha = s.ReadLine(); //id
        _id = int.Parse(linha);
        Name = s.ReadLine(); //nome
        linha = s.ReadLine(); //dt nasc
        _birthdate = DateTime.Parse(linha);
        linha = s.ReadLine(); //vip
        _vip = bool.Parse(linha);
        
        }

        public static int GetNumberCli()
        {
            return _nextId;
        }

        private static int _nextId; // static significa q estã na classe apenas,não fica no molde dos objectos 
        //membros - constituintes (campos e métodos) campos são variáveis
        private string _name;
        private int _id;
        private DateTime _birthdate;
        private bool _vip = true;

        public string Name // criar uma propriedade chamada Nome
        {

            get {return _name; } // código a ser efectuado no momento da leitura

            set { _name = value.ToUpper(); } // código a ser efectuado no momento da escrita

        }

        public int Id
        {
            get { return _id; }

        }


        public int Age
        {
            get
            {
                DateTime today = DateTime.Now;
                int age = today.Year -_birthdate.Year -1;
                if (today.Month > _birthdate.Month ||
                      (today.Month == _birthdate.Month &&
                       today.Day >= _birthdate.Day))

                { age = age + 1; }

                return age;
            }

        }    
        //construtores - quando o objecto é criado fica logo num estado integro, iniciado

        protected Person() { }

        public Person(string name, DateTime birthdate) : this(name, birthdate, false) // o nome do contrutor tem de ter o nome da classe

        {



            //_name = name.ToUpper();
            //Name = name; // chama a propriedade Name usando o set
            //_id = _nextId;
            //_nextId += 1;
            //_birthdate = birthdate;

        }

        public Person(string name, DateTime birthdate, bool vip)
        {

            Name = name; // chama a propriedade Name usando o set
            _id = _nextId;
            _nextId += 1;
            _birthdate = birthdate;

            _vip = vip;

        }

        // métodos - acções, procedimentos

        public void Show()
        {

            Console.WriteLine("Nome: {0}, Id: {1}, Data nascimento {2}, vip {3}",
                   _name, 
                   _id, 
                   _birthdate,
                   _vip ? "sim":"não"
                   );


        }

        public override string ToString() // com override passa por cima do to string que existe em object
        {
            return "ID= "+_id+ "\nName= "+ _name+"\nDt Nasc= "+_birthdate+ "\nVip: "+_vip;

        }


        public virtual void SaveFile(StreamWriter s)
        {
        
            //if (GetType() == typeof(Student))
            //     {s.WriteLine("S");}
            //else
            //     {s.WriteLine("P");}
        
            s.WriteLine(this._id);
            s.WriteLine(this.Name);
            s.WriteLine(this._birthdate);
            s.WriteLine(this._vip);
        }


 
    }

    class Student : Person
    {
        int _nr_aluno; 

        public Student( string name, DateTime birthdate, int nr_aluno)
            : base (name, birthdate) {
                _nr_aluno = nr_aluno;
                        }

        private Student() { }


        protected override void Read(StreamReader s)
        {

            base.Read(s);
            string linha;
            linha = s.ReadLine(); //nr aluno
            _nr_aluno = int.Parse(linha);

        }

        public override string ToString() // com override passa por cima do to string que existe em object
        {
            return base.ToString() + "\nnr_aluno= "+_nr_aluno ; // base.tostring referencia para o proprio objecto considerando a classe base

        }

        public int nr_aluno { get { return _nr_aluno; } }

        public override void SaveFile(StreamWriter s) 
        {
            base.SaveFile(s);
            s.WriteLine(this._nr_aluno);

        }


    }

    class Teacher : Person
    {
        
        public enum Categoria {coordenador, adjunto, assistente};
        Categoria _categoria;

        public Teacher(string name, DateTime birthdate, Categoria categoria)
            : base(name, birthdate)
        {
            _categoria = categoria;
        }

        private Teacher () { }


        protected override void Read(StreamReader s)
        {

            base.Read(s);
            string linha;
            linha = s.ReadLine(); //categoria
            _categoria = (Categoria)Enum.Parse(typeof(Categoria), linha);

        }

        public override string ToString() // com override passa por cima do to string que existe em object
        {
            return base.ToString() + "\ncategoria= " + _categoria; // base.tostring referencia para o proprio objecto considerando a classe base

        }

        public Categoria categoria { get { return _categoria; } }

        public override void SaveFile(StreamWriter s)
        {
            base.SaveFile(s);
            s.WriteLine(this._categoria);

        }


    }


    class Program
    {


        public static Person ObtemNome() // devolve uma estrutura person
        {
            string _name;
            DateTime _dt_nasc;
            Console.Write("Introduza o Nome:");
            _name=Console.ReadLine();
            Console.Write("Introduza a data de nascimento:");
            string linha = Console.ReadLine();
            _dt_nasc=DateTime.Parse(linha);

            Person p = new Person(_name, _dt_nasc);

            return p;
        }


        static void Main5(string[] args)
        {
            Person[] malta; // criar um instancia q identifica um array de Person
            malta = new Person[10]; // identifica q malta é um array de 10




            /*int max = 3; // máx pessoas a ler
            
            for (int pointer = 0; pointer < max; ++pointer)
            {

                malta[pointer] = ObtemNome();
            }*/

            int max = ReadFilePersons(malta, "Pessoas.txt");

            for (int pointer = 0; pointer < max; ++pointer)
            {

                Console.WriteLine(malta[pointer].ToString()); 
            }
            malta[3] = new Student("Zé", new DateTime(2005, 1, 1), 10);

            foreach (Person elemento in malta)
            {
                if (elemento != null)
                    Console.WriteLine("{0} Idade: {1}", elemento, elemento.Age);
            }

            int i;
            string linha1;
            Console.Write("Introduza número:");
            
            linha1 = Console.ReadLine();
            i = int.Parse(linha1);
            //Console.WriteLine(malta[i].ToString()); 

            
            Student s = malta [i] as Student;
            if (s != null)
                Console.WriteLine("nr_aluno {0} ", s.nr_aluno);
            else 
                Console.WriteLine("Não é estudante  {0} ", malta [i]); 
            //Console.WriteLine("Fim");


        }

        private static int ReadFilePersons(Person[] array, string fich)
        {
            int contador = 0;

            var sr = new StreamReader (fich); 
            {
                string line_nome;
                  while ((line_nome = sr.ReadLine()) != null)  
                  {
                      string line_data = sr.ReadLine() ;
                      array[contador] = new Person(line_nome, DateTime.Parse(line_data));
                      contador ++ ; // contador = contador + 1

                  }

                  sr.Close();

            }



            return contador;
        }




        static void Main4(string[] args)  

        {

            Object p;
            p = ObtemNome();
            Console.WriteLine(p.ToString());


        }

        static void Main3(string[] args)
        {
            int i;
            string s;
            float f;
            double d;
            bool b;

            i =4;
            s = "abc";
            f = 3.14f;
            d = f * 0.1;
            b = true;

           // i = i * -42;
            s = s + "123";
            Console.WriteLine(s);

            if (i > 1)
            {

                Console.WriteLine("i> 1 is true");

            }else
            {

                Console.WriteLine("i> 1 is not true");
                Console.WriteLine("i> 1 is not true2");

            }

            while (i > 0)
            {
                Console.WriteLine ("i = {0}", i);
                i -= 1;

            }

            i = 4;
            do
            {

                Console.WriteLine("i = {0}", i);
                i -= 1;

            } while (i > 0);

            int[] array = { 1, 2, 3, 4, 5 };

            for (int ix = 0; ix < array.Length; ++ix)
            {
                Console.WriteLine("O conteudo do indice {0} é {1}", ix, array[ix]);
            }


            foreach (int elemento in array)
            {
                Console.WriteLine(elemento);
            }


        }


        static void Main2(string[] args)
        {

            Person p1 = new Person("Alice", new DateTime(1980,1,1),true); // p1 é uma <referência para um objecto com a estrutura da classe person
            int i = p1.Id;
            p1.Name = "Alice Tomás";
            p1.Show(); // chama o objecto show sobre o objecto p1
            Console.WriteLine("age{0} é parecido com {1}", p1.Name, p1.Age);
            Console.WriteLine("número de bonecos {0}", Person.GetNumberCli());

            Person p2 = new Person("Bob",  new DateTime(1990,1,1)); ;

            p2.Show(); // chama o objecto show sobre o objecto p2

            Console.WriteLine("número de bonecos {0}", Person.GetNumberCli());
 

        }

        static void Main(string[] args)
        {
            Person[] malta; // criar um instancia q identifica um array de Person
            malta = new Person[10]; // identifica q malta é um array de 10

            malta[0] = new Person("Zé", new DateTime(2005, 1, 1),true);
            malta[1] = new Student("Manel", new DateTime(2006, 1, 1), 10);
            malta[2] = new Person("Xico", new DateTime(2002, 1, 1), false);
            malta[3] = new Teacher("Mário", new DateTime(2002, 1, 1), Teacher.Categoria.assistente);

            foreach (Person elemento in malta)
            {
                if (elemento != null)
                    Console.WriteLine("{0} Idade: {1}", elemento, elemento.Age);
            }


             string fich;
            Console.Write("Indique ficheiro: ");

            fich = Console.ReadLine();

            Person.SavePersons(malta, fich);

            var malta1 = Person.ReadFilePersons(fich);
            Console.WriteLine("Leu");
            foreach (Person elemento in malta1)
            {
                Console.WriteLine(elemento);
                Console.WriteLine();
            }


        }



    }
}
