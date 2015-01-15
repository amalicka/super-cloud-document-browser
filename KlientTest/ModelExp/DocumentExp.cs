using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlientTest.ServiceGameReference;
using System.Reflection;

namespace KlientTest {

    public abstract class DocumentExp {
        protected Document documentData;
        protected ContentExp contentExp;
        public virtual string DocumentType { get; set; }

        public ContentExp ContentExp {
            get { return contentExp; }
        }

        public static DocumentExp from(Document doc) {

            if (doc.GetType() == typeof(DocumentDoc)) {
                return new DocumentDocExp((DocumentDoc)doc);
            } else if (doc.GetType() == typeof(DocumentPdf)) {
                return new DocumentPdfExp((DocumentPdf)doc);
            } else if (doc.GetType() == typeof(DocumentHtml)) {
                return new DocumentHtmlExp((DocumentHtml)doc);
            } else {
                throw new ArgumentException("Brak klasy: " + doc.GetType());
            }
        }
        
        protected DocumentExp() {
            this.documentData = new Document();
            this.contentExp = new ContentExp();
            this.documentData.Content = this.contentExp.getContentData();
        }

        protected DocumentExp(Document doc) {
            this.documentData = doc;
            if (doc.Content != null) {
                this.contentExp = ContentExp.from(doc.Content);
            }
        }

        public string getAuthor(){
            return documentData.Author;
        }
        public string getName() {
            return documentData.Name;
        }
        public double getSize() {
            return documentData.Size;
        }
        public Document getDocument() {
            return documentData;
        }
        public void setAuthor(string author) {
           this.documentData.Author = author; ;
        }
        public void setName(string name) {
            this.documentData.Name = name;
        }
        public void setSize(double size) {
            this.documentData.Size = size;
        }

        public virtual int getNumberOfCustomProperties() {
            // Get the public properties.
            Type t = typeof(DocumentDoc);
            PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("The number of public properties: {0}.\n",
                              propInfos.Length);
            return propInfos.Length;
        }
    }
}
