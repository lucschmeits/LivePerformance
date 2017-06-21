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
    /// Interaction logic for NieuwePartij.xaml
    /// </summary>
    public partial class NieuwePartij : Window
    {
        public NieuwePartij()
        {
            InitializeComponent();
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

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            var afkorting = txtAfkorting.Text;
            var naam = txtNaam.Text;
            var lijsttrekker = txtLijsttrekker.Text;

            var partij = new Partij(afkorting, naam, lijsttrekker);
            try
            {
                Partij.CreatePartij(partij);
                var partijenScherm = new Partijen();
                partijenScherm.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Er is iets misgegaan met het toevoegen van een nieuwe partij. Controleer de VPN verbinding en probeer het opnieuw");
            }
           
        }
    }
}
