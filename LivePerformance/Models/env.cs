using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance.Models
{
    public class env
    {
        public readonly SqlConnection Con = new SqlConnection("Data Source=desktop-luc;Initial Catalog=liveperformance;User ID=liveperformance;Password=Test1234;Encrypt=False;TrustServerCertificate=True");
    }
}
