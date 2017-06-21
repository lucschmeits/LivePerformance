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
    /// Interaction logic for Partijen.xaml
    /// </summary>
    public partial class Partijen : Window
    {
        public Partijen()
        {
            InitializeComponent();
            VulList();
        }

        private void VulList()
        {
            try
            {
                foreach (var partij in Partij.RetrieveAll())
                {
                    lstPartijen.Items.Add(partij);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Het ophalen van de partijen is niet gelukt. Controleer de VPN verbinding en probeer het opnieuw.");
            }
           
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            var homeScherm = new MainWindow();
            homeScherm.Show();
            this.Hide();
        }

        private void btnNieuwePartij_Click(object sender, RoutedEventArgs e)
        {
            var nieuwePartijSherm = new NieuwePartij();
            nieuwePartijSherm.Show();
            this.Hide();
        }

        private void btnAanpassen_Click(object sender, RoutedEventArgs e)
        {
            var partij = (Partij) lstPartijen.SelectedItem;
            if (partij != null)
            {
                var partijAanpassenScherm = new PartijAanpassen(partij);
                partijAanpassenScherm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Er moet een partij geselecteerd zijn om deze aan te passen.");
            }
           
        }

        private void btnMeerderheid_Click(object sender, RoutedEventArgs e)
        {
            var partijList = new List<Partij>();
            var partijen = lstPartijen.SelectedItems;

          
            foreach (var partij in partijen)
            {
                var partijt = partij as Partij;
                partijList.Add(partijt);
            }

            var meerderheidScherm = new Meerderheid(partijList);
            meerderheidScherm.Show();
            this.Hide();
        }

        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            var partij = (Partij)lstPartijen.SelectedItem;
            if (partij != null)
            {
                try
                {
                    Partij.DeletePartij(partij.Id);
                    var partijenScherm = new Partijen();
                    partijenScherm.Show();
                    this.Hide();
                }
                catch (Exception)
                {
                    MessageBox.Show("Het is niet gelukt om de partij te verwijderen. Waarschijnlijk is deze partij gekoppeld aan een uitslag en een coalitie.");
                }
          
            }
            else
            {
                MessageBox.Show("Selecteer een partij.");
            }
        }
    }
}
