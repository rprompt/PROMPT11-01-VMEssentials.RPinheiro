using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleApplication4
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




            var save = new StreamWriter(fich);  // StreamWriter permite escrever num ficheiro fisico

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
            linha1 = sr.ReadLine();
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
                    Type tipo = Type.GetType(linha);    // Type - é uma classe da API de Reflexão que devolve informação sobre
                                                        // uma determinada classe

                    //ConstructorInfo[] info_const1 = tipo.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                    //p= info_const1[0].Invoke(new object[0]) as Person;

                    p = Activator.CreateInstance(tipo, true) as Person;


         //           var infocampos = tipo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

                    p.Read(sr, persons);

                    /*
                    if (infocampos[0].FieldType == typeof(string))
                        infocampos[0].SetValue(p, "xpto");
                    */
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


        protected virtual void Read(StreamReader s, Person [] ps)
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

            get { return _name; } // código a ser efectuado no momento da leitura

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
                int age = today.Year - _birthdate.Year - 1;
                if (today.Month > _birthdate.Month ||
                      (today.Month == _birthdate.Month &&
                       today.Day >= _birthdate.Day))

                { age = age + 1; }

                return age;
            }

        }
        //construtores - quando o objecto é criado fica logo num estado integro, iniciado

        protected Person() { }

        public Person(string name, DateTime birthdate)
            : this(name, birthdate, false) // o nome do contrutor tem de ter o nome da classe
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
                   _vip ? "sim" : "não"
                   );


        }

        public override string ToString() // com override passa por cima do to string que existe em object
        {
            return this.GetType().Name + ": ID= " + _id + " Name= " + _name + " Age = " + Age + " Vip: " + _vip;

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
}
