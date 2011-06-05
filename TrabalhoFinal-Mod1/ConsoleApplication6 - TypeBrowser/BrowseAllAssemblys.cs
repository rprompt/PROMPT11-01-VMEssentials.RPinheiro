using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleApplication6___TypeBrowser
{
    [UrlDev]
    class BrowseAllAssemblys
    {
        
        public static FileInfo[] DirFile;
        //static TextWriter tw;

        [Url("/as")]

        public static void Browse(string assbs, TextWriter tw)
        {
            tw.WriteLine("<html><head><title> Assembly List </title></head>");
            tw.WriteLine("<body>");
            tw.WriteLine("<h1> ASSEMBLY LIST </h1>");
            tw.WriteLine("<ol>");

            DirectoryInfo di = new DirectoryInfo(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\");
            DirFile = di.GetFiles("*.dll");

            List<string> assemblieList = new List<string>();

            foreach (FileInfo d in DirFile)
            {
                assemblieList.Add(d.Name);
//                BrowseAssembly.Browse(d.Name, tw);

            }

            foreach (var al in assemblieList)
            {
                BrowseA(al, tw);                    

            }
            tw.WriteLine("</ol>");
            tw.WriteLine("</body></html>");
        }


        public static void BrowseA(string assb, TextWriter tw1)
        {

            try
            {
                Assembly ass = Assembly.LoadFrom(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\" + assb);


                Type h0T = ass.GetType();
                string h1T = ass.GetName().Name;
              
                string h0T1 = h0T.Name;
                Type[] xx = ass.GetExportedTypes();


                //tw1.WriteLine("<h1> {0} </h1>", h0T1);
                //tw1.WriteLine("<h1><a href=\"{0}\"></a></h1>", h1T);
                //tw1.WriteLine("<li><a href=\"{0}\"></a></li>", h1T);
                tw1.WriteLine("<li><a href = {0}as/{1}>{1}</a></li>", Program.PREFIX, assb);


                //tw1.WriteLine("<p>FullName : {0} </p>", ass.GetName().FullName);
                //tw1.WriteLine("<p>Location : {0} </p>", ass.Location);


            }

            catch (Exception x)
            {

            }

        }

        //public static void BrowseA(string assb, TextWriter tw1)
        //{

        //    try
        //    {

        //        Assembly ass = Assembly.LoadFrom(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\" + assb);
        //        _tw = tw1;
        //        //Dicionários

        //        //List<string> assemblieList = new List<string>();
        //        ////create a list for the namespaces
        //        //List<string> namespaceList = new List<string>();
        //        Type h0T = ass.GetType();
        //        string h1T = ass.GetName().Name;
        //        string h0T1 = h0T.Name;

        //        _tw.WriteLine("<html><head><title> {0} </title></head>", h1T);
        //        _tw.WriteLine("<body>");

        //        WriteH1(h0T1);
        //        WriteH2(h1T);


        //        _tw.WriteLine("<p>FullName : {0} </p>", ass.GetName().FullName);
        //        _tw.WriteLine("<p>Location : {0} </p>", ass.Location);


        //        //            WriteTypes(ass);
        //        //

        //        //Type[] aNs = ass.GetTypes();
        //        Type[] aNs = ass.GetExportedTypes();
        //        assDic = new SortedDictionary<string, SortedDictionary<string, Type>>();

        //        _tw.WriteLine("<p> {0} </p><ol>", h1T);



        //        foreach (Type an in aNs)
        //        {

        //            string ns = an.Namespace;
        //            if (ns == null)
        //            {
        //                ns = "";
        //            }

        //            if (!assDic.TryGetValue(ns, out assDicaux))
        //            {
        //                assDic.Add(ns, assDicaux = new SortedDictionary<string, Type>());
        //            }

        //            assDicaux.Add(an.FullName, an);


        //        }


        //        foreach (var ns in assDic.Keys)
        //        {
        //            if (ns != "")
        //            {
        //                string p = Program.PREFIX + ns; // ass.FullName;
        //                int ix = p.LastIndexOf(".");

        //                if (ix > 0)
        //                {
        //                    assDicaux = assDic[ns];
        //                    foreach (var nt in assDicaux.Keys)
        //                    {

        //                        string s1 = p.Substring(0, ix) + "/" + p.Substring(ix + 1);
        //                        _tw.WriteLine("<li><a href=\"{0}\">{1}</a></li>", s1, nt);
        //                    }

        //                }
        //                else
        //                    _tw.WriteLine("<li><a href=\"{0}/{1}\">{1}</a></li>", Program.PREFIX, ns);


        //            }
        //        }


        //        _tw.WriteLine("</ol>");


        //        //




        //        _tw.WriteLine("</body></html>");

        //    }
        //    catch (Exception x)
        //    {
        //        _tw.WriteLine("<html><head><title>ERRO BROWSE!! {0} !!!</title></head>", assb);
        //        _tw.WriteLine("<body> ERRO!!!!! </body></html>");
        //        return;

        //    }
        //}


    }
 
}



    //{
    //    //create an Assembly and use its GetExecutingAssembly Method
    //    //http://msdn2.microsoft.com/en-us/library/system.reflection.assembly.getexecutingassembly.aspx
    //    Assembly asm = Assembly.GetExecutingAssembly();
    //    //create a list for the namespaces
    //    List<string> namespaceList = new List<string>();
    //    //create a list that will hold all the classes
    //    //the suplied namespace is executing
    //    List<string> returnList = new List<string>();
    //    //loop through all the "Types" in the Assembly using
    //    //the GetType method:
    //    //http://msdn2.microsoft.com/en-us/library/system.reflection.assembly.gettypes.aspx
    //    foreach (Type type in asm.GetTypes())
    //    {
    //        if (type.Namespace == nameSpace)
    //            namespaceList.Add(type.Name);
    //    }
    //    //now loop through all the classes returned above and add
    //    //them to our classesName list
    //    foreach (String className in namespaceList)
    //        returnList.Add(className);
    //    //return the list
    //    return returnList;
    //}