using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanqueWpf.Classes
{
    public class Operation
    {
        private int id;
        private decimal montant;
        private DateTime dateOperation;
        private int compteId;
        public int Id { get => id; set => id = value; }
        public decimal Montant { get => montant; set => montant = value; }
        public DateTime DateOperation { get => dateOperation; set => dateOperation = value; }
        public int CompteId { get => compteId; set => compteId = value; }
    }
}
