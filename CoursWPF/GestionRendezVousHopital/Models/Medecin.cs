using GestionRendezVousHopital.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public bool Update()
        {
            bool res = false;
            DataBase.Instance.command = new SqlCommand("UPDATE medecin set " +
                "nomMedecin = @nom, telMedecin = @tel, dateEmbauche = @dateEmbauche, specialiteMedecin = @specialite " +
                "WHERE id = @id", DataBase.Instance.connection);
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@nom", Nom));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@tel", Telephone));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@dateEmbauche",DateEmbauche));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@specialite",Specialite));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@id",Id));
            DataBase.Instance.connection.Open();
            if(DataBase.Instance.command.ExecuteNonQuery() > 0)
            {
                res = true;
            }
            DataBase.Instance.command.Dispose();
            DataBase.Instance.connection.Close();
            return res;
        }

        public bool Delete()
        {
            bool res = false;
            DataBase.Instance.command = new SqlCommand("DELETE FROM Medecin where id = @id", DataBase.Instance.connection);
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@id", Id));
            DataBase.Instance.connection.Open();
            if (DataBase.Instance.command.ExecuteNonQuery() > 0)
            {
                res = true;
            }
            DataBase.Instance.command.Dispose();
            DataBase.Instance.connection.Close();
            return res;
        }

        public static Medecin SearchMedecinByPhone(string phone)
        {
            Medecin m = null;
            DataBase.Instance.command = new SqlCommand("SELECT id, nomMedecin, dateEmbauche, specialiteMedecin from medecin where telMedecin = @telephone", DataBase.Instance.connection);
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@telephone", phone));
            DataBase.Instance.connection.Open();
            DataBase.Instance.reader = DataBase.Instance.command.ExecuteReader();
            if(DataBase.Instance.reader.Read())
            {
                m = new Medecin();
                m.Id = DataBase.Instance.reader.GetInt32(0);
                m.Nom = DataBase.Instance.reader.GetString(1);
                m.DateEmbauche = DataBase.Instance.reader.GetDateTime(2);
                m.Specialite = (Specialite)DataBase.Instance.reader.GetInt32(3);
                m.Telephone = phone;
            }
            DataBase.Instance.command.Dispose();
            DataBase.Instance.connection.Close();
            return m;
        }

        public static ObservableCollection<Medecin> GetAllMedecins()
        {
            ObservableCollection<Medecin> liste = new ObservableCollection<Medecin>();
            DataBase.Instance.command = new SqlCommand("SELECT id, nomMedecin, dateEmbauche, specialiteMedecin, TelMedecin from medecin", DataBase.Instance.connection);
            
            DataBase.Instance.connection.Open();
            DataBase.Instance.reader = DataBase.Instance.command.ExecuteReader();
            while(DataBase.Instance.reader.Read())
            {
                Medecin m = new Medecin();
                m.Id = DataBase.Instance.reader.GetInt32(0);
                m.Nom = DataBase.Instance.reader.GetString(1);
                m.DateEmbauche = DataBase.Instance.reader.GetDateTime(2);
                m.Specialite = (Specialite)DataBase.Instance.reader.GetInt32(3);
                m.Telephone = DataBase.Instance.reader.GetString(4);
                liste.Add(m);
            }
            DataBase.Instance.command.Dispose();
            DataBase.Instance.connection.Close();

            return liste;
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
