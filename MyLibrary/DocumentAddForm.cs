﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrary {
    public delegate void DodajDokumentHandler(string[] str);

    public partial class DocumentAddForm : UserControl {

        private string[] docData = new string[4];
        public event DodajDokumentHandler AddClick;
        public event EventHandler CancelClick;

        [Category("Dane dokumentu")]
        public string DocumentName {
            get {
                return textBoxName.Text;
            }
            set {
                textBoxName.Text = value;
            }
        }

        [Category("Dane dokumentu")]
        public string Type {
            get {
                return comboBoxType.Text;
            }
            set {
                comboBoxType.Text = value;
            }
        }

        [Category("Dane dokumentu")]
        public string Author {
            get {
                return textBoxAuthor.Text;
            }
            set {
                textBoxAuthor.Text = value;
            }
        }
        [Category("Dane dokumentu")]
        public string Content {
            get {
                return richTextBoxContent.Text;
            }
            set {
                richTextBoxContent.Text = value;
            }
        }

        public DocumentAddForm() {
            InitializeComponent();
            buttonAdd.Click += new EventHandler(buttonAdd_Click);
            buttonCancel.Click += new EventHandler(buttonCancel_Click);
        }

        public string[] getDocumentData() {
            return docData;
        }

        private void buttonAdd_Click(object sender, EventArgs arg) {
            if (AddClick != null) {
                docData[0] = textBoxName.Text;
                docData[1] = comboBoxType.Text;
                docData[2] = textBoxAuthor.Text;
                docData[3] = richTextBoxContent.Text;
                for (int i = 0; i < docData.Length; i++) {
                    Console.WriteLine("docData [ " + i + " ] " + docData[i] + "!");
                }
                Console.WriteLine("buttonAdd_Click");

                AddClick(docData);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs arg) {
            if (CancelClick != null) {
                CancelClick(this, null);
            }
        }

        public void addTypesToComboBox(string[] types) {
            foreach(string type in types){
                comboBoxType.Items.Add(type);
            }
        }
    }
}
