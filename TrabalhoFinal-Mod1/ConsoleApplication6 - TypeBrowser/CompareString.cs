using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6___TypeBrowser
{
    class CompareString
    {


        public static bool CompareStrings(string[] surl, string[] surl1, string[] sarg, out string[] sout)
        {
            sout = null;
            int p = 0;
            
            if (surl.Length == sarg.Length)
            {
                sout = new string[surl1.Length-1];

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
                        if (surl[i][0] != '{')
                        {
                            if (!surl[i].Equals(sarg[i])) 
                                return false;
                        }
                        
                       else
                        {
                            sout[p] = sarg[i];
                            p++;
                        }
                    }
                }
                return true;
            }
            return false;

        }
    }
}
