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
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataDbContext, Migrations.Configuration>());
        }
        public DbSet<Produit> Produits { get; set; }

        public DbSet<Panier> Paniers { get; set; }

        public DbSet<PanierProduit> PaniersProduits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produit>().ToTable("MesProduits");
            modelBuilder.Entity<Produit>().HasKey(x=> x.Id);
            //modelBuilder.Entity<Panier>().HasMany<Produit>(x=>x.Produits).WithMany(x=>x.Paniers).Map(x=> x.ToTable("ProduitEtPanier").MapLeftKey("ProduitId").MapRightKey("PanierId"));
        }
    }
}
