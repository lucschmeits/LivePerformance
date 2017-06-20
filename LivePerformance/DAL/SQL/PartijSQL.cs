using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using LivePerformance.DAL.INTERFACE;
using LivePerformance.Models;

namespace LivePerformance.DAL.SQL
{
    public class PartijSQL : IPartij
    {
        public void CreatePartij(Partij partij)
        {
            try
            {
                var con = new SqlConnection(env.Con);

                con.Open();
                var query1 = "INSERT INTO Partij (Afkorting, Naam, Lijsttrekker) VALUES (@Afkorting, @Naam, @Lijsttrekker)";
                var command = new SqlCommand(query1, con);

                command.Parameters.AddWithValue("@Afkorting", partij.Afkorting);
                command.Parameters.AddWithValue("@Naam", partij.Naam);
                command.Parameters.AddWithValue("@Lijsttrekker", partij.Lijsttrekker);
               

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }

        public void DeletePartij(int id)
        {
            try
            {
                var con = new SqlConnection(env.Con);
                con.Open();
                var query1 = "DELETE FROM Partij WHERE Id = @id";
                var command = new SqlCommand(query1, con);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Partijuitslag> GetUitslagByPartij(int id)
        {
            try
            {
                var returnList = new List<Partijuitslag>();
                var con = new SqlConnection(env.Con);
                con.Open();
                var cmdString = "SELECT * FROM Partijuitslag WHERE PartijId = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var partijUitslag = new Partijuitslag(reader.GetInt32(0), reader.GetDateTime(2), reader.GetInt32(5), reader.GetDecimal(3), reader.GetInt32(4), RetrievePartij(reader.GetInt32(1)));
                    returnList.Add(partijUitslag);
                }
                con.Close();
                return returnList;
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Partij> RetrieveAll()
        {
            try
            {
                var returnList = new List<Partij>();
                var con = new SqlConnection(env.Con);
                con.Open();
                var cmdString = "SELECT * FROM Partij";
                var command = new SqlCommand(cmdString, con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var partij = new Partij(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    returnList.Add(partij);
                }
                con.Close();
                return returnList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Partij RetrievePartij(int id)
        {
            try
            {
                var partij = new Partij();
                var con = new SqlConnection(env.Con);
                con.Open();
                var cmdString = "SELECT * FROM Partij WHERE Id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    partij= new Partij(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                   
                }
                con.Close();
                return partij;
            }
            catch (Exception e)
            {
              throw e;
            }
        }

        public void UpdatePartij(Partij partij)
        {
            try
            {
                var con = new SqlConnection(env.Con);
                con.Open();
                var query = "UPDATE Partij SET Afkorting = @Afkorting, Naam = @Naam, Lijsttrekker = @Lijsttrekker WHERE id = @id";
                var cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", partij.Id);
                cmd.Parameters.AddWithValue("@Afkorting", partij.Afkorting);
                cmd.Parameters.AddWithValue("@Naam", partij.Naam);
                cmd.Parameters.AddWithValue("@Lijsttrekker", partij.Lijsttrekker);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
