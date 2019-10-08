using CoursWpfMVVM.Models;
using CoursWpfMVVM.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoursWpfMVVM.ViewModels
{
    public class ClientAdresseViewModel : ViewModelBase
    {
        private Client client;

        private Adresse adresse;

        public ObservableCollection<object> listeClientsAdresses { get; set; }
        public string Nom
        {
            get
            {
                return client.Nom;
            }

            set
            {
                client.Nom = value;
                NotifyChange();
            }
        }

        public string Prenom
        {
            get
            {
                return client.Prenom;
            }
            set
            {
                client.Prenom = value;
                NotifyChange();
            }
        }

        public string Rue
        {
            get
            {
                return adresse.Rue;
            }
            set
            {
                adresse.Rue = value;
                NotifyChange();
            }
        }

        public string Ville
        {
            get
            {
                return adresse.Ville;
            }

            set
            {
                adresse.Ville = value;
                NotifyChange();
            }
        }

        public ICommand AddBoutonCommand { get; set; }


        public ClientAdresseViewModel()
        {
            listeClientsAdresses = new ObservableCollection<object>();
            client = new Client { Nom = "abadi", Prenom = "ihab", Id = 1 };
            adresse = new Adresse { ClientId = 1, Id = 1, Rue = "paris", Ville = "tourcoing" };
            //AddBoutonCommand = new AddCommand(listeClientsAdresses, new { Nom = Nom, Prenom = Prenom, Rue = Rue, Ville = Ville });
            AddBoutonCommand = new RelayCommand((o) => { AddClientToList(); });
        }


        public void AddClientToList()
        {
           
            listeClientsAdresses.Add(new { Nom = Nom, Prenom = Prenom, Rue = Rue, Ville = Ville});
        }
        public void Update()
        {
            client.Update();
        }
    }
}
