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
        //Player ja = new Player();
        //Player[] playersi = new Player[0];
        Document[] documentsArray = new Document[10];

        ServiceGameClient client = new ServiceGameClient();
        public Form1() {
            InitializeComponent();
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
            documentsArray = client.GetData();
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
            listView1.Items.Add("Nazwa").SubItems.AddRange(new string[] { "Autor", "Rozmiar" });
        }
        catch (Exception ms) { }
        }

        public DataTable GetTable() {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Author", typeof(string));
            table.Columns.Add("Size", typeof(double));

            // Here we add five DataRows.
            foreach (var d in documentsArray) {
                table.Rows.Add(d.Name, d.Author, d.Size);
            }
            
            return table;
        }

    }

    
}


