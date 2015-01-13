using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlientTest.ServiceGameReference;

namespace KlientTest {
    public class DocumentDocExp : DocumentExp {

        public DocumentDocExp() {
            this.documentData = new DocumentDoc();
        }
        public DocumentDocExp(Document doc) : base(doc) {

        }
    }
}
