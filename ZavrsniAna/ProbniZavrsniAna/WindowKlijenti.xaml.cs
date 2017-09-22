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
    /// Interaction logic for WindowKlijenti.xaml
    /// </summary>
    public partial class WindowKlijenti : Window
    {
        public bool valAuto=true;
        private AutomobilDal aDal = new AutomobilDal();
        private KlijentDal kDal = new KlijentDal();
        private IznajmljivanjeDal izDal = new IznajmljivanjeDal();
        private Iznajmljivanje_klijentDal iznDal = new Iznajmljivanje_klijentDal();
        private Opis_gorivaDal osDal = new Opis_gorivaDal();
        private StanjeDal sDal = new StanjeDal();
        private TipDal tDal = new TipDal();
        public decimal cenaAuta = 0;
        public decimal cenaGoriva = 0;
        public int kolicina = 0;
        public WindowKlijenti()
        {
            InitializeComponent();
            PrikaziRezervoar();
            PrikaziAutomobile();
            DatumPreuzimanja.SelectedDate = DateTime.Today;
            DatumPreuzimanja.IsEnabled = false;
            DatumVracanja.SelectedDate = DatumPreuzimanja.SelectedDate.Value.AddDays(1);
            TimeSpan ts = DatumVracanja.SelectedDate.Value - DatumPreuzimanja.SelectedDate.Value;
            kolicina = ts.Days;
         
        }

        private void PrikaziRezervoar()
        {
            comboVrstarezervoara.Items.Clear();
            List<Opis_goriva> listaOpisa = osDal.VratiOpis();
            if (listaOpisa != null)
            {
                foreach (Opis_goriva op in listaOpisa)
                {
                    comboVrstarezervoara.Items.Add(op);
                }
            }
        }
        
        public decimal IzracunajCenu()
        {
            return ((cenaAuta + cenaGoriva) * kolicina);
        }
        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(TextBoxIme.Text))
            {
                MessageBox.Show("Niste uneli ime");
                TextBoxIme.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TextBoxPrezime.Text))
            {
                MessageBox.Show("Niste uneli prezime");
                TextBoxPrezime.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TextBoxBrDozvole.Text))
            {
                MessageBox.Show("Niste uneli broj vozacke dozvole");
                TextBoxBrDozvole.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TextBoxKontakt.Text))
            {
                MessageBox.Show("Niste uneli kontakt telefon");
                return false;
            }

            if (DatumVracanja.SelectedDate.Value < DatumPreuzimanja.SelectedDate.Value)
            {
                MessageBox.Show("Neispravan unos datuma vracanja");
                DatumVracanja.SelectedDate =
                       DatumPreuzimanja.SelectedDate.Value.AddDays(1);
                return false;
            }

            if (comboAutomobili.SelectedIndex < 0)
            {
                MessageBox.Show("Izaberite automobil");
                return false;
            }
            if (comboVrstarezervoara.SelectedIndex < 0)
            {
                MessageBox.Show("Izaberite opciju rezervoara");
                return false;
            }
            if(valAuto)
            {
                if (radioZauzet.IsChecked == true)
                {
                    MessageBox.Show("Automobil je zauzet");
                    return false;
                }
            }
           
            if (!DatePickerDatumRodjenja.SelectedDate.HasValue)
            {
                MessageBox.Show("Selektujte datum rodjenja");
                return false;
            }
            if (DatePickerDatumRodjenja.SelectedDate.Value >
                DateTime.Today.AddYears(-18))
            {
                MessageBox.Show("Klijent mora biti punoletan");
                return false;
            }
            return true;
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
           
        private void PrikaziAutomobile()
        {
            
            comboAutomobili.Items.Clear();
            List<Automobil> ListAutomobila = aDal.VratiAutomobile();
            if (ListAutomobila != null)
            {
                foreach (Automobil a in ListAutomobila)
                {
                    comboAutomobili.Items.Add(a);
                }
            }  
        
        }

        private void PrikaziOpisGoriva()
        {
            comboVrstarezervoara.Items.Clear();
            List<Opis_goriva> ListOpis = osDal.VratiOpis();
            if (ListOpis != null)
            {
                foreach (Opis_goriva os in ListOpis)
                {
                    comboVrstarezervoara.Items.Add(os);
                }
            }
        }
        public int SelektujAutomobil(int id)
        {
            foreach (Automobil a in comboAutomobili.Items)
            {
                if (a.AutomobilId == id)
                    return comboAutomobili.Items.IndexOf(a);
            }
            return -1;
        }

        public int SelektujGorivo(string opis)
        {
            foreach (Opis_goriva op in comboVrstarezervoara.Items)
            {
                if (op.Opis == opis)
                    return comboVrstarezervoara.Items.IndexOf(op);
            }
           return -1;
        }
        private void comboAutomobili_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboAutomobili.SelectedIndex < 0)
            {
                return;
            }

            Automobil a = (Automobil)comboAutomobili.SelectedItem;

            TextBoxAutoId.Text = a.AutomobilId.ToString();
            TextBoxBrend.Text = a.Brend;
            TextBoxModel.Text = a.Model;
            TextBoxKapacitetsedista.Text = a.Kapacitet_sedista.ToString();
            TextBoxBoja.Text = a.Boja;
            TextBoxBrojvrata.Text = a.Broj_vrata.ToString();
            TextBoxVrstamenjaca.Text = a.Vrsta_menjaca;
            TextBoxCenapodanu.Text = Math.Round(a.Cena_po_danu, 2).ToString();
            TextBoxTipId.Text = a.TipId.ToString();
            TextBoxTipgoriva.Text = a.Tip_goriva;
            if(a.StanjeId==1)
            {
                radioSlobodan.IsChecked = true;
            }
            else
            {
                radioZauzet.IsChecked = true;
            }
            TextBoxGodinaproizvodnje.Text = a.Godina_proizvodnje.ToString();
            cenaAuta = a.Cena_po_danu;

           

            
        }

        private void comboVrstarezervoara_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboVrstarezervoara.SelectedIndex < 0)
            {
                return;
            }


            Opis_goriva op = (Opis_goriva)comboVrstarezervoara.SelectedItem;
            cenaGoriva = op.Cena_goriva;
        }

        private void DatumVracanja_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            kolicina = 0;
            TimeSpan ts = DatumVracanja.SelectedDate.Value - DatumPreuzimanja.SelectedDate.Value;
            kolicina = ts.Days;
        }

        private void ButtonPrikaziCenu_Click(object sender, RoutedEventArgs e)
        {
            TextBoxUkupnaCena.Text = Math.Round(IzracunajCenu(), 2) + "e";
        }

        private void comboboxKlijenti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxKlijenti.SelectedIndex < 0)
            {
                return;
            }

            Klijent k = (Klijent)comboboxKlijenti.SelectedItem;

            TextBoxIme.Text = k.Ime;
            TextBoxPrezime.Text = k.Prezime;
            TextBoxBrDozvole.Text = k.Br_vozacke_dozvole;
            TextBoxKontakt.Text = k.Kontakt_telefon;
            if (k.Email != null)
            {
                TextBoxEmail.Text = k.Email;
            }
            DatePickerDatumRodjenja.SelectedDate = k.Datum_rodjenja;
        }
    
    }
}
