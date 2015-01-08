using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlientTest.ServiceGameReference;
using MyLibrary;

namespace KlientTest {
    public delegate void ReadyToUpadeHandler();

    public partial class Form2addDocument : Form {

        ServiceGameClient client;
        private Document document = new Document();
        public event ReadyToUpadeHandler AllowUpdate;

        public Form2addDocument(ServiceGameClient client) {
            this.client = client;
            InitializeComponent();
            documentAddForm1.AddClick += new DodajDokumentHandler(documentAddForm1_AddClick);
            documentAddForm1.CancelClick += new EventHandler(documentAddForm1_CancelClick);
        }

        private void  documentAddForm1_AddClick(string[] str){
            
            System.Diagnostics.Debug.WriteLine("documentAddForm1_AddClick");
            client.AddDocument(makeDocumentFromData(str));
            if (AllowUpdate != null) {
                AllowUpdate();
            }
            this.Close();
        }

        private void documentAddForm1_CancelClick(object sender, EventArgs arg){
            System.Diagnostics.Debug.WriteLine("documentAddForm1_CancelClick");
            this.Close();
        }

        private Document makeDocumentFromData(string[] str){
            if (str[1] == "pdf") {
                DocumentPdf tmpDoc = new DocumentPdf();
                tmpDoc.Name = str[0];
                tmpDoc.Author = str[2];
                tmpDoc.Content = str[3];
                return tmpDoc;
            } 
            else  /*(str[1] == "doc") */{
                DocumentDoc tmpDoc = new DocumentDoc();
                tmpDoc.Name = str[0];
                tmpDoc.Author = str[2];
                tmpDoc.Content = str[3];
                return tmpDoc;
            }
        }
    }
}
