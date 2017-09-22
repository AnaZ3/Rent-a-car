using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace ProbniZavrsniAna
{
    class TipDal
    {
        public List<Tip> VratiTipove()
        {
            List<Tip> ListaTip = new List<Tip>();
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("SELECT * FROM Tip;", kon);

            try
            {
                kon.Open();
                SqlDataReader read = kom.ExecuteReader();

                while (read.Read())
                {
                    Tip t = new Tip();
                    t.TipId = read.GetInt32(0);
                    t.Naziv_tipa = read.GetString(1);

                    ListaTip.Add(t);
                }
                return ListaTip;
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
