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
    public partial class DocumentAddForm : UserControl {

        public delegate void TypZdarzenia();

        private string[] docData = new string[4];

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
        }

        public event TypZdarzenia ZapiszClicked;

        private void buttonAdd_Click(object sender, EventArgs e) {
            docData[0] = this.Name;
            docData[1] = this.Author;
            docData[2] = this.Type;
            docData[3] = this.Content;

            if (ZapiszClicked != null) {
                ZapiszClicked();
            }
        }
        public string[] getDocumentData() {
            return docData;
        }
    }
}
