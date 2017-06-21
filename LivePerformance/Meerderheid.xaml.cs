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
    /// Interaction logic for Meerderheid.xaml
    /// </summary>
    public partial class Meerderheid : Window
    {
        private readonly List<Partij> _partijList;
        public Meerderheid(List<Partij> partijList)
        {
            InitializeComponent();
            _partijList = partijList;
            VulList();
            VulZetelLabel();
            SetColor();
        }

        private void VulList()
        {
            foreach (var partij in _partijList)
            {
                partij.Partijuitslag = Partij.GetUitslagByPartijId(partij.Id);
               
                lstPartij.Items.Add(partij);
                
            }
        }

        private void VulZetelLabel()
        {
            int totaal = 0;
            foreach (var partij in _partijList)
            {
                partij.Partijuitslag = Partij.GetUitslagByPartijId(partij.Id);
                totaal = totaal + partij.Partijuitslag.Zetels;
            }
            
            lblZetels.Content = totaal.ToString();
        }

        private void btnCoalitie_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(lblZetels.Content) > 75)
            {
                var coalitieScherm = new Coalitie(_partijList);
                coalitieScherm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Het totale zetelaantal moet boven de 75 uitkomen.");
            }
            
        }

        private void SetColor()
        {
            var brush = new SolidColorBrush(Colors.Green);
            if (Convert.ToInt32(lblZetels.Content) > 75)
            {
                lblZetels.Background = brush;
            }
            else
            {
                lblZetels.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            var homeScherm = new MainWindow();
            homeScherm.Show();
            this.Hide();
        }
    }
}
