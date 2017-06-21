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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LivePerformance.Models;

namespace LivePerformance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            VulListView();
        }

        private void VulListView()
        {
            try
            {
                foreach (var partij in Partij.RetrieveAll())
                {
                    ListPartij.Items.Add(partij);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Het ophalen van de partijen is niet gelukt. Controleer de VPN verbinding en probeer het opnieuw.");
            }
           
            
        }

        private void btnPartij_Click(object sender, RoutedEventArgs e)
        {
            var partijenScherm = new Partijen();
            partijenScherm.Show();
            this.Hide();
        }

        private void btnUitslagen_Click(object sender, RoutedEventArgs e)
        {
            var uitslagenScherm = new Uitslagen();
            uitslagenScherm.Show();
            this.Hide();
        }

        private void btnPartijUitslag_Click(object sender, RoutedEventArgs e)
        {
            var partij = (Partij) ListPartij.SelectedItem;
            if (partij != null)
            {
                var partijUitslag = new PartijUitslag(partij);
                partijUitslag.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Er moet een partij geselecteerd zijn om de uitslag in te voeren.");
            }
        }
    }
}
