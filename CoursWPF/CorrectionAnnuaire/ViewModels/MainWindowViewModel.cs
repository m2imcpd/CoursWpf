using CorrectionAnnuaire.Models;
using CorrectionAnnuaire.Tools;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CorrectionAnnuaire.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Contact contact;
        private Email email;

        public ObservableCollection<object> Contacts { get; set; }

        public ICommand AddContactCommand { get; set; }

        public ICommand AddEmailCommand { get; set; }

        public ICommand SearchContactCommand { get; set; }

        public List<string> listeEmails { get; set; }


        public string Email
        {
            get
            {
                return email.Mail;
            }
            set
            {
                email.Mail = value;
                RaisePropertyChanged();
            }
        }

        public string Nom
        {
            get => contact.Nom;
            set
            {
                contact.Nom = value;
                RaisePropertyChanged();
            }
        }

        public string Prenom
        {
            get => contact.Prenom;
            set
            {
                contact.Prenom = value;
                RaisePropertyChanged();
            }
        }

        public int Count
        {
            get => listeEmails.Count;
           
        }

        public string Telephone
        {
            get => contact.Telephone;
            set
            {
                contact.Telephone = value;
                RaisePropertyChanged();
            }
        }


        public MainWindowViewModel()
        {
            contact = new Contact();
            email = new Email();
            Contacts = DataBase.Instance.GetContactWithEmail();
            listeEmails = new List<string>();
            AddEmailCommand = new RelayCommand(() =>
            {
                listeEmails.Add(Email);
                Email = "";
                RaisePropertyChanged("Count");
            });

            AddContactCommand = new RelayCommand(() =>
            {
                dynamic o = new
                {
                    
                    Nom = Nom,
                    Prenom =Prenom,
                    Telephone = Telephone,
                    Emails = listeEmails
                };
                Contacts.Add(o);
                Nom = "";
                Prenom = "";
                Telephone = "";
                listeEmails = new List<string>();
                RaisePropertyChanged();
            });
        }
    }
}
