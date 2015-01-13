using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlientTest.ServiceGameReference;
using System.Runtime.Serialization;

namespace KlientTest {
    class EditableContentExp : ContentExp{
                
        private EditableContent editableCont;

        public static EditableContentExp from(EditableContent editCont) {
            return new EditableContentExp(editCont);
        }

        public EditableContentExp(EditableContent editCont) {
            this.editableCont = editCont;
        }
    }
}
