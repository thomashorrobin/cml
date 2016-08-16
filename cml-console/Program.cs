using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cml_model;

namespace cml_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = System.IO.File.ReadAllText(@"C:\Users\THOMASHO\Documents\WriteText2.txt");
            try
            {
                DocumentRoot root = Parser.ParserCML(file);
                Console.Write(root.render(0));
            }
            catch (cml_model.MalformedCMLException ex)
            {
                Console.WriteLine("File tags not closed properly");
            }
            Console.ReadLine();
        }
    }
}
