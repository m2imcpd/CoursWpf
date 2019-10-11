using GestionRendezVousHopital.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRendezVousHopital.Models
{
    public class RDV
    {
        private int id;
        private DateTime dateRDV;
        private string heure;
        private int patientId;
        private int medecinId;

        public int Id { get => id; set => id = value; }
        public DateTime DateRDV { get => dateRDV; set => dateRDV = value; }
        public string Heure { get => heure; set => heure = value; }
        public int PatientId { get => patientId; set => patientId = value; }
        public int MedecinId { get => medecinId; set => medecinId = value; }

        public bool Add()
        {
            bool res = false;
            DataBase.Instance.command = new SqlCommand("INSERT INTO RDV (DateRDV, HeureRDV, CodeMedecin, CodePatient) OUTPUT INSERTED.ID values(@DateRDV, @HeureRDV, @CodeMedecin, @CodePatient)", DataBase.Instance.connection);
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@DateRDV", DateRDV));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@HeureRDV", Heure));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@CodeMedecin", MedecinId));
            DataBase.Instance.command.Parameters.Add(new SqlParameter("@CodePatient", PatientId));
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
    }
}
