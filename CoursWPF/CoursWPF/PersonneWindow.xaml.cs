using CoursWPF.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Logique d'interaction pour PersonneWindow.xaml
    /// </summary>
    public partial class PersonneWindow : Window
    {
        private Personne maPersonne;
        private bool edition = false;
        private ObservableCollection<Personne> ListePersonne;

        
        public PersonneWindow()
        {
            MaPersonne = new Personne() { Nom = "tata", Prenom = "titi" };
            DataContext = MaPersonne;
            ListePersonne = new ObservableCollection<Personne>();
            ListePersonne.Add(MaPersonne);
            InitializeComponent();
            maListe.ItemsSource = ListePersonne;
        }

        public Personne MaPersonne { get => maPersonne; set => maPersonne = value; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!edition)
                ListePersonne.Add(new Personne { Nom =tNom.Text, Prenom = tPrenom.Text});
            else
            {
                foreach(Personne p in ListePersonne)
                {
                    if(p.Nom == MaPersonne.Nom)
                    {
                        p.Prenom = MaPersonne.Prenom;
                        break;
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(maListe.SelectedItem != null)
            {
                MaPersonne = maListe.SelectedItem as Personne;
                edition = true;
            }
        }
    }
}
