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
    public partial class Form3ShowDocumentContent : Form {

        private EditableField[] docEditFields;

        public Form3ShowDocumentContent(DocumentExp document) {
            InitializeComponent();
            this.labelName.Text = document.getName();
            this.labelSize.Text = Convert.ToString(document.getSize());
            this.labelType.Text = checkWhatIsTheDocumentType(document);
            this.labelAuthor.Text = document.getAuthor();
            try {
                if (document.ContentExp!= null) {
                    this.labelContent.Text = document.ContentExp.getContentData().DocContent;
                }
            } 
            catch {
                this.labelContent.Text = "---- nie znaleziono zawartości ---";
            }
            try {
                if (document.ContentExp.GetType() == typeof(EditableContentExp)) {
                    EditableContentExp editableContent = (EditableContentExp)document.ContentExp;
                    docEditFields = editableContent.getEditableContentData().EditableFields;
                    System.Diagnostics.Debug.WriteLine("Yupii! Got editable content!");
                    this.labelEditabeFields.Text = docEditFields[0].Name + " " + docEditFields[0].Value
                        + "\n" + docEditFields[1].Name + " " + docEditFields[1].Value;
                    //tworzenie textboxsów
                    var textBox = new TextBox();
                    textBox.Text = docEditFields[0].Name + " " + docEditFields[0].Value;
                    panelEditableElements.Controls.Add(textBox);
                    var textBox1 = new TextBox();
                    textBox1.Location = new Point(textBox.Location.X, textBox.Location.Y + 20);
                    textBox1.Text = docEditFields[1].Name + " " + docEditFields[1].Value;
                    panelEditableElements.Controls.Add(textBox1);
                }
            } catch {
                this.labelEditabeFields.Text = "---- nie znaleziono pól edytowalnych ---";
            } 
        }

        public string checkWhatIsTheDocumentType(DocumentExp document) {
            if (document.GetType() == typeof(DocumentDocExp))
                return "doc";
            else if (document.GetType() == typeof(DocumentPdfExp))
                return "pdf";
            else if (document.GetType() == typeof(DocumentHtmlExp))
                return "html";
            else
                return "unnown";
        }
    }
}
