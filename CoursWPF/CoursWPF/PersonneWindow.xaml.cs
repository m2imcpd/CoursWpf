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
    /// Logique d'interaction pour PersonneWindow.xaml
    /// </summary>
    public partial class PersonneWindow : Window
    {
        private Personne maPersonne;

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
            //MessageBox.Show(MaPersonne.Prenom);
            //ListePersonne.Add(MaPersonne);
            ListePersonne[0].Nom = "zerze";

        }
    }
}
