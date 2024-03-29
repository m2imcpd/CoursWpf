﻿using CorrectionAnnuaire.Models;
using CorrectionAnnuaire.Tools;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public List<Email> listeEmails { get; set; }

        public bool NomRadio { get; set; }
        public bool PrenomRadio { get; set; }

        private string searchPhone;

        private DataDbContext data;
        public string SearchPhone
        {
            get => searchPhone; set
            {
                searchPhone = value; RaisePropertyChanged();
            }
        }

        //public string SearchResult { get; set; }

        public ObservableCollection<object> SearchResult { get; set; }
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
            //Contacts = DataBase.Instance.GetContactWithEmail();
            data = new DataDbContext();
            Contact ct = data.Contacts.Find(1);
            data.Contacts.Remove(ct);
            data.SaveChanges();
            Contacts = new ObservableCollection<object>(data.Contacts.Include("Emails"));
            listeEmails = new List<Email>();
            AddEmailCommand = new RelayCommand(() =>
            {
                listeEmails.Add(new Email { Mail = Email});
                Email = "";
                RaisePropertyChanged("Count");
                
            });

            AddContactCommand = new RelayCommand(() =>
            {
                //dynamic o = new
                //{

                //    Nom = Nom,
                //    Prenom = Prenom,
                //    Telephone = Telephone,
                //    Emails = listeEmails
                //};

                Contact c = new Contact
                {
                    Nom = Nom,
                    Prenom = Prenom,
                    Telephone = Telephone,
                    Emails = listeEmails
                };
                data.Contacts.Add(c);
                //if (DataBase.Instance.AddContactWithEmails(o))
                if(data.SaveChanges() > 0)
                {
                    Contacts.Add(c);

                    Nom = "";
                    Prenom = "";
                    Telephone = "";
                    listeEmails = new List<Email>();
                    RaisePropertyChanged();
                }
                else
                {
                    MessageBox.Show("Error serveur");
                }

            });

            SearchContactCommand = new RelayCommand(() =>
            {
                //SearchResult = DataBase.Instance.SearchContactByPhone((SearchPhone != null) ? SearchPhone : "");
                SearchResult = new ObservableCollection<object>(data.Contacts.Include("Emails").Where(x => x.Telephone == SearchPhone));
                RaisePropertyChanged("SearchResult");
            });
        }
    }
}
