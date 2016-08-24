using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            renderDocument();
        }

        private void renderDocument()
        {
            var file = System.IO.File.ReadAllText(@"C:\Users\THOMASHO\Documents\WriteText3.txt");
            cml_model.DocumentRoot doc = cml_model.Parser.ParserCML(file);
            var mockRewrite = new MockObject(doc);
            foreach (cml_model.IRenderable component in doc.Components)
            {
                switch (component.ComponentType)
                {
                    case cml_model.ComponentType.Section:
                        break;
                    case cml_model.ComponentType.Root:
                        break;
                    case cml_model.ComponentType.Integer:
                        break;
                    case cml_model.ComponentType.String:
                        stackPanel1.Children.Add(new StringCMLControl((cml_model.Components.cml_string)component,mockRewrite));
                        break;
                    case cml_model.ComponentType.Boolean:
                        stackPanel1.Children.Add(new BooleanCMLControl((cml_model.Components.cml_boolean)component, mockRewrite));
                        break;
                    case cml_model.ComponentType.Date:
                        break;
                    default:
                        break;
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //MockObject m = new MockObject();
            //cml_model.Components.cml_boolean booleanControlTest = new cml_model.Components.cml_boolean("test option 1", false);
            //cml_model.Components.cml_string stringControlTest = new cml_model.Components.cml_string("test option 2", "test string");
            //BooleanCMLControl control1 = new BooleanCMLControl(booleanControlTest, m);
            //StringCMLControl control2 = new StringCMLControl(stringControlTest, m);
            //stackPanel1.Children.Add(control1);
            //stackPanel1.Children.Add(control2);
            //sv1.Content = stackPanel1;
        }
    }

    public class MockObject : IRewriteFile
    {
        private cml_model.DocumentRoot doc;
        public MockObject(cml_model.DocumentRoot d)
        {
            doc = d;
        }
        public void rewrite()
        {
            System.IO.File.WriteAllText(@"C:\Users\THOMASHO\Documents\WriteText3.txt", doc.render(0));
        }
    }
}
