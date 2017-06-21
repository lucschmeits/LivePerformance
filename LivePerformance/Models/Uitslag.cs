using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePerformance.DAL.REPO;
using LivePerformance.DAL.SQL;

namespace LivePerformance.Models
{
    public class Uitslag
    {
        public int Id { get; private set; }
        public string Naam { get; private set; }
        public DateTime Datum { get; private set; }
        public List<Partijuitslag> Partijuislagen { get;  set; }

        public Uitslag(int id, string naam, DateTime datum, List<Partijuitslag> partijuislagen)
        {
            Id = id;
            Naam = naam;
            Datum = datum;
            Partijuislagen = partijuislagen;
        }
        public Uitslag(string naam, DateTime datum, List<Partijuitslag> partijuislagen)
        {
            Naam = naam;
            Datum = datum;
            Partijuislagen = partijuislagen;
        }
        public Uitslag(string naam, DateTime datum)
        {
            Naam = naam;
            Datum = datum;
            
        }
        public Uitslag(int id, string naam, DateTime datum)
        {
            Id = id;
            Naam = naam;
            Datum = datum;

        }
        public Uitslag()
        {
        }

        public static List<Uitslag> RetrieveAll()
        {
            var uislagSql = new UitslagSQL();
            var uitslagRepo = new UitslagREPO(uislagSql);

            return uitslagRepo.RetrieveAll();
        }

        public static void CreateUitslag(Uitslag uitslag)
        {
            var uislagSql = new UitslagSQL();
            var uitslagRepo = new UitslagREPO(uislagSql);
            uitslagRepo.CreateUitslag(uitslag);
        }

        public static void DeleteUitslag(int id)
        {
            var uislagSql = new UitslagSQL();
            var uitslagRepo = new UitslagREPO(uislagSql);
            uitslagRepo.DeleteUitslag(id);
        }

        public static Uitslag RetrieveUitslag(int id)
        {
            var uislagSql = new UitslagSQL();
            var uitslagRepo = new UitslagREPO(uislagSql);
            return uitslagRepo.RetrieveUitslag(id);
        }
    }
}
