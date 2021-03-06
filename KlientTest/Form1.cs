﻿using System;
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
using System.Reflection;
using KlientTest.Renderer;
namespace KlientTest {
    public partial class Form1 : Form {
        DocumentExp[] documentsArray;
        Form2addDocument addDocumentForm;
        ServiceGameClient client;
        public IDocumentRenderer docRenderer;

        public Form1() {
            client = new ServiceGameClient();
            addDocumentForm = new Form2addDocument(client);
            InitializeComponent();
            makeListView();  
            addDocumentForm.AllowUpdate += new ReadyToUpadeHandler(refreshDocumentList);
            usageStatisticsReporter1.UserStatisticsSend += new UserStatisticsSendingHandler(statisticsSend);
            docRenderer = new DemoDocumentRenderer();

            //Wczytanie DLL ---http://www.codeproject.com/Articles/30612/Load-a-User-DLL-implementing-an-AppIn-interface
            Assembly ass = Assembly.LoadFrom(@"C:\Users\Aleksandra\Desktop\JPP_W_Ptasznik\SerwerGry\DocumentRendererFullVersionDLL.dll");
            foreach (Type t in ass.GetExportedTypes())
            {
                if (t.GetInterface("IDocumentRenderer", true) != null){
                    var fullRenderer = Activator.CreateInstance(t) as IDocumentRenderer;
                    docRenderer = fullRenderer;
                }
            }
        }

        public void makeListView() {
            //http: //msdn.microsoft.com/pl-pl/library/system.windows.forms.listview.checkboxes(v=vs.110).aspx
            listView1.Columns.Add("Nazwa",100);
            listView1.Columns.Add("Autor");
            listView1.Columns.Add("Rozmiar",60);
            listView1.Columns.Add("Zawartość",150);
            listView1.Columns.Add("Typ",100);
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
                        Convert.ToString(document.getSize()), tpmContent, document.DocumentType
                    });
            }
        }


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


        public void statisticsSend() {
            System.Diagnostics.Debug.WriteLine("Klient app: statistics send");
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
            usageStatisticsReporter1.reportClickedButton("Button Show");
            if (listView1.CheckedItems.Count != 1) {
                MessageBox.Show("Wybierz 1 plik");
                return;
            }
            Form3ShowDocumentContent showDocumentContent = new Form3ShowDocumentContent(
                    (DocumentExp)listView1.CheckedItems[0].Tag, 
                    docRenderer);
            ((DocumentExp)listView1.CheckedItems[0].Tag).getNumberOfCustomProperties();
            showDocumentContent.ShowDialog();
        }
        
        private void buttonPrint_Click(object sender, EventArgs e) {
            usageStatisticsReporter1.reportClickedButton("Button Print");
            DocumentExp docToPrint;
            if (listView1.CheckedItems.Count != 1) {
                MessageBox.Show("Wybierz 1 plik");
                return;
            } else {
                docToPrint = (DocumentExp)listView1.CheckedItems[0].Tag;
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
            usageStatisticsReporter1.reportClickedButton("Button Refresh");
            refreshDocumentList();
        }
    }    
}


