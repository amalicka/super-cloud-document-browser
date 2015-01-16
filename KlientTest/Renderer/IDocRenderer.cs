using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlientTest.Renderer {
    public interface IDocRenderer {
        string render(DocumentExp document);
    }
}
