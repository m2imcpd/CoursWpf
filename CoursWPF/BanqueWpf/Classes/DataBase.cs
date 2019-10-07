using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Compte> GetComptes()
        {
            ObservableCollection<Compte> liste = new ObservableCollection<Compte>();
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

        //public bool AddClient(string nom, string prenom, string telephone)
        //{
        //    bool res = false;

        //    command = new SqlCommand("INSERT INTO banque_client (nom, prenom, telephone) OUTPUT INSERTED.ID values(@nom, @prenom, @telephone)", connection);
        //    command.Parameters.Add(new SqlParameter("@nom", nom));
        //    command.Parameters.Add(new SqlParameter("@prenom", prenom));
        //    command.Parameters.Add(new SqlParameter("@telephone", telephone));
        //    connection.Open();
        //    int clientId = (int)command.ExecuteScalar();
        //    command.Dispose();
        //    if(clientId > 0)
        //    {
        //        command = new SqlCommand("INSERT INTO banque_compte(numero_compte, clientId, solde, date_creation) values (@numero_compte, @clientId, 0, @date_creation)", connection);
        //        command.Parameters.Add(new SqlParameter("@numero_compte", Guid.NewGuid().ToString()));
        //        command.Parameters.Add(new SqlParameter("@clientId", clientId));
        //        command.Parameters.Add(new SqlParameter("@date_creation", DateTime.Now));
        //        if(command.ExecuteNonQuery() > 0)
        //        {
        //            res = true;
        //        }
        //        command.Dispose();
        //    }
        //    connection.Close();
        //    return res;
        //}

        public Compte AddClient(string nom, string prenom, string telephone)
        {
            Compte c = new Compte();

            command = new SqlCommand("INSERT INTO banque_client (nom, prenom, telephone) OUTPUT INSERTED.ID values(@nom, @prenom, @telephone)", connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            command.Parameters.Add(new SqlParameter("@prenom", prenom));
            command.Parameters.Add(new SqlParameter("@telephone", telephone));
            connection.Open();
            int clientId = (int)command.ExecuteScalar();
            command.Dispose();
            if (clientId > 0)
            {
                string numero_compte = Guid.NewGuid().ToString();
                command = new SqlCommand("INSERT INTO banque_compte(numero_compte, clientId, solde, date_creation) OUTPUT INSERTED.ID values (@numero_compte, @clientId, 0, @date_creation)", connection);
                command.Parameters.Add(new SqlParameter("@numero_compte", numero_compte));
                command.Parameters.Add(new SqlParameter("@clientId", clientId));
                command.Parameters.Add(new SqlParameter("@date_creation", DateTime.Now));
                c.Id = (int)command.ExecuteScalar();
                c.Numero = numero_compte;
                c.Solde = 0;
                c.Client = new Client { Id = clientId, Nom = nom, Prenom = prenom, Telephone = telephone };
                command.Dispose();
            }
            connection.Close();
            return c;
        }

        public bool AddOperation(decimal montant, int compteId)
        {
            bool res = false;
            command = new SqlCommand("INSERT INTO banque_operation (montant, compteId, date_operation) values(@montant, @compteId, @date_operation)", connection);
            command.Parameters.Add(new SqlParameter("@montant", montant));
            command.Parameters.Add(new SqlParameter("@compteId", compteId));
            command.Parameters.Add(new SqlParameter("@date_operation", DateTime.Now));
            connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                command.Dispose();
                command = new SqlCommand("UPDATE banque_compte SET solde = solde + @montant WHERE id = @id", connection);
                command.Parameters.Add(new SqlParameter("@montant", montant));
                command.Parameters.Add(new SqlParameter("@id", compteId));
                if (command.ExecuteNonQuery() > 0)
                    res = true;
                command.Dispose();
            }
            connection.Close();
            return res;
        }

        public List<Operation> GetOperationsByCompte(int compteId)
        {
            List<Operation> liste = new List<Operation>();
            command = new SqlCommand("SELECT id, date_operation, montant from banque_operation where compteId = @compteId", connection);
            command.Parameters.Add(new SqlParameter("@compteId", compteId));
            connection.Open();
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                Operation o = new Operation
                {
                    Id = reader.GetInt32(0),
                    DateOperation = reader.GetDateTime(1),
                    Montant = reader.GetDecimal(2),
                    CompteId = compteId
                };
                liste.Add(o);
            }
            command.Dispose();
            connection.Close();
            return liste;
        }
    }
}
