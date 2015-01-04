using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Kontrakt;

namespace SerwerGry {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Serwer gry Oli");
            //tworzenie instacnji hoosta i wskazanie jaki kontrakt ma obsługiwać (Game Service)
            ServiceHost host = new ServiceHost(new ServiceGame());
            host.Open();
            Console.ReadKey();
            host.Close();

            
        }
    }
}
