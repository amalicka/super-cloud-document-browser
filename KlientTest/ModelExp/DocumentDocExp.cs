﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlientTest.ServiceGameReference;

namespace KlientTest {
    public class DocumentDocExp : DocumentExp, Printable {

        public DocumentDocExp() {
            this.documentData = new DocumentDoc();
            this.contentExp = new ContentExp();
            this.documentData.Content = this.ContentExp.getContentData();
        }
        public DocumentDocExp(Document doc) 
            : base(doc) {
        }

        public PaperPrint getPrintableVersion() {
            return new PaperPrint(this.ContentExp.getContentString());
        }
    }
}
