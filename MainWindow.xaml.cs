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
using Bridge; // you can use my api if you want i dont care
using Microsoft.Win32;

namespace imatutorialforwpf
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(imrich.Document.ContentStart, imrich.Document.ContentEnd);
            Sentinel.ExecuteScript(range.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(imrich.Document.ContentStart, imrich.Document.ContentEnd);
            range.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Files (*.*)|*.*";
            open.RestoreDirectory = true;
            if(open.ShowDialog() == true)
            {
                TextRange range = new TextRange(imrich.Document.ContentStart, imrich.Document.ContentEnd);
                range.Text = System.IO.File.ReadAllText(open.FileName);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            InjectionResult inj = Injector.Inject();
            if (inj.Result == InjectionError.Success)
                Sentinel.Start();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "All Files (*.*)|*.*";
            save.RestoreDirectory = true;
            if (save.ShowDialog() == true)
            {
                TextRange range = new TextRange(imrich.Document.ContentStart, imrich.Document.ContentEnd);
                System.IO.File.WriteAllText(save.FileName, range.Text);
            }
        }
    }
}
