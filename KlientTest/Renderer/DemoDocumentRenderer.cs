using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlientTest.Renderer;

namespace KlientTest.Renderer {
    public class DemoDocumentRenderer : IDocumentRenderer {
        public string render(DocumentExp documnet) {
            if (documnet.GetType() == typeof(DocumentPdfExp)) {
                return "| DEMO Version | Load full version to render PDF document |";
            } 
            else {
                if (documnet.ContentExp.getContentString() != null)
                    return documnet.ContentExp.getContentString();
            }
            return "#### nothing to render ####";
        }
    }
}
