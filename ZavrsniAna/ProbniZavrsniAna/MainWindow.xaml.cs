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

namespace ProbniZavrsniAna
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private TipDal tDal = new TipDal();
        private AutomobilDal aDal = new AutomobilDal();
        private KlijentDal kDal = new KlijentDal();
        private IznajmljivanjeDal izDal = new IznajmljivanjeDal();
        private Iznajmljivanje_klijentDal iznDal = new Iznajmljivanje_klijentDal();
        private StanjeDal sDal = new StanjeDal();
      
        private Opis_gorivaDal osDal = new Opis_gorivaDal();

        private void Resetuj(bool rez)
        {
            TextBoxAutomobilId.Clear();
            TextBoxTipId.Clear();
            TextBoxTipGoriva.Clear();
            TextBoxBrend.Clear();
            TextBoxModel.Clear();
            TextBoxGodProizvodnje.Clear();
            TextBoxBoja.Clear();
            TextBoxKapacitet.Clear();
            TextBoxBrVrata.Clear();
            TextBoxVrstaMenjaca.Clear();
            TextBoxRezervacijaId.Clear();
            DateDatumIznajmljivanja.SelectedDate = DateTime.Today;
            DateDatumVracanja.SelectedDate = DateDatumIznajmljivanja.SelectedDate.Value.AddDays(1);
            TextBoxCenaAuta.Clear();
            TextBoxCenaRezervoara.Clear();
            TextBoxUkupnaCena.Clear();
            TextBoxOpis.Clear();

            if(rez)
            {
                TextBoxImeKlijenta.Clear();
                comboKlijenti.SelectedIndex = -1;
                TextBoxImePrezime.Clear();
                TextBoxDatum_rodjenja.Clear();
                TextBoxEmail.Clear();
                TextBoxBroj_telefona.Clear();
                TextBoxBr_vozacke_dozvole.Clear();
                TextBoxId.Clear();
            }
            
        }
        private void DodajIznajmjivanje()
        {
            WindowKlijenti wk = new WindowKlijenti();
            wk.Title = "Dodaj iznajmljivanje";
            if (wk.ShowDialog() == true)
            {
                Klijent k = new Klijent();
                k.Ime = wk.TextBoxIme.Text;
                k.Prezime = wk.TextBoxPrezime.Text;
                k.Datum_rodjenja = wk.DatePickerDatumRodjenja.SelectedDate.Value;
                k.Br_vozacke_dozvole = wk.TextBoxBrDozvole.Text;
                k.Kontakt_telefon = wk.TextBoxKontakt.Text;
                if (!string.IsNullOrWhiteSpace(wk.TextBoxEmail.Text))
                    k.Email = wk.TextBoxEmail.Text;

                int klijentId = kDal.DodajKlijenta(k);
                if (klijentId == -1)
                {
                    MessageBox.Show("Greska");
                    return;
                }

                Iznajmljivanje i = new Iznajmljivanje();
                if (wk.comboAutomobili.SelectedIndex <0)
                    return;
                    Automobil a = (Automobil)wk.comboAutomobili.SelectedItem;
                    i.AutomobilId = a.AutomobilId;
                

                i.Datum_preuzimanja = wk.DatumPreuzimanja.SelectedDate.Value;
                i.Datum_vracanja = wk.DatumVracanja.SelectedDate.Value;
                i.Ukupna_cena = wk.IzracunajCenu();
                if (wk.comboVrstarezervoara.SelectedIndex > -1)
                {
                    Opis_goriva op = (Opis_goriva)wk.comboVrstarezervoara.SelectedItem;
                    i.OpisId = op.OpisId;
                }

                int rezultatUpita = izDal.DodajIznajmljivanje(i, klijentId);
                if (rezultatUpita > -1)
                {
                    MessageBox.Show("Iznajmljivanje uspesno dodato");
                    aDal.PromeniStanje(a.AutomobilId, 2);
                    Resetuj(true);
                }
                else
                {
                    MessageBox.Show("Greska");
                }
                
            }
       
        }
        private void NapuniListbox(List<Iznajmljivanje> lista)
        {
            ListBoxSvaIzn.Items.Clear();
            foreach (Iznajmljivanje i in lista)
            {
                ListBoxSvaIzn.Items.Add(i);
            }
        }
        private void NapuniCombo(List<Klijent> lista)
        {
            comboKlijenti.Items.Clear();
            foreach (Klijent k in lista)
            {
                comboKlijenti.Items.Add(k);
            }
        }
        private void PretraziKlijentaPoImenu(string ime)
        {
            
                List<Klijent> listaK = kDal.PretraziKlijenta(TextBoxImeKlijenta.Text);
                if (listaK == null)
                {
                  
                    return;
                }

                if (listaK.Count == 1)
                {
                    Klijent k = listaK[0];

                    NapuniCombo(listaK);
                 
                    comboKlijenti.SelectedIndex = 0;

                }
                 else if(listaK.Count>1)
                {
                    
                    NapuniCombo(listaK);
                }

            
        }
        public MainWindow()
        {
            InitializeComponent();
           
        }
  
        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            WindowNoviAutomobili wn = new WindowNoviAutomobili();
            wn.ShowDialog();
        }

        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
              DodajIznajmjivanje();
        }      
        private void ListBoxSvaIzn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxSvaIzn.SelectedIndex < 0)
            {
                return;
            }

            Iznajmljivanje iz = (Iznajmljivanje)ListBoxSvaIzn.SelectedItem;

            Automobil a = aDal.PronadjiAutomobil(iz.AutomobilId);
            if (a != null)
            {
                TextBoxAutomobilId.Text = a.AutomobilId.ToString();
                TextBoxBoja.Text = a.Boja;
                TextBoxBrend.Text = a.Brend;
                TextBoxBrVrata.Text = a.Broj_vrata.ToString();
                TextBoxModel.Text = a.Model;
                TextBoxGodProizvodnje.Text = a.Godina_proizvodnje.ToString();
                TextBoxKapacitet.Text = a.Kapacitet_sedista.ToString();
                TextBoxVrstaMenjaca.Text = a.Vrsta_menjaca;
                TextBoxTipId.Text = a.TipId.ToString();
                TextBoxTipGoriva.Text = a.Tip_goriva;
                Opis_goriva o = osDal.PronadjiGorivo(iz.OpisId);
                if (o != null)
                {
                    TextBoxOpis.Text = o.Opis;

                    TextBoxRezervacijaId.Text = iz.IznajmljivanjeId.ToString();
                    DateDatumIznajmljivanja.SelectedDate = iz.Datum_preuzimanja;
                    DateDatumVracanja.SelectedDate = iz.Datum_vracanja;
                    TextBoxCenaAuta.Text = a.Cena_po_danu.ToString();
                    TextBoxCenaRezervoara.Text = o.Cena_goriva.ToString();

                    TimeSpan ts = iz.Datum_vracanja - iz.Datum_preuzimanja;
                    TextBoxUkupnaCena.Text = ((a.Cena_po_danu + o.Cena_goriva) * ts.Days).ToString();

                }
            }
        }

        private void ButtonPretraga_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxImeKlijenta.Text))
            {
                MessageBox.Show("Unesite ime");
                return;
            }
            string ime = TextBoxImeKlijenta.Text.Substring(0, 1).ToUpper() + TextBoxImeKlijenta.Text.Substring(1).ToLower();
            PretraziKlijentaPoImenu(ime);
            TextBoxImeKlijenta.Clear();
               
        }

        private void ButtonAzuriraj_Click(object sender, RoutedEventArgs e)
        {
            if(ListBoxSvaIzn.SelectedIndex<0)
            {
                MessageBox.Show("Selektujte iznajmljivanje");
                return;
            }

            Iznajmljivanje i = (Iznajmljivanje)ListBoxSvaIzn.SelectedItem;
            WindowKlijenti wk = new WindowKlijenti();
            wk.Title = "Azuriranje";
            if (comboKlijenti.SelectedIndex < 0)
                return;

                wk.comboboxKlijenti.Items.Clear();
                Klijent k = (Klijent)comboKlijenti.SelectedItem;
                wk.comboboxKlijenti.Items.Add(k);
                wk.comboboxKlijenti.SelectedIndex = 0;
            wk.valAuto = false;
            wk.DatumPreuzimanja.SelectedDate = i.Datum_preuzimanja;
            wk.DatumVracanja.SelectedDate = i.Datum_vracanja;
            wk.comboAutomobili.SelectedIndex = wk.SelektujAutomobil(int.Parse(TextBoxAutomobilId.Text));
            wk.comboVrstarezervoara.SelectedIndex = wk.SelektujGorivo(TextBoxOpis.Text);
            wk.TextBoxUkupnaCena.Text = Math.Round(i.Ukupna_cena, 2) + "e";
            if(wk.ShowDialog()==true)
            {
                k.Ime = wk.TextBoxIme.Text;
                k.Prezime = wk.TextBoxPrezime.Text;
                k.Datum_rodjenja = wk.DatePickerDatumRodjenja.SelectedDate.Value;
                k.Br_vozacke_dozvole = wk.TextBoxBrDozvole.Text;
                k.Kontakt_telefon = wk.TextBoxKontakt.Text;
                if (!string.IsNullOrWhiteSpace(wk.TextBoxEmail.Text))
                    k.Email = TextBoxEmail.Text;
           
                if (wk.comboAutomobili.SelectedIndex > -1)
                {
                    Automobil a = (Automobil)wk.comboAutomobili.SelectedItem;
                    i.AutomobilId = a.AutomobilId;
                }

                i.Datum_preuzimanja = wk.DatumPreuzimanja.SelectedDate.Value;
                i.Datum_vracanja = wk.DatumVracanja.SelectedDate.Value;
                i.Ukupna_cena = wk.IzracunajCenu();
                if (wk.comboVrstarezervoara.SelectedIndex > -1)
                {
                    Opis_goriva op = (Opis_goriva)wk.comboVrstarezervoara.SelectedItem;
                    i.OpisId = op.OpisId;
                }

                int rezKlijent = kDal.PromeniKlijenta(k);
                if(rezKlijent>-1)
                {
                    MessageBox.Show("KLijent promenjen");
                }
                else
                {
                    MessageBox.Show("greska");
                }
              
                int rezIzn = izDal.PromeniIznajmljivanje(i);
                if(rezIzn>-1)
                {
                    MessageBox.Show("Iznajmljivanje promenjeno");
                    Resetuj(true);
                }
                else
                {
                    MessageBox.Show("greska");
                }

            }
            else
            {
                MessageBox.Show("Odustali ste od promene");
            }
           

        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            WindowBrisanje BrisanjeKlijenta = new WindowBrisanje();
            BrisanjeKlijenta.Title = "Obrisi klijenta";
            if (BrisanjeKlijenta.ShowDialog() == true)
            {
                Klijent k =(Klijent) BrisanjeKlijenta.comboboxKlijenti.SelectedItem;
                if(kDal.IzbrisiKlijenta(k.KlijentId)>-1)
                {
                    MessageBox.Show("Klijent uspesno izbrisan");
                    Resetuj(true);
                }
                else
                {
                    MessageBox.Show("Greksa");
                }
            }
            else
            {
                MessageBox.Show("Pritisnuli ste dugme odustani");
            }

        }

        private void comboKlijenti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboKlijenti.SelectedIndex < 0)
                return;
            Resetuj(false);
            Klijent k = (Klijent)comboKlijenti.SelectedItem;
            TextBoxImePrezime.Text = k.Ime + " " + k.Prezime;
            TextBoxId.Text = k.KlijentId.ToString();
            TextBoxDatum_rodjenja.Text = k.Datum_rodjenja.ToLongDateString();
            if (k.Email != null)
                TextBoxEmail.Text = k.Email;
            TextBoxBr_vozacke_dozvole.Text = k.Br_vozacke_dozvole;
            TextBoxBroj_telefona.Text = k.Kontakt_telefon;
      
            List<Iznajmljivanje> listaIznajmljivanja = izDal.PretraziIznajmljivanje(k.KlijentId);
            if (listaIznajmljivanja == null)
            {
                MessageBox.Show($"Klijent {k.Ime} {k.Prezime} nema iznajmljen auto");
                return;
            }
            NapuniListbox(listaIznajmljivanja);
        }

        private void buttonObrisiIznajmljivanje_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxSvaIzn.SelectedIndex < 0)
            {
                MessageBox.Show("Selektujte iznajmljivanje");
                return;
            }

            Iznajmljivanje i = (Iznajmljivanje)ListBoxSvaIzn.SelectedItem;
            MessageBoxResult rez = MessageBox.Show($"potvrdi brisanje?", "brisanje", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (rez == MessageBoxResult.Yes)
            {
                int rezUpita = izDal.IzbrisiIznajmljivanje(i.IznajmljivanjeId);
                if (rezUpita > -1)
                {
                    MessageBox.Show("brisanje uspesno");
                }
                else
                {
                    MessageBox.Show("Greska");
                }
            }
        }
    }
}
