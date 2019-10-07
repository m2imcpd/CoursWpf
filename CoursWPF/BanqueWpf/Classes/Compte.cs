using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanqueWpf.Classes
{
    public class Compte
    {
        private int id;
        private string numero;
        private decimal solde;
        private Client client;
        private List<Operation> listeOperations;

        public int Id { get => id; set => id = value; }
        public string Numero { get => numero; set => numero = value; }
        public decimal Solde { get => solde; set => solde = value; }
        public Client Client { get => client; set => client = value; }
        public List<Operation> ListeOperations { get => listeOperations; set => listeOperations = value; }
    }
}
