namespace BanqueWpf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class banque_operation
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date_operation { get; set; }

        public decimal montant { get; set; }

        public int compteId { get; set; }
    }
}
