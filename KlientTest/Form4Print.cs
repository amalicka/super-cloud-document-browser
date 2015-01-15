using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Timers;

namespace KlientTest {
    public partial class Form4Print : Form {

        private System.Windows.Forms.Timer timer; // = new System.Windows.Forms.Timer();

        private int currentPage;
        private int numPages;

        public Form4Print(DocumentExp document) {
            InitializeComponent();
            PaperPrint paperPrint = new PaperPrint(document.ContentExp.getContentString());
            numPages = paperPrint.PageList.Count();
            currentPage = 0;
            onPrintProgress(null, null);
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += new EventHandler(onPrintProgress);
            timer.Start();
        }

        private void onPrintProgress(object sender, EventArgs args) {

            if (currentPage == numPages) {
                timer.Stop();
                this.Close();
                return;
            }

            ++currentPage;
            if (currentPage == numPages) {
                labelTotal.Text = "Printing done!";
            } else {
                labelTotal.Text = "Printing page: " + currentPage;
            }

        }
    }
}
