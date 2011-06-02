using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            string fich;
            Console.Write("Indique ficheiro: ");
            // fich = Console.ReadLine();
            fich = "pessoas2.txt";
            try
            {
                var malta1 = Person.ReadFilePersons(fich);
                Console.WriteLine("Leu");
                foreach (Person elemento in malta1)
                {
                    Console.WriteLine(elemento);
                }
            }catch(FileNotFoundException e)
            {
                Console.WriteLine("O ficheiro que indicou não existe");
            }
        }
    }

}
