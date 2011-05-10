using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace Sessao2
{
    class Program
    {
        static void ShowObject(object obj)
        {
            var tipo = obj.GetType();
            Console.WriteLine(tipo.Name);
            Console.WriteLine("{0,-30}   {1,-30}", "Nome", "Valor");
            foreach (var prop in tipo.GetProperties())
            {
                Console.WriteLine("{0,-30} = {1,-30}", prop.Name, prop.GetValue(obj, null).ToString());
            }

        }
        static void Main(string[] args)
        {
            var dir = new DirectoryInfo(@"c:\program files");

            ShowHtmlObject(dir, 0);

        }

        static Dictionary<object, string> dic = new Dictionary<object, string>();

        static void ShowHtmlObject(object obj, int fichnum)

        {

            if (fichnum > 10)
                return;

            var fichname = @"D:\Prompt\Prompt11\fich" + fichnum + ".html";
            dic.Add(obj, fichname);
            var fich = new StreamWriter(fichname);
            var tipo = obj.GetType();

            Console.WriteLine(fichname);

            fich.WriteLine("<body> <h1> {0} </h1> <table border=\"2\">", tipo.Name);
            foreach (var prop in tipo.GetProperties(BindingFlags.Public|BindingFlags.Instance))
            {
                fich.WriteLine("<tr> <td> {0} </td> ", prop.Name);

                var tp = prop.PropertyType;
                var propvalue = prop.GetValue(obj, null);
                string value;
                if (propvalue == null)
                    value = "null";
                else
                    value = propvalue.ToString();


                if (tp.IsPrimitive || tp == typeof(string) || propvalue==null)

                    fich.WriteLine("<td> {0} </td> </tr> ", value);

                else
                {
                    string linkname;

                    if (dic.ContainsKey(propvalue))
                        dic.TryGetValue(propvalue, out linkname);
                    else
                    {
                        fichnum++;
                        linkname = @"D:\Prompt\Prompt11\fich" + fichnum + ".html";
                        ShowHtmlObject(propvalue, fichnum);
                    }
                    fich.WriteLine("<td> <a href = \"{0}\" > {1}  </a> </td> </tr> ", linkname,value);
                }

            }

            fich.WriteLine(@"</table> </body>");

            fich.Close();
        }
    }
}
