using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace ConsoleApplication6___TypeBrowser
{
    class Program
    {
       // public static int x;
       // public static event EventHandler<EventArgs> y;

        // servidor http

        public static string PREFIX = "http://localhost:8080/";
        public static void Main(string[] args)
        {
            HttpListener h1 = new HttpListener();
            h1.Prefixes.Add(PREFIX);
            h1.Start();
            for (; ; )
            {
                System.Net.HttpListenerContext hc = h1.GetContext();
                string url = hc.Request.Url.AbsolutePath;
                Console.WriteLine("Request = " + url);
                //               using (var tw = new StreamWriter("res.html"))
                using (TextWriter tw = new StreamWriter(hc.Response.OutputStream))
                {
                    //    //BrowseType.Browse("System", "Object", tw);
                    //    //BrowseType.Browse("System.IO", "DirectoryInfo", tw);
                    //    BrowseType.Browse("ConsoleApplication6___TypeBrowser","Program",tw);


                if (url != "/favicon.ico")
                {
                    string[] args1 = url.Split('/');

                    Assembly cur=  Assembly.GetExecutingAssembly();

                    foreach (var c in cur.GetTypes() )
                    {
                        if (c.IsDefined(typeof(UrlDevAttribute),false))
                        {
                            foreach (var m in c.GetMethods())
                            {
                                if (m.IsDefined(typeof(UrlAttribute),false))
                                {
                                
                                object at = m.GetCustomAttributes(typeof(UrlAttribute),false)[0];
                                UrlAttribute ua = (UrlAttribute) at;
                                
                                string[] ua1 = ua.urlValue.Split('/');

                                if (CompareString.CompareStrings(ua1, args1))
                                {
                                    int ic = 0;
                                    for (int i = 0; i < args1.Length; i++)
                                    {
                                        if (args1[i].Length != 0)
                                           ic++;
                                    }
                                    
                                    
                                    Object[] argm = new object[ic+1];
                         
                                    for (int i = 0, j = 0; i < args1.Length; i++ )
                                    {
                                        if (args1[i].Length != 0)
                                        {
                                            argm[j] = args1[i];
                                            j++;
                                        }
                                    }
                                    argm[ic] = tw;

                                    m.Invoke(null,argm);
                                }

                                

                                }

                            }
                        }
                    }
                    
                    
                    
                    
                    
                    
                    
                    
                    //if (args1.Length == 1)
                    //    BrowseAssembly.Browse(url, tw);
                    //else
                    //    if (args1.Length == 2)
                    //        BrowseType.Browse(args1[0],args1[1], tw);
                           
                }
                
                }
                if (url.Contains("STOP"))
                    break;

            }

            h1.Stop();
        }
    }
}
