using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;


namespace ConsoleApplication6___TypeBrowser
{
    [UrlDev]
    class BrowseClassesInNamespace
    {


        static List<string> GetAllClasses(string nameSpace)
        {
            //create an Assembly and use its GetExecutingAssembly Method
            //http://msdn2.microsoft.com/en-us/library/system.reflection.assembly.getexecutingassembly.aspx
            Assembly asm = Assembly.GetExecutingAssembly();
            //create a list for the namespaces
            List<string> namespaceList = new List<string>();
            //create a list that will hold all the classes
            //the suplied namespace is executing
            List<string> returnList = new List<string>();
            //loop through all the "Types" in the Assembly using
            //the GetType method:
            //http://msdn2.microsoft.com/en-us/library/system.reflection.assembly.gettypes.aspx
            foreach (Type type in asm.GetTypes())
            {
                if (type.Namespace == nameSpace)
                    namespaceList.Add(type.Name);
            }
            //now loop through all the classes returned above and add
            //them to our classesName list
            foreach (String className in namespaceList)
                returnList.Add(className);
            //return the list
            return returnList;
        }
              
    }
}
