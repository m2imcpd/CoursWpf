using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ProduitEntityWPF.Classes;
using ProduitEntityWPF.Tools;
using ProduitEntityWPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProduitEntityWPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Produit produit;
        public string Titre
        {
            get => produit.Titre;
            set
            {
                produit.Titre=value;
                RaisePropertyChanged();

            }
        }
        public float Prix
        {
            get => produit.Prix;
            set
            {
                produit.Prix = value;
                RaisePropertyChanged();
            }
        }
        public int Stock
        {
            get => produit.Stock;
            set
            {
                produit.Stock = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Produit> ListeProduits { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand StartPanierWindowCommand { get; set; }

        private DataDbContext data;
        public MainWindowViewModel()
        {
            produit = new Produit();
            data = new DataDbContext();
            ListeProduits = new ObservableCollection<Produit>(data.Produits.Cast<Produit>());
            AddCommand = new RelayCommand(AddProduits);
            StartPanierWindowCommand = new RelayCommand(() =>
            {
                PanierWindow w = new PanierWindow();
                w.Show();
            });
        }
        private void AddProduits()
        {
            data.Produits.Add(produit);
            if(data.SaveChanges() > 0)
            {
                ListeProduits.Add(produit);
            }
        }
    }
}
