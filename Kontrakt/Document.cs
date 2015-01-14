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
        long id;
        string name;
        double size;
        string author;
        Content content;
        DateTime creationDate;

        [DataMember]
        public long Id {
            get { return id; }
            set { id = value; }
        }

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
        // http://resources.infosecinstitute.com/pdf-file-format-basic-structure/

        [DataMember] public string pageTree { get; set; }
        [DataMember] public string outlineHierarchy { get; set; }
        [DataMember] public string documentCatalog { get; set; }

        public DocumentPdf() { }
        override public Content getContent() {
            return Content;
        }
    }

    [DataContract]
    public class DocumentDoc : Document {

        // http://www.forensicswiki.org/wiki/Word_Document_%28DOCX%29
        [DataMember] public int cp_revision { get; set; }
        [DataMember] public string fontTable { get; set; }
        [DataMember] public string theme { get; set; }
        [DataMember] public string style { get; set; }

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
