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
    /// Logique d'interaction pour AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        private List<Client> ListeClients;
        private Client clientEdit;
        public AddClient()
        {
            InitializeComponent();
        }

        public AddClient(List<Client> l) : this()
        {
            ListeClients = l;
        }

        public AddClient(List<Client> l, Client c): this()
        {
            ListeClients = l;
            tNom.Text = c.Nom;
            tPrenom.Text = c.Prenom;
            tTelephone.Text = c.Telephone;
            clientEdit = c;
            bAjouter.Content = "Modifier client";
            Title = "Modification du client";
        }

        private void BAjouter_Click(object sender, RoutedEventArgs e)
        {
            if(clientEdit == null)
            {
                Client c = new Client
                {
                    Nom = tNom.Text,
                    Prenom = tPrenom.Text,
                    Telephone = tTelephone.Text
                };

                ListeClients.Add(c);
                MessageBox.Show("Client ajouté");
            }
            else
            {
                clientEdit.Nom = tNom.Text;
                clientEdit.Prenom = tPrenom.Text;
                clientEdit.Telephone = tTelephone.Text;
                MessageBox.Show("Client Modifié");
            }
            
        }
    }
}
