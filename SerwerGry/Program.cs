using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Kontrakt;
using System.Threading;
using System.Data.SqlClient;
using System.IO;

namespace SerwerGry {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Serwer Oli");
            Console.WriteLine("I'm in: " + Directory.GetCurrentDirectory());
            ServiceHost host = new ServiceHost(new ServiceGame());
            host.Open();
            SqlConnection con = new SqlConnection();
            // con.ConnectionString = @"Data Source=.\SQLEXPRESS;
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;
                          AttachDbFilename = C:\Users\Aleksandra\Desktop\JPP_W_Ptasznik\SerwerGry\SerwerGry\DocumentDB.mdf;
                          Connect Timeout=30;";
            SqlDataReader reader = null;
//            //try {
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from Document", con);
            reader = cmd.ExecuteReader();

            while (reader.Read()) {
                Console.WriteLine(reader[1]);
            }
            //} finally {
            //    if (reader != null) {
            //        reader.Close();
            //    }
            //    if (con != null) {
            //        con.Close();
            //    }
            //}


            Console.ReadKey();
            host.Close();
        }
    }
}
