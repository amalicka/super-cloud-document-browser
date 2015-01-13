using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlientTest.ServiceGameReference;

namespace KlientTest {
    public class DocumentPdfExp : DocumentExp {

        public DocumentPdfExp() {
            this.documentData = new DocumentPdf();
        }
        public DocumentPdfExp(Document doc) 
            : base(doc) {
        }
    }
}
