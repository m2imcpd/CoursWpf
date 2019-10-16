using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduitEntityWPF.Classes
{
    public class Produit
    {
        private int id;
        private string titre;
        private float prix;
        private int stock;

        public int Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }
        public float Prix { get => prix; set => prix = value; }
        public int Stock { get => stock; set => stock = value; }

        public virtual ICollection<PanierProduit> PaniersProduit { get; set; }

        public virtual ICollection<ImageProduit> Images { get; set; }

        public Produit()
        {
            PaniersProduit = new List<PanierProduit>();
            Images = new List<ImageProduit>();
        }

        public override string ToString()
        {
            return $"{Titre} {Prix}€ qty disponible {Stock}";
        }
    }
}
