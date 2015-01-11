using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Kontrakt;
using System.Threading;

namespace SerwerGry {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Serwer Oli");
            
            
            
            ServiceHost host = new ServiceHost(new ServiceGame());
            host.Open();
            Console.ReadKey();
            host.Close();
        }
    }
}
