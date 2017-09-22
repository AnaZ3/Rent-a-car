using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProbniZavrsniAna
{
    class Konekcija
    {
        public static SqlConnection KreirajKonekciju()
        {
            SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder(); 
            cb.DataSource = @"DESKTOP-ARFANKM\SQLEXPRESS2016";
            cb.InitialCatalog = "Rent-a-car";
            cb.IntegratedSecurity = true;

            SqlConnection kk = new SqlConnection(cb.ToString());
            return kk;
            
        }
    }

}
