﻿using System;
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
            Console.ReadKey();
            host.Close();
        }
    }
}
