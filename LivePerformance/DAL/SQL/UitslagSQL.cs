using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePerformance.DAL.INTERFACE;
using LivePerformance.Models;

namespace LivePerformance.DAL.SQL
{
    public class UitslagSQL : IUitslag
    {
        public void CreateUitslag(Uitslag uitslag)
        {
            try
            {
                var con = new SqlConnection(env.Con);
                con.Open();
                var query1 = "INSERT INTO Uitslag (Naam, Datum) VALUES (@Naam, @Datum);SELECT CAST(scope_identity() AS int)";
                var command = new SqlCommand(query1, con);
                command.Parameters.AddWithValue("@Naam", uitslag.Naam);
                command.Parameters.AddWithValue("@Datum", uitslag.Datum);
                var id = (int)command.ExecuteScalar();

                foreach (var partijuitslag in uitslag.Partijuislagen)
                {
                    command.CommandText = "INSERT INTO Partijuitslag_Uitslag (PartijuitslagId, UitslagId) VALUES (@partijUitslagId, @uitslagId)";
                    command.Parameters.AddWithValue("@partijUitslagId", partijuitslag.Id);
                    command.Parameters.AddWithValue("@uitslagId", id);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
               
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteUitslag(int id)
        {
            try
            {
                var con = new SqlConnection(env.Con);
                con.Open();
                var query1 = "DELETE FROM Uitslag WHERE Id = @id";
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

        public List<Uitslag> RetrieveAll()
        {
            try
            {
                var returnList = new List<Uitslag>();
                var con = new SqlConnection(env.Con);
                con.Open();
                var cmdString = "SELECT * FROM Uitslag";
                var command = new SqlCommand(cmdString, con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                  var uitslag = new Uitslag(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2));
                  returnList.Add(uitslag);
                }
                con.Close();
                return returnList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Uitslag RetrieveUitslag(int id)
        {
            try
            {
                var uitslag = new Uitslag();
                var con = new SqlConnection(env.Con);
                con.Open();
                var cmdString = "SELECT * FROM Uitslag WHERE Id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@Id", id);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // uitslag = new Uitslag(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), );

                }
                con.Close();
                return uitslag;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Uitslag RetrieveUitslagByDate(DateTime datum)
        {
            try
            {
                var uitslag = new Uitslag();
                var con = new SqlConnection(env.Con);
                con.Open();
                var cmdString = "SELECT * FROM Uitslag WHERE Datum = @Datum";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@Datum", datum);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // uitslag = new Uitslag(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), );

                }
                con.Close();
                return uitslag;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateUitslag(Uitslag uitslag)
        {
            try
            {
                var con = new SqlConnection(env.Con);
                con.Open();
                var query = "UPDATE Uitslag SET Naam = @Naam, Datum = @Datum WHERE id = @id";
                var cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", uitslag.Id);
                cmd.Parameters.AddWithValue("@Naam", uitslag.Naam);
                cmd.Parameters.AddWithValue("@Datum", uitslag.Datum);
               

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
