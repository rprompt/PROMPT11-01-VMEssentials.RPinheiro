using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6___TypeBrowser
{
    class CompareString
    {


        public string urlO;
        public string argO;

        public static bool CompareStrings(string[] surl, string[] sarg)
        {


            if (surl.Length == sarg.Length)
            {
                for (int i = 0; i < surl.Length; i++)
                {
                    if (surl[i].Length == 0)
                        if (sarg[i].Length == 0)
                            continue;
                        else
                            return false;

                    if (surl[i] == sarg[i])
                        continue;
                    else
                    {
                        if (surl[i][0] == '{')

                            continue;
                        else
                            return false;
                    }
                }
                return true;
            }
            return false;

        }
    }
}
