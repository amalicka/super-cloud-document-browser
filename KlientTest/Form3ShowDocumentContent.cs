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
using KlientTest.Renderer;

namespace KlientTest {
    public partial class Form3ShowDocumentContent : Form {

        private EditableField[] docEditFields;

        public Form3ShowDocumentContent(DocumentExp document, IDocumentRenderer docRenderer) {
            InitializeComponent();
            this.labelName.Text = document.getName();
            this.labelSize.Text = Convert.ToString(document.getSize());
            this.labelType.Text = document.DocumentType;//checkWhatIsTheDocumentType(document);
            this.labelAuthor.Text = document.getAuthor();
            this.labelType.Text = document.DocumentType;
            System.Diagnostics.Debug.WriteLine("DocumentType: " + document.DocumentType);

            this.labelContent.Text = docRenderer.render(document);
            if (document.ContentExp.GetType() == typeof(EditableContentExp)) {
                EditableContentExp editableContent = (EditableContentExp)document.ContentExp;
                docEditFields = editableContent.getEditableContentData().EditableFields;
                System.Diagnostics.Debug.WriteLine("Yupii! Got editable content!");
                labelEditabeFields.Text = "Pola edytowalne:";
                
                //tworzenie textboxsów
                Point location = new Point(0,0);
                for (int i = 0; i < docEditFields.Length; i++) {
                    var textBox = new TextBox();
                    textBox.Text = docEditFields[i].Name + " " + docEditFields[i].Value;
                    textBox.Location = location;
                    location = new Point(textBox.Location.X, textBox.Location.Y + 25);
                    textBox.Width = panelEditableElements.Width - 5;
                    panelEditableElements.Controls.Add(textBox);
                }
            } 
            else {
                labelEditabeFields.Text = " ";
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
