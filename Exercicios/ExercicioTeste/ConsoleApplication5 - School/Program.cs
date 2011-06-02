using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5___School
{
    class Program
    {
        static void Main(string[] args)
        {
            School s = new School("ISEL");
            var   t1 = new Teacher("Pedro",6863886);
            s.AddPerson(t1);

            var s1 = new Student("Luis",33542,27);
            t1.addStudent(s1);
            s.AddPerson(s1);

            var s2 = new Student("Rui", 12345, 28);
            t1.addStudent(s2);
            s.AddPerson(s2);

            Console.WriteLine(s2);
            foreach (Student st in t1.Alunos)
            {
                st.Show();
            }

            //Console.WriteLine(s);

            //foreach (Student st in t1.Alunos)
            //{
            //    st.Show();
            //}


            // Interface 
            IShowable[] stuff = new IShowable[4];
            stuff[0] = s;
            stuff[1] = t1;
            stuff[2] = s1;
            stuff[3] = s2;


            //Print via interface
            foreach (IShowable p in stuff)
            {
                p.Show();
            }

            
            Student[] nordem = new Student[4];
            nordem[0] = s1;
            nordem[1] = s2;
            nordem[2] = new Student("Ze",23456,10);
            nordem[3] = new Student("Barnabé", 14567, 5);
            
            Console.WriteLine("Ordenação por BI");
            Array.Sort(nordem);
            foreach (Student n in nordem)
                n.Show();

            CompareStudentbyNumber inum = new CompareStudentbyNumber();

            Console.WriteLine("Ordenação por Numero Aluno");
            Array.Sort(nordem,inum);
            foreach (Student n in nordem)
                n.Show();

            ComparfeStudentbyName iname = new ComparfeStudentbyName();

            Console.WriteLine("Ordenação por Nome Aluno");
            Array.Sort(nordem, iname);
            foreach (Student n in nordem)
                n.Show();


            var s3 = new Student("Luis", 33542, 27);
            Console.WriteLine("{0}", t1.hasStudent(s3)); 

            // use DELEGATE

            string word;
            
            Console.WriteLine("Qual o nome a pesquisar? ");
            word = Console.ReadLine();
          

            if (word != null)
            {
                Console.WriteLine("A lista de estudantes é:");
                ShowAluno(t1.getFilterStudent(p => p.Name.Contains(word)));

            }
            else
            {
                Console.WriteLine("Não introdoziu nenhum nome!!");
                
            }

            t1.Msg += s1.ReceiveMsg;
            t1.Msg += s2.ReceiveMsg;

            t1.SendMsg("publicou as notas");

            t1.Msg -= s2.ReceiveMsg;

            t1.SendMsg("publicou as notas 2 vezes");
        }

        public static void ShowAluno(Student[] result)
        {
            
            foreach (Student s in result)
            {
                s.Show();
            }

        }


    
    }
}
