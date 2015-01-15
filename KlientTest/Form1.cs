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
    public partial class Form1 : Form {
        DocumentExp[] documentsArray;
        Form2addDocument addDocumentForm;
        ServiceGameClient client;

        public Form1() {
            client = new ServiceGameClient();
            addDocumentForm = new Form2addDocument(client);
            InitializeComponent();
            makeListView();  
            addDocumentForm.AllowUpdate += new ReadyToUpadeHandler(refreshDocumentList);
            usageStatisticsReporter1.UserStatisticsSend += new UserStatisticsSendingHandler(statisticsSend);
            refreshDocumentList();
        }
        public void makeListView() {
            //http: //msdn.microsoft.com/pl-pl/library/system.windows.forms.listview.checkboxes(v=vs.110).aspx
            listView1.Columns.Add("Name", 120);
            listView1.Columns.Add("Author", 70);
            listView1.Columns.Add("Size", 70);
            listView1.Columns.Add("Content", 70);
            listView1.View = View.Details;
            listView1.CheckBoxes = true;
            listView1.FullRowSelect = true;// Select the item and subitems when selection is made.
            listView1.GridLines = true;
            listView1.Sorting = SortOrder.Ascending;
        }

        private void refreshDocumentList() {
            try { 
                Document[] tmpDocsArray = client.GetDocumentsList();
                documentsArray = new DocumentExp[tmpDocsArray.Length];
                DocumentExp tmpDocument;
                for(int i=0; i < tmpDocsArray.Length ; i++){
                    tmpDocument = DocumentExp.from(tmpDocsArray[i]);
                    documentsArray[i] = tmpDocument;
                }
            } 
            catch { 
                System.Diagnostics.Debug.WriteLine("Brak połaczenia z serwerem"); 
                MessageBox.Show("Włącz serwer"); 
                return; 
            }
            listView1.Items.Clear();
            string tpmContent;
            foreach (var document in documentsArray) {
                try{
                     tpmContent = document.ContentExp.getContentString();
                }
                catch{
                    tpmContent = "brak tresci";
                }
                   
                ListViewItem item = new ListViewItem();
                item.Text = document.getName();
                item.Tag = document;
                listView1.Items
                    .Add(item)
                    .SubItems
                    .AddRange(new string[] { 
                        document.getAuthor(),
                        Convert.ToString(document.getSize()), tpmContent
                    });
            }
        }

        //private List<EditableFieldExp> getListOfEditableFields(DocumentExp documentExp) {
        //    try {
        //        if (documentExp.ContentExp.getContentData().GetType() == typeof(EditableContentExp)) {
        //            //EditableContentExp editableContentExt = (EditableContentExp)documentExp.getDocument().Content;
        //            List<EditableFieldExp> editableFields;
        //                documentExp.ContentExp.getEditableContent().getEditableContentData().editableFields;
        //               // editableContentExt.getContentData().E;
        //            System.Diagnostics.Debug.WriteLine("Yupii! Got editable content!");
        //            return editableFields;
        //        } 
        //        else {
        //            System.Diagnostics.Debug.WriteLine(documentExp.getName() + " ma EditableContent");
        //            return null;
        //        }

        //    } catch {
        //         System.Diagnostics.Debug.WriteLine("Coś poszło nie tak, przy szukaniu pól edytowalnych");
        //         return null;
        //    }
        //}

        private void deleteDocument() {
            if (listView1.CheckedItems.Count == 0) {
                MessageBox.Show("Zaznacz pliki do usunięcia");
                return;
            }
            foreach (ListViewItem item in listView1.CheckedItems) {
                DocumentExp documentTodelete = (DocumentExp)item.Tag;
                client.RemoveDocument(documentTodelete.getDocument());
            }
            refreshDocumentList();
            MessageBox.Show("usunięto!");
        }

        private void buttonAddDocument_Click(object sender, EventArgs e) {
            usageStatisticsReporter1.reportClickedButton("Button Add");
            addDocumentForm.ShowDialog();
        }

        private void buttonDeleteDocs_Click(object sender, EventArgs e) {
            deleteDocument();
            usageStatisticsReporter1.reportClickedButton("Button Delete");
        }

        private void buttonShowDoc_Click(object sender, EventArgs e) {
            if (listView1.CheckedItems.Count != 1) {
                MessageBox.Show("Wybierz 1 plik");
                return;
            }
            Form3ShowDocumentContent showDocumentContent = 
                new Form3ShowDocumentContent((DocumentExp)listView1.CheckedItems[0].Tag);
            showDocumentContent.ShowDialog();
        }

        public void statisticsSend() {
            System.Diagnostics.Debug.WriteLine("Klient app: statistics send");
        }

        private void buttonPrint_Click(object sender, EventArgs e) {
            DocumentExp docToPrint = (DocumentExp)listView1.CheckedItems[0].Tag;
            if (listView1.CheckedItems.Count != 1) {
                MessageBox.Show("Wybierz 1 plik");
                return;
            }
            if (docToPrint is Printable) {
                Form4Print printDocumentContent = new Form4Print(docToPrint);
                printDocumentContent.ShowDialog();
            } 
            else {
                MessageBox.Show("Tego dokumentu nie można wydrukować");
                return;
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e) {
            refreshDocumentList();
        }
    }    
}


