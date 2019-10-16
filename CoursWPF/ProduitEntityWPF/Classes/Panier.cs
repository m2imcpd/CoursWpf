using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduitEntityWPF.Classes
{
    public class Panier
    {
        private int id;
        private decimal total;



        public int Id { get => id; set => id = value; }
        public decimal Total { get => total; set => total = value; }

        public virtual ICollection<PanierProduit> ProduitsPanier { get; set; }

        public Panier()
        {
            ProduitsPanier = new List<PanierProduit>();
        }
    }
}
