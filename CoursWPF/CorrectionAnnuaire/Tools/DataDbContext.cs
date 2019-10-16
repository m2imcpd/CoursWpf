using CorrectionAnnuaire.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionAnnuaire.Tools
{
    public class DataDbContext : DbContext
    {
        public DataDbContext() : base(@"Data Source=(LocalDb)\CoursMCPD;Integrated Security=True")
        {

        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Email> Emails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Email>().HasRequired(x => x.Contact).WithMany().WillCascadeOnDelete(false);
        }
    }
}
