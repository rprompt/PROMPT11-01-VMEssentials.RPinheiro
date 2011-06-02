using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5___School
{
    class Student : Person, IComparable<Student>
    {
        private int _Number;

        public Student(string name, int bi, int num) : base(name,bi)
        {
            _Number = num;
        }

        public int Number
        {
            get
            {
                return _Number;
            }

        }


    

        public int Length { get; set; }


        public int CompareTo(Student other)
        { 
        
            return this.Bi - other.Bi;

        }

        public void ReceiveMsg(object teacher, MsgArgs msg)
        {
 
            Console.WriteLine("O aluno {0} recebeu a msg: {1} do Prof. {2}",
                this.Name,msg.Msg,((Teacher) teacher).Name);
        }

    }

}
