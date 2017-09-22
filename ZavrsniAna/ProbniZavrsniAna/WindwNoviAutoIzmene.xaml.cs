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

namespace ProbniZavrsniAna
{
    /// <summary>
    /// Interaction logic for WindwNoviAutoIzmene.xaml
    /// </summary>
    public partial class WindwNoviAutoIzmene : Window
    {
        private TipDal tDal = new TipDal();
        private Automobil auto = new Automobil();

        internal Automobil Auto
        {
            get
            {
                if (comboBoxTip.SelectedIndex > -1)
                {
                    Tip t = (Tip)comboBoxTip.SelectedItem;
                    auto.TipId = t.TipId;
                }
                auto.Brend = TextBoxBrend.Text;
                auto.Model = TextBoxModel.Text;
                auto.Godina_proizvodnje = int.Parse(TextBoxGodinaproizvodnje.Text);
                auto.Boja = TextBoxBoja.Text;
                auto.Cena_po_danu = decimal.Parse(TextBoxCenapodanu.Text);
                auto.StanjeId = 1;
                auto.Kapacitet_sedista = int.Parse(TextBoxKapacitetsedista.Text);
                auto.Broj_vrata = int.Parse(TextBoxBrojvrata.Text);
                auto.Vrsta_menjaca = TextBoxVrstamenjaca.Text;
                auto.Tip_goriva = textboxTipGoriva.Text;
                return auto;
            }
            set
            {
                auto = value;
                TextBoxBrend.Text = auto.Brend;
                TextBoxModel.Text = auto.Model;
                TextBoxGodinaproizvodnje.Text = auto.Godina_proizvodnje.ToString();
                TextBoxBoja.Text = auto.Boja;
                TextBoxCenapodanu.Text = auto.Cena_po_danu.ToString();
                TextBoxKapacitetsedista.Text = auto.Kapacitet_sedista.ToString();
                TextBoxBrojvrata.Text = auto.Broj_vrata.ToString();
                TextBoxVrstamenjaca.Text = auto.Vrsta_menjaca;
                if(auto.StanjeId==1)
                {
                    RadioSlobodan.IsChecked = true;
                }
                else
                {
                    radioZauzet.IsChecked = true;
                }
                comboBoxTip.SelectedIndex = SelectujTIp(auto.TipId);
                textboxTipGoriva.Text = auto.Tip_goriva;
            }
        }

        private void PrikaziTip()
        {
            comboBoxTip.Items.Clear();
            List<Tip> listaTip = tDal.VratiTipove();
            if (listaTip != null)
            {
                foreach (Tip t1 in listaTip)
                {
                    comboBoxTip.Items.Add(t1);
                }
            }
        }
        private int SelectujTIp(int id)
        {
            foreach (Tip t in comboBoxTip.Items)
            {
                if(t.TipId==id)
                {
                    return comboBoxTip.Items.IndexOf(t);
                }
            }
            return -1;
        }
        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(TextBoxBrend.Text))
            {
                MessageBox.Show("Niste uneli brend");
                TextBoxBrend.Focus();
                return false;
            }
            int godinaProizvodnje;
            if (!int.TryParse(TextBoxGodinaproizvodnje.Text,out godinaProizvodnje))
            {
                MessageBox.Show("Godina proizvodnje mora biti ceo broj");
                TextBoxGodinaproizvodnje.Clear();
                TextBoxGodinaproizvodnje.Focus();
                return false;
            }
            int brojVrata;
            if (!int.TryParse(TextBoxBrojvrata.Text,out brojVrata))
            {
                MessageBox.Show("Unesite broj vrata");
                TextBoxBrojvrata.Clear();
                TextBoxBrojvrata.Focus();
                return false;
            }
            decimal cenaPoDanu;
            if (!decimal.TryParse(TextBoxCenapodanu.Text,out cenaPoDanu))
            {
                MessageBox.Show("Neispravan unos cene");
                TextBoxCenapodanu.Clear();
                TextBoxCenapodanu.Focus();
                return false;
            }
            int kapacitetSedista;
            if (!int.TryParse(TextBoxKapacitetsedista.Text,out kapacitetSedista))
            {
                MessageBox.Show("Unesite kapacitet sedista");
                TextBoxKapacitetsedista.Clear();
                TextBoxKapacitetsedista.Focus();
                return false;
            }
            if(string.IsNullOrWhiteSpace(TextBoxVrstamenjaca.Text))
            {
                MessageBox.Show("Unesite vrstu menjaca");
                TextBoxVrstamenjaca.Focus();
                return false;
            }
            if(string.IsNullOrWhiteSpace(TextBoxBoja.Text))
            {
                MessageBox.Show("Unesite boju");
                TextBoxBoja.Focus();
                return false;
            }
            if(string.IsNullOrWhiteSpace(TextBoxModel.Text))
            {
                MessageBox.Show("Unesite model");
                TextBoxModel.Focus();
                return false;
            }
            if(comboBoxTip.SelectedIndex<0)
            {
                MessageBox.Show("Selektujte tip");
                return false;
            }
            if(string.IsNullOrWhiteSpace(textboxTipGoriva.Text))
            {
                MessageBox.Show("Unesite tip goriva");
                textboxTipGoriva.Focus();
                return false;
            }
          
            return true;
        }
        public WindwNoviAutoIzmene()
        {
            InitializeComponent();
            PrikaziTip();
            RadioSlobodan.IsChecked = true;
            radioZauzet.IsEnabled = false;
        }

        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
            if(!Validacija())
            {
                return;
            }
            DialogResult = true;
        }

        private void ButtonOdustani_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

      
    }
}
