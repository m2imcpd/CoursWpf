using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWpfMVVM.Models
{
    public class Client
    {
        private int id;
        private string nom;
        private string prenom;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }

        public void Update()
        {
            //Logic Metier
        }
    }
}
