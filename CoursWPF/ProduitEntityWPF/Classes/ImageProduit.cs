using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduitEntityWPF.Classes
{
    public class ImageProduit
    {
        private int id;

        private string urlImage;

        public int Id { get => id; set => id = value; }
        public string UrlImage { get => urlImage; set => urlImage = value; }

        [ForeignKey("Produit")]
        public int ProduitId { get; set; }
        public Produit Produit { get; set; }
    }
}
