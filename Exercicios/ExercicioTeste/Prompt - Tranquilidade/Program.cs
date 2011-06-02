using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prompt___Tranquilidade
{
    //public interface IFilterPerson
    //{
    //    bool filter(Person p);
    //}

    //public class NameFilter : IFilterPerson
    //{
        

    //}

    public delegate bool FilterPerson(Person p);

    class Program
    {
        static void Main(string[] args)
        {


            FilterPerson fp;
            t1.showFilteredStudents (p => p.Name.Contains("Rui"))
            ;
        }
    }
}
