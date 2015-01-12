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

        private Document document;
        private EditableField[] docEditFields;

        public Form3ShowDocumentContent(Document document) {
            InitializeComponent();
            this.labelName.Text = document.Name;
            this.labelSize.Text = Convert.ToString(document.Size);
            this.labelType.Text = checkWhatIsTheDocumentType(document);
            this.labelAuthor.Text = document.Author;
            try {
                if (document.Content.DocContent != null) {
                    this.labelContent.Text = document.Content.DocContent;
                }
            } 
            catch {
                this.labelContent.Text = "---- nie znaleziono zawartości ---";
            }
            try {
                if (document.Content.GetType() == typeof(EditableContent)) {
                    EditableContent editableContent = (EditableContent)document.Content;
                    docEditFields = editableContent.EditableFields;
                    System.Diagnostics.Debug.WriteLine("Yupii! Got editable content!");
                    this.labelEditabeFields.Text = docEditFields[0].Name + " " + docEditFields[0].Value
                        + "\n" + docEditFields[1].Name + " " + docEditFields[1].Value;
                }
            } catch {
                this.labelEditabeFields.Text = "---- nie znaleziono pól edytowalnych ---";
            } 
        }

        public string checkWhatIsTheDocumentType(Document document) {
            string docType;
            if (document.GetType() == typeof(DocumentDoc))
                return "doc";
            else if (document.GetType() == typeof(DocumentPdf))
                return "pdf";
            else if (document.GetType() == typeof(DocumentHtml))
                return "html";
            else
                return "unnown";
        }
    }
}
