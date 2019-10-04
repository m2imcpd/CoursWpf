using GestionClients.Classes;
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

namespace GestionClients
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Client> ListeClients;
        public MainWindow()
        {
            InitializeComponent();
            ListeClients = new List<Client>();
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            AddClient addWindow = new AddClient(ListeClients);
            addWindow.Show();
        }

        private void ListeClients_Click(object sender, RoutedEventArgs e)
        {
            ListeClientsWindow listeWindow = new ListeClientsWindow(ListeClients);
            listeWindow.Show();
        }
    }
}
