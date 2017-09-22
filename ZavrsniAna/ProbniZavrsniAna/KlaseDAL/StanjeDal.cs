using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace ProbniZavrsniAna
{
    class StanjeDal
    {
        public List<Stanje> VratiStanje()
        {
            List<Stanje> ListaStanje = new List<Stanje>();
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("SELECT * FROM Stanje;", kon);

            try
            {
                kon.Open();
                SqlDataReader read = kom.ExecuteReader();

                while (read.Read())
                {
                    Stanje s = new Stanje();
                    s.StanjeId = read.GetInt32(0);
                    s.StanjeOpis = read.GetString(1);

                    ListaStanje.Add(s);
                }
                return ListaStanje;
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
