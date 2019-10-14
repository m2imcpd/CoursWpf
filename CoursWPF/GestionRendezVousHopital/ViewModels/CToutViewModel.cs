using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GestionRendezVousHopital.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace GestionRendezVousHopital.ViewModels
{
    public class CToutViewModel : ViewModelBase
    {
        //public ObservableCollection<Medecin> ListeMedecins { get; set; }

        //public ObservableCollection<Patient> ListePatients { get; set; }

        //public ObservableCollection<RDV> ListeRDV { get; set; }

        public dynamic ListeAfficher { get; set; }

        public GridView maGridView { get; set; }
        public bool AllMedecins
        {
            get => allMedecins; set
            {
                allMedecins = value;
                if (value)
                {
                    AllPatients = false;
                    AllRDV = false;
                    //maGridView = GenerateGridViewMedecin();
                    //maGridView = GenerateGridViewByType(typeof(Medecin));
                    ListeAfficher = Medecin.GetAllMedecins();
                    RaisePropertyChanged("ListeAfficher");
                    //RaisePropertyChanged("maGridView");
                }
                RaisePropertyChanged();
            }
        }
        public bool AllPatients
        {
            get => allPatients; set
            {
                allPatients = value;
                if (value)
                {
                    AllMedecins = false;
                    AllRDV = false;
                    //maGridView = GenerateGridViewPatient();
                    //maGridView = GenerateGridViewByType(typeof(Patient));
                    ListeAfficher = Patient.GetAllPatients();
                    RaisePropertyChanged("ListeAfficher");
                    //RaisePropertyChanged("maGridView");
                }
                RaisePropertyChanged();
            }
        }
        public bool AllRDV
        {
            get => allRDV;
            set
            {
                allRDV = value;
                if (value)
                {
                    AllPatients = false;
                    AllMedecins = false;
                    //maGridView = GenerateGridViewRDV();
                    //maGridView = GenerateGridViewByType(typeof(RDV));
                    ListeAfficher = RDV.GetAllRDVS();
                    RaisePropertyChanged("ListeAfficher");
                    //RaisePropertyChanged("maGridView");
                }
                RaisePropertyChanged();
            }
        }

        private bool allMedecins;

        private bool allPatients;

        private bool allRDV;

        public ICommand EditDataCommand { get; set; }


        public CToutViewModel()
        {
            //maGridView = GenerateGridViewMedecin();
            //maGridView = GenerateGridViewByType(typeof(Medecin));
            AllMedecins = true;
            ListeAfficher = Medecin.GetAllMedecins();

            EditDataCommand = new RelayCommand(EditData);
        }

        private void EditData()
        {
            foreach(dynamic o in ListeAfficher)
            {
                if(o.Id > 0)
                {
                    o.Update();
                }
                else
                {
                    o.Add();
                }
            }
        }

        //private GridView GenerateGridViewMedecin()
        //{
        //    GridView g = new GridView();
        //    g.Columns.Add(new GridViewColumn { Header = "Code Medecin", Width = 150, DisplayMemberBinding = new Binding("Id") }); ;
        //    g.Columns.Add(new GridViewColumn { Header = "Nom Medecin", Width = 150, DisplayMemberBinding = new Binding("Nom") });
        //    g.Columns.Add(new GridViewColumn { Header = "Téléphone Medecin", Width = 150, DisplayMemberBinding = new Binding("Telephone") });
        //    g.Columns.Add(new GridViewColumn { Header = "date d'embauche Medecin", Width = 150, DisplayMemberBinding = new Binding("DateEmbauche") });
        //    g.Columns.Add(new GridViewColumn { Header = "Specialité Medecin", Width = 150, DisplayMemberBinding = new Binding("Specialite") });
        //    return g;
        //}

        //private GridView GenerateGridViewPatient()
        //{
        //    GridView g = new GridView();
        //    g.Columns.Add(new GridViewColumn { Header = "Code Patient", Width = 150, DisplayMemberBinding = new Binding("Id") }); ;
        //    g.Columns.Add(new GridViewColumn { Header = "Nom Patient", Width = 150, DisplayMemberBinding = new Binding("Nom") });
        //    g.Columns.Add(new GridViewColumn { Header = "Adresse Patient", Width = 150, DisplayMemberBinding = new Binding("Adresse") });
        //    g.Columns.Add(new GridViewColumn { Header = "date de naissance Patient", Width = 150, DisplayMemberBinding = new Binding("DateNaissance") });
        //    g.Columns.Add(new GridViewColumn { Header = "Sexe Patient", Width = 150, DisplayMemberBinding = new Binding("SexePatient") });
        //    return g;
        //}

        //private GridView GenerateGridViewRDV()
        //{
        //    GridView g = new GridView();
        //    g.Columns.Add(new GridViewColumn { Header = "Code RDV", Width = 150, DisplayMemberBinding = new Binding("Id") }); ;
        //    g.Columns.Add(new GridViewColumn { Header = "Date RDV", Width = 150, DisplayMemberBinding = new Binding("DateRDV") });
        //    g.Columns.Add(new GridViewColumn { Header = "Heure RDV", Width = 150, DisplayMemberBinding = new Binding("Heure") });
        //    g.Columns.Add(new GridViewColumn { Header = "Code Medecin", Width = 150, DisplayMemberBinding = new Binding("MedecinId") });
        //    g.Columns.Add(new GridViewColumn { Header = "Code Patient", Width = 150, DisplayMemberBinding = new Binding("PatientId") });
        //    return g;
        //}

        //private GridView GenerateGridViewByType(Type type)
        //{
        //    GridView g = new GridView();
        //    PropertyInfo[] allProperties = type.GetProperties();
        //    foreach(PropertyInfo p in allProperties)
        //    {
        //        g.Columns.Add(new GridViewColumn() { Width = 150, Header =  p.Name, DisplayMemberBinding = new Binding(p.Name)});
        //    }
        //    return g;
        //}
    }
}
