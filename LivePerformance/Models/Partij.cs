using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance.Models
{
    public class Partij
    {
        public int Id { get;  set; }
        public string Afkorting { get;  set; }
        public string Naam { get;  set; }
        public string Lijsttrekker { get;  set; }

        public Partij(string afkorting, string naam, string lijsttrekker)
        {
            Afkorting = afkorting;
            Naam = naam;
            Lijsttrekker = lijsttrekker;

        }

        public Partij(int id, string afkorting, string naam, string lijsttrekker)
        {
            Id = id;
            Afkorting = afkorting;
            Naam = naam;
            Lijsttrekker = lijsttrekker;
        }

        public Partij()
        {
        }
    }
}
