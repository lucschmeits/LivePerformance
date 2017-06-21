using System;
using System.Collections.Generic;
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
    /// Interaction logic for Uitslagen.xaml
    /// </summary>
    public partial class Uitslagen : Window
    {
        public Uitslagen()
        {
            InitializeComponent();
            vulList();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            var homeScherm = new MainWindow();
            homeScherm.Show();
            this.Hide();
        }

        private void vulList()
        {
            try
            {
                foreach (var uitslag in Uitslag.RetrieveAll())
                {
                    lstUitslag.Items.Add(uitslag);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Er ging iets mis met het ophalen van de uitslagen. Controleer de VPN en probeer het nogmaals.");
            }
        }

        private void btnNieuweUitslag_Click(object sender, RoutedEventArgs e)
        {
            var nieuwUitslagScherm = new NieuweUitslag();
            nieuwUitslagScherm.Show();
            this.Hide();
        }
    }
}
