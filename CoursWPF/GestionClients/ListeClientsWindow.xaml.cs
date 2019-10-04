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
            ListeBoxClients.ItemsSource = ListeClients;
            //foreach(Client c in ListeClients)
            //{
               
            //    TextBlock l = new TextBlock { Text = c.ToString()};
            //    Button b = new Button { Content = "Modifier" };
            //    b.Click += (sender, e) =>
            //    {
            //        Modifier(c);
            //    };
            //    StackPanel s = new StackPanel { Orientation = Orientation.Horizontal };
            //    s.Children.Add(l);
            //    s.Children.Add(b);
            //    listeClientsPanel.Children.Add(s);
            //}
        }

        private void Modifier(Client c)
        {
            AddClient editWindow = new AddClient(ListeClients, c);
            editWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Modifier(ListeBoxClients.SelectedItem as Client);
        }
    }
}
