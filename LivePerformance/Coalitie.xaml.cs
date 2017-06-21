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
    /// Interaction logic for Coalitie.xaml
    /// </summary>
    public partial class Coalitie : Window
    {
        private readonly List<Partij> _partijList;
        public Coalitie(List<Partij> partijList)
        {
            InitializeComponent();
            _partijList = partijList;
            VulList();
            VulPremier();
        }

       

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            var homeScherm = new MainWindow();
            homeScherm.Show();
            this.Hide();
        }

        private void VulList()
        {
            foreach (var partij in _partijList)
            {
                lstPartij.Items.Add(partij);
            }
        }

        private void VulPremier()
        {
            var coalitie = new Models.Coalitie();
            var premier = coalitie.BepaalPremier(_partijList);
            lblPremier.Content = premier;
        }

        private void bntOpslaan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int totaal = 0;
                foreach (var partij in _partijList)
                {
                    partij.Partijuitslag = Partij.GetUitslagByPartijId(partij.Id);
                    totaal = totaal + partij.Partijuitslag.Zetels;
                }
                var coalitie = new Models.Coalitie(lblPremier.Content.ToString(), totaal, txtNaam.Text, _partijList);
                Models.Coalitie.CreateCoalitie(coalitie);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Het is niet gelukt om de coalitie op te slaan. Controleer de invoer.");
            }
           
        }
    }
}
