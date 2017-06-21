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
        List<Models.Coalitie> RetrieveAll();

        void CreateCoalitie(Models.Coalitie coalitie);

        Models.Coalitie RetrieveCoalitie(int id);

        void DeleteCoalitie(int id);

        void UpdateCoalitie(Models.Coalitie coalitie);

        
    }
}
