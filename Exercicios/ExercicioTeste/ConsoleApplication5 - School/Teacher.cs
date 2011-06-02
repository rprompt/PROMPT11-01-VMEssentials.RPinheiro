using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5___School
{
    public delegate bool FilterPerson(Person p);

    public class MsgArgs : EventArgs
    {
        public string Msg { get; set; } // o compilador gera automaticamente a variavel para usar no get e no set

        public MsgArgs(string txt)
        {
            Msg = txt;
        }
    }
    class Teacher : Person
    {
        public event EventHandler<MsgArgs> Msg; //Evento Msg onde vamos acrescentar (somar) funções

        public void SendMsg(string txt)
        {
            Msg(this, new MsgArgs(txt));
        }

        public Teacher(String name, int bi) : base(name, bi)
        {
            alunos = new Student[0];
        }


        private Student[] alunos;

        public Student[] Alunos
        {
            get { return alunos; }
        }


        public void addStudent(Student st)
        {
            Student[] alunos1;
            alunos1 = new Student[alunos.Length + 1];


            for (int i = 0; i < alunos.Length; i++)
            {
                alunos1[i] = alunos[i];
            }

            alunos1[alunos1.Length-1] = st;

            alunos = alunos1;
            
        }

        public bool hasStudent(Student st)
        {
            foreach (Student s in alunos)

                if (s.Equals(st))

                {
                    return true;  
                }

            return false;

        }


        public Student[] getFilterStudent(FilterPerson fp)
        {
            Student[] result1 = new Student[alunos.Length];
            int inx = 0;

            foreach (Student s in alunos)
            {

                if (fp(s))
                {
                    result1[inx] = s;
                    inx++;
                }
            }

            Student[] result = new Student[inx];

            Array.Copy(result1, result, inx);
            
            return result;
        }

    }
}
