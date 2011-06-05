using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApplication6___TypeBrowser
{
    public class PreHTML
    {
        static TextWriter tw;

        public static void LinkType(string nt)
        {

            string ns;
            string type;
            int i = nt.LastIndexOf('.');
            if (i > 0)
            {
                ns = nt.Substring(0, i);
                type = nt.Substring(i + 1);
                tw.WriteLine("<a href = {0}/{1}>{2}</a>", Program.PREFIX + "ns/" + ns, type, nt);
            }
            else
            {
                tw.WriteLine("<a href = {0}/{1}>{1}</a>", Program.PREFIX + "ns/", nt);
            }
        }

        public void LinkNs(string assemb, string ns)
        {

            tw.WriteLine("<a href = {0}/ns/{1}>{1}</a>", Program.PREFIX + assemb, ns);
        }        


    }
}
