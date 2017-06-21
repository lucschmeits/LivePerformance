using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePerformance.DAL.INTERFACE;
using LivePerformance.Models;

namespace LivePerformance.DAL.REPO
{
    public class PartijREPO
    {
        private IPartij _iPartij;

        public PartijREPO(IPartij iPartij)
        {
            _iPartij = iPartij;
        }
        public List<Partij> RetrieveAll()
        {
            return _iPartij.RetrieveAll();
        }

        public void CreatePartij(Partij partij)
        {
            _iPartij.CreatePartij(partij);
        }

        public Partij RetrievePartij(int id)
        {
            return _iPartij.RetrievePartij(id);
        }

        public void DeletePartij(int id)
        {
            _iPartij.DeletePartij(id);
        }

        public void UpdatePartij(Partij partij)
        {
            _iPartij.UpdatePartij(partij);
        }

        public List<Partijuitslag> GetUitslagByPartij(int id)
        {
            return _iPartij.GetUitslagByPartij(id);
        }

        public List<Partij> PartijByCoalitie(int id)
        {
            return _iPartij.PartijByCoalitie(id);
        }

        public Partijuitslag GetUitslagByPartijId(int id)
        {
            return _iPartij.GetUitslagByPartijId(id);
        }

        public Partij GetPartijByUitslagId(int id)
        {
            return _iPartij.GetPartijByUitslagId(id);
        }
    }
}
