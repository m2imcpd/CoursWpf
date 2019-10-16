namespace BanqueWpf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class banque_compte
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string numero_compte { get; set; }

        public int clientId { get; set; }

        public decimal solde { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date_creation { get; set; }
    }
}
