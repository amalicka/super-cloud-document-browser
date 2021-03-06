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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonShowDoc = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonAddDocument = new System.Windows.Forms.Button();
            this.buttonDeleteDocs = new System.Windows.Forms.Button();
            this.usageStatisticsReporter1 = new MyLibrary.UsageStatisticsReporter();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonShowDoc
            // 
            this.buttonShowDoc.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonShowDoc.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonShowDoc.Location = new System.Drawing.Point(3, 3);
            this.buttonShowDoc.Name = "buttonShowDoc";
            this.buttonShowDoc.Size = new System.Drawing.Size(75, 55);
            this.buttonShowDoc.TabIndex = 3;
            this.buttonShowDoc.Text = "Pokaż dokument";
            this.buttonShowDoc.UseVisualStyleBackColor = true;
            this.buttonShowDoc.Click += new System.EventHandler(this.buttonShowDoc_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(176, 28);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(450, 349);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // buttonAddDocument
            // 
            this.buttonAddDocument.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAddDocument.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonAddDocument.Location = new System.Drawing.Point(3, 64);
            this.buttonAddDocument.Name = "buttonAddDocument";
            this.buttonAddDocument.Size = new System.Drawing.Size(75, 55);
            this.buttonAddDocument.TabIndex = 9;
            this.buttonAddDocument.Text = "Dodaj dokument";
            this.buttonAddDocument.UseVisualStyleBackColor = true;
            this.buttonAddDocument.Click += new System.EventHandler(this.buttonAddDocument_Click);
            // 
            // buttonDeleteDocs
            // 
            this.buttonDeleteDocs.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDeleteDocs.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonDeleteDocs.Location = new System.Drawing.Point(3, 125);
            this.buttonDeleteDocs.Name = "buttonDeleteDocs";
            this.buttonDeleteDocs.Size = new System.Drawing.Size(75, 55);
            this.buttonDeleteDocs.TabIndex = 10;
            this.buttonDeleteDocs.Text = "Usuń";
            this.buttonDeleteDocs.UseVisualStyleBackColor = true;
            this.buttonDeleteDocs.Click += new System.EventHandler(this.buttonDeleteDocs_Click);
            // 
            // usageStatisticsReporter1
            // 
            this.usageStatisticsReporter1.FileName = "statistics";
            this.usageStatisticsReporter1.StatisticsCollectingServer = null;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPrint.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonPrint.Location = new System.Drawing.Point(3, 186);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 55);
            this.buttonPrint.TabIndex = 11;
            this.buttonPrint.Text = "Drukuj";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.Image")));
            this.buttonRefresh.Location = new System.Drawing.Point(111, 3);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(40, 40);
            this.buttonRefresh.TabIndex = 12;
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.buttonShowDoc, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddDocument, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonPrint, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonDeleteDocs, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonRefresh, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(156, 245);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(638, 389);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Document Browser";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonShowDoc;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonAddDocument;
        private System.Windows.Forms.Button buttonDeleteDocs;
        private MyLibrary.UsageStatisticsReporter usageStatisticsReporter1;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

