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
    public class Patient
    {
        private int id;
        private string nom;
        private DateTime dateNaissance;
        private string adresse;
        private string sexePatient;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string SexePatient { get => sexePatient; set => sexePatient = value; }

        public bool Add()
        {
            bool res = false;
            DataBase.Instance.command = new SqlCommand("INSERT INTO patient (nomPatient, adressePatient, dateNaissance, sexePatient) OUTPUT INSERTED.ID values(@nomPatient, @adressePatient, @dateNaissance, @sexePatient)", DataBase.Instance.connection);
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@nomPatient", Nom));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@adressePatient", Adresse));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@dateNaissance", DateNaissance));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@sexePatient", SexePatient));
            DataBase.Instance.connection.Open();
            Id = (int)DataBase.Instance.command.ExecuteScalar();
            DataBase.Instance.command.Dispose();
            DataBase.Instance.connection.Close();
            if (Id > 0)
            {
                res = true;
            }
            return res;
        }

        public bool Update()
        {
            bool res = false;
            DataBase.Instance.command = new SqlCommand("UPDATE patient set " +
                "nomPatient = @nomPatient, adressePatient = @adressePatient, dateNaissance = @dateNaissance, sexePatient = @sexePatient " +
                "WHERE id = @id", DataBase.Instance.connection);
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@nomPatient", Nom));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@adressePatient", Adresse));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@dateNaissance", DateNaissance));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@sexePatient", SexePatient));
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

        public bool Delete()
        {
            bool res = false;
            DataBase.Instance.command = new SqlCommand("DELETE FROM patient WHERE id = @id", DataBase.Instance.connection);
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

        public static Patient GetPatientByNom(string nom)
        {
            Patient p = null;
            DataBase.Instance.command = new SqlCommand("SELECT id, adressePatient, dateNaissance, sexePatient from patient where nomPatient = @nomPatient", DataBase.Instance.connection);
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@nomPatient", nom));
            DataBase.Instance.connection.Open();
            DataBase.Instance.reader = DataBase.Instance.command.ExecuteReader();
            if (DataBase.Instance.reader.Read())
            {
                p = new Patient();
                p.Id = DataBase.Instance.reader.GetInt32(0);
                p.Nom = nom;
                p.DateNaissance = DataBase.Instance.reader.GetDateTime(2);
                p.SexePatient = DataBase.Instance.reader.GetString(3);
                p.Adresse = DataBase.Instance.reader.GetString(1);     
            }
            DataBase.Instance.command.Dispose();
            DataBase.Instance.connection.Close();
            return p;
        }

        public static ObservableCollection<Patient> GetAllPatients()
        {
            ObservableCollection<Patient> liste = new ObservableCollection<Patient>();
            DataBase.Instance.command = new SqlCommand("SELECT id, adressePatient, dateNaissance, sexePatient, nomPatient from patient", DataBase.Instance.connection);
            
            DataBase.Instance.connection.Open();
            DataBase.Instance.reader = DataBase.Instance.command.ExecuteReader();
            while(DataBase.Instance.reader.Read())
            {
                Patient p = new Patient();
                p.Id = DataBase.Instance.reader.GetInt32(0);
                p.Nom = DataBase.Instance.reader.GetString(4);
                p.DateNaissance = DataBase.Instance.reader.GetDateTime(2);
                p.SexePatient = DataBase.Instance.reader.GetString(3);
                p.Adresse = DataBase.Instance.reader.GetString(1);
                liste.Add(p);
            }
            DataBase.Instance.command.Dispose();
            DataBase.Instance.connection.Close();
            return liste;
        }
    }
}
