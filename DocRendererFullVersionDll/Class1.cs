using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlientTest.Renderer;
using KlientTest;

namespace DocRendererFullVersionDll
{
    public class DocRendererFullVersion : IDocRenderer {

        public string render(DocumentExp document) {
            try { return document.ContentExp.getContentString(); } catch { }
            return "## Empty ##";
        }
    }
}
