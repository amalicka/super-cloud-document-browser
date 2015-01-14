using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlientTest.ServiceGameReference;

namespace KlientTest {
    public class DocumentHtmlExp : DocumentExp {

        public DocumentHtmlExp(){
            this.documentData = new DocumentHtml();
            this.contentExp = new ContentExp();
            this.documentData.Content = this.contentExp.getContentData();
        }
        public DocumentHtmlExp(DocumentHtml doc)
            : base(doc) {

        }
    }
}
