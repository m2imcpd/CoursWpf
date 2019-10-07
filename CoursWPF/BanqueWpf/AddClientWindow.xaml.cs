using BanqueWpf.Classes;
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

namespace BanqueWpf
{
    /// <summary>
    /// Logique d'interaction pour AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        ObservableCollection<Compte> listeComptes;
        public AddClientWindow()
        {
            InitializeComponent();
        }

        public AddClientWindow(ObservableCollection<Compte> l) : this()
        {
            listeComptes = l;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Compte c = DataBase.Instance.AddClient(tNom.Text, tPrenom.Text, tTelephone.Text);
            if (c.Id > 0)
            {
                MessageBox.Show("Client ajouté");
                listeComptes.Add(c);
            }
            else
            {
                MessageBox.Show("Error serveur");
            }
        }
    }
}
