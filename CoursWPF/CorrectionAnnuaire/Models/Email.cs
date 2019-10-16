using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionAnnuaire.Models
{
    public class Email
    {
        private int id;
        private string mail;
        private int contactId;

        public int Id { get => id; set => id = value; }
        public string Mail { get => mail; set => mail = value; }
        [ForeignKey("Contact")]
        public int ContactId { get => contactId; set => contactId = value; }

        public virtual Contact Contact { get; set; } 
    }
}
