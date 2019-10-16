using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduitEntityWPF.Classes
{
    public class PanierProduit
    {
        private int id;
        private int produitId;

        private int panierId;


        [Key]
        public int Id { get => id; set => id = value; }

        [ForeignKey("Produit")]
        public int ProduitId { get => produitId; set => produitId = value; }

        [ForeignKey("Panier")]
        public int PanierId { get => panierId; set => panierId = value; }


        public virtual Panier Panier { get; set; }

        public virtual Produit Produit { get; set; }
    }
}
