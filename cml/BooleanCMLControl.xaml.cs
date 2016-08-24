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
    /// Interaction logic for BooleanCMLControl.xaml
    /// </summary>
    public partial class BooleanCMLControl : UserControl
    {
        public BooleanCMLControl(cml_boolean cmlConstructor, IRewriteFile rewriteFile)
        {
            cmlObject = cmlConstructor;
            rewritableFile = rewriteFile;
            InitializeComponent();
            label.Content = cmlObject.Name;
            if (cmlObject.Value)
            {
                buttonTrue.Background = Brushes.Gray;
            }
            else
            {
                buttonFalse.Background = Brushes.Gray;
            }
        }

        private cml_boolean cmlObject;
        private IRewriteFile rewritableFile;

        private void buttonTrue_Click(object sender, RoutedEventArgs e)
        {
            cmlObject.Value = true;
            Brush b = buttonTrue.Background;
            buttonTrue.Background = Brushes.Gray;
            buttonFalse.Background = b;
            rewritableFile.rewrite();
        }

        private void buttonFalse_Click(object sender, RoutedEventArgs e)
        {
            cmlObject.Value = false;
            Brush b = buttonFalse.Background;
            buttonFalse.Background = Brushes.Gray;
            buttonTrue.Background = b;
            rewritableFile.rewrite();
        }
    }
}
