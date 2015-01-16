using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlientTest.Renderer {
    public class DocRendererDemo : IDocRenderer {

        public string render(DocumentExp document) {
            if (document.GetType() == typeof(DocumentPdfExp)) {
                return "Super Doc RENdeRER: DEMO Version. PDF documents supported only in full version!";
            }

            try { return document.ContentExp.getContentData().DocContent; } catch {}

            return "## EMPTY ##";
        }
    }
}
