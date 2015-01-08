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
        Document[] documentsArray = new Document[10];
        Form2addDocument addDocumentForm = new Form2addDocument();

        ServiceGameClient client = new ServiceGameClient();
        public Form1() {
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

        private void button2_Click(object sender, EventArgs e) {
            documentsArray = client.GetDocumentsList();
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
            //DataTable dt = GetTable();
            //listView1.Items.Clear();

            //stackoverflow.com/questions/473148/c-sharp-listview-how-do-i-add-items-to-columns-2-3-and-4-etc
            foreach (var d in documentsArray) {
                listView1.Items.Add(d.Name).SubItems.AddRange(new string[] {d.Author, Convert.ToString(d.Size) });
            }
        }
        catch (Exception ms) { }
        }

        private void buttonAddDocument_Click(object sender, EventArgs e) {
            addDocumentForm.ShowDialog();
        }
    }

    
}


