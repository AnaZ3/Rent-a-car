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
    /// Interaction logic for WindowBrisanje.xaml
    /// </summary>
    public partial class WindowBrisanje : Window
    {
        private KlijentDal kDal = new KlijentDal();
        public WindowBrisanje()
        {
            InitializeComponent();
        }
        private void NapuniCombo(List<Klijent> lista)
        {
            comboboxKlijenti.Items.Clear();
            foreach (Klijent k in lista)
            {
                comboboxKlijenti.Items.Add(k);
            }
        }
        private void PretraziKlijente(string ime)
        {

            List<Klijent> listaK = kDal.PretraziKlijenta(TextBoxPretraziKorisnika.Text);
            if (listaK == null)
            {
                MessageBox.Show($"klijent {ime} nije pronadjen");
                return;
            }

            if (listaK.Count == 1)
            {
                Klijent k = listaK[0];
                NapuniCombo(listaK);
                comboboxKlijenti.SelectedIndex = 0;

            }
            else
            {
                NapuniCombo(listaK);
                
            }
        }

        private void btnPretrazi_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextBoxPretraziKorisnika.Text))
            {
                MessageBox.Show("Unesite ime klijenta");
                return;
            }
            PretraziKlijente(TextBoxPretraziKorisnika.Text);
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (comboboxKlijenti.SelectedIndex < 0)
            {
                return;
            }
            DialogResult = true;
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void comboboxKlijenti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxKlijenti.SelectedIndex < 0)
                return;

            Klijent k = (Klijent)comboboxKlijenti.SelectedItem;

            string prikaz = $"Ime: {k.Ime} Prezime: {k.Prezime}\n Datum rodj: {k.Datum_rodjenja}\n" +
                $"Klijent ce biti izbrisan";
            TextBoxKorisnik.Text = prikaz;


        }
    }
}
