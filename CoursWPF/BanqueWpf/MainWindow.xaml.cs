using BanqueWpf.Classes;
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

namespace BanqueWpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            listeCompteView.ItemsSource = DataBase.Instance.GetComptes();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow w = new AddClientWindow();
            w.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(listeCompteView.SelectedItem != null)
            {
                OperationWindow w = new OperationWindow(listeCompteView.SelectedItem as Compte);
                w.Show();
            }
            else
            {
                MessageBox.Show("Merci de selectionner un compte");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (listeCompteView.SelectedItem != null)
            {
                ListeOperationsWindow w = new ListeOperationsWindow(listeCompteView.SelectedItem as Compte);
                w.Show();
            }
            else
            {
                MessageBox.Show("Merci de selectionner un compte");
            }
        }
    }
}
