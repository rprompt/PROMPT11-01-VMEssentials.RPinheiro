using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace Sessao3
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootFolder = new DirectoryInfo(@"d:\software");

            ProcessFiles(rootFolder,filedatesup,escrita);

        }

        public static bool filedatesup(FileInfo fich)
        {
            DateTime data = new DateTime(2010,01,01);
            long tamanho = new long();
            tamanho = 347228;
                
                
            if (data.CompareTo(fich.LastWriteTime) < 0 && tamanho.CompareTo(fich.Length) < 0) 
               return true;
            
            return false;                                     
        }


        public static void escrita(FileInfo fich)
        {
            Console.WriteLine(" {0} ", fich.LastWriteTime);
            Console.WriteLine(" {0}.{1} ",fich.DirectoryName , fich.Extension);
            Console.WriteLine(" {0} ", fich.Length);
                                     
        }


        public static void ProcessFiles(DirectoryInfo rootFolder, Func<FileInfo, bool> pred, Action<FileInfo> action)
        {
            foreach (var fich in rootFolder.EnumerateFiles())
            {
                if (pred(fich))
                    action(fich);
            }
 
        }
    }


}
