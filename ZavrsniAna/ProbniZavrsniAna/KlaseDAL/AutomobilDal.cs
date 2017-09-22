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
    class AutomobilDal
    {
        public List<Automobil> VratiAutomobile()
        {
            List<Automobil> ListaAutomobil = new List<Automobil>();
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("SELECT * FROM Automobil;", kon);

            try
            {
                kon.Open();
                SqlDataReader read = kom.ExecuteReader();

                while (read.Read())
                {
                    Automobil a = new Automobil();
                    a.AutomobilId = read.GetInt32(0);
                    a.TipId = read.GetInt32(1);
                    a.Brend = read.GetString(2);
                    a.Model = read.GetString(3);
                    a.Godina_proizvodnje = read.GetInt32(4);
                    a.Boja = read.GetString(5);
                    a.Cena_po_danu = read.GetDecimal(6);
                    a.StanjeId = read.GetInt32(7);
                    a.Kapacitet_sedista = read.GetInt32(8);
                    a.Broj_vrata = read.GetInt32(9);
                    a.Vrsta_menjaca = read.GetString(10);
                    a.Tip_goriva = read.GetString(11);


                    ListaAutomobil.Add(a);
                }
                return ListaAutomobil;
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

        public int DodajAutomobil(Automobil auto)
        {
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("INSERT INTO Automobil VALUES(@TipId, @Brend, @Model, @Godina_proizvodnje, @Boja, @Cena_po_danu, @StanjeId, @Kapacitet_sedista, @Broj_vrata, @Vrsta_menjaca) ", kon);
            kom.Parameters.AddWithValue("@TipId", auto.TipId);
            kom.Parameters.AddWithValue("@Brend", auto.Brend);
            kom.Parameters.AddWithValue("@Model", auto.Model);
            kom.Parameters.AddWithValue("@Godina_proizvodnje", auto.Godina_proizvodnje);
            kom.Parameters.AddWithValue("@Boja", auto.Boja);
            kom.Parameters.AddWithValue("@Cena_po_danu", auto.Cena_po_danu);
            kom.Parameters.AddWithValue("@StanjeId", auto.StanjeId);
            kom.Parameters.AddWithValue("@Kapacitet_sedista", auto.Kapacitet_sedista);
            kom.Parameters.AddWithValue("@Broj_vrata", auto.Broj_vrata);
            kom.Parameters.AddWithValue("@Vrsta_menjaca", auto.Vrsta_menjaca);
            kom.Parameters.AddWithValue("@Tip_goriva", auto.Tip_goriva);


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

        public int PromeniAutomobil(Automobil auto)
        {
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("PromeniAutomobil", kon);
            kom.CommandType = CommandType.StoredProcedure;
            kom.Parameters.AddWithValue("@AutomobilId", auto.AutomobilId);
            kom.Parameters.AddWithValue("@TipId", auto.TipId);
            kom.Parameters.AddWithValue("@Brend", auto.Brend);
            kom.Parameters.AddWithValue("@Model", auto.Model);
            kom.Parameters.AddWithValue("@Godina_proizvodnje", auto.Godina_proizvodnje);
            kom.Parameters.AddWithValue("@Boja", auto.Boja);
            kom.Parameters.AddWithValue("@Cena_po_danu", auto.Cena_po_danu);
            kom.Parameters.AddWithValue("@StanjeId", auto.StanjeId);
            kom.Parameters.AddWithValue("@Kapacitet_sedista", auto.Kapacitet_sedista);
            kom.Parameters.AddWithValue("@Broj_vrata", auto.Broj_vrata);
            kom.Parameters.AddWithValue("@Vrsta_menjaca", auto.Vrsta_menjaca);
            kom.Parameters.AddWithValue("@Tip_goriva", auto.Tip_goriva);

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

        public int IzbrisiAutomobil(int id)
        {
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("IzbrisiAutomobil", kon);
            kom.CommandType = CommandType.StoredProcedure;
            kom.Parameters.AddWithValue("@AutomobilId", id);

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

        public Automobil PronadjiAutomobil(int id)
        {
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("PronadjiAutomobil", kon);
            kom.CommandType = CommandType.StoredProcedure;
            kom.Parameters.AddWithValue("@AutomobilId", id);
            try
            {
                kon.Open();
                SqlDataReader read = kom.ExecuteReader();

                read.Read();
                Automobil a = new Automobil();
                a.AutomobilId = read.GetInt32(0);
                a.TipId = read.GetInt32(1);
                a.Brend = read.GetString(2);
                a.Model = read.GetString(3);
                a.Godina_proizvodnje = read.GetInt32(4);
                a.Boja = read.GetString(5);
                a.Cena_po_danu = read.GetDecimal(6);
                a.StanjeId = read.GetInt32(7);
                a.Kapacitet_sedista = read.GetInt32(8);
                a.Broj_vrata = read.GetInt32(9);
                a.Vrsta_menjaca = read.GetString(10);
                a.Tip_goriva = read.GetString(11);

                return a;
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


        public int PromeniStanje(int automobilId, int stanjeId)
        {
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("UPDATE Automobil SET StanjeId = @StanjeId WHERE AutomobilId = @AutomobilId;", kon);
            kom.Parameters.AddWithValue("@AutomobilId", automobilId);
            kom.Parameters.AddWithValue("@StanjeId", stanjeId);

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

        public List<Automobil>AutomobilPretraga(string brend)
        {

            List<Automobil> ListaAutomobil = new List<Automobil>();
            SqlConnection kon = Konekcija.KreirajKonekciju();
            SqlCommand kom = new SqlCommand("SELECT * FROM Automobil WHERE Brend LIKE @brend+'%'", kon);
            kom.Parameters.AddWithValue("@brend", brend);
            try
            {
                kon.Open();
                SqlDataReader read = kom.ExecuteReader();

                while (read.Read())
                {
                    Automobil a = new Automobil();
                    a.AutomobilId = read.GetInt32(0);
                    a.TipId = read.GetInt32(1);
                    a.Brend = read.GetString(2);
                    a.Model = read.GetString(3);
                    a.Godina_proizvodnje = read.GetInt32(4);
                    a.Boja = read.GetString(5);
                    a.Cena_po_danu = read.GetDecimal(6);
                    a.StanjeId = read.GetInt32(7);
                    a.Kapacitet_sedista = read.GetInt32(8);
                    a.Broj_vrata = read.GetInt32(9);
                    a.Vrsta_menjaca = read.GetString(10);
                    a.Tip_goriva = read.GetString(11);


                    ListaAutomobil.Add(a);
                }
                return ListaAutomobil;
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
