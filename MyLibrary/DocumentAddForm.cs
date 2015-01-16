using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrary {
    public delegate void DodajDokumentHandler(string[] str);

    public partial class DocumentAddForm : UserControl {

        private string[] docData = new string[4];
        public event DodajDokumentHandler AddClick;
        public event EventHandler CancelClick;

        [Category("Document's info")]
        public string ControlTitle {
            get { return labelTitle.Text; }
            set { labelTitle.Text = value; }
        }
        [Category("Document's info")]
        public string LabelName {
            get { return labelName.Text; }
            set { labelName.Text = value; }
        }
        [Category("Document's info")]
        public string LabelAuthor {
            get { return labelAuthor.Text; }
            set { labelAuthor.Text = value; }
        }
        [Category("Document's info")]
        public string LabelType {
            get { return labelType.Text; }
            set { labelType.Text = value; }
        }
        [Category("Document's info")]
        public string LabelContent {
            get { return labelContent.Text; }
            set { labelContent.Text = value; }
        }

        [Category("Document's info")]
        public string DocumentName {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
        }

        [Category("Document's info")]
        public string Author {
            get { return textBoxAuthor.Text; }
            set { textBoxAuthor.Text = value; }
        }
        [Category("Document's info")]
        public string Content {
            get { return richTextBoxContent.Text; }
            set {richTextBoxContent.Text = value; }
        }

        [Category("Customise buttons")]
        public string ButtonAddText {
            get { return buttonAdd.Text; }
            set { buttonAdd.Text = value; }
        }
        [Category("Customise buttons")]
        public string ButtonCancelText {
            get { return buttonCancel.Text; }
            set { buttonCancel.Text = value; }
        }

        public string Type {
            get { return comboBoxType.Text; }
            set { comboBoxType.Text = value; }
        }

        public DocumentAddForm() {
            InitializeComponent();
            buttonAdd.Click += new EventHandler(buttonAdd_Click);
            buttonCancel.Click += new EventHandler(buttonCancel_Click);                
        }

        public string[] getDocumentData() {
            return docData;
        }

        private void buttonAdd_Click(object sender, EventArgs arg) {

            if (AddClick != null) {
                docData[0] = textBoxName.Text;
                docData[1] = comboBoxType.Text;
                docData[2] = textBoxAuthor.Text;
                docData[3] = richTextBoxContent.Text;
                for (int i = 0; i < docData.Length; i++) {
                    Console.WriteLine("docData [ " + i + " ] " + docData[i] + "!");
                }
                Console.WriteLine("buttonAdd_Click");
                AddClick(docData);
            }

            textBoxName.Text = "";
            textBoxAuthor.Text = "";
            comboBoxType.Text = "";
            richTextBoxContent.Text = "";
        }

        private void buttonCancel_Click(object sender, EventArgs arg) {
            if (CancelClick != null) {
                CancelClick(this, null);
            }
        }

        public void addTypesToComboBox(string[] types) {
            foreach(string type in types){
                comboBoxType.Items.Add(type);
            }
        }
    }
}
