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
    class IznajmljivanjeDal
    {
        public List<Iznajmljivanje> VratiIznajmljivanje()
        {
            List<Iznajmljivanje> ListaIznajmljivanje = new List<Iznajmljivanje>();
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("SELECT * FROM Iznajmljivanje", kon);

            try
            {
                kon.Open();
                SqlDataReader read = kom.ExecuteReader();

                while (read.Read())
                {
                    Iznajmljivanje iz = new Iznajmljivanje();
                    iz.IznajmljivanjeId = read.GetInt32(0);
                    iz.AutomobilId = read.GetInt32(1);
                    iz.Datum_preuzimanja = read.GetDateTime(2);
                    iz.Datum_vracanja = read.GetDateTime(3);
                    iz.Iznajmljivanje_klijentId = read.GetInt32(4);
                    if (!Convert.IsDBNull(read[5]))
                        iz.OpisId = read.GetInt32(5);

                    iz.Ukupna_cena = read.GetDecimal(6);
                    ListaIznajmljivanje.Add(iz);
                }
                return ListaIznajmljivanje;
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

        public List<Iznajmljivanje>PretraziIznajmljivanje(int klijentId)
        {
            List<Iznajmljivanje> ListaIznajmljivanje = new List<Iznajmljivanje>();
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("PretraziIznajmljivanje", kon);
            kom.CommandType = CommandType.StoredProcedure;
            kom.Parameters.AddWithValue("@KlijentId", klijentId);

            try
            {
                kon.Open();
                SqlDataReader read = kom.ExecuteReader();
                while (read.Read())
                {
                    Iznajmljivanje iz = new Iznajmljivanje();
                    iz.IznajmljivanjeId = read.GetInt32(0);
                    iz.AutomobilId = read.GetInt32(1);
                    iz.Datum_preuzimanja = read.GetDateTime(2);
                    iz.Datum_vracanja = read.GetDateTime(3);
                    iz.Iznajmljivanje_klijentId = read.GetInt32(4);
                   
                    if (!Convert.IsDBNull(read[5]))
                        iz.OpisId = read.GetInt32(5);

                    iz.Ukupna_cena = read.GetDecimal(6);
                    ListaIznajmljivanje.Add(iz);
                       
                }

                return ListaIznajmljivanje;
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

        public int DodajIznajmljivanje(Iznajmljivanje i, int klijentId)
        {
            SqlConnection kon = Konekcija.KreirajKonekciju();
            kon.Open();
            SqlTransaction transakcija = kon.BeginTransaction();
            SqlCommand kom = new SqlCommand("UbaciIznajmljivanje_Klijent", kon, transakcija);
            kom.CommandType = CommandType.StoredProcedure;
            kom.Parameters.AddWithValue("@KlijentId", klijentId);
            SqlParameter idParametar = new SqlParameter("@Iznajmljivanje_klijentId", SqlDbType.Int);
            idParametar.Direction = ParameterDirection.Output;
            try
            {
                kom.Parameters.Add(idParametar);
                kom.ExecuteNonQuery();
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
                kon.Close();
                return -1;
            }

            int iznKlijentId = (int)idParametar.Value;

            SqlCommand komIzn = new SqlCommand("UbaciIznajmljivanje", kon, transakcija);
            komIzn.CommandType = CommandType.StoredProcedure;
            komIzn.Parameters.AddWithValue("@AutomobilId", i.AutomobilId);
            komIzn.Parameters.AddWithValue("@Datum_preuzimanja", i.Datum_preuzimanja);
            komIzn.Parameters.AddWithValue("@Datum_vracanja", i.Datum_vracanja);
            komIzn.Parameters.AddWithValue("@Iznajmljivanje_klijentId", iznKlijentId);
            SqlParameter iznajmljivanjeIdParametar = new SqlParameter("@IznajmljivanjeId", SqlDbType.Int);
            iznajmljivanjeIdParametar.Direction = ParameterDirection.Output;
            komIzn.Parameters.Add(iznajmljivanjeIdParametar);
            
            komIzn.Parameters.AddWithValue("@OpisId", i.OpisId);
            komIzn.Parameters.AddWithValue("@Ukupna_cena", i.Ukupna_cena);

            try
            {
                komIzn.ExecuteNonQuery();
            }
            catch (Exception)
            {
                transakcija.Rollback();
                kon.Close();
                return -1;

            }

            transakcija.Commit();
            kon.Close();
            return (int)iznajmljivanjeIdParametar.Value;

        }



        public int PromeniIznajmljivanje(Iznajmljivanje i)
        {
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("PromeniIznajmljivanje", kon);
            kom.CommandType = CommandType.StoredProcedure;

            kom.Parameters.AddWithValue("@IznajmljivanjeId", i.IznajmljivanjeId);
            kom.Parameters.AddWithValue("@AutomobilId", i.AutomobilId);
            kom.Parameters.AddWithValue("@Datum_preuzimanja", i.Datum_preuzimanja);
            kom.Parameters.AddWithValue("@Datum_vracanja", i.Datum_vracanja);

            kom.Parameters.AddWithValue("@OpisId",i.OpisId);
            kom.Parameters.AddWithValue("@Ukupna_cena", i.Ukupna_cena);

            try
            {
                kon.Open();
                kom.ExecuteNonQuery();
                return 0;
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
                return -1;
            }
            finally
            {
                kon.Close();
                kon.Dispose(); //DJORDJE
            }


        }

        public int IzbrisiIznajmljivanje(int id)
        {
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("DELETE FROM Iznajmljivanje WHERE IznajmljivanjeId=@IznajmljivanjeId;", kon);
            kom.Parameters.AddWithValue("@IznajmljivanjeId", id);
            try
            {
                kon.Open();
                kom.ExecuteNonQuery();
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                kon.Close();
              
            }
        }
    }
}
