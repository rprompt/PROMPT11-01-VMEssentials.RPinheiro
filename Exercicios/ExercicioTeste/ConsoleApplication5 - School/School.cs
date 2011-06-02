using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5___School
{
    public class School : IShowable
    {

        private string _Name;

        public School(string name)
        {
            _Name = name;
        }
        
        public string Name                          // criar uma propriedade chamada Nome
        {

            get { return _Name; }                   // código a ser efectuado no momento da leitura

            set { _Name = value; }                  // código a ser efectuado no momento da escrita

        }

   
        //construtores - quando o objecto é criado fica logo num estado integro, iniciado

           
        public void AddPerson(Person p)
        {
            p.Instituition = this;

        }


        public void Show()

        {
            var sb = new StringBuilder();

            sb.AppendFormat("NomeEscola: {0}", _Name);
            Console.WriteLine(sb);
       }


        

    }
}
