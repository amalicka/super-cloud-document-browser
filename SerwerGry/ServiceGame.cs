using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Kontrakt;
using System.Data.SqlClient;

namespace SerwerGry {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Single)]
    public class ServiceGame : IServiceGame {

        List<Document> documents;

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

            Document editablePdfDoc = new DocumentPdf();

            // Stworz liste edytowalnych pol
            List<EditableField> editableFields = new List<EditableField>();
            editableFields.Add(new EditableField(FieldType.STRING, "name", "Katarzyna"));
            editableFields.Add(new EditableField(FieldType.STRING, "surname", "Stankiewicz"));

            // Ustaw editable content w dokumentcie
            editablePdfDoc.Content = new EditableContent("My document content", editableFields);
            editablePdfDoc.Author = "Joanna XYZ";
            editablePdfDoc.Name = "Editable PDF";

            // Dodaj dokument
            documents.Add(editablePdfDoc);
        }

        public Document[] GetDocumentsList() {

            // Wyciagnij liste dokumentow
            // Challenge 1: tylko z tabelki Document (bez editable i parametow PDF/DOC)
            //      UWAGA: TYP dokumentu -> odpowiednia klasa!!!
            // Challenge 2: dodaj editable fieldsy
            // Challenge 3: dodaj parametry dokumentow (tabelki PDF i DOC)

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
            Console.WriteLine("metoda: AddDocument");
            // Insert nowego dokumentu
            // Challenge 1: do tabelki Document
            // Nie mozna edytowac EditableField-sow, wiec nie trzeba wrzucac danych do tej tabelki
            // Nie mozna edytowac specyficznych parametrow PDF/DOC, wiec pomijamy
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;
                          AttachDbFilename = C:\Users\Aleksandra\Desktop\JPP_W_Ptasznik\SerwerGry\SerwerGry\DocumentDB.mdf;
                          Connect Timeout=30;";
            con.Open();  
          
            string type;
            if(newDoc.GetType() == typeof(DocumentPdf))
                type = "pdf";
            else if (newDoc.GetType() == typeof(DocumentDoc))
                type = "doc";
            if (newDoc.GetType() == typeof(DocumentHtml))
                type = "html";
            else
                type = "unnown";


            string insertString = "insert into Document (Name, Author, Type) values "
                + "('" + newDoc.Name + "', '" + newDoc.Author + "', '" + type + "');";
            Console.WriteLine("insert string : " + insertString);
            SqlCommand cmd = new SqlCommand(insertString, con);
            int nmbrAffected =  cmd.ExecuteNonQuery();
            Console.WriteLine("Number of rows affected: " + nmbrAffected);

            con.Close();
            
            documents.Add(newDoc);
            Console.WriteLine("**************************\nDodano dokument wprowadzony przez usera:");
            Console.WriteLine(newDoc.Name + " " + newDoc.Author + " " + newDoc.Content.DocContent);
        }

        public void RemoveDocument(Document delDoc) {
            // Delete wybranego dokumentu, po ID dokumentu
            Console.WriteLine("#### Searching for document to delete ####");
            foreach(Document document in documents){
                if (delDoc.Name == document.Name) {
                    Console.WriteLine("\n#### Accessing documents ####");
                    documents.Remove(document);
                    Console.WriteLine(document.Name + " deleted \ndeleted#### DONE ####");
                    return;
                }
            }
        }
    }
}
