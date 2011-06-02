using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5___School
{
    public class Person : IShowable
    {

        private string _Name;
        private int _Bi;
        private School _School;

        public string Name                          // criar uma propriedade chamada Nome
        {

            get { return _Name; }                   // código a ser efectuado no momento da leitura

            set { _Name = value.ToUpper(); }        // código a ser efectuado no momento da escrita

        }

        public School Instituition                     // criar uma propriedade chamada SchoolName
        {

            get { return _School; }                   // código a ser efectuado no momento da leitura

            set { _School = value; }        // código a ser efectuado no momento da escrita

        }


        public int Bi                     // criar uma propriedade chamada BI
        {

            get { return _Bi; }                   // código a ser efectuado no momento da leitura

        }
   

        //construtores - quando o objecto é criado fica logo num estado integro, iniciado

        public Person(string name, int bi)
        {
           _Name = name;
           _Bi   = bi;
        }


        // métodos - acções, procedimentos

        public void Show()
        {
            
            Console.WriteLine(ToString());

            //Console.Write("Nome: {0}, \t BI: {1}", _Name, _Bi);
            //if (_School != null)
            //    Console.WriteLine("Escola: {0}", Instituition.Name);

            //else
            //    Console.WriteLine();

        }

        public override bool Equals(object obj)
        {
            
            Person y = obj as Person;

            return y != null && y.Bi == Bi;

            //if (y == null)
            //{ 
            //    return false;
            //}

            //if (this.Bi == y.Bi)
            //    return true;

            //return false;

        }

        public override int GetHashCode()
        {
            return Bi;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Nome: {0} \t BI: {1}", _Name, _Bi);
            if (_School != null)
                sb.AppendFormat("\nEscola: {0}", Instituition.Name);

            else
                sb.AppendFormat("\n");

            return sb.ToString();
        }
        
         
    

    }
}

