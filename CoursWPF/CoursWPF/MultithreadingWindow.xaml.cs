using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CoursWPF
{
    /// <summary>
    /// Logique d'interaction pour MultothreadingWindow.xaml
    /// </summary>
    public partial class MultothreadingWindow : Window
    {
        public MultothreadingWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                Thread.Sleep(5000);
                //invoke main thread to edit window
                Application.Current.Dispatcher.Invoke(() =>
                {
                    result.Text = "j'ai fini";
                });
                
            });
        }
    }
}
