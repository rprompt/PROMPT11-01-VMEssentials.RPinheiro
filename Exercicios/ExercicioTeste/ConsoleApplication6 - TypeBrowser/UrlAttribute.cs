using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace ConsoleApplication6___TypeBrowser
{
    [AttributeUsage(AttributeTargets.Method)]
    class UrlAttribute : Attribute
    {
        public string urlValue;
        public string Url
        {
            set { urlValue = value; }
        }

        public UrlAttribute(string url)
        {
            urlValue = url;
        }
        public UrlAttribute()
        {

        }

    }
}
