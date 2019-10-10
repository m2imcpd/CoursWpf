using GestionRendezVousHopital.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRendezVousHopital.Models
{
    public class Medecin
    {
        private int id;
        private string nom;
        private string telephone;
        private DateTime dateEmbauche;
        private Specialite specialite;


        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public DateTime DateEmbauche { get => dateEmbauche; set => dateEmbauche = value; }
        public Specialite Specialite { get => specialite; set => specialite = value; }


        public bool Add()
        {
            bool res = false;
            DataBase.Instance.command = new SqlCommand("INSERT INTO medecin (NomMedecin, TelMedecin, DateEmbauche, SpecialiteMedecin) OUTPUT INSERTED.ID values(@nomMedecin, @telMedecin, @dateEmbauche, @specialiteMedecin)", DataBase.Instance.connection);
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@nomMedecin", Nom));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@telMedecin", Telephone));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@dateEmbauche", DateEmbauche));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@specialiteMedecin", Specialite));
            DataBase.Instance.connection.Open();
            Id = (int)DataBase.Instance.command.ExecuteScalar();
            DataBase.Instance.command.Dispose();
            DataBase.Instance.connection.Close();
            if(Id > 0)
            {
                res = true;
            }
            return res;
        }

    }

    public enum Specialite
    {
        Cardiologie,
        Chirurgie,
        Dermatologie,
        Gériatrie,
        Oncologie,
        Pédiatrie
    }
}
