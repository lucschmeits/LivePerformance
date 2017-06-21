using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance.Models
{
    public class Partijuitslag
    {
        public int Id { get; private set; }
        public DateTime Datum { get; private set; }
        public int Stemmen { get; private set; }
        public decimal Percentage { get; private set; }
        public int Zetels { get; private set; }

        public Partij Partij { get; private set; }

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

        public Partijuitslag()
        {
            
        }

        public int GetZetelsByStemmen(int stemmen)
        {
            return 0;
        }

        public decimal GetPercentageByZetels(int zetels)
        {
            return 0;
        }

        public override string ToString()
        {
            return Stemmen.ToString();
        }
    }
}
