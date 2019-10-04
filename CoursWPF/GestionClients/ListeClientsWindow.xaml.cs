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
using System.Windows.Shapes;

namespace GestionClients
{
    /// <summary>
    /// Logique d'interaction pour ListeClientsWindow.xaml
    /// </summary>
    public partial class ListeClientsWindow : Window
    {
        private List<Client> ListeClients;
        public ListeClientsWindow()
        {
            InitializeComponent();
        }

        public ListeClientsWindow(List<Client> l) : this()
        {
            ListeClients = l;
            AfficherClients();
        }

        private void AfficherClients()
        {
            foreach(Client c in ListeClients)
            {
               
                TextBlock l = new TextBlock { Text = c.ToString()};
                listeClientsPanel.Children.Add(l);
            }
        }
    }
}
