using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Drawing;

namespace Kontrakt {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceGame {

        [OperationContract]
        Document[] GetDocumentsList();

        //    [OperationContract]
        //    void AddDocument(Document newDoc);

        //    [OperationContract]
        //    void RemoveDocument(Document delDoc);

        //    [OperationContract]
        //    byte[] GetContents(Document doc);
        //}

        // Use a data contract as illustrated in the sample below to add composite types to service operations.
        // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "Kontrakt.ContractType".

    }

    [DataContract]
    [KnownType(typeof(DocumentDoc))]
    [KnownType(typeof(DocumentPdf))]
    public abstract class Document {
        string name;
        double size;
        string author;
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

        public abstract void showFileContent();
    }

    [DataContract]
    public class DocumentPdf : Document {
        public override void showFileContent() {
        }
    }

    [DataContract]
    public class DocumentDoc : Document {
        public DocumentDoc() { }

        public DocumentDoc(string name, string author)
            : base() {
            this.Name = name;
            this.Author = author;
        }

        public override void showFileContent() {
        }
    }
}
