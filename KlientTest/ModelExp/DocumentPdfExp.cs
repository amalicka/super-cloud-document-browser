using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlientTest.ServiceGameReference;

namespace KlientTest {
    public class DocumentPdfExp : DocumentExp, Printable {

        public DocumentPdfExp() {
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
    }
}
