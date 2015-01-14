using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Kontrakt;
using System.Threading;
using System.Data.SqlClient;

namespace SerwerGry {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Serwer Oli");
            ServiceHost host = new ServiceHost(new ServiceGame());
            host.Open();
            SqlConnection con = new SqlConnection(@"Server=(localdb)\v11.0;Integrated Security=true;Database=Practice;");


            Console.ReadKey();
            host.Close();
        }
    }
}
