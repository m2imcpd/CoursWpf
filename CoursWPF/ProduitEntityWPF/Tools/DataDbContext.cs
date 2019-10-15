using ProduitEntityWPF.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduitEntityWPF.Tools
{
    public class DataDbContext : DbContext
    {
        public DataDbContext() : base(@"Data Source=(LocalDb)\CoursMCPD;Integrated Security=True")
        {

        }
        public DbSet<Produit> Produits { get; set; }
    }
}
