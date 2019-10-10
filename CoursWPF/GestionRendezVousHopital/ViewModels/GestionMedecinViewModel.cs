using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GestionRendezVousHopital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GestionRendezVousHopital.ViewModels
{
    public class GestionMedecinViewModel : ViewModelBase
    {
        private Medecin medecin;

        public string Nom
        {
            get => medecin.Nom;
            set
            {
                medecin.Nom = value;
                RaisePropertyChanged();
            }
        }

        public string Telephone
        {
            get => medecin.Telephone;
            set
            {
                medecin.Telephone = value;
                RaisePropertyChanged();
            }
        }

        public DateTime DateEmbauche
        {
            get => medecin.DateEmbauche;
            set {
                medecin.DateEmbauche = value;
                RaisePropertyChanged();
            }
        }

        public Specialite Specialite
        {
            get => medecin.Specialite;
            set
            {
                medecin.Specialite = value;
                RaisePropertyChanged();
            }
        }

        public List<Specialite> Specialites { get; set; }

        public ICommand NewCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public GestionMedecinViewModel()
        {
            medecin = new Medecin();
            Specialites = Enum.GetValues(typeof(Specialite)).Cast<Specialite>().ToList();
            NewCommand = new RelayCommand(NewMedecin);
            AddCommand = new RelayCommand(AddMedecin);
        }

        private void NewMedecin()
        {
            medecin = new Medecin();
            Nom = "";
            Telephone = "";
            DateEmbauche = DateTime.Now;
            Specialite = default(Specialite);
        }

        private void AddMedecin()
        {
            if(medecin.Add())
            {
                MessageBox.Show("Medecin ajouté avec numéro : " + medecin.Id);
                NewMedecin();
            }
            else
            {
                MessageBox.Show("Erreur d'insertion");
            }
        }
    }
}
