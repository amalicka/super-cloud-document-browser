using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlientTest.ServiceGameReference;
using System.Reflection;

namespace KlientTest {
    public class DocumentDocExp : DocumentExp, Printable {
        private const string DOC = "doc";
        public override string DocumentType { get; set; }

        public DocumentDocExp() {
            this.DocumentType = DOC.ToString();
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

        public override int getNumberOfCustomProperties() {
            // Get the public properties.
            Type t = typeof(DocumentDoc);
            PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("The number of public properties: {0}.\n",
                              propInfos.Length);
            return propInfos.Length;
        }
    }
}
