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
    public class CoalitieSQL : ICoalitie
    {
        public void CreateCoalitie(Coalitie coalitie)
        {
            try
            {
                var con = new SqlConnection(env.Con);
                con.Open();
                var query1 = "INSERT INTO Coalitie (Premier, Zetels, Naam) VALUES (@Premier, @Zetels, @Naam)";
                var command = new SqlCommand(query1, con);

                command.Parameters.AddWithValue("@Premier", coalitie.Premier);
                command.Parameters.AddWithValue("@Zetels", coalitie.Zetels);
                command.Parameters.AddWithValue("@Naam", coalitie.Naam);

                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteCoalitie(int id)
        {
            try
            {
                var con = new SqlConnection(env.Con);
                con.Open();
                var query1 = "DELETE FROM Coalities WHERE Id = @id";
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

        public List<Coalitie> RetrieveAll()
        {
            try
            {
                var returnList = new List<Coalitie>();
                var con = new SqlConnection(env.Con);
                con.Open();
                var cmdString = "SELECT * FROM Coalitie";
                var command = new SqlCommand(cmdString, con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                 //   var coalitie = new Coalitie(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), //get partijen by Id);
                  //  returnList.Add(coalitie);
                }
                con.Close();
                return returnList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Coalitie RetrieveCoalitie(int id)
        {
            try
            {
                var coalitie = new Coalitie();
                var con = new SqlConnection(env.Con);
                con.Open();
                var cmdString = "SELECT * FROM Coalitie WHERE Id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@Id", id);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // coalitie = new Coalitie(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), //get partijen by Id);
                   
                }
                con.Close();
                return coalitie;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateCoalitie(Coalitie coalitie)
        {
            try
            {
                var con = new SqlConnection(env.Con);
                con.Open();
                var query = "UPDATE Coalitie SET Premier = @Premier, Zetels = @Zetels, Naam = @Naam WHERE id = @id";
                var cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", coalitie.Id);
                cmd.Parameters.AddWithValue("@Premier", coalitie.Premier);
                cmd.Parameters.AddWithValue("@Zetels", coalitie.Zetels);
                cmd.Parameters.AddWithValue("@Naam", coalitie.Naam);

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
