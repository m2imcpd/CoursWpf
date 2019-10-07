using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanqueWpf.Classes
{
    public class DataBase
    {
        private static DataBase instance = null;
        private static object _lock = new object();
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
            connection = new SqlConnection(@"Data Source=(LocalDb)\CoursMCPD;Integrated Security=True");
        }

        public List<Compte> GetComptes()
        {
            List<Compte> liste = new List<Compte>();
            command = new SqlCommand("SELECT c.id, c.numero_compte, c.solde, c.clientId, cl.nom, cl.prenom, cl.telephone from banque_compte as c inner join banque_client as cl on cl.id = c.clientId", connection);
            connection.Open();
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                Compte c = new Compte
                {
                    Id = reader.GetInt32(0),
                    Numero = reader.GetString(1),
                    Solde = reader.GetDecimal(2),
                    Client = new Client { Id = reader.GetInt32(3), Nom = reader.GetString(4), Prenom = reader.GetString(5), Telephone = reader.GetString(6) }
                };
                liste.Add(c);
            }
            command.Dispose();
            connection.Close();
            return liste;
        }

        public bool AddClient(string nom, string prenom, string telephone)
        {
            bool res = false;

            command = new SqlCommand("INSERT INTO banque_client (nom, prenom, telephone) OUTPUT INSERTED.ID values(@nom, @prenom, @telephone)", connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            command.Parameters.Add(new SqlParameter("@prenom", prenom));
            command.Parameters.Add(new SqlParameter("@telephone", telephone));
            connection.Open();
            int clientId = (int)command.ExecuteScalar();
            command.Dispose();
            if(clientId > 0)
            {
                command = new SqlCommand("INSERT INTO banque_compte(numero_compte, clientId, solde, date_creation) values (@numero_compte, @clientId, 0, @date_creation)", connection);
                command.Parameters.Add(new SqlParameter("@numero_compte", Guid.NewGuid().ToString()));
                command.Parameters.Add(new SqlParameter("@clientId", clientId));
                command.Parameters.Add(new SqlParameter("@date_creation", DateTime.Now));
                if(command.ExecuteNonQuery() > 0)
                {
                    res = true;
                }
                command.Dispose();
            }
            connection.Close();
            return res;
        }
    }
}
