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

        [Category("Dane dokumentu")]
        public string Name {
            get {
                return textBoxName.Text;
            }
            set {
                textBoxName.Text = value;
            }
        }

        [Category("Dane dokumentu")]
        public string Type {
            get {
                return comboBoxType.Text;
            }
            set {
                comboBoxType.Text = value;
            }
        }

        [Category("Dane dokumentu")]
        public string Author {
            get {
                return textBoxAuthor.Text;
            }
            set {
                textBoxAuthor.Text = value;
            }
        }
        [Category("Dane dokumentu")]
        public string Content {
            get {
                return richTextBoxContent.Text;
            }
            set {
                richTextBoxContent.Text = value;
            }
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
                AddClick(docData);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs arg) {
            if (CancelClick != null) {
                CancelClick(this, null);
            }
        }
    }
}
