using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CML = cml_model;

namespace cml_console
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var file = System.IO.File.ReadAllText(@"C:\Users\THOMASHO\Documents\WriteText2.txt");
        //    try
        //    {
        //        //CML.DocumentRoot root = CML.Parser.ParserCML(file);
        //        var root = CML.Token.getTokens(file);
        //        foreach (var item in root)
        //        {
        //            Console.WriteLine(item.ToString());
        //        }
        //    }
        //    catch (cml_model.MalformedCMLException ex)
        //    {
        //        Console.WriteLine("File tags not closed properly");
        //    }
        //    Console.ReadLine();
        //}
        static void Main(string[] args)
        {
            CML.DocumentRoot root = new cml_model.DocumentRoot();
            root.Add(new CML.Components.cml_boolean("boolean test 1", false));
            root.Add(new CML.Components.cml_string("string test 1", "test string 1"));
            root.Add(new CML.Components.cml_string("string test 2", "test string 2"));
            root.Add(new CML.Components.cml_boolean("boolean test 2", true));
            System.IO.File.WriteAllText(@"C:\Users\THOMASHO\Documents\WriteText3.txt", root.render(0));
        }
    }
}
