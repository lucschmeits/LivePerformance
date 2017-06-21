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
    /// Interaction logic for PartijUitslag.xaml
    /// </summary>
    public partial class PartijUitslag : Window
    {
        private readonly Partij _partij;
        public PartijUitslag(Partij partij)
        {
            InitializeComponent();
            _partij = partij;
            VulTxt();
        }

        public PartijUitslag()
        {
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            var homeScherm = new MainWindow();
            homeScherm.Show();
            this.Hide();
        }

        private void VulTxt()
        {
            txtPartij.Text = _partij.Afkorting;
            
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                var stemmen = Convert.ToInt32(txtStemmen.Text);
                var partijUitslag = new Partijuitslag(stemmen, _partij);
                Partijuitslag.CreatePartijuitslag(partijUitslag);
            }
            catch (FormatException)
            {
                MessageBox.Show("Er dient een cijfer ingegeven te worden in het veld stemmen.");
            }
            catch (Exception)
            {
                MessageBox.Show("Er ging iets mis met het opslaan van de partijuitslag. Controleer de VPN en probeer het nogmaals.");
            }
           
           

        }
    }
}
