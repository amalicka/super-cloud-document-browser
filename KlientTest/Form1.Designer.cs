﻿namespace KlientTest {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonShowDoc = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonAddDocument = new System.Windows.Forms.Button();
            this.documentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonDeleteDocs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonShowDoc
            // 
            this.buttonShowDoc.Location = new System.Drawing.Point(28, 28);
            this.buttonShowDoc.Name = "buttonShowDoc";
            this.buttonShowDoc.Size = new System.Drawing.Size(75, 70);
            this.buttonShowDoc.TabIndex = 3;
            this.buttonShowDoc.Text = "Pokaż dokument";
            this.buttonShowDoc.UseVisualStyleBackColor = true;
            this.buttonShowDoc.Click += new System.EventHandler(this.buttonShowDoc_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(183, 28);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(357, 245);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // buttonAddDocument
            // 
            this.buttonAddDocument.Location = new System.Drawing.Point(28, 104);
            this.buttonAddDocument.Name = "buttonAddDocument";
            this.buttonAddDocument.Size = new System.Drawing.Size(75, 77);
            this.buttonAddDocument.TabIndex = 9;
            this.buttonAddDocument.Text = "Dodaj dokument";
            this.buttonAddDocument.UseVisualStyleBackColor = true;
            // 
            // documentBindingSource
            // 
            this.documentBindingSource.DataSource = typeof(KlientTest.ServiceGameReference.Document);
            // 
            // buttonDeleteDocs
            // 
            this.buttonDeleteDocs.Location = new System.Drawing.Point(28, 187);
            this.buttonDeleteDocs.Name = "buttonDeleteDocs";
            this.buttonDeleteDocs.Size = new System.Drawing.Size(75, 76);
            this.buttonDeleteDocs.TabIndex = 10;
            this.buttonDeleteDocs.Text = "Usun wybrane dokumenty";
            this.buttonDeleteDocs.UseVisualStyleBackColor = true;
            this.buttonDeleteDocs.Click += new System.EventHandler(this.buttonDeleteDocs_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 312);
            this.Controls.Add(this.buttonDeleteDocs);
            this.Controls.Add(this.buttonAddDocument);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonShowDoc);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonShowDoc;
        private System.Windows.Forms.BindingSource documentBindingSource;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonAddDocument;
        private System.Windows.Forms.Button buttonDeleteDocs;
    }
}

