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
                con.Close();
            }
            catch (Exception e)
            {

            }
        }

        public void DeleteUitslag(int id)
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

        public List<Uitslag> RetrieveAll()
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

        public Uitslag RetrieveUitslag(int id)
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

        public Uitslag RetrieveUitslagByDate(DateTime datum)
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

        public void UpdateUitslag(Uitslag uitslag)
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
