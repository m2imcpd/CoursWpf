namespace BanqueWpf
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BanqueDbContext : DbContext
    {
        public BanqueDbContext()
            : base("name=BanqueDbContext")
        {
        }

        public virtual DbSet<banque_client> banque_client { get; set; }
        public virtual DbSet<banque_compte> banque_compte { get; set; }
        public virtual DbSet<banque_operation> banque_operation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<banque_client>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<banque_client>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<banque_client>()
                .Property(e => e.telephone)
                .IsUnicode(false);

            modelBuilder.Entity<banque_compte>()
                .Property(e => e.numero_compte)
                .IsUnicode(false);

            modelBuilder.Entity<banque_compte>()
                .Property(e => e.solde)
                .HasPrecision(18, 0);

            modelBuilder.Entity<banque_operation>()
                .Property(e => e.montant)
                .HasPrecision(18, 0);
        }
    }
}
