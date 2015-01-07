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
        Document[] documents; // = new Document[10];

        public ServiceGame() {
            documents = new Document[] {
                new DocumentDoc(),
                new DocumentPdf(),
                new DocumentDoc()
            };
        }

        public Document[] GetData() {
            return documents;
        }

        public void SendData(Document[] doc) {
            Console.WriteLine("Trololololo łochochochoooo!");
        }
    }
}
