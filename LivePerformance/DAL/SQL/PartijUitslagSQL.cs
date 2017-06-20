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
    public class PartijUitslagSQL : IPartijUitslag
    {
        public void CreatePartijuitslag(Partijuitslag partijuitslag)
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

        public void DeletePartijuitslag(int id)
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

        public List<Partijuitslag> RetrieveAll()
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

        public Partijuitslag RetrievePartijuitslag(int id)
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

        public void UpdatePartijuitslag(Partijuitslag partijuitslag)
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
