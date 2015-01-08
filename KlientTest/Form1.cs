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

            documentsArray = client.GetDocumentsList();
            foreach(var d in documentsArray){
                System.Diagnostics.Debug.WriteLine("name: " + d.Name + "author: " + d.Author + "size: " + d.Size);
            }
            listView1.View = View.Details;
            listView1.Columns.Add("Name", 70);
            listView1.Columns.Add("Author", 70);
            listView1.Columns.Add("Size", 70);
            listViewFill();
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

        public void listViewFill(){
            try{
                foreach (var d in documentsArray) {
                    listView1.Items.Add(d.Name).SubItems.AddRange(new string[] {d.Author, Convert.ToString(d.Size) });
                }
            }
            catch (Exception ms) {}
        }

        private void buttonAddDocument_Click(object sender, EventArgs e) {
            addDocumentForm.ShowDialog();
        }
    }

    
}


