using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePerformance.Models;

namespace LivePerformance.DAL.INTERFACE
{
    public interface ICoalitie
    {
        List<Coalitie> RetrieveAll();

        void CreateCoalitie(Coalitie coalitie);

        Coalitie RetrieveCoalitie(int id);

        void DeleteCoalitie(int id);

        void UpdateCoalitie(Coalitie coalitie);

        
    }
}
