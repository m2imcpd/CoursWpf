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

        public bool AddContactWithEmails(dynamic o)
        {
            bool res = false;
            command = new SqlCommand("INSERT INTO contact_wpf(nom, prenom, telephone) OUTPUT INSERTED.ID values (@nom, @prenom, @telephone)", connection);
            command.Parameters.Add(new SqlParameter("@nom", o.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", o.Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", o.Telephone));
            connection.Open();
            int contactId = (int)command.ExecuteScalar();
            command.Dispose();
            if(contactId > 0)
            {
                foreach(string e in o.Emails)
                {
                    command = new SqlCommand("INSERT INTO email_wpf (mail, contactid) values (@mail,@contactid)", connection);
                    command.Parameters.Add(new SqlParameter("@mail", e));
                    command.Parameters.Add(new SqlParameter("@contactid", contactId));
                    command.ExecuteNonQuery();
                    command.Dispose();
                }
                res = true;
              
            }
            connection.Close();
            return res;
        }

        //public string SearchContactByPhone(string phone = "")
        //{
        //    bool found = false;
        //    command = new SqlCommand("SELECT c.nom, c.prenom, c.telephone, e.mail " +
        //        "From contact_wpf as c right join email_wpf as e on e.contactid = c.id where telephone = @telephone", connection);
        //    command.Parameters.Add(new SqlParameter("@telephone", phone));
        //    connection.Open();
        //    reader = command.ExecuteReader();
        //    string nom ="", prenom="", telephone="", emails = "";
        //    while (reader.Read())
        //    {
        //        nom = reader.GetString(0);
        //        prenom = reader.GetString(1);
        //        telephone = reader.GetString(2);
        //        emails += " " + reader.GetString(3);
        //        found = true;
        //    }
        //    command.Dispose();
        //    connection.Close();
        //    return (found) ? $"{nom}  {prenom} {telephone}, {emails}" : "No contact found";
        //}

        public ObservableCollection<object> SearchContactByPhone(string phone = "")
        {
            ObservableCollection<dynamic> liste = new ObservableCollection<object>();

            command = new SqlCommand("SELECT c.id, c.nom, c.prenom, c.telephone, e.mail " +
                "From contact_wpf as c right join email_wpf as e on e.contactid = c.id where c.telephone like @telephone OR c.Nom like @telephone OR c.Prenom like @telephone", connection);
            command.Parameters.Add(new SqlParameter("@telephone", phone + "%"));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                dynamic o = liste.FirstOrDefault(x => x.Id == reader.GetInt32(0));
                if (o != null)
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
