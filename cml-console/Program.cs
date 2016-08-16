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
        static void Main(string[] args)
        {
            var file = System.IO.File.ReadAllText(@"C:\Users\THOMASHO\Documents\WriteText2.txt");
            try
            {
                //CML.DocumentRoot root = CML.Parser.ParserCML(file);
                var root = CML.Token.getTokens(file);
                foreach (var item in root)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (cml_model.MalformedCMLException ex)
            {
                Console.WriteLine("File tags not closed properly");
            }
            Console.ReadLine();
        }
    }
}
