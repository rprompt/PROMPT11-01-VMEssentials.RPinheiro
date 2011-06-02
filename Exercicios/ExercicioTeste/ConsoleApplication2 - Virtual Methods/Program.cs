using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApp1
{
    class Person // Molde / Formulário
    {
        private static int _nextId; // este inteiro existe sempre nesta classe e não é passado para os objectos

        public static int GetNumberOfPersons() // método da classe que não é passado para os objectos
        {
            return _nextId;
        }

        // Membros: campos e métodos
        protected string _name;
        private int _id;
        protected DateTime _birthDate;
        private bool _isGoldCostumer;


        public override string ToString() 
        {

            return "Name: "+_name+"\n Dt Nasc: "+_birthDate;
        }



        //Propriedades 
        public string Name // as linhas deste código são executadas em  momentos diferentes
        {
            get { return _name; } //afectado na chamada de Name
            set { _name = value.ToUpper(); } //afectado escrita de Name
        }

        public int Id 
        {
            get { return _id; } //afectado na chamada de Id
        }

        public int Age 
        {
            get 
            {
                DateTime today = DateTime.Now;
                int age = today.Year - _birthDate.Year - 1;
                    if (today.Month > _birthDate.Month || 
                       (today.Month == _birthDate.Month &&
                       (today.Day >= _birthDate.Day)))
                    {
                        age += 1;
                    }
                return age;
            } //afectado na chamada de Id
        }


        // constructores - tem como finalidade inicializar a estrutura de forma a que o obj seja íntegro
        public Person(string name, DateTime birhDate)
        {
          //  this.name = name;
          //  this.id = id;

          //  _name = name.ToUpper();
            Name = name;   // na propriedade Name será aplicado o ToUpper 
            _id = _nextId;
            _nextId += 1;  //_nextId = _nextId + 1
            _birthDate = birhDate;
                   
        }

        public Person(string name, DateTime birthDate, bool isGoldCustomer)
        {
            Name = name;   // na propriedade Name será aplicado o ToUpper 
            _id = _nextId;
            _nextId += 1;  //_nextId = _nextId + 1
            _birthDate = birthDate;
            _isGoldCostumer = isGoldCustomer;

        }

        // métodos - acções, procedimentos

        public void Show() // void significa que o método não retorna nada
        {

            Console.WriteLine("Nome: {0}, ID: {1}, Data de nascimento; {2} VIP: {3}",
                _name, 
                _id, 
                _birthDate, 
                _isGoldCostumer ? "Sim" : "Não"
                );

        }


    }

    class Student : Person {


        int numAluno;

        public Student(string name, DateTime dtNasc, int num) 
        : base(name, dtNasc) {
        
            numAluno = num;


        }

        public override string ToString()
        {

            //string txt = "Name: " + _name + "\n Dt Nasc: " + _birthDate ;
            // ou
            string txt = base.ToString();
            txt += "\n NumAluno: " + numAluno;

            return txt;
        }

        public int Number
        {
            get
            {
                return numAluno;
            }
        }

   }

    class Program
    {

        public static Person readPerson()
        {

            string name;
            DateTime dt;
            Console.Write("Introduza o nome:");
            name = Console.ReadLine();
            Console.Write("Introduza dtnasc:");
            string line = Console.ReadLine();
            dt = DateTime.Parse(line);
            return new Person(name, dt);
            
        }



        static void Main(string[] args)
        {
            
            Person[] malta; 
            malta = new Person[10];
//            int mx = 3;
//            for (int ix = 0; ix < mx; ix++)
//                malta[ix] = readPerson();
            
            int max = readFilePersons(malta, "pessoas.txt");
            
            malta[max] = new Student("Zé", new DateTime(2001,1,1), 10);
            
            Console.WriteLine("Lista de Pessoas");

            foreach(Person p in malta)
            {
             
                if (p != null)
                   Console.WriteLine("{0} Idade = {1}", p, p.Age);

            }

            int i;
            
            Console.Write("Introduza o indice: ");
            string line = Console.ReadLine();
            i = int.Parse(line);

            // if (malta[i] is Student) pergunta se é do tipo student 
            // Student s = (student) malta[i];  se quisermos forçar o tipo student
            Student s = malta[i] as Student; // se quisermos que assuma null se n for do tipo student

            if (s!=null)
                Console.WriteLine("number = {0}", s.Number);
            else
                Console.WriteLine("not student");

             //Console.WriteLine("Pessoa : {0}", p.ToString());
        }

        private static int readFilePersons(Person[] a, string f)
        {
            int count = 0;
            StreamReader sr = new StreamReader(f);
            string lineName;
            string lineDt;
            while ((lineName = sr.ReadLine()) !=null)
            {
                lineDt = sr.ReadLine();
                //string line = Console.ReadLine();
                //dt = DateTime.Parse(line);
                a[count] = new Person(lineName, DateTime.Parse(lineDt));
                count ++;
            }

            sr.Close();
            return count;

        }

        static void Main3(string[] args)
        {
            int i;
            string s;
            float f;
            double d;
//            bool b;

            i = 2;
            s = "abc";
            f = 3.14f;
            d = f * 0.1;
//            b = true;

            i = i + 2 * 3 / 4;
            s = s + "123";
            s = s + 456;
            s = s + (20 + 30);
            Console.WriteLine(s);

            if (i < 1)
            {
                // Se i > 1 é true
                Console.WriteLine("i>1 é true");
            }
            else
            {
                Console.WriteLine("i>1 é false");
            }

            if (i > 1)
                // Se i > 1 é true
                Console.WriteLine("i>1 é true");
            else
                Console.WriteLine("i>1 é false");
            Console.WriteLine("i>1 é false");


            while (i > 0)
            {

                Console.WriteLine("i = {0}", i);
                i -= 1;
            
            }
            i = 4;


            do
            {
                Console.WriteLine("i = {0}",i);
                i -= 1;

            } while (i > 0);

            // o índice é   0  1  2  3  4
            int[] array = { 1, 2, 3, 4, 5 };

            for (int ix = 0; ix < array.Length; ++ix )
            {
                Console.WriteLine("O conteúdo do array {0} é {1}", ix, array[ix]);

            }

            foreach (int elem in array)
            {
                Console.WriteLine(elem);
            }

        }
        static void Main2(string[] args)
        {
            Person p1 = new Person("Alice",new DateTime(1980,1,1),true);
            p1.Name = "Alice Smith";
            p1.Show();
            Console.WriteLine("{0} age is more or less {1} ", p1.Name, p1.Age);


            Person p2 = new Person("Bob the Builder", new DateTime(1992,5,12));
            p2.Show();
            Console.WriteLine("{0} age is more or less {1} ", p2.Name, p2.Age);

            Console.WriteLine("O total de pessoas é: {0}", Person.GetNumberOfPersons());

            //Person p1 = new Person();

            //p1.name = "Alice";
            //p1.id = 123;
            //p1.birthDate = new DateTime(1980, 1, 1);
            //p1.Show();

            //Person p2 = new Person();

            //p2.name = "Bob the Builder";
            //p2.id = 456;
            //p2.birthDate = new DateTime(1992,5,12);
            //p2.Show();

        }
    }
}
