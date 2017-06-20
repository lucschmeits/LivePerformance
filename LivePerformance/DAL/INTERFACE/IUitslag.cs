using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePerformance.Models;

namespace LivePerformance.DAL.INTERFACE
{
    public interface IUitslag
    {
        List<Uitslag> RetrieveAll();

        void CreateUitslag(Uitslag uitslag);

        Uitslag RetrieveUitslag(int id);

        void DeleteUitslag(int id);

        void UpdateUitslag(Uitslag uitslag);

        Uitslag RetrieveUitslagByDate(DateTime datum);
    }
}
