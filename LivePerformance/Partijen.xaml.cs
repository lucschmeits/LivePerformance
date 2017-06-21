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
            catch (Exception ex)
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
    }
}
