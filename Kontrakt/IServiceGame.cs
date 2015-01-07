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
        //[OperationContract]
        //string SendData(Player ja);

        //[OperationContract]
        //void SendData(Player ja);

        //[OperationContract]
        //string SendData(Dictionary<double, double> positionDict);

        //[OperationContract]
        //string SendData(List<double> positionList);

        [OperationContract]
        //Player[] GetData();
        Document[] GetData();

        [OperationContract]
        void SendData(Document[] doc);
        
        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "Kontrakt.ContractType".

    [DataContract]
    [KnownType(typeof(DocumentDoc))]
    [KnownType(typeof(DocumentPdf))] 
    public abstract class Document {
        string name;
        string fileExtension;
        double size;
        string author;
        DateTime creationDate;

        [DataMember]
        public string Name {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public string FileExtension {
            get { return fileExtension; }
            set { fileExtension = value; }
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
        public Document() {
            name = "abstr test name";
            fileExtension = "abstr test ext";
            size = 123;
            author = "abstr test author";
        }
        public Document(string name, string author) {
            this.name = name;
            this.author = author;
        }

        public abstract void showFileContent();
    }
    [DataContract]

    public class DocumentPdf : Document {
        public DocumentPdf() {
            Name = " test name";
            FileExtension = "pdf";
            Size = 123;
            Author = " test author";
        }
        public DocumentPdf(string name, string author)
            : base(name, author) { }

        public override void showFileContent() {
        }
    }

    [DataContract]
    public class DocumentDoc : Document {
        public DocumentDoc() {
            Name = " test name";
            FileExtension = "doc";
            Size = 123;
            Author = " test author";
        }
        public DocumentDoc(string name, string author)
            : base(name, author) {
                this.Name = name;
                this.Author = author;
        }

        public override void showFileContent() {
        }
    }

    //[DataContract]
    //public class Player {
    //    double x;
    //    double y;
    //    int type;
    //    string nick;
    //    List<Point> shape;   

    //    [DataMember]
    //    public double X {
    //        get { return x; }
    //        set { x = value; }
    //    }

    //    [DataMember]
    //    public double Y {
    //        get { return y; }
    //        set { y = value; }
    //    }

    //    [DataMember]
    //    public int Type {
    //        get { return type; }
    //        set { type = value; }
    //    }

    //    [DataMember]
    //    public List<Point> Shape {
    //        get { return shape; }
    //        set { shape = value; }
    //    }

    //    [DataMember]
    //    public string Nick {
    //        get { return nick; }
    //        set { nick = value; }
    //    }
    //}
 

    
}
