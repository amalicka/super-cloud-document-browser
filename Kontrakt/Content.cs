using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Kontrakt {
    [DataContract]
    [KnownType(typeof(EditableContent))]
    public class Content {
        private string docContent;

        [DataMember]
        public string DocContent {
            get { return docContent; }
            set { docContent = value; }
        }
    }
}
