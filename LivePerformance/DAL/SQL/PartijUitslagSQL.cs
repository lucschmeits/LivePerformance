using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePerformance.DAL.INTERFACE;
using LivePerformance.DAL.REPO;
using LivePerformance.Models;

namespace LivePerformance.DAL.SQL
{
    public class PartijUitslagSQL : IPartijUitslag
    {
        public void CreatePartijuitslag(Partijuitslag partijuitslag)
        {
            try
            {
                var con = new SqlConnection(env.Con);
                con.Open();
                var query1 = "INSERT INTO Partij (PartijId, Datum, Percentage, Zetels, Stemmen) VALUES (@PartijId, @Datum, @Percentage, @Zetels, @Stemmen)";
                var command = new SqlCommand(query1, con);

                command.Parameters.AddWithValue("@PartijId", partijuitslag.Partij.Id);
                command.Parameters.AddWithValue("@Datum", partijuitslag.Datum);
                command.Parameters.AddWithValue("@Percentage", partijuitslag.Percentage);
                command.Parameters.AddWithValue("@Zetels", partijuitslag.Zetels);
                command.Parameters.AddWithValue("@Stemmen", partijuitslag.Stemmen);

                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeletePartijuitslag(int id)
        {
            try
            {
                var con = new SqlConnection(env.Con);
                con.Open();
                var query1 = "DELETE FROM Partijuitslag WHERE Id = @id";
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

        public List<Partijuitslag> PartijUitslagByUitslagId(int id)
        {

            try
            {
                var partijSql = new PartijSQL();
                var partijRepo = new PartijREPO(partijSql);
                var returnList = new List<Partijuitslag>();
                var con = new SqlConnection(env.Con);
                con.Open();
                var cmdString = "SELECT Partijuitslag.* FROM Partijuitslag INNER JOIN Partijuitslag_Uitslag ON Partijuitslag.Id = Partijuitslag_Uitslag.PartijuitslagId WHERE UitslagId = @id";
                var command = new SqlCommand(cmdString, con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var partijuislag = new Partijuitslag(reader.GetInt32(0), reader.GetDateTime(2), reader.GetInt32(5), reader.GetDecimal(3), reader.GetInt32(4), partijRepo.RetrievePartij(reader.GetInt32(1)));
                    returnList.Add(partijuislag);
                }
                con.Close();
                return returnList;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Partijuitslag> RetrieveAll()
        {
            try
            {
                var partijSql = new PartijSQL();
                var partijRepo = new PartijREPO(partijSql);
                var returnList = new List<Partijuitslag>();
                var con = new SqlConnection(env.Con);
                con.Open();
                var cmdString = "SELECT * FROM Partijuitslag";
                var command = new SqlCommand(cmdString, con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var partijuislag = new Partijuitslag(reader.GetInt32(0), reader.GetDateTime(2), reader.GetInt32(5), reader.GetDecimal(3), reader.GetInt32(4), partijRepo.RetrievePartij(reader.GetInt32(1)));
                    returnList.Add(partijuislag);
                }
                con.Close();
                return returnList;
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Partijuitslag RetrievePartijuitslag(int id)
        {
            try
            {
                var partijSql = new PartijSQL();
                var partijRepo = new PartijREPO(partijSql);
                var partijUitslag = new Partijuitslag();
                var con = new SqlConnection(env.Con);
                con.Open();
                var cmdString = "SELECT * FROM Partijuitslag WHERE Id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    partijUitslag = new Partijuitslag(reader.GetInt32(0), reader.GetDateTime(2), reader.GetInt32(5), reader.GetDecimal(3), reader.GetInt32(4), partijRepo.RetrievePartij(reader.GetInt32(1)));

                }
                con.Close();
                return partijUitslag;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdatePartijuitslag(Partijuitslag partijuitslag)
        {
            try
            {
                var con = new SqlConnection(env.Con);
                con.Open();
                var query = "UPDATE Partijuitslag SET PartijId = @PartijId, Datum = @Datum, Percentage = @Percentage, Zetels = @Zetels, Stemmen = @Stemmen WHERE id = @id";
                var cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", partijuitslag.Id);
                cmd.Parameters.AddWithValue("@PartijId", partijuitslag.Partij.Id);
                cmd.Parameters.AddWithValue("@Datum", partijuitslag.Datum);
                cmd.Parameters.AddWithValue("@Percentage", partijuitslag.Percentage);
                cmd.Parameters.AddWithValue("@Zetels", partijuitslag.Zetels);
                cmd.Parameters.AddWithValue("@Stemmen", partijuitslag.Stemmen);
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
