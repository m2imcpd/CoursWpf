using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClients.Classes
{
    public class Client
    {
        private string nom;
        private string prenom;
        private string telephone;

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }

        //public override string ToString()
        //{
        //    return $"Nom : {Nom}, Prénom : {Prenom}, Téléphone : {Telephone}";
        //}
    }
}
