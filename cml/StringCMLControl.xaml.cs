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
using cml_model.Components;

namespace cml
{
    /// <summary>
    /// Interaction logic for StringCMLControl.xaml
    /// </summary>
    public partial class StringCMLControl : UserControl
    {
        private cml_string cmlObject;
        private IRewriteFile rewritableFile;
        public StringCMLControl(cml_string cmlConstructor, IRewriteFile rewriteFile)
        {
            cmlObject = cmlConstructor;
            rewritableFile = rewriteFile;
            InitializeComponent();
            label.Content = cmlObject.Name;
            textBox.Text = cmlObject.Value;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            cmlObject.Value = textBox.Text;
            rewritableFile.rewrite();
        }
    }
}
