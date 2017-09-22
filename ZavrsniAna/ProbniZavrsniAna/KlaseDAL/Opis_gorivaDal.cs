using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Data;

namespace ProbniZavrsniAna
{
    class Opis_gorivaDal
    {
        public List<Opis_goriva> VratiOpis()

        {
            List<Opis_goriva> ListaOpis = new List<Opis_goriva>();
        SqlConnection kon = Konekcija.KreirajKonekciju();
        SqlCommand kom = new SqlCommand("Select * from Opis_goriva;", kon);

         try
            {
                kon.Open();
                SqlDataReader read = kom.ExecuteReader();

                while (read.Read())
                {
                    Opis_goriva os = new Opis_goriva();
                    os.OpisId = read.GetInt32(0);
                    os.Opis = read.GetString(1);
                    os.Cena_goriva = read.GetDecimal(2);

                    ListaOpis.Add(os);
                }
                return ListaOpis;
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

        public Opis_goriva PronadjiGorivo(int id)
        {
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("PronadjiOpisGoriva", kon);
            kom.CommandType = CommandType.StoredProcedure;
            kom.Parameters.AddWithValue("@OpisGorivaId", id);
            try
            {
                kon.Open();
                SqlDataReader read = kom.ExecuteReader();

                read.Read();

                Opis_goriva os = new Opis_goriva();
                os.OpisId = read.GetInt32(0);
                os.Opis = read.GetString(1);
                os.Cena_goriva = read.GetDecimal(2);

                return os;
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


