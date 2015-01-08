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

namespace KlientTest {
    public partial class Form1 : Form {
        Document[] documentsArray;
        Form2addDocument addDocumentForm;
        ServiceGameClient client;

        public Form1() {
            client = new ServiceGameClient();
            addDocumentForm = new Form2addDocument(client);
            
            InitializeComponent();

            // Zarejestruj obserwatora w buttonie
            this.buttonAddDocument.Click += new EventHandler(buttonAddDocument_Click);
            addDocumentForm.AllowUpdate += new ReadyToUpadeHandler(refreshDocumentList);

            refreshDocumentList();

            
        }
        
        private void button1_Click(object sender, EventArgs e) {
            label1.Text = myComponent1.dajMiText();
        }

        private void button3_Click(object sender, EventArgs e) {

            foreach (var d in documentsArray) {
                if (d is DocumentPdf) {
                    System.Diagnostics.Debug.WriteLine("got PDF");
                }
                if (d is DocumentDoc) {
                    System.Diagnostics.Debug.WriteLine("got DOC");
                }
            }
        }

        private void buttonAddDocument_Click(object sender, EventArgs e) {
            addDocumentForm.ShowDialog();
        }

        private void refreshDocumentList() {
            documentsArray = client.GetDocumentsList();

            //http: //msdn.microsoft.com/pl-pl/library/system.windows.forms.listview.checkboxes(v=vs.110).aspx
            listView1.Columns.Add("Name", 70);
            listView1.Columns.Add("Author", 70);
            listView1.Columns.Add("Size", 70);


            listView1.View = View.Details;
            listView1.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Sorting = SortOrder.Ascending;
            listViewFill();
        }

        private void listViewFill() {
            try {
                foreach (var d in documentsArray) {
                    listView1.Items.Add(d.Name).SubItems.AddRange(new string[] { d.Author, Convert.ToString(d.Size) });
                }
            } catch (Exception ms) { }
        }

        private void deleteDocument() {
            int c = listView1.CheckedItems.Count;
            List<string> docsToDeleteNames = new List<string>();

            if (c == 0) {
                MessageBox.Show("Zaznacz pliki do usunięcia");
            } 
            else {
                System.Diagnostics.Debug.WriteLine("zaznaczone itemy:");
                foreach (var ch in listView1.CheckedItems) {
                    System.Diagnostics.Debug.WriteLine(ch.ToString());
                    docsToDeleteNames.Add(ch.ToString());
                }

            }
        }

        private void buttonDeleteDocs_Click(object sender, EventArgs e) {
            deleteDocument();
        }

    }

    
}


