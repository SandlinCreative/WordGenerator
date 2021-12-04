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
using System.Windows.Shapes;

namespace WordGenerator
{
    /// <summary>
    /// Interaction logic for OutputWindow.xaml
    /// </summary>
    public partial class OutputWindow : Window
    {
        public static TextBox OutputTextBox { get; set; }

        public OutputWindow(TextBox outputTextBox)
        {
            OutputTextBox = outputTextBox;
        }

        public OutputWindow()
        {
            InitializeComponent();
            OutputTextBox.Margin = new Thickness(10);
            OutputTextBox.BorderThickness = new Thickness(0);
            theGrid.Children.Add(OutputTextBox);
            OutputTextBox.Text = "Local Init\n";

        }
    }
}
