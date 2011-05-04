using System;
using Sessao1;
namespace Sessao1
{
    class Program
    {
        static void Main(string[] args)
        { Ponto p1;
          Ponto p2;
          Int32 res;
          Int32 compt;

            p1 = new Ponto(3,4);
            p2 = new Ponto(5,7);

            res = p1.Distance(p2); 
            compt = p1.CompareTo(p2);

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(res);
            Console.WriteLine(compt);
        }
    }
}


