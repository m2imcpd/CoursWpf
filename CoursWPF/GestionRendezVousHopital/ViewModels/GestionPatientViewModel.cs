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
    public class GestionPatientViewModel : ViewModelBase
    {
        private Patient patient;

        public string Nom
        {
            get => patient.Nom;
            set
            {
                patient.Nom = value;
                RaisePropertyChanged();
            }
        }

        public string Adresse
        {
            get => patient.Adresse;
            set
            {
                patient.Adresse = value;
                RaisePropertyChanged();
            }
        }

        public DateTime DateNaissance
        {
            get => patient.DateNaissance;
            set
            {
                patient.DateNaissance = value;
                RaisePropertyChanged();
            }
        }

        public bool SexeHomme
        {
            get => patient.SexePatient == "Homme";

            set
            {
                if (value)
                    patient.SexePatient = "Homme";
                RaisePropertyChanged();
            }
        }

        public bool SexeFemme
        {
            get => patient.SexePatient == "Femme";

            set
            {
                if (value)
                    patient.SexePatient = "Femme";
                RaisePropertyChanged();
            }
        }

        public ICommand NewCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand DeleteCommand { get; set; }


        public GestionPatientViewModel()
        {
            patient = new Patient();
            NewCommand = new RelayCommand(NewPatient);
            AddCommand = new RelayCommand(AddPatient);
            EditCommand = new RelayCommand(UpdatePatient);
            DeleteCommand = new RelayCommand(DeletePatient);
            SearchCommand = new RelayCommand(SearchPatient);
        }

        
        private void NewPatient()
        {
            patient = new Patient();
            Nom = "";
            Adresse = "";
            DateNaissance = DateTime.Now;
            SexeHomme = false;
            SexeFemme = false;
        }


        private void AddPatient()
        {
            if (patient.Add())
            {
                MessageBox.Show("Patient ajouté avec numéro : " + patient.Id);
                NewPatient();
            }
            else
            {
                MessageBox.Show("Erreur d'insertion");
            }
        }

        private void SearchPatient()
        {
            patient = Patient.GetPatientByNom(Nom);
            if (patient == null)
            {
                MessageBox.Show("Aucun patient");
                NewPatient();
            }
            else
            {
                RaiseAllProperties();
            }
        }

        private void UpdatePatient()
        {

            if (patient.Id > 0)
            {
                if (patient.Update())
                {
                    MessageBox.Show("patient mis à jour");
                }
                else
                {
                    MessageBox.Show("Erreur serveur");
                }
            }
            else
            {
                MessageBox.Show("Merci de rechercher un patient");
            }
        }

        private void DeletePatient()
        {

            if (patient.Id > 0)
            {
                if (patient.Delete())
                {
                    MessageBox.Show("patient supprimé");
                    NewPatient();
                    RaiseAllProperties();
                }
                else
                {
                    MessageBox.Show("Erreur serveur");
                }
            }
            else
            {
                MessageBox.Show("Merci de rechercher un patient");
            }
        }

        private void RaiseAllProperties()
        {
            RaisePropertyChanged("Nom");
            RaisePropertyChanged("DateNaissance");
            RaisePropertyChanged("Adresse");
            RaisePropertyChanged("SexeHomme");
            RaisePropertyChanged("SexeFemme");
        }
    }
}
