using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePerformance.Models;

namespace LivePerformance.DAL.INTERFACE
{
    public interface IPartijUitslag
    {
        List<Partijuitslag> RetrieveAll();

        void CreatePartijuitslag(Partijuitslag partijuitslag);

        Partijuitslag RetrievePartijuitslag(int id);

        void DeletePartijuitslag(int id);

        void UpdatePartijuitslag(Partijuitslag partijuitslag);

        List<Partijuitslag> PartijUitslagByUitslagId(int id);
    }
}
