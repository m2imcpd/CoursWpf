using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfEntity
{
    public class DataDbContext : DbContext
    {

        public DataDbContext() : base(@"Data Source=(LocalDb)\CoursMCPD;Integrated Security=True")
        {

        }

        public DbSet<Personne> Personnes { get; set; }

        public DbSet<Adresse> Adresses { get; set; }
    }
}
