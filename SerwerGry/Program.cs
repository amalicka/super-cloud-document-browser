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

            Console.WriteLine("Serwer gry Oli");
            //tworzenie instacnji hoosta i wskazanie jaki kontrakt ma obsługiwać (Game Service)
            ServiceHost host = new ServiceHost(new ServiceGame());
            host.Open();
            Thread thread = new Thread(new ThreadStart(write));
            thread.Start();

            while(true){
                Thread.Sleep(100);
                Console.WriteLine("petla gry");
            }
           
            //Console.ReadKey();
            //host.Close();
        }

        public static void write() {
            while (true) {
                Thread.Sleep(500);
                Console.WriteLine("thread");
            }
        }
    }
}
