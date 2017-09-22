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
    /// Interaction logic for WindowNoviAutomobili.xaml
    /// </summary>
    public partial class WindowNoviAutomobili : Window
    {
        private AutomobilDal aDal = new AutomobilDal();
        public WindowNoviAutomobili()
        {
            InitializeComponent();
            PrikaziAutomobile();
        }
        private void PrikaziAutomobile()
        {
            datagridAutomobili.Items.Clear();
            List<Automobil> listaAuta = aDal.VratiAutomobile();
            if (listaAuta != null)
            {
                foreach (Automobil a in listaAuta)
                {
                    datagridAutomobili.Items.Add(a);
                }
            }
        }
        private void AutomobilPretraga(string brend)
        {
            datagridAutomobili.Items.Clear();
            List<Automobil> listaAuta = aDal.AutomobilPretraga(brend);
            if (listaAuta != null)
            {
                foreach (Automobil a in listaAuta)
                {
                    datagridAutomobili.Items.Add(a);
                }
            }
        }


        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            WindwNoviAutoIzmene w1 = new WindwNoviAutoIzmene();
            if (w1.ShowDialog() == true)
            {
                Automobil a = w1.Auto;
                int rezultatUpita = aDal.DodajAutomobil(a);
                if (rezultatUpita > -1)
                {
                    MessageBox.Show("Automobil uspesno ubacen");
                    PrikaziAutomobile();
                }
                else
                {
                    MessageBox.Show("Greska");
                }

            }
            else
            {
                MessageBox.Show("Odustali ste od ubacivanja");
            }
        }

        private void buttonPromeni_Click(object sender, RoutedEventArgs e)
        {
             if(datagridAutomobili.SelectedIndex<0)
             {
                MessageBox.Show("Selektujte automobil koji zelite da promenite");
                return;
             }

            Automobil a = (Automobil)datagridAutomobili.SelectedItem;
            WindwNoviAutoIzmene w1 = new WindwNoviAutoIzmene();
            w1.Title = "Azuriranje";
            w1.Auto = a;
            if(w1.ShowDialog()==true)
            {
                int rezultatUpita = aDal.PromeniAutomobil(w1.Auto);
                if(rezultatUpita>-1)
                {
                    MessageBox.Show("Automobil uspesno promenjen");
                    PrikaziAutomobile();
                }
                else
                {
                    MessageBox.Show("Greska");
                }
            }



        }

        private void buttonIzbrisi_Click(object sender, RoutedEventArgs e)
        {
            if (datagridAutomobili.SelectedIndex < 0)
            {
                MessageBox.Show("Selektujte automobil koji zelite da izbrisete");
                return;
            }
            Automobil a = (Automobil)datagridAutomobili.SelectedItem;
           MessageBoxResult rez= MessageBox.Show($"potvrdi brisanje?", "brisanje", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(rez==MessageBoxResult.Yes)
            {
                int rezUpita=aDal.IzbrisiAutomobil(a.AutomobilId);
                if(rezUpita>-1)
                {
                    MessageBox.Show("Automobil uspesno izbrisan");
                    PrikaziAutomobile();
                }
                else
                {
                    MessageBox.Show("Greska");
                }
            }
        }

        private void textboxPretraga_SelectionChanged(object sender, RoutedEventArgs e)
        {

            AutomobilPretraga(textboxPretraga.Text);
        }
    }
}
