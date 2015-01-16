using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KlientTest;
using KlientTest.Renderer;

namespace DocumentRendererFullVersionDLL
{
    public class DocumentRendererFullVersion : IDocumentRenderer {
        public string render(DocumentExp documnet) {
            
            if(documnet.ContentExp.getContentString() == null || documnet.ContentExp.getContentString() == String.Empty)
                 return "### no content to render ###";
            if(documnet.GetType() == typeof(DocumentDocExp))
                return documnet.ContentExp.getContentString();           
            else if(documnet.GetType() == typeof(DocumentPdfExp))
                return documnet.ContentExp.getContentString();
            else if(documnet.GetType() == typeof(DocumentHtmlExp))
                return documnet.ContentExp.getContentString();
            else
                return documnet.ContentExp.getContentString();
        }
    }
}
