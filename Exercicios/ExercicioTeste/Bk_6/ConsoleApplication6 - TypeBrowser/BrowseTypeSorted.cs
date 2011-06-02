//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;

//namespace ConsoleApplication6___TypeBrowser
//{
//    class BrowseTypeSorted
//    {
////-------------------------------
//        private static TextWriter tw;
//        public static void Browse(string ns, string ntype, TextWriter tw1)
//        {
//            Type tipo = Type.GetType(ns+"."+ntype);
//            tw = tw1;

//            if (tipo == null)
//            {
//                tw.Write("<html><head><title>ERRO!!!!!</title></head>");
//                tw.Write("<body> ERRO TYPE = NULL!!!!! </body></html>");
//                return;
               
//            }

//            tw.Write("<html><head><title> {0} </title></head>", tipo.FullName);
//            tw.Write("<body>");
//            tw.Write("<h1> Type = {0} </h1>", tipo.FullName);

//            WriteMethods(tipo);
//            WriteConst(tipo);
//            WriteProperties(tipo);
//            WriteFields(tipo);
//            WriteEvents(tipo);

//            tw.Write("</body></html>");
            
            
//        }

//        private static void WriteMethods(Type tipo)
//        {
//            MethodInfo[] minfo = tipo.GetMethods();

//            tw.Write("<p> Methods: </p><ol>");

//            //Escreve a Lista de Métodos


//            foreach (MethodInfo m in minfo)
//            {
//                tw.Write("<li>{0}(", m.Name);

//                ParameterInfo[] pminfo = m.GetParameters();
//                foreach (ParameterInfo pm in pminfo)
//                { 
//                    tw.Write(" {0} ", pm.ParameterType.Name); 
//                }

//                tw.Write("){0} ; </li>", m.IsStatic ? " - Static" : ""); 
                
//            }
//            tw.Write("</ol>"); 
//        }

//        private static void WriteConst(Type tipo)
//        {
//            ConstructorInfo[] cinfo = tipo.GetConstructors();

//            tw.Write("<p> Constructor: </p><ol>");

//            //Escreve o construtor


//            foreach (ConstructorInfo c in cinfo)
//            {
//                tw.Write("<li>{0}(", c.Name);

//                ParameterInfo[] pminfo = c.GetParameters();
//                foreach (ParameterInfo pm in pminfo)
//                {
//                    tw.Write(" {0} ", pm.Name);
//                }


//                tw.Write("){0} ; </li>", c.IsStatic ? " - Static" : "");

//            }
//            tw.Write("</ol>"); 

//        }

//        public static void WriteProperties(Type tipo)
//        {
//            PropertyInfo[] pinfo = tipo.GetProperties();

//            tw.Write("<p> Properties: </p><ol>");

//            foreach (PropertyInfo p in pinfo)
//            {
//                tw.Write("<li>{0}</li>", p.Name);
//            }
//            tw.Write("</ol>"); 

        
//        }
        
//        public static void WriteFields(Type tipo)
//        {
//            FieldInfo[] finfo = tipo.GetFields();

//            tw.Write("<p> Fields: </p><ol>");

//            foreach (FieldInfo f in finfo)
//            {
//                tw.Write("<li>{0} {1}</li>", f.Name,f.FieldType.Name);
//            }
//            tw.Write("</ol>"); 
//        }

//        public static void WriteEvents(Type tipo)
//        {
//            EventInfo[] einfo = tipo.GetEvents();

//            tw.Write("<p> Events: </p><ol>");

//            foreach (EventInfo e in einfo)
//            {
//                tw.Write("<li>{0} {1}</li>", e.Name, e.EventHandlerType.Name);
//            }
//            tw.Write("</ol>"); 

//        }



////-------------------------------
//    }
//}

//        // Create a new sorted dictionary of strings, with string
//        // keys.
//        SortedDictionary<string, string> openWith = 
//            new SortedDictionary<string, string>();

//        // Add some elements to the dictionary. There are no 
//        // duplicate keys, but some of the values are duplicates.
//        openWith.Add("txt", "notepad.exe");
//        openWith.Add("bmp", "paint.exe");
//        openWith.Add("dib", "paint.exe");
//        openWith.Add("rtf", "wordpad.exe");

//        // The Add method throws an exception if the new key is 
//        // already in the dictionary.
//        try
//        {
//            openWith.Add("txt", "winword.exe");
//        }
//        catch (ArgumentException)
//        {
//            Console.WriteLine("An element with Key = \"txt\" already exists.");
//        }

//        // The Item property is another name for the indexer, so you 
//        // can omit its name when accessing elements. 
//        Console.WriteLine("For key = \"rtf\", value = {0}.", 
//            openWith["rtf"]);

//        // The indexer can be used to change the value associated
//        // with a key.
//        openWith["rtf"] = "winword.exe";
//        Console.WriteLine("For key = \"rtf\", value = {0}.", 
//            openWith["rtf"]);

//        // If a key does not exist, setting the indexer for that key
//        // adds a new key/value pair.
//        openWith["doc"] = "winword.exe";

//        // The indexer throws an exception if the requested key is
//        // not in the dictionary.
//        try
//        {
//            Console.WriteLine("For key = \"tif\", value = {0}.", 
//                openWith["tif"]);
//        }
//        catch (KeyNotFoundException)
//        {
//            Console.WriteLine("Key = \"tif\" is not found.");
//        }

//        // When a program often has to try keys that turn out not to
//        // be in the dictionary, TryGetValue can be a more efficient 
//        // way to retrieve values.
//        string value = "";
//        if (openWith.TryGetValue("tif", out value))
//        {
//            Console.WriteLine("For key = \"tif\", value = {0}.", value);
//        }
//        else
//        {
//            Console.WriteLine("Key = \"tif\" is not found.");
//        }

//        // ContainsKey can be used to test keys before inserting 
//        // them.
//        if (!openWith.ContainsKey("ht"))
//        {
//            openWith.Add("ht", "hypertrm.exe");
//            Console.WriteLine("Value added for key = \"ht\": {0}", 
//                openWith["ht"]);
//        }

//        // When you use foreach to enumerate dictionary elements,
//        // the elements are retrieved as KeyValuePair objects.
//        Console.WriteLine();
//        foreach( KeyValuePair<string, string> kvp in openWith )
//        {
//            Console.WriteLine("Key = {0}, Value = {1}", 
//                kvp.Key, kvp.Value);
//        }

//        // To get the values alone, use the Values property.
//        SortedDictionary<string, string>.ValueCollection valueColl = 
//            openWith.Values;

//        // The elements of the ValueCollection are strongly typed
//        // with the type that was specified for dictionary values.
//        Console.WriteLine();
//        foreach( string s in valueColl )
//        {
//            Console.WriteLine("Value = {0}", s);
//        }

//        // To get the keys alone, use the Keys property.
//        SortedDictionary<string, string>.KeyCollection keyColl = 
//            openWith.Keys;

//        // The elements of the KeyCollection are strongly typed
//        // with the type that was specified for dictionary keys.
//        Console.WriteLine();
//        foreach( string s in keyColl )
//        {
//            Console.WriteLine("Key = {0}", s);
//        }

//        // Use the Remove method to remove a key/value pair.
//        Console.WriteLine("\nRemove(\"doc\")");
//        openWith.Remove("doc");

//        if (!openWith.ContainsKey("doc"))
//        {
//            Console.WriteLine("Key \"doc\" is not found.");
//        }
//    }
//}

///* This code example produces the following output:

//An element with Key = "txt" already exists.
//For key = "rtf", value = wordpad.exe.
//For key = "rtf", value = winword.exe.
//Key = "tif" is not found.
//Key = "tif" is not found.
//Value added for key = "ht": hypertrm.exe

//Key = bmp, Value = paint.exe
//Key = dib, Value = paint.exe
//Key = doc, Value = winword.exe
//Key = ht, Value = hypertrm.exe
//Key = rtf, Value = winword.exe
//Key = txt, Value = notepad.exe

//Value = paint.exe
//Value = paint.exe
//Value = winword.exe
//Value = hypertrm.exe
//Value = winword.exe
//Value = notepad.exe

//Key = bmp
//Key = dib
//Key = doc
//Key = ht
//Key = rtf
//Key = txt

//Remove("doc")
//Key "doc" is not found.
// */

