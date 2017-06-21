using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePerformance.Models;

namespace LivePerformance.DAL.INTERFACE
{
    public interface IPartij
    {
        List<Partij> RetrieveAll();

        void CreatePartij(Partij partij);

        Partij RetrievePartij(int id);

        void DeletePartij(int id);

        void UpdatePartij(Partij partij);

        List<Partijuitslag> GetUitslagByPartij(int id);

        List<Partij> PartijByCoalitie(int id);
    }
}
