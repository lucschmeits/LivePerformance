using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePerformance.DAL.REPO;
using LivePerformance.DAL.SQL;

namespace LivePerformance.Models
{
    public class Partij
    {
        public int Id { get; private set; }
        public string Afkorting { get; private set; }
        public string Naam { get; private set; }
        public string Lijsttrekker { get; private set; }

        public int Stemmen { get;  set; }

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

        public static List<Partij> RetrieveAll()
        {
            var partijSql = new PartijSQL();
            var partijRepo = new PartijREPO(partijSql);

            return partijRepo.RetrieveAll();
        }

        public static void CreatePartij(Partij partij)
        {
            var partijSql = new PartijSQL();
            var partijRepo = new PartijREPO(partijSql);
            partijRepo.CreatePartij(partij);
        }
    }
}
