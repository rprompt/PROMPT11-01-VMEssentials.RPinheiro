using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    class Teacher : Person
    {
        private const int STUDENTS_CAPACITY = 10;
        public enum Categoria { coordenador, adjunto, assistente };
        Categoria _categoria;
        private Student [] _students;

        private Teacher()
        {
            _students = new Student[STUDENTS_CAPACITY];
        }

        public Teacher(string name, DateTime birthdate, Categoria categoria)
            : base(name, birthdate)
        {
            _categoria = categoria;
            _students = new Student[STUDENTS_CAPACITY];
        }

        protected override void Read(StreamReader s, Person[] ps)
        {

            base.Read(s, ps);
            string linha;
            linha = s.ReadLine(); //categoria
            _categoria = (Categoria)Enum.Parse(typeof(Categoria), linha);

        }

        public override string ToString() // com override passa por cima do to string que existe em object
        {
            String strAlunos = "Alunos:\n";
            foreach (var str in _students)
            {
                if(str != null) strAlunos += str + "\n";
            }
            return base.ToString() + " categoria= " + _categoria + "\n" + strAlunos; // base.tostring referencia para o proprio objecto considerando a classe base
        }

        public Categoria categoria { get { return _categoria; } }

        public override void SaveFile(StreamWriter s)
        {
            base.SaveFile(s);
            s.WriteLine(this._categoria);

        }

        public bool AddStudent(Student person)
        {
            for(int i = 0; i<_students.Length; i++)
            {
                if (_students[i] == null)
                {
                    _students[i] = person;
                    return true;
                }
            }
            return false;
        }
    }
}
