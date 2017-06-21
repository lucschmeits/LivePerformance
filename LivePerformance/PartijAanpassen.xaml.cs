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
    /// Interaction logic for PartijAanpassen.xaml
    /// </summary>
    public partial class PartijAanpassen : Window
    {
        private readonly Partij _partij;
        public PartijAanpassen(Partij partij)
        {
            InitializeComponent();
            _partij = partij;
            VulGegevens();
        }

        private void VulGegevens()
        {
            txtAfkorting.Text = _partij.Afkorting;
            txtNaam.Text = _partij.Naam;
            txtLijsttrekker.Text = _partij.Lijsttrekker;
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var partij = new Partij(_partij.Id, txtAfkorting.Text, txtNaam.Text, txtLijsttrekker.Text);
                Partij.UpdatePartij(partij);
                var partijenScherm = new Partijen();
                partijenScherm.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Het aanpassen van de partij is niet gelukt. Controleer de VPN verbinding en probeer het opnieuw.");
            }
            
        }

        private void btnPartijen_Click(object sender, RoutedEventArgs e)
        {
            var partijenScherm = new Partijen();
            partijenScherm.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            var homeScherm = new MainWindow();
            homeScherm.Show();
            this.Hide();
        }
    }
}
