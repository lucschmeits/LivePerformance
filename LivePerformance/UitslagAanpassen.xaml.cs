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
    /// Interaction logic for UitslagAanpassen.xaml
    /// </summary>
    public partial class UitslagAanpassen : Window
    {
        private readonly Uitslag _uitslag;
        public UitslagAanpassen(Uitslag uitslag)
        {
            InitializeComponent();
            _uitslag = uitslag;
            VulTxt();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            var homeScherm = new MainWindow();
            homeScherm.Show();
            this.Hide();
        }

        private void VulTxt()
        {
            try
            {
                txtNaam.Text = _uitslag.Naam;
                datePick.Text = _uitslag.Datum.ToString();
                _uitslag.Partijuislagen = Partijuitslag.PartijUitslagByUitslagId(_uitslag.Id);
                foreach (var uitslag in _uitslag.Partijuislagen)
                {
                    uitslag.Partij = Partij.GetPartijByUitslagId(uitslag.Id);
                    lstPartij.Items.Add(uitslag.Partij);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Er kunnen geen partijen worden opgehaald.");
            }
         
        }

        private void btnAanpassen_Click(object sender, RoutedEventArgs e)
        {
            var partij = (Partij) lstPartij.SelectedItem;
            if (partij != null)
            {
                var zetelsAanpassen = new PasStemmenAan(partij, _uitslag);
                zetelsAanpassen.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Selecteer een partij.");
            }
        }
    }
}
