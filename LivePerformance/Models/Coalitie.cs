using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance.Models
{
    public class Coalitie
    {
        public int Id { get; private set; }
        public string Premier { get; private set; }
        public int Zetels { get; private set; }
        public List<Partij> Partijen { get; private set; }

        public Coalitie(int id, string premier, int zetels, List<Partij> partijen)
        {
            Id = id;
            Premier = premier;
            Zetels = zetels;
            Partijen = partijen;
        }
        public Coalitie(string premier, int zetels, List<Partij> partijen)
        {
           
            Premier = premier;
            Zetels = zetels;
            Partijen = partijen;
        }

        public string BepaalPremier(List<Partij> partijen)
        {
            return Premier;
        }

        public int GetTotaalZetels(List<Partij> partijen)
        {
            return 0;
        }

        public void ExportCoalitie(Coalitie coalitie)
        {
            
        }
    }
}
