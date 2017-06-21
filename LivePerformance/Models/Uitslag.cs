using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance.Models
{
    public class Uitslag
    {
        public int Id { get; private set; }
        public string Naam { get; private set; }
        public DateTime Datum { get; private set; }
        public List<Partijuitslag> Partijuislagen { get; private set; }

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

        public Uitslag()
        {
        }
    }
}
