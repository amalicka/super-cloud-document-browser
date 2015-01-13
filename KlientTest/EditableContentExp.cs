using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlientTest.ServiceGameReference;
using System.Runtime.Serialization;

namespace KlientTest {
    public class EditableContentExp : ContentExp{
                
        private EditableContent editableContentData;

        public static EditableContentExp from(EditableContent editCont) {
            return new EditableContentExp(editCont);
        }

        public EditableContentExp(EditableContent editCont) {
            this.editableContentData = editCont;
        }

        public EditableContent getEditableContent() {
            System.Diagnostics.Debug.WriteLine("Metoda --getEditableContent()-- wywolana z EditableContentExp");
            return this.editableContentData;
        }
        
        public EditableContent getEditableContentData(){
            return this.editableContentData;
        }
        public EditableContentExp() { }
    }
}
