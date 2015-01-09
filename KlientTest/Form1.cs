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

            // Zarejestruj obserwatora w buttonie
            this.buttonAddDocument.Click += new EventHandler(buttonAddDocument_Click);
            addDocumentForm.AllowUpdate += new ReadyToUpadeHandler(refreshDocumentList);

            refreshDocumentList();
        }
        
        private void button1_Click(object sender, EventArgs e) {
            label1.Text = myComponent1.dajMiText();
        }

        private void buttonAddDocument_Click(object sender, EventArgs e) {
            addDocumentForm.ShowDialog();
        }

        private void refreshDocumentList() {
            documentsArray = client.GetDocumentsList();
            listView1.Items.Clear();
            foreach (var document in documentsArray) {
                ListViewItem item = new ListViewItem();
                item.Text = document.Name;
                item.Tag = document;
                listView1.Items
                    .Add(item)
                    .SubItems
                    .AddRange(new string[] { 
                        document.Author,
                        Convert.ToString(document.Size)
                    });
            }
        }

        private void deleteDocument() {
            if (listView1.CheckedItems.Count == 0) {
                MessageBox.Show("Zaznacz pliki do usunięcia");
                return;
            }
            foreach (ListViewItem item in listView1.CheckedItems) {
                client.RemoveDocument((Document)item.Tag);
            }
            refreshDocumentList();
            MessageBox.Show("usunięto!");
        }

        private void buttonDeleteDocs_Click(object sender, EventArgs e) {
            deleteDocument();
        }

    }

    
}


