using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePerformance.DAL.INTERFACE;
using LivePerformance.Models;

namespace LivePerformance.DAL.REPO
{
    public class PartijUitslagREPO
    {
        private IPartijUitslag _iPartijUitslag;

        public PartijUitslagREPO(IPartijUitslag iPartijUitslag)
        {
            _iPartijUitslag = iPartijUitslag;
        }

        public List<Partijuitslag> RetrieveAll()
        {
            return _iPartijUitslag.RetrieveAll();
        }

        public void CreatePartijuitslag(Partijuitslag partijuitslag)
        {
            _iPartijUitslag.CreatePartijuitslag(partijuitslag);
        }

        public Partijuitslag RetrievePartijuitslag(int id)
        {
            return _iPartijUitslag.RetrievePartijuitslag(id);
        }

        public void DeletePartijuitslag(int id)
        {
            _iPartijUitslag.DeletePartijuitslag(id);
        }

        public void UpdatePartijuitslag(Partijuitslag partijuitslag)
        {
            _iPartijUitslag.UpdatePartijuitslag(partijuitslag);
        }

        public List<Partijuitslag> PartijUitslagByUitslagId(int id)
        {
            return _iPartijUitslag.PartijUitslagByUitslagId(id);
        }
    }
}
