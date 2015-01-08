using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary; //wlasne kontrolki

namespace KlientTest {
    public partial class Form2addDocument : Form {
        public Form2addDocument() {
            InitializeComponent();

            documentAddForm1.AddClick += new DodajDokumentHandler(dokumentAddForm1_AddClick);
            documentAddForm1.CancelClick += new EventHandler(dokumentAddForm1_CancelClick);
        }
        private void dokumentAddForm1_AddClick(string[] str) {
            System.Diagnostics.Debug.WriteLine("method: dokumentAddForm1_AddClick");
        }
        private void dokumentAddForm1_CancelClick(object sender, EventArgs arg) {
            System.Diagnostics.Debug.WriteLine("method: dokumentAddForm1_CancelClick");

        }
    }
}
