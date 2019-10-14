using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfEntity
{
    [Table("MesAdresses")]
    public class Adresse
    {

        private int adresseId;
        private string rue;
        private string ville;

        [Key]
        public int AdresseId { get => adresseId; set => adresseId = value; }

        [Required, MaxLength(50)]
        public string Rue { get => rue; set => rue = value; }

        [Required, MaxLength(50), Column("LaVille")]
        public string Ville { get => ville; set => ville = value; }

        [ForeignKey("Personne")]
        public int PersonneId { get; set; }
        public Personne Personne { get; set; }
    }
}
