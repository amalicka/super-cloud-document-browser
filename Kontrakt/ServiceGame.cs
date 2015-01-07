using System;
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

       // Dictionary<string, Player> players = new Dictionary<string, Player>();
        List<Document> documents = new List<Document>();

        

        //public Player[] GetData() {
            // Wyslij dane -> stan swiata gry
        //    Console.WriteLine("GetData() send data to client!");
        //    return players.Values.ToArray();
        //}

        //public string SendData(Player ja) {
        //    // Odbierz dane -> ruch gracza
        //    try {
        //        Console.WriteLine("SendData(): got data from client!");
        //        //if (!players.ContainsKey(ja.Nick)) {
        //        //    Console.WriteLine("{0} zalogował(a) sie do gry", ja.Nick);
        //        //}
        //        players[ja.Nick] = ja;
        //        return "ok";
        //    } 
        //    catch {
        //        return "Błąd";
        //    }
        //}

        public Document[] GetData() {
            // Wyslij dane -> do kleinta
            return documents.ToArray();
        }
        public void SendData(Document[] doc) {
        //przyjmij dane wysłane rpzez klienta
            documents = doc.ToList();
        }

        public void InserTestDocs() {
            try {
                Document dok1 = new DocumentDoc("Dokument 1", "Autor 1");
                Document dok2 = new DocumentDoc("Dokument 1", "Autor 2");
                Document dok3 = new DocumentDoc("Dokument 1", "Autor 3");
                Document dok4 = new DocumentDoc("Dokument 1", "Autor 4");
                Document dok5 = new DocumentDoc("Dokument 1", "Autor 5");
                Document dok6 = new DocumentDoc("Dokument 1", "Autor 6");
                documents.Add(dok1);
                documents.Add(dok2);
                documents.Add(dok3);
                documents.Add(dok4);
                documents.Add(dok5);
                documents.Add(dok6);
            } catch { }

        }
    }
}
