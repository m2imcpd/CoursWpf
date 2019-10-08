using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionAnnuaire.Tools
{
    public class DataBase
    {
        private static DataBase instance = null;
        private static object _lock = new object();

        private string connectionString = @"Data Source=(LocalDb)\CoursMCPD;Integrated Security=True";
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        public static DataBase Instance
        {
            get
            {
                lock(_lock)
                {
                    if (instance == null)
                        instance = new DataBase();
                    return instance;
                }
            }
        }
        private DataBase()
        {
            connection = new SqlConnection(connectionString);
        }
        
        public ObservableCollection<object> GetContactWithEmail()
        {
            ObservableCollection<dynamic> liste = new ObservableCollection<object>();

            command = new SqlCommand("SELECT c.id, c.nom, c.prenom, c.telephone, e.mail " +
                "From contact_wpf as c right join email_wpf as e on e.contactid = c.id",connection);
            connection.Open();
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                dynamic o = liste.FirstOrDefault(x => x.Id == reader.GetInt32(0));
                if(o != null)
                {
                    (o.Emails as List<string>).Add(reader.GetString(4));
                }
                else
                {
                    o = new
                    {
                        Id = reader.GetInt32(0),
                        Nom = reader.GetString(1),
                        Prenom = reader.GetString(2),
                        Telephone = reader.GetString(3),
                        Emails = new List<string>() { reader.GetString(4) }
                    };
                    liste.Add(o);
                }

                
                
            }
            command.Dispose();
            connection.Close();
            return liste;
        }
    }
}
