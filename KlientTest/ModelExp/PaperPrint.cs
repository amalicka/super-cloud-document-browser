using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlientTest.ServiceGameReference;

namespace KlientTest {
    public class PaperPrint {
        private List<string> pageList;
        private const int CHARACT_BY_PAGE = 100; 

        public List<string> PageList {
            get { return pageList; }
            set { pageList = value; }
        }

        public PaperPrint(string content) {
            pageList = new List<string>();
            makePages(content);
        }

        private void makePages(string content) {
            if (content == null) {
                return;
            } 
            else {
                System.Diagnostics.Debug.WriteLine("content: " + content + "\n\n");
                for (var i = 0; i < content.Length; i += CHARACT_BY_PAGE) {
                    string page = content.Substring(i, Math.Min(CHARACT_BY_PAGE, content.Length - i));
                    System.Diagnostics.Debug.WriteLine("\npage as substring: " + page);
                    this.pageList.Add(page);
                }
                        
            }                                               
        }

    }
}
