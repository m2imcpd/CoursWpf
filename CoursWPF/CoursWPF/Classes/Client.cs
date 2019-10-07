using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWPF.Classes
{
    public class Client : INotifyPropertyChanged
    {
        private string nom;
        private string prenom;

        public string Nom
        {
            get => nom; set
            {
                if (value != nom)
                {
                    nom = value;
                    NotifyPropertyChange("Nom");
                }
            }
        }
        public string Prenom
        {
            get => prenom; set
            {
                if (value != prenom)
                {
                    prenom = value;
                    NotifyPropertyChange("Prenom");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
