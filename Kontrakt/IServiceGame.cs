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
        string SendData(Player ja);

        //[OperationContract]
        //string SendData(Dictionary<double, double> positionDict);

        //[OperationContract]
        //string SendData(List<double> positionList);

        [OperationContract]
        Player[] GetData();
        
        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "Kontrakt.ContractType".

    [DataContract]
    public class Player {
        double x;
        double y;
        int type;
        string nick;
        List<Point> shape;   

        [DataMember]
        public double X {
            get { return x; }
            set { x = value; }
        }

        [DataMember]
        public double Y {
            get { return y; }
            set { y = value; }
        }

        [DataMember]
        public int Type {
            get { return type; }
            set { type = value; }
        }

        [DataMember]
        public List<Point> Shape {
            get { return shape; }
            set { shape = value; }
        }

        [DataMember]
        public string Nick {
            get { return nick; }
            set { nick = value; }
        }


        public abstract class Document {
            string fileExtension;
            double size;
            string author;
            DateTime creationDate;

            public string FileExtension {
                get { return fileExtension; }
                set { fileExtension = value; }
            }
            protected double Size {
                get { return size; }
                set { size = value; }
            }
            protected string Author {
                get { return author; }
                set { author = value; }
            }
            protected DateTime CreationDate {
                get { return creationDate; }
                set { creationDate = value; }
            }

            protected Document();
            protected Document(string extention, string author){
                this.fileExtension = extention;
                this.author = author;
            }

            virtual void showFileContent();
        }

        public class DocumentPdf : Document {
            public DocumentPdf(){
                FileExtension = "pdf";
            }
            
            public override void showFileContent(){
            }
        }
        public class DocumentDoc : Document {
            public DocumentPdf() {
                FileExtension = "doc";
            }

            public override void showFileContent() {
            }
        }





    }
}
