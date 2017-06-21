using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePerformance.DAL.INTERFACE;

namespace LivePerformance.DAL.REPO
{
    public class CoalitieREPO
    {
        private ICoalitie _iCoalitie;

        public CoalitieREPO(ICoalitie iCoalitie)
        {
            _iCoalitie = iCoalitie;
        }
        public List<Models.Coalitie> RetrieveAll()
        {
            return _iCoalitie.RetrieveAll();
        }

        public void CreateCoalitie(Models.Coalitie coalitie)
        {
            _iCoalitie.CreateCoalitie(coalitie);
        }

        public Models.Coalitie RetrieveCoalitie(int id)
        {
           return _iCoalitie.RetrieveCoalitie(id);
        }

        public void DeleteCoalitie(int id)
        {
            _iCoalitie.DeleteCoalitie(id);
        }

        public void UpdateCoalitie(Models.Coalitie coalitie)
        {
            _iCoalitie.UpdateCoalitie(coalitie);
        }
    }

    
}
