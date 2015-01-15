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
        public event ReadyToUpadeHandler AllowUpdate;

        public Form2addDocument(ServiceGameClient client) {
            this.client = client;
            InitializeComponent();
            documentAddForm1.AddClick += new DodajDokumentHandler(documentAddForm1_AddClick);
            documentAddForm1.CancelClick += new EventHandler(documentAddForm1_CancelClick);
            documentAddForm1.addTypesToComboBox(new string[] {"html", "pdf", "doc" });
        }

        private void  documentAddForm1_AddClick(string[] dataFromControl){
            System.Diagnostics.Debug.WriteLine("documentAddForm1_AddClick");
            Document tmpDocument = makeDocumentFromData(dataFromControl).getDocument();
            client.AddDocument(tmpDocument);
            if (AllowUpdate != null) {
                AllowUpdate();
            }
            this.Close();
        }

        private DocumentExp makeDocumentFromData(string[] dataFromControl) {
            System.Diagnostics.Debug.WriteLine("makeDocumentFromData");
            if (dataFromControl[1] == "pdf") {
                DocumentPdfExp tmpDoc = new DocumentPdfExp();
                tmpDoc.setName(dataFromControl[0]);
                tmpDoc.setAuthor(dataFromControl[2]);
                tmpDoc.ContentExp.setContentString(dataFromControl[3]);
                return tmpDoc;
            } else if (dataFromControl[1] == "doc") {
                DocumentDocExp tmpDoc = new DocumentDocExp();
                tmpDoc.setName(dataFromControl[0]);
                tmpDoc.setAuthor(dataFromControl[2]);
                tmpDoc.ContentExp.setContentString(dataFromControl[3]);
                return tmpDoc;
            } else /*if (dataFromControl[1] == "html")*/ {
                DocumentHtmlExp tmpDoc = new DocumentHtmlExp();
                tmpDoc.setName(dataFromControl[0]);
                tmpDoc.setAuthor(dataFromControl[2]);
                tmpDoc.ContentExp.setContentString(dataFromControl[3]);
                return tmpDoc;
            }
        }

        private void documentAddForm1_CancelClick(object sender, EventArgs arg) {
            System.Diagnostics.Debug.WriteLine("documentAddForm1_CancelClick");
            this.Close();
        }

        private void documentAddForm1_Load(object sender, EventArgs e) {

        }
    }
}
