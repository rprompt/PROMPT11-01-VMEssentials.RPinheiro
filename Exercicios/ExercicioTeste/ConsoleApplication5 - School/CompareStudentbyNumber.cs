using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5___School
{
    class CompareStudentbyNumber : IComparer<Student>
    {

        public int Compare(Student s1, Student s2)
        {

            return s1.Number - s2.Number;

        }

    }
}
