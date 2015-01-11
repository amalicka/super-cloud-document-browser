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

        [OperationContract]
        void AddDocument(Document newDoc);

        [OperationContract]
        void RemoveDocument(Document delDoc);
    }
}
