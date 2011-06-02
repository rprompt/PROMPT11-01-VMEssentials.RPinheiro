using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleApplication6___TypeBrowser
{
    class BrowseAssembly
    {
        private static TextWriter _tw;
        public static void Browse(string assb, TextWriter tw1)
        {

            Assembly ass = Assembly.LoadFrom(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\"+assb);
            _tw = tw1;

            if (ass == null)
            {
                _tw.WriteLine("<html><head><title>ERRO!!!!!</title></head>");
                _tw.WriteLine("<body> ERRO!!!!! </body></html>");
                return;

            }

        
            string h1T = ass.GetName().Name;
            
            _tw.WriteLine("<html><head><title> {0} </title></head>", h1T);
            _tw.WriteLine("<body>");

            WriteH1("ASSEMBLY = " + h1T);

            _tw.WriteLine("<p>FullName : {0} </p>", ass.GetName().FullName);
            _tw.WriteLine("<p>Location : {0} </p>", ass.Location);

            
            WriteTypes(ass);

            _tw.WriteLine("</body></html>");
     


        }

        private static void WriteH1(string h1T)
        {
            string h1Txt = h1T;

            _tw.WriteLine("<h1> {0} </h1>",h1Txt);
        }

        public static void WriteTypes(Assembly a)
        {

            Type[] aT = a.GetTypes();
            int iDic = 0;
            string keyType;
            string keyObject;

            // Create a new sorted dictionary of strings, with string
            // keys.
            SortedDictionary<string , SortedDictionary<string, Type> > typeDic =
                new SortedDictionary<string, SortedDictionary<string, Type>>();


            foreach (Type t in aT)
            {

                string pDic = t.FullName;
                int ix = pDic.LastIndexOf(".");

                if (ix > 0)
                {
                    string s1 = pDic.Substring(0, ix);
                    string s2 = pDic.Substring(ix + 1);
                    string st = s1 + "/" + s2;

                    string[] argsType = st.Split('/');

                    try
                    {
                        if (!typeDic.ContainsKey(s1))
                            typeDic.Add(s1, ();

                    }
                    catch
                    {
                    }
                    ;

                }


            }


            foreach (KeyValuePair<string, string> tDic in typeDic)
  


            _tw.WriteLine("<p> TYPES: </p><ol>");


            
            foreach (Type t in aT)
            {

                string p = Program.PREFIX + t.FullName;
                int ix = p.LastIndexOf(".");

                if (ix > 0)
                {
                    string s1 = p.Substring(0, ix) + "/" + p.Substring(ix + 1);
                       _tw.WriteLine("<li><a href=\"{0}\">{1}</a></li>",s1,t.FullName );
                }
                else
                   _tw.WriteLine("<li><a href=\"{0}/{1}\">{1}</a></li>",Program.PREFIX, t.FullName);
            }
            _tw.WriteLine("</ol>");


        }
     


    }
    
}
