using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using ProduitEntityWPF.Classes;
using ProduitEntityWPF.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProduitEntityWPF.ViewModels
{
    public class PanierWindowViewModel : ViewModelBase
    {
        private string search;

        private Panier panier;

        public ObservableCollection<Produit> ListeProduits { get; set; }

        public ObservableCollection<ProduitPanier> ListeProduitsPanier { get; set; }

        

        public Produit ProduitSelected { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand AddPanierCommand { get; set; }

        public ICommand ValidPanierCommand { get; set; }

       
        public string Search { get => search; set { search = value; RaisePropertyChanged(); } }

        public decimal Total
        {
            get
            {
                return ListeProduitsPanier.Sum(x => x.TotalProduit);
            }
        }

        private DataDbContext data;

        public PanierWindowViewModel()
        {
            data = new DataDbContext();
            SearchCommand = new RelayCommand(SearchProducts);
            AddPanierCommand = new RelayCommand(AddProduitToPanier);
            ValidPanierCommand = new RelayCommand(ValidPanier);
            
            ListeProduitsPanier = new ObservableCollection<ProduitPanier>();
           
            panier = new Panier();
        }

        

        private void AddProduitToPanier()
        {
            if (ProduitSelected.Stock > 0)
            {
                ProduitPanier p = ListeProduitsPanier.FirstOrDefault(x => x.Produit.Id == ProduitSelected.Id);
                if (p == null)
                {
                    ListeProduitsPanier.Add(new ProduitPanier { Produit = ProduitSelected, Qty = 1 });
                }
                else
                {
                    p.Qty++;
                }
                ProduitSelected.Stock--;
            }
            else
            {
                MessageBox.Show("Pas de stock");
            }
            RaisePropertyChanged("Total");
        }

        private void SearchProducts()
        {
            ListeProduits = new ObservableCollection<Produit>(data.Produits.Where(x => x.Titre.StartsWith(Search)));
            RaisePropertyChanged("ListeProduits");
        }

        private void ValidPanier()
        {
            foreach(ProduitPanier p in ListeProduitsPanier)
            {
                for(int i=1; i <= p.Qty; i++)
                {
                    panier.ProduitsPanier.Add(new PanierProduit { Produit = p.Produit, Panier = panier });
                }
            }
            panier.Total = Total;
            data.Paniers.Add(panier);
            data.SaveChanges();
        }
    }
}
