using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlientTest.ServiceGameReference;
using System.Reflection;

namespace KlientTest {
    public class DocumentPdfExp : DocumentExp, Printable {
        private const string PDF = "pdf";
        public override string DocumentType { get; set; }

        public DocumentPdfExp() {
            this.DocumentType = PDF;
            this.documentData = new DocumentPdf();
            this.contentExp = new ContentExp();
            this.documentData.Content = this.ContentExp.getContentData();
        }
        public DocumentPdfExp(Document doc) 
            : base(doc) {
        }

        public PaperPrint getPrintableVersion() {
            return new PaperPrint(this.ContentExp.getContentString());
        }
        public override int getNumberOfCustomProperties() {
            // Get the public properties.
            Type t = typeof(DocumentPdf);
            PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("The number of public properties: {0}.\n",
                              propInfos.Length);
            return propInfos.Length;
        }
    }
}
