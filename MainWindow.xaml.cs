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

namespace WordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> _nouns;
        private List<string> _verbs;
        private List<string> _adjectiveSuffixes;
        private List<string> _nounSuffixes;
        private List<string> _verbSuffixes;
        private List<string> _conjunctions;
        private OutWindow OutputWindow;


        //private string _localPath = @"C:\Users\Jeremy\Source\Repos\SandlinCreative\WordGenerator\WordLists";
        private string _localPath = @"C:\Users\jeremy.knlc\source\repos\WordGenerator\WordLists";
        private static Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();

            _nouns = ImportWordList(_localPath + @"\Nouns(6801).txt");
            _verbs = ImportWordList(_localPath + @"\Verbs(4953).txt");
            _adjectiveSuffixes = ImportWordList(_localPath + @"\AdjectiveSuffixes(14).txt");
            _nounSuffixes = ImportWordList(_localPath + @"\NounSuffixes(15).txt");
            _verbSuffixes = ImportWordList(_localPath + @"\VerbSuffixes(4).txt");
            _conjunctions = ImportWordList(_localPath + @"\SubordinatingConjunctions(49).txt");

            
            
        }

        private List<string> ImportWordList(string _path)
        {
            List<string> wordList = new List<string>();
            foreach (string line in System.IO.File.ReadLines(_path))
                wordList.Add(line);
            return wordList;
        }

        private string GetRandomWord(List<string> _list, Button sender)
        {
            string word = _list[random.Next(_list.Count)];

            if((string)sender.Content == "(suffix)" || (string)sender.Content == "Adjective Suffix")
                OutputWindow.OutBox.Text = word + OutputWindow.OutBox.Text;
            else
                OutputWindow.OutBox.Text = "\n" + word + OutputWindow.OutBox.Text;

            Clipboard.SetText(word);
            return word;
        }
        private void noun_Click(object sender, RoutedEventArgs e) => GetRandomWord(_nouns, (Button)sender);
        private void nSuffix_Click(object sender, RoutedEventArgs e) => GetRandomWord(_nounSuffixes, (Button)sender);
        private void verb_Click(object sender, RoutedEventArgs e) => GetRandomWord(_verbs, (Button)sender);
        private void vSuffix_Click(object sender, RoutedEventArgs e) => GetRandomWord(_verbSuffixes, (Button)sender);
        private void aSuffix_Click(object sender, RoutedEventArgs e) => GetRandomWord(_adjectiveSuffixes, (Button)sender);
        private void conjunction_Click(object sender, RoutedEventArgs e) => GetRandomWord(_conjunctions, (Button)sender);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OutputWindow = new OutWindow();
            OutputWindow.Show();
            WindowCollection windows = Application.Current.Windows;
        }
    }




    public class OutWindow : Window
    {
        public Grid TheGrid { get; set; }
        public TextBox OutBox { get; set; }
        public OutWindow()
        {
            WindowStyle = WindowStyle.ToolWindow;
            Title = "Output";
            Width = 320;
            Height = 600;
            Margin = new Thickness(0);
            FontFamily = new System.Windows.Media.FontFamily("Corbel");
            Top = Application.Current.MainWindow.Top;
            Left = Application.Current.MainWindow.Left - this.Width * 1.03;

            TheGrid = new Grid();
            OutBox = new TextBox();
            OutBox.Margin = new Thickness(8);
            OutBox.BorderThickness = new Thickness(0);
            OutBox.FontSize = 24;
            TheGrid.Children.Add(OutBox);
            this.AddChild(TheGrid);
        }
    }
}
