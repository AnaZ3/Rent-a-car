using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace ProbniZavrsniAna
{
    class Iznajmljivanje_klijentDal
    {
        public List<Iznajmljivanje_klijent> VratiIznajmljivanje_klijent()
        {
            List<Iznajmljivanje_klijent> ListaIznajmljivanje_klijent = new List<Iznajmljivanje_klijent>();
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("SELECT * FROM Iznajmljivanje_klijent;", kon);

            try
            {
                kon.Open();
                SqlDataReader read = kom.ExecuteReader();

                while (read.Read())
                {
                    Iznajmljivanje_klijent izt = new Iznajmljivanje_klijent();
                    izt.Iznajmljivanje_klijentId = read.GetInt32(0);
                    izt.KlijentId = read.GetInt32(1);

                    ListaIznajmljivanje_klijent.Add(izt);
                }
                return ListaIznajmljivanje_klijent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                kon.Close();

            }
        }
    }
}
