using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Kontrakt {

    [DataContract]
    [KnownType(typeof(DocumentDoc))]
    [KnownType(typeof(DocumentPdf))]
    [KnownType(typeof(DocumentHtml))]
    public abstract class Document {
        string name;
        double size;
        string author;
        Content content;
        DateTime creationDate;

        [DataMember]
        public string Name {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public double Size {
            get { return size; }
            set { size = value; }
        }
        [DataMember]
        public string Author {
            get { return author; }
            set { author = value; }
        }
        [DataMember]
        public DateTime CreationDate {
            get { return creationDate; }
            set { creationDate = value; }
        }

        [DataMember]
        public Content Content {
            get { return content; }
            set { content = value; }
        }

        public abstract Content getContent();
    }

    [DataContract]
    public class DocumentPdf : Document {
        public DocumentPdf() { }
        override public Content getContent() {
            return Content;
        }
    }

    [DataContract]
    public class DocumentDoc : Document {
        public DocumentDoc() { }
        override public Content getContent() {
            return Content;
        }
    }
    [DataContract]
    public class DocumentHtml : Document {
        public DocumentHtml() { }
        override public Content getContent() {
            return Content;
        }
    }
}
