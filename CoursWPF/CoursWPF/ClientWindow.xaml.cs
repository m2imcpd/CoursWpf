using CoursWPF.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        private ObservableCollection<Client> clients { get; set; }
        private Client cEdit { get; set; }

        private bool edition = false;
        public ClientWindow()
        {
            InitializeComponent();
            clients = new ObservableCollection<Client>();
            cEdit = new Client() { Nom = "tata", Prenom = "titi"};
            ListeClient.ItemsSource = clients;
            DataContext = cEdit;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!edition)
            {
                Client c = new Client { Nom = tNom.Text, Prenom = tPrenom.Text };
                clients.Add(c);
                cEdit.Nom = "";
                cEdit.Prenom = "";
            }
            else
            {
                foreach(Client c in clients)
                {
                    if(c.Nom == cEdit.Nom)
                    {
                        c.Prenom = tPrenom.Text;
                        edition = false;
                    }
                }
            }      
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cEdit = ListeClient.SelectedItem as Client;
            edition = true;
            tNom.Text = cEdit.Nom;
            tPrenom.Text = cEdit.Prenom;
        }
    }
}
