using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Kontrakt {
    [DataContract]
    public class EditableContent : Content {
        private List<EditableField> editableFields;

        [DataMember]
        public List<EditableField> EditableFields {
            get { return editableFields; }
            set { editableFields = value; }
        }        
       
        public EditableContent(){
            editableFields = new List<EditableField>();
        }

        public EditableContent(String content, List<EditableField> editableFieldList) : base(content) {
            this.editableFields = editableFieldList;
        }
    }
}
