using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePerformance.DAL.INTERFACE;
using LivePerformance.Models;

namespace LivePerformance.DAL.REPO
{
    public class UitslagREPO
    {
        private IUitslag _iUitslag;

        public UitslagREPO(IUitslag iUitslag)
        {
            _iUitslag = iUitslag;
        }

        public List<Uitslag> RetrieveAll()
        {
            return _iUitslag.RetrieveAll();
        }

        public void CreateUitslag(Uitslag uitslag)
        {
            _iUitslag.CreateUitslag(uitslag);
        }

        public Uitslag RetrieveUitslag(int id)
        {
            return _iUitslag.RetrieveUitslag(id);
        }

        public void DeleteUitslag(int id)
        {
            _iUitslag.DeleteUitslag(id);
        }

        public void UpdateUitslag(Uitslag uitslag)
        {
            _iUitslag.UpdateUitslag(uitslag);
        }

        public Uitslag RetrieveUitslagByDate(DateTime datum)
        {
            return _iUitslag.RetrieveUitslagByDate(datum);
        }
    }
}
