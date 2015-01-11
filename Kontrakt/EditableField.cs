using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Kontrakt {
    [DataContract]
    public class EditableField {
        private FieldType fieldType;
        private String name;
        private String value;

        [DataMember] 
        public FieldType FieldType {
            get { return fieldType; }
            set { fieldType = value; }
        }

        [DataMember] 
        public String Name {
            get { return name; }
            set { name = value; }
        }

        [DataMember] 
        public String Value {
            get { return this.value; }
            set { this.value = value; }
        }

        public EditableField() { }
        public EditableField(FieldType type, String name, String value) {
            this.name = name;
            this.fieldType = type;
            this.value = value;
        }
    }
}
