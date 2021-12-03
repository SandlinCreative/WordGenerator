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

        private string _localPath = @"C:\Users\Jeremy\Source\Repos\SandlinCreative\WordGenerator\WordLists";
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
                this.history.Text = word + this.history.Text;
            else
                this.history.Text = "\n" + word + this.history.Text;

            Clipboard.SetText(word);
            return word;
        }
        private void noun_Click(object sender, RoutedEventArgs e) => output.Text = GetRandomWord(_nouns, (Button)sender);
        private void nSuffix_Click(object sender, RoutedEventArgs e) => output.Text = GetRandomWord(_nounSuffixes, (Button)sender);
        private void verb_Click(object sender, RoutedEventArgs e) => output.Text = GetRandomWord(_verbs, (Button)sender);
        private void vSuffix_Click(object sender, RoutedEventArgs e) => output.Text = GetRandomWord(_verbSuffixes, (Button)sender);
        private void aSuffix_Click(object sender, RoutedEventArgs e) => output.Text = GetRandomWord(_adjectiveSuffixes, (Button)sender);
        private void conjunction_Click(object sender, RoutedEventArgs e) => output.Text = GetRandomWord(_conjunctions, (Button)sender);
    }
}
