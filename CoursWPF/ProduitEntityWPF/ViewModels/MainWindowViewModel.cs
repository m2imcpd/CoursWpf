using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using ProduitEntityWPF.Classes;
using ProduitEntityWPF.Tools;
using ProduitEntityWPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        public ObservableCollection<string> ListeUrlImages { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand StartPanierWindowCommand { get; set; }

        public ICommand AddImageCommand { get; set; }

        private DataDbContext data;
        public MainWindowViewModel()
        {
            produit = new Produit();
            data = new DataDbContext();
            ListeProduits = new ObservableCollection<Produit>(data.Produits.Cast<Produit>());
            AddCommand = new RelayCommand(AddProduits);
            AddImageCommand = new RelayCommand(AddImageProduit);
            ListeUrlImages = new ObservableCollection<string>();
            StartPanierWindowCommand = new RelayCommand(() =>
            {
                PanierWindow w = new PanierWindow();
                w.Show();
            });
        }

        public void AddImageProduit()
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == true)
            {
                ListeUrlImages.Add(open.FileName);
            }
            RaisePropertyChanged("ListeUrlImages");
        }
        private void AddProduits()
        {
            foreach(string url in ListeUrlImages)
            {
                produit.Images.Add(new ImageProduit { UrlImage = MoveImageToImageFolder(url), Produit = produit });
            }
            data.Produits.Add(produit);
            if(data.SaveChanges() > 0)
            {
                ListeProduits.Add(produit);
                ListeUrlImages = new ObservableCollection<string>();
            }
        }

        private string MoveImageToImageFolder(string urlToMove)
        {
            if(!Directory.Exists("images"))
            {
                Directory.CreateDirectory("images");
            }
            string urlAfterMove = Path.Combine("images", Path.GetFileName(urlToMove));
            File.Copy(urlToMove, urlAfterMove);
            return urlAfterMove;
        }
    }
}
