using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePerformance.DAL.REPO;
using LivePerformance.DAL.SQL;

namespace LivePerformance.Models
{
    public class Partijuitslag
    {
        public int Id { get; private set; }
        public DateTime Datum { get; private set; }
        public int Stemmen { get; private set; }
        public decimal Percentage { get; private set; }
        public int Zetels { get;  set; }

        public Partij Partij { get;  set; }

        public Partijuitslag(int id, DateTime datum, int stemmen, decimal percentage, int zetels, Partij partij)
        {
            Id = id;
            Datum = datum;
            Stemmen = stemmen;
            Percentage = percentage;
            Zetels = zetels;
            Partij = partij;
        }
        public Partijuitslag(DateTime datum, int stemmen, decimal percentage, int zetels, Partij partij)
        {
            Datum = datum;
            Stemmen = stemmen;
            Percentage = percentage;
            Zetels = zetels;
            Partij = partij;
        }

        public Partijuitslag(int id, DateTime datum, int stemmen, decimal percentage, int zetels)
        {
            Id = id;
            Datum = datum;
            Stemmen = stemmen;
            Percentage = percentage;
            Zetels = zetels;
           
        }

        public Partijuitslag()
        {
            
        }

        public Partijuitslag(int stemmen, Partij partij)
        {
            Stemmen = stemmen;
            Partij = partij;
        }

        public int GetZetelsByStemmen(int stemmen, int totaalstemmen)
        {
            var zetels = totaalstemmen / stemmen * 150;
            zetels = Convert.ToInt32(Math.Round(Convert.ToDecimal(zetels), 0));
            return zetels;
        }

        public decimal GetPercentageByZetels(int zetels)
        {
         
            return 0;
        }

        public override string ToString()
        {
            return Stemmen.ToString();
        }

        public static void CreatePartijuitslag(Partijuitslag partijuitslag)
        {
            var partijuitslagSql = new PartijUitslagSQL();
            var partijuislagRepo = new PartijUitslagREPO(partijuitslagSql);
            partijuislagRepo.CreatePartijuitslag(partijuitslag);
        }

        public static List<Partijuitslag> PartijUitslagByUitslagId(int id)
        {
            var partijuitslagSql = new PartijUitslagSQL();
            var partijuislagRepo = new PartijUitslagREPO(partijuitslagSql);
            return partijuislagRepo.PartijUitslagByUitslagId(id);
        }

        public static void UpdatePartijuitslag(Partijuitslag partijuitslag)
        {
            var partijuitslagSql = new PartijUitslagSQL();
            var partijuislagRepo = new PartijUitslagREPO(partijuitslagSql);
            partijuislagRepo.UpdatePartijuitslag(partijuitslag);
        }

       
    }
}
