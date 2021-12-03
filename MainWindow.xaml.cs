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

        private static Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();

            _nouns = ImportWordList(@"C:\Users\jeremy.knlc\source\repos\WordGenerator\WordLists\Nouns(6801).txt");
            _verbs = ImportWordList(@"C:\Users\jeremy.knlc\source\repos\WordGenerator\WordLists\Verbs(4953).txt");
            _adjectiveSuffixes = ImportWordList(@"C:\Users\jeremy.knlc\source\repos\WordGenerator\WordLists\AdjectiveSuffixes(14).txt");
            _nounSuffixes = ImportWordList(@"C:\Users\jeremy.knlc\source\repos\WordGenerator\WordLists\NounSuffixes(15).txt");
            _verbSuffixes = ImportWordList(@"C:\Users\jeremy.knlc\source\repos\WordGenerator\WordLists\VerbSuffixes(4).txt");
            _conjunctions = ImportWordList(@"C:\Users\jeremy.knlc\source\repos\WordGenerator\WordLists\SubordinatingConjunctions(49).txt");
        }

        private List<string> ImportWordList(string _path)
        {
            List<string> wordList = new List<string>();
            foreach (string line in System.IO.File.ReadLines(_path))
                wordList.Add(line);
            return wordList;
        }

        private string GetRandomWord(List<string> _list)
        {
            string word = _list[random.Next(_list.Count)];
            Clipboard.SetText(word);
            return word;
        }

        private void noun_Click(object sender, RoutedEventArgs e) => output.Text = GetRandomWord(_nouns);

        private void nSuffix_Click(object sender, RoutedEventArgs e) => output.Text = GetRandomWord(_nounSuffixes);

        private void verb_Click(object sender, RoutedEventArgs e) => output.Text = GetRandomWord(_verbs);

        private void vSuffix_Click(object sender, RoutedEventArgs e) => output.Text = GetRandomWord(_verbSuffixes);

        private void aSuffix_Click(object sender, RoutedEventArgs e) => output.Text = GetRandomWord(_adjectiveSuffixes);

        private void conjunction_Click(object sender, RoutedEventArgs e) => output.Text = GetRandomWord(_conjunctions);
    }
}
