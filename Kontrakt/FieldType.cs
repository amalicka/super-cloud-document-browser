using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Kontrakt {
    [DataContract]
    public enum FieldType {
        [EnumMember] STRING,
        [EnumMember] NUMBER,
        [EnumMember] DATE
    }
}
