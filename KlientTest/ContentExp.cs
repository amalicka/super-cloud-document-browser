using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlientTest.ServiceGameReference;

namespace KlientTest {
    public class ContentExp {

        private Content contentData;

        public static ContentExp from(Content content) {
            if (content.GetType() == typeof(EditableContent)) {
                return new EditableContentExp((EditableContent)content);
            } else if (content.GetType() == typeof(Content)) {
                return new ContentExp((Content)content);
            } else {
                throw new ArgumentException("Brak klasy: " + content.GetType());
            }
        }

        public ContentExp() { }

        public ContentExp(Content cont) {
            this.contentData = cont;
        }

        public Content getContentData() {
            return this.contentData;
        }
        public string getContentString() {
            return this.contentData.DocContent;
        }
        public void setContentString(string c) {
            this.contentData.DocContent = c; 
        }
        protected virtual EditableContentExp getEditableContent() {
            System.Diagnostics.Debug.WriteLine("Metoda --getEditableContent()-- wywolana z ContentExp");
            return new EditableContentExp();
        }
    }
}
