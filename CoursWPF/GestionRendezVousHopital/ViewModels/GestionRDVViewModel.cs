using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GestionRendezVousHopital.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GestionRendezVousHopital.ViewModels
{
    public class GestionRDVViewModel : ViewModelBase
    {
        public ObservableCollection<Medecin> ListeMedecins { get; set; }

        public ObservableCollection<Patient> ListePatients { get; set; }

        private Patient patient;

        private RDV rdv;

        public Patient Patient
        {
            get => patient;
            set
            {
                patient = value;
                RaisePropertyChanged("NomPatient");
                RaisePropertyChanged("SexeHomme");
                RaisePropertyChanged("SexeFemme");
            }
        }

        public DateTime DateRDV
        {
            get => rdv.DateRDV;
            set
            {
                rdv.DateRDV = value;
                RaisePropertyChanged();
            }
        }

        public string HeureRDV
        {
            get => rdv.Heure;
            set
            {
                rdv.Heure = value;
                RaisePropertyChanged();
            }
        }

        private static DateTime? dateStart = DateTime.Today;
        

        public ICommand AddRDVCommand { get; set; }

        public ICommand NewRDVCommand { get; set; }


        private Medecin medecin;
        public Medecin Medecin
        {
            get => medecin;
            set
            {
                medecin = value;
                RaisePropertyChanged("NomMedecin");
                RaisePropertyChanged("Specialite");
            }
        }

        public string NomPatient
        {
            get => patient.Nom;
        }

        public bool SexeHomme
        {
            get
            {
                return patient.SexePatient == "Homme";
            }
        }

        public bool SexeFemme
        {
            get
            {
                return patient.SexePatient == "Femme";
            }
        }

        public string NomMedecin
        {
            get => medecin.Nom;
        }

        public Specialite Specialite
        {
            get => medecin.Specialite;
        }
        public static DateTime? DateStart { get => dateStart; set => dateStart = value; }

        public GestionRDVViewModel()
        {
            ListeMedecins = Medecin.GetAllMedecins();
            ListePatients = Patient.GetAllPatients();
            rdv = new RDV();
            NewRDVCommand = new RelayCommand(NewRDV);
           
            AddRDVCommand = new RelayCommand(AddRDV);
            Messenger.Default.Register<Patient>(this, p =>
            {
                Patient pat = ListePatients.FirstOrDefault((x => x.Id == p.Id));
                if (pat == null)
                    ListePatients.Add(p);
                else
                {
                    pat.Nom = p.Nom;
                    pat.SexePatient = p.SexePatient;
                    RaisePropertyChanged("NomPatient");
                    RaisePropertyChanged("SexeHomme");
                    RaisePropertyChanged("SexeFemme");
                }
            });
        }


        private void NewRDV()
        {
            patient = null;
            medecin = null;
            rdv = new RDV();
            RaiseAll();
        }


        private void AddRDV()
        {
            rdv.PatientId = Patient.Id;
            rdv.MedecinId = Medecin.Id;
            if (rdv.Add())
            {
                MessageBox.Show("RDV ajouté");
            }
            else
            {
                MessageBox.Show("Erreur serveur");
            }
            NewRDV();

        }
        public void RaiseAll()
        {
            RaisePropertyChanged("NomPatient");
            RaisePropertyChanged("SexeHomme");
            RaisePropertyChanged("SexeFemme");
            RaisePropertyChanged("NomMedecin");
            RaisePropertyChanged("Specialite");
            RaisePropertyChanged("DateRDV");
            RaisePropertyChanged("HeureRDV");
            RaisePropertyChanged("Patient");
            RaisePropertyChanged("Medecin");
        }
    }
}
