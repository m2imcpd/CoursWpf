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

namespace wpfEntity
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataDbContext data = new DataDbContext();
            //ajouter des données dans la table
            //Personne p = new Personne() { Nom = "abadi", Prenom = "ihab", Telephone="010101010" };
            //data.Personnes.Add(p);
            //data.SaveChanges();

            //Get All Personnes
            //List<Personne> liste = data.Personnes.Cast<Personne>().ToList();
            //Get Personne with predicate
            //Personne p = data.Personnes.Where(x => x.Nom.StartsWith("t")).FirstOrDefault();
            ////Update
            ////p.Prenom = "coucou";
            ////Delete
            //data.Personnes.Remove(p);

            //Personne p = new Personne() { Nom = "abadi", Prenom = "tata", Telephone = "03030303" };
            //data.Personnes.Add(p);
            //data.SaveChanges();
            //Adresse a = new Adresse { PersonneId = p.Id, Rue = "Paris", Ville = "tourcoing" };
            //data.Adresses.Add(a);
            //data.SaveChanges();

            //var a = data.Adresses.Include("Personne").FirstOrDefault();
            //MessageBox.Show(a.Personne.Nom);


            //Student s = new Student { FirstName = "Ihab", LastName = "Abadi" };
            //Course c = new Course { Title = "c#" };
            //s.Courses.Add(c);
            //c.Students.Add(s);
            //data.Students.Add(s);
            //data.Courses.Add(c);
            //data.SaveChanges();
            Student s = data.Students.Include("Courses").FirstOrDefault(x => x.LastName.StartsWith("a"));
            MessageBox.Show((s.Courses as List<Course>)[0].Title);
        }
    }
}
