using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlientTest.Renderer {
    public interface IDocumentRenderer {
        string render(DocumentExp documnet);
    }
}
