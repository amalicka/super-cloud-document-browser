﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Drawing;

namespace Kontrakt {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceGame : IServiceGame {

        Dictionary<string, Player> players = new Dictionary<string, Player>();

        public Player[] GetData() {
            // Wyslij dane -> stan swiata gry
            Console.WriteLine("GetData() send data to client!");
            return players.Values.ToArray();
        }

        public string SendData(Player ja) {
            // Odbierz dane -> ruch gracza
            try {
                Console.WriteLine("SendData(): got data from client!");
                if (!players.ContainsKey(ja.Nick)) {
                    Console.WriteLine("{0} zalogował(a) sie do gry", ja.Nick);
                }
                players[ja.Nick] = ja;
                return "ok";
            } 
            catch {
                return "Błąd";
            }
        }

    }
}
