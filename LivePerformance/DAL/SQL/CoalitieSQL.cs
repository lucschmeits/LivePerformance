﻿using System;
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
    public class CoalitieSQL : ICoalitie
    {
        public void CreateCoalitie(Models.Coalitie coalitie)
        {
            try
            {
                var con = new SqlConnection(env.Con);
                con.Open();
                var query1 = "INSERT INTO Coalitie (Premier, Zetels, Naam) VALUES (@Premier, @Zetels, @Naam);SELECT CAST(scope_identity() AS int)";
                var command = new SqlCommand(query1, con);

                command.Parameters.AddWithValue("@Premier", coalitie.Premier);
                command.Parameters.AddWithValue("@Zetels", coalitie.Zetels);
                command.Parameters.AddWithValue("@Naam", coalitie.Naam);

                var id = (int)command.ExecuteScalar();
                foreach (var partij in coalitie.Partijen)
                {
                    command.CommandText = "INSERT INTO Coalitie_Partij (CoalitieId, PartijId) VALUES (@CoalitieId, @PartijId)";
                    command.Parameters.AddWithValue("@CoalitieId", id);
                    command.Parameters.AddWithValue("@PartijId", partij.Id);
                   
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                con.Close();
            }
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }
        }

        public List<Models.Coalitie> RetrieveAll()
        {
            try
            {
                var partijSql = new PartijSQL();
                var partijRepo = new PartijREPO(partijSql);
                var returnList = new List<Models.Coalitie>();
                var con = new SqlConnection(env.Con);
                con.Open();
                var cmdString = "SELECT * FROM Coalitie";
                var command = new SqlCommand(cmdString, con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var coalitie  = new Models.Coalitie(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), partijRepo.PartijByCoalitie(reader.GetInt32(0)));
                    returnList.Add(coalitie);
                }
                con.Close();
                return returnList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Models.Coalitie RetrieveCoalitie(int id)
        {
            try
            {
                var partijSql = new PartijSQL();
                var partijRepo = new PartijREPO(partijSql);
                var coalitie = new Models.Coalitie();
                var con = new SqlConnection(env.Con);
                con.Open();
                var cmdString = "SELECT * FROM Coalitie WHERE Id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@Id", id);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    coalitie = new Models.Coalitie(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), partijRepo.PartijByCoalitie(reader.GetInt32(0)));
                   
                }
                con.Close();
                return coalitie;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateCoalitie(Models.Coalitie coalitie)
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
            catch (Exception )
            {
                throw;
            }
        }
    }
}
