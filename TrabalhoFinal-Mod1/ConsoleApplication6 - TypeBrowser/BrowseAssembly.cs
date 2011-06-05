using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleApplication6___TypeBrowser
{
    [UrlDev]
    public class BrowseAssembly
    {
        
        static TextWriter _tw;

        public static SortedDictionary<string, SortedDictionary<string, Type>> assDic;
        public static SortedDictionary<string, Type> assDicaux;


        [Url("/as/{assembly}")]
        public static void Browse(string assb, TextWriter tw1)
        {
            Assembly ass = Assembly.LoadFrom(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\" + assb);
            //Type tipo = Type.GetType(assb);
            Type[] tipo = ass.GetExportedTypes();

            if (tipo.Length == 0)
            {
                _tw.WriteLine("<html><head><title>ERRO {0} é NULL !!!</title></head>", assb);
                _tw.WriteLine("<body> ERRO ASSEMBLY NULL!!!!! </body></html>");
                return;
            }
            try
            {

//            Assembly ass = Assembly.LoadFrom(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\"+assb);
            _tw = tw1;
        //Dicionários

            //List<string> assemblieList = new List<string>();
            ////create a list for the namespaces
            //List<string> namespaceList = new List<string>();



             
                
            Type h0T = ass.GetType();
            string h1T = ass.GetName().Name;
            string h0T1 = h0T.Name;

            _tw.WriteLine("<html><head><title> {0} </title></head>", h1T);
            _tw.WriteLine("<body>");

            WriteH1(assb);
//            WriteH2(h1T);

            

            _tw.WriteLine("<p>FullName : {0} </p>", ass.GetName().FullName);
            _tw.WriteLine("<p>Location : {0} </p>", ass.Location);
                
            
//            WriteTypes(ass);
//

            //Type[] aNs = ass.GetTypes();
                Type[] aNs = ass.GetExportedTypes();
            assDic = new SortedDictionary<string, SortedDictionary<string, Type>>();

            _tw.WriteLine("<p> {0} </p><ol>",h1T);



            foreach (Type an in aNs)
            {

                string ns = an.Namespace;
                if (ns == null)
                {
                    ns = "";
                }

                if (!assDic.TryGetValue(ns, out assDicaux))
                {
                    assDic.Add(ns, assDicaux = new SortedDictionary<string, Type>());
                }

                assDicaux.Add(an.FullName, an);


            }


            foreach (var ns in assDic.Keys)
            {
                if (ns != "")
                {
                    string p = Program.PREFIX + ns; // ass.FullName;
                    int ix = p.LastIndexOf(".");
                    _tw.WriteLine("<li><a href = {0}/ns/{1}>{1}</a>", Program.PREFIX + assb, ns);
                  //  _tw.WriteLine("<li><a href = {0}/{1}>{1}</a>", Program.PREFIX + assb);        
                    if (ix > 0)
                    {
                        assDicaux = assDic[ns];
                        foreach (var nt in assDicaux.Keys)
                        {
                            

                          //  string s1 = p.Substring(0, ix) + "/" + p.Substring(ix + 1);
                         //   _tw.WriteLine("<li><a href=\"{0}\">{1}</a></li>", s1, nt);
                            if (nt.Length != 0)
                            {
                                _tw.WriteLine("<li>");
                                //PreHTML.LinkType(nt);

                                string nt1;
                                string type;
                                int i = nt.LastIndexOf('.');
                                if (i > 0)
                                {
                                    nt1 = nt.Substring(0, i);
                                    type = nt.Substring(i + 1);
                                    _tw.WriteLine("<a href = {0}/{1}>{2}</a>", Program.PREFIX + "ns/" + ns, type, nt);
                                }
                                else
                                {
                                    _tw.WriteLine("<a href = {0}/{1}>{1}</a>", Program.PREFIX + "ns/", nt);
                                }
                                _tw.WriteLine("</li>");   
                            }
                        }

                    }
                    else
                        _tw.WriteLine("<li><a href=\"{0}/{1}\">{1}</a></li>", Program.PREFIX, ns);


                }
            }


            _tw.WriteLine("</ol>");


//




            _tw.WriteLine("</body></html>");
     
            }
            catch (Exception x)
            {
                  _tw.WriteLine("<html><head><title>ERRO BROWSE!! {0} !!!</title></head>",assb);
                  _tw.WriteLine("<body> ERRO!!!!! </body></html>");
                  return;

                }
        }
    

        private static void WriteH1(string h1T)
        {
            string h1Txt = h1T;

            _tw.WriteLine("<h1> {0} </h1>",h1Txt);
        }

        private static void WriteH2(string h1T)
        {
            string h1Txt = h1T;

            _tw.WriteLine("<h1><a href=\"{0}\"></a></h1>", h1Txt);
            

        }


        ////public void WriteTypes(Assembly a)
        ////{

            
        ////    Type[] aNs = a.GetTypes();
        ////    assDic = new SortedDictionary<string, SortedDictionary<string, Type>>();

        ////    _tw.WriteLine("<p> TYPES: </p><ol>");

        ////    foreach (Type an in aNs)
        ////    {

        ////        string ns = an.Namespace;
        ////        if (ns == null)
        ////        {
        ////            ns = "";
        ////        }

        ////        if (!assDic.TryGetValue(ns, out assDicaux))
        ////        {
        ////            assDic.Add(ns, assDicaux = new SortedDictionary<string, Type>());
        ////        }

        ////        assDicaux.Add(an.FullName, an);


        ////    }


        ////    foreach (var ns in assDic.Keys)
        ////    {
        ////        if (ns != "")
        ////        {
        ////            string p = Program.PREFIX + a.FullName;
        ////            int ix = p.LastIndexOf(".");

        ////            if (ix > 0)
        ////            {
        ////                assDicaux = assDic[ns]; 
        ////                foreach (var nt in assDicaux.Keys)
        ////                {

        ////                    string s1 = p.Substring(0, ix) + "/" + p.Substring(ix + 1);
        ////                    _tw.WriteLine("<li><a href=\"{0}\">{1}</a></li>", s1, nt);
        ////                }

        ////            }
        ////            else
        ////                _tw.WriteLine("<li><a href=\"{0}/{1}\">{1}</a></li>", Program.PREFIX, a.FullName);

                    
        ////        }
        ////    }


        ////    _tw.WriteLine("</ol>");

            
            //foreach (Type t in aNs)
            //{

            //    string p = Program.PREFIX + t.FullName;
            //    int ix = p.LastIndexOf(".");

            //    if (ix > 0)
            //    {
            //        string s1 = p.Substring(0, ix) + "/" + p.Substring(ix + 1);
            //        _tw.WriteLine("<li><a href=\"{0}\">{1}</a></li>",s1,t.FullName );
            //    }
            //    else
            //       _tw.WriteLine("<li><a href=\"{0}/{1}\">{1}</a></li>",Program.PREFIX, t.FullName);
            //}
            //_tw.WriteLine("</ol>");


        //}
     


    }
    
}
