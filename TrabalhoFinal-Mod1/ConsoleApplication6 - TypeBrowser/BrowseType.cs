using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleApplication6___TypeBrowser
{
    [UrlDev]
    class BrowseType
    {
        private static TextWriter tw;

        [Url("/ns/{assembly}/{tipo}")]
        public static void Browse(string ns, string ntype, TextWriter tw1)
        {
            Type tipo = Type.GetType(ns+"."+ntype);
            tw = tw1;

            if (tipo == null)
            {
                tw.Write("<html><head><title>ERRO!!!!!</title></head>");
                tw.Write("<body> ERRO TYPE = NULL!!!!! </body></html>");
                return;
               
            }

            tw.Write("<html><head><title> {0} </title></head>", tipo.FullName);
            tw.Write("<body>");
            tw.Write("<h1> Type = {0} </h1>", tipo.FullName);

            WriteMethods(tipo);
            WriteConst(tipo);
            WriteProperties(tipo);
            WriteFields(tipo);
            WriteEvents(tipo);

            tw.Write("</body></html>");
            
            
        }

        private static void WriteMethods(Type tipo)
        {
            MethodInfo[] minfo = tipo.GetMethods();

            tw.Write("<p> Methods: </p><ol>");

            //Escreve a Lista de Métodos


            foreach (MethodInfo m in minfo)
            {
                tw.Write("<li>{0}(", m.Name);

                ParameterInfo[] pminfo = m.GetParameters();
                foreach (ParameterInfo pm in pminfo)
                { 
                    tw.Write(" {0} ", pm.ParameterType.Name); 
                }

                tw.Write("){0} ; </li>", m.IsStatic ? " - Static" : ""); 
                
            }
            tw.Write("</ol>"); 
        }

        private static void WriteConst(Type tipo)
        {
            ConstructorInfo[] cinfo = tipo.GetConstructors();

            tw.Write("<p> Constructor: </p><ol>");

            //Escreve o construtor


            foreach (ConstructorInfo c in cinfo)
            {
                tw.Write("<li>{0}(", c.Name);

                ParameterInfo[] pminfo = c.GetParameters();
                foreach (ParameterInfo pm in pminfo)
                {
                    tw.Write(" {0} ", pm.Name);
                }


                tw.Write("){0} ; </li>", c.IsStatic ? " - Static" : "");

            }
            tw.Write("</ol>"); 

        }

        public static void WriteProperties(Type tipo)
        {
            PropertyInfo[] pinfo = tipo.GetProperties();

            tw.Write("<p> Properties: </p><ol>");

            foreach (PropertyInfo p in pinfo)
            {
                tw.Write("<li>{0}</li>", p.Name);
            }
            tw.Write("</ol>"); 

        
        }
        
        public static void WriteFields(Type tipo)
        {
            FieldInfo[] finfo = tipo.GetFields();

            tw.Write("<p> Fields: </p><ol>");

            foreach (FieldInfo f in finfo)
            {
                tw.Write("<li>{0} {1}</li>", f.Name,f.FieldType.Name);
            }
            tw.Write("</ol>"); 
        }

        public static void WriteEvents(Type tipo)
        {
            EventInfo[] einfo = tipo.GetEvents();

            tw.Write("<p> Events: </p><ol>");

            foreach (EventInfo e in einfo)
            {
                tw.Write("<li>{0} {1}</li>", e.Name, e.EventHandlerType.Name);
            }
            tw.Write("</ol>"); 

        }
    }
}
