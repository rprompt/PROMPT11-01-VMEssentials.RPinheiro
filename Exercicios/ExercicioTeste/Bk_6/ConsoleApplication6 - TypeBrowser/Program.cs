using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
                string url = hc.Request.RawUrl.Substring(1);
                Console.WriteLine("Request = " + url);
                //               using (var tw = new StreamWriter("res.html"))
                using (TextWriter tw = new StreamWriter(hc.Response.OutputStream))
                {
                    //    //BrowseType.Browse("System", "Object", tw);
                    //    //BrowseType.Browse("System.IO", "DirectoryInfo", tw);
                    //    BrowseType.Browse("ConsoleApplication6___TypeBrowser","Program",tw);


                if (url != "favicon.ico")
                {
                    string[] args1 = url.Split('/');
                    if (args1.Length == 1)
                        BrowseAssembly.Browse(url, tw);
                    else
                        if (args1.Length == 2)
                            BrowseType.Browse(args1[0],args1[1], tw);
                           
                }
                
                }
                if (url.Contains("STOP"))
                    break;

            }

            h1.Stop();
        }
    }
}
