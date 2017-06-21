using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LivePerformance.DAL.REPO;
using LivePerformance.DAL.SQL;

namespace LivePerformance.Models
{
    public class Coalitie
    {
        public int Id { get; private set; }
        public string Premier { get; private set; }
        public int Zetels { get; private set; }
        public string Naam { get; private set; }
        public List<Partij> Partijen { get; private set; }

        public Coalitie(int id, string premier, int zetels, string naam, List<Partij> partijen)
        {
            Id = id;
            Premier = premier;
            Zetels = zetels;
            Naam = naam;
            Partijen = partijen;
        }
        public Coalitie(string premier, int zetels, string naam, List<Partij> partijen)
        {
           
            Premier = premier;
            Zetels = zetels;
            Naam = naam;
            Partijen = partijen;
        }
        public Coalitie()
        {
        }

        public string BepaalPremier(List<Partij> partijen)
        {
            //var item = partijen.Max(x => x.Stemmen);
            int max = (from l in partijen select l.Stemmen).Max();
            var partij = (from premier in partijen
                where premier.Stemmen == max
                select premier).First();
            return partij.Lijsttrekker;
        }

        public int GetTotaalZetels(List<Partij> partijen)
        {
            return 0;
        }

        public static void CreateCoalitie(Models.Coalitie coalitie)
        {
            var coalitieSql = new CoalitieSQL();
            var coalitieRepo = new CoalitieREPO(coalitieSql);
            coalitieRepo.CreateCoalitie(coalitie);
        }
        public void ExportCoalitie(Coalitie coalitie)
        {
            try
            {
                string path = @"C:\Users\Luc\Google Drive\Fontys\Leerjaar 1\Semester 2\Live performance\Coalitie.txt";
                File.WriteAllText(path, String.Empty);
                using (StreamWriter sw = new StreamWriter(path))
                {
                    //foreach (var user in users)
                    //{
                    //    sw.WriteLine(user.Naam + ";" + user.Achternaam + ";" + user.Leeftijd);
                    //}
                    //// users.Clear();
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("Het wegschrijven is niet gelukt :" + e.Message);
            }
        }
    }
}
