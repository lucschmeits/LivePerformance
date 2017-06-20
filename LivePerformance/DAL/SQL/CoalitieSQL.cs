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
                con.Close();
            }
            catch (Exception e)
            {

            }
        }

        public void DeleteCoalitie(int id)
        {
            try
            {
                var con = new SqlConnection(env.Con);
                con.Open();
                con.Close();
            }
            catch (Exception e)
            {

            }
        }

        public List<Coalitie> RetrieveAll()
        {
            try
            {
                var con = new SqlConnection(env.Con);
                con.Open();
                con.Close();
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Coalitie RetrieveCoalitie(int id)
        {
            try
            {
                var con = new SqlConnection(env.Con);
                con.Open();
                con.Close();
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void UpdateCoalitie(Coalitie coalitie)
        {
            try
            {
                var con = new SqlConnection(env.Con);
                con.Open();
                con.Close();
            }
            catch (Exception e)
            {

            }
        }
    }
}
