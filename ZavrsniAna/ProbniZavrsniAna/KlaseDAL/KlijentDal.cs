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
    class KlijentDal
    {
        public List<Klijent> VratiKlijente()
        {
            List<Klijent> ListaKlijent = new List<Klijent>();
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("SELECT * FROM Klijent;", kon);

            try
            {
                kon.Open();
                SqlDataReader read = kom.ExecuteReader();

                while (read.Read())
                {
                    Klijent k = new Klijent();
                    k.KlijentId = read.GetInt32(0);
                    k.Ime = read.GetString(1);
                    k.Prezime = read.GetString(2);
                    k.Datum_rodjenja = read.GetDateTime(3);
                    k.Br_vozacke_dozvole = read.GetString(4);
                    k.Kontakt_telefon = read.GetString(5);
                    if (!Convert.IsDBNull(read[6]))
                    {
                        k.Email = read.GetString(6);
                    }


                    ListaKlijent.Add(k);
                }
                return ListaKlijent;
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


        public int DodajKlijenta(Klijent k)
        {
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("DodajKlijenta", kon);
            kom.CommandType = CommandType.StoredProcedure;
            SqlParameter idParametar = new SqlParameter("@KlijentId", SqlDbType.Int);
            idParametar.Direction = ParameterDirection.Output;
            kom.Parameters.AddWithValue("@Ime", k.Ime);
            kom.Parameters.AddWithValue("@Prezime", k.Prezime);
            kom.Parameters.AddWithValue("@Datum_rodjenja", k.Datum_rodjenja);
            kom.Parameters.AddWithValue("@Br_vozacke_dozvole", k.Br_vozacke_dozvole);
            kom.Parameters.AddWithValue("@Kontakt_telefon", k.Kontakt_telefon);
            if (k.Email != null)
            kom.Parameters.AddWithValue("@Email", k.Email);
            kom.Parameters.Add(idParametar);

            try
            {
                kon.Open();
                kom.ExecuteNonQuery();
                return(int)idParametar.Value;
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
                return -1;
            }

            finally
            {
                kon.Close();
            }
        }

        public int PromeniKlijenta(Klijent k)
        {
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("PromeniKlijenta", kon);
            kom.CommandType = CommandType.StoredProcedure;
            kom.Parameters.AddWithValue("@KlijentId", k.KlijentId);
            kom.Parameters.AddWithValue("@Ime", k.Ime);
            kom.Parameters.AddWithValue("@Prezime", k.Prezime);
            kom.Parameters.AddWithValue("@Datum_rodjenja", k.Datum_rodjenja);
            kom.Parameters.AddWithValue("@Br_vozacke_dozvole", k.Br_vozacke_dozvole);
            kom.Parameters.AddWithValue("@Kontakt_telefon", k.Kontakt_telefon);
            if (k.Email != null)
                kom.Parameters.AddWithValue("@Email", k.Email);
          

            try
            {
                kon.Open();
                kom.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }

            finally
            {
                kon.Close();
            }
        }






        public List<Klijent> PretraziKlijenta(string ime)
        {
            List<Klijent> listK = new List<Klijent>();
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("PretraziKorisnika", kon);
            kom.CommandType = CommandType.StoredProcedure;
            kom.Parameters.AddWithValue("@Ime", ime);
            try
            {
                kon.Open();
                SqlDataReader read = kom.ExecuteReader();

                while (read.Read())
                {
                    Klijent k = new Klijent();
                    k.KlijentId = read.GetInt32(0);
                    k.Ime = read.GetString(1);
                    k.Prezime = read.GetString(2);
                    k.Datum_rodjenja = read.GetDateTime(3);
                    k.Br_vozacke_dozvole = read.GetString(4);
                    k.Kontakt_telefon = read.GetString(5);
                    if (!Convert.IsDBNull(read[6]))
                    {
                        k.Email = read.GetString(6);
                    }
                    listK.Add(k);
                }

                return listK; 
                 
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
            

        public int IzbrisiKlijenta(int id)
        {
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("DELETE FROM Klijent WHERE KlijentId=@KlijentId;", kon);
            kom.Parameters.AddWithValue("@KlijentId", id);
            try
            {
                kon.Open();
                kom.ExecuteNonQuery();
                return 0;
            }
            catch (Exception )
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
