using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduitEntityWPF.Classes
{
    public class ProduitPanier : ViewModelBase
    {
        private int qty;
        private Produit produit;
       

        public int Qty { get => qty; set { qty = value; RaisePropertyChanged(); RaisePropertyChanged("TotalProduit"); } }
        public Produit Produit { get => produit; set => produit = value; }
        public decimal TotalProduit { get => qty * (decimal)produit.Prix; }
    }
}
