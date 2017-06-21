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
    /// Interaction logic for PasStemmenAan.xaml
    /// </summary>
    public partial class PasStemmenAan : Window
    {
        private readonly Partij _partij;
        private readonly Uitslag _uitslag;
        public PasStemmenAan(Partij partij, Uitslag uitslag)
        {
            InitializeComponent();
            _partij = partij;
            _uitslag = uitslag;
            VulTxt();
        }


        private void VulTxt()
        {
            _partij.Partijuitslag = Partij.GetUitslagByPartijId(_partij.Id);
            txtNaam.Text = _partij.Afkorting;
            txtZetels.Text = _partij.Partijuitslag.Zetels.ToString();

        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _partij.Partijuitslag.Zetels = Convert.ToInt32(txtZetels.Text);
                var partijUitslag = new Partijuitslag(_partij.Partijuitslag.Id, _partij.Partijuitslag.Datum,
                    _partij.Partijuitslag.Stemmen, _partij.Partijuitslag.Percentage, _partij.Partijuitslag.Zetels,
                    _partij);
                Partijuitslag.UpdatePartijuitslag(partijUitslag);
                var uislagAanpassen = new UitslagAanpassen(_uitslag);
                uislagAanpassen.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Het is niet gelukt om het aantal zetels te updaten.");
            }
          
        }
    }
}
