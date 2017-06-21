using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LivePerformance.Models;

namespace LivePerformance
{
    /// <summary>
    /// Interaction logic for NieuweUitslag.xaml
    /// </summary>
    public partial class NieuweUitslag : Window
    {
        public NieuweUitslag()
        {
            InitializeComponent();
            VulListView();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            var homeScherm = new MainWindow();
            homeScherm.Show();
            this.Hide();
        }

        private void VulListView()
        {
            try
            {
                foreach (var partij in Partij.RetrieveAll())
                {
                    lstPartij.Items.Add(partij);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Het ophalen van de partijen is niet gelukt. Controleer de VPN verbinding en probeer het opnieuw.");
            }


        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var uitslag = new Uitslag(txtNaam.Text, Date.DisplayDate);
                uitslag.Partijuislagen = new List<Partijuitslag>();

                var partijen = lstPartij.SelectedItems;
                foreach (var partij in partijen)
                {
                    var partijt = partij as Partij;
                    var partijUitslag = Partij.GetUitslagByPartijId(partijt.Id);
                    uitslag.Partijuislagen.Add(partijUitslag);
                }

                Uitslag.CreateUitslag(uitslag);
                var uitslagenScherm = new Uitslagen();
                uitslagenScherm.Show();
                this.Hide();
            }
            catch (SqlException)
            {
                MessageBox.Show("De ingevoerde naam bestaat al en moet uniek zijn.");
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Het is niet gelukt om deze uitslag op te slaan. Controleer de ingevulde velden en de VPN.");
            }

}
    }
}
