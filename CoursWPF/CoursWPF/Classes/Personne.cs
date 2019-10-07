using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWPF.Classes
{
    public class Personne : INotifyPropertyChanged
    {
        private string nom;
        private string prenom;

        public string Nom { get => nom; set { nom = value;
                PropertyChange("Nom");
            }
        }
        public string Prenom
        {
            get => prenom;
            set
            {
                prenom = value;
                PropertyChange("Prenom");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return Nom + " "+ Prenom;
        }

        private void PropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
