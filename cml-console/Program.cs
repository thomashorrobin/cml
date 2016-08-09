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
            var root1 = new MultiAreaDocumentRoot();
            var root2 = new SingleAreaDocumentRoot();
            var area1 = new Area("Area 1");
            var area2 = new Area("Area 2");
            var option1 = new cml_model.Components.cml_boolean("option 1", true);
            area1.Add(option1);
            var section1 = new Section("Happy Section");
            var option2 = new cml_model.Components.cml_boolean("option 1", true);
            var option3 = new cml_model.Components.cml_string("option 1", "Hi everybody");
            section1.Add(option2);
            section1.Add(option3);
            area1.Add(section1);
            var option4 = new cml_model.Components.cml_boolean("option 4", true);
            var option5 = new cml_model.Components.cml_string("option 5", "Hi everybody");
            var option6 = new cml_model.Components.cml_integer("option 5", 54);
            area2.Add(option4);
            area2.Add(option5);
            area1.Add(option6);
            root1.Add(area1);
            root1.Add(area2);
            root2.Add(option1);
            root2.Add(section1);
            System.IO.File.WriteAllText(@"C:\Users\THOMASHO\Documents\WriteText1.txt", root1.render());
            System.IO.File.WriteAllText(@"C:\Users\THOMASHO\Documents\WriteText2.txt", root2.render());
        }
    }
}
