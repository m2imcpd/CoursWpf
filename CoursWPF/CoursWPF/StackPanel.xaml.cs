using CoursWPF.Classes;
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

namespace CoursWPF
{
    /// <summary>
    /// Logique d'interaction pour StackPanel.xaml
    /// </summary>
    public partial class StackPanel : Window
    {
        public StackPanel()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Taquin tWindow = new Taquin();
            tWindow.Show();
            tWindow.Closed += (s, el) =>
             {
                 MessageBox.Show("Taquin fermé");
             };
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Info iWindow = new Info(new Personne { Nom = t1.Text, Prenom = t2.Text });
            iWindow.Show();
        }
    }
}
