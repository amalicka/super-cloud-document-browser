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
            listView1.Columns.Add("Name", 120);
            listView1.Columns.Add("Author", 70);
            listView1.Columns.Add("Size", 70);
            listView1.Columns.Add("Content",70 );
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
        private void buttonAddDocument_Click(object sender, EventArgs e) {
            addDocumentForm.ShowDialog();
        }

        private void refreshDocumentList() {
            documentsArray = client.GetDocumentsList();
            listView1.Items.Clear();
            string tpmContent;
            foreach (var document in documentsArray) {
                getListOfEditableFields(document);
                try{
                     tpmContent = document.Content.DocContent;
                }
                catch{
                    tpmContent = "brak tresci";
                }
                   
                ListViewItem item = new ListViewItem();
                item.Text = document.Name;
                item.Tag = document;
                listView1.Items
                    .Add(item)
                    .SubItems
                    .AddRange(new string[] { 
                        document.Author,
                        Convert.ToString(document.Size), tpmContent
                    });
            }
        }

        private EditableField[] getListOfEditableFields(Document document) {
            try {
                if (document.Content.GetType() == typeof(EditableContent)) {
                    EditableContent editableContent = (EditableContent)document.Content;
                    EditableField[] editableFields = editableContent.EditableFields;
                    System.Diagnostics.Debug.WriteLine("Yupii! Got editable content!");
                    return editableFields;
                } 
                else {
                    System.Diagnostics.Debug.WriteLine(document.Name + " ma EditableContent");
                    return null;
                }

            } catch {
                 System.Diagnostics.Debug.WriteLine("Coś poszło nie tak, przy szukaniu pól edytowalnych");
                 return null;
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

        private void buttonShowDoc_Click(object sender, EventArgs e) {
            if (listView1.CheckedItems.Count != 1) {
                MessageBox.Show("Wybierz 1 plik");
                return;
            }
            Form3ShowDocumentContent showDocumentContent = new Form3ShowDocumentContent((Document)listView1.CheckedItems[0].Tag);
            showDocumentContent.ShowDialog();
        }

    }    
}


