using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace BoiteDialog
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == true)
            {
                textB.Text = File.ReadAllText(open.FileName);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == true)
            {
                string fileName ="T"+DateTime.Now.Second+"-"+System.IO.Path.GetFileName(open.FileName);
                File.Copy(open.FileName, fileName);
                BitmapImage imageSource = new BitmapImage();
                imageSource.BeginInit();
                imageSource.UriSource = new Uri(open.FileName);
                imageSource.EndInit();
                monImage.Source = imageSource;
            }
        }
    }
}
