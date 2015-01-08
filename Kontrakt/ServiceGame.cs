using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Drawing;

namespace Kontrakt {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Single)]
    public class ServiceGame : IServiceGame {

       // Dictionary<string, Player> players = new Dictionary<string, Player>();
        List<Document> documents; // = new Document[10];

        public ServiceGame() {
            documents = new List<Document> {
                new DocumentDoc(),
                new DocumentPdf(),
                new DocumentDoc()
            };
            documents[0].Name = "Name Jeden";
            documents[1].Name = "Name Dwa";
            documents[2].Name = "Name Trzy";
            documents[0].Author = "Autor Jeden";
            documents[1].Author = "Autor Dwa";
            documents[2].Author = "Autor Trzy";
            documents[0].Size = 111;
            documents[1].Size = 222;
            documents[2].Size = 333;
        }

        public Document[] GetDocumentsList() {
            Console.WriteLine("#### Accessing documents ####");
            foreach (var doc in documents) {
                Console.WriteLine("Name: " + doc.Name + ", author: " + doc.Author + ", size: " + doc.Size);
            }
            Console.WriteLine("#### DONE ####");
            return documents.ToArray();
        }

        public void SendData(Document[] doc) {
            Console.WriteLine("Trololololo łochochochoooo!");
        }

        public void AddDocument(Document newDoc) {
            Console.WriteLine("metoda: łochAddDocumentochochoooo!");
            documents.Add(newDoc);
            Console.WriteLine("**************************\nDodano dokument wprowadzony przez usera:");
            Console.WriteLine(newDoc.Name + " " + newDoc.Author + " " + newDoc.Content);
        }

        public void RemoveDocument(Document delDoc) {
            documents.Remove(delDoc);
        }
    }
}
