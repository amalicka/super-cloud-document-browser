namespace KlientTest {
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.documentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.myComponent1 = new MyLibrary.MyComponent(this.components);
            this.buttonAddDocument = new System.Windows.Forms.Button();
            this.documentAddForm1 = new MyLibrary.DocumentAddForm();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tekst z komponentu";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Poaz tekst";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // documentBindingSource
            // 
            this.documentBindingSource.DataSource = typeof(KlientTest.ServiceGameReference.Document);
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
            // myComponent1
            // 
            this.myComponent1.Text = "tekst z komponentu";
            // 
            // buttonAddDocument
            // 
            this.buttonAddDocument.Location = new System.Drawing.Point(28, 122);
            this.buttonAddDocument.Name = "buttonAddDocument";
            this.buttonAddDocument.Size = new System.Drawing.Size(75, 69);
            this.buttonAddDocument.TabIndex = 9;
            this.buttonAddDocument.Text = "Dodaj dokument";
            this.buttonAddDocument.UseVisualStyleBackColor = true;
            this.buttonAddDocument.Click += new System.EventHandler(this.buttonAddDocument_Click);
            // 
            // documentAddForm1
            // 
            this.documentAddForm1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.documentAddForm1.Location = new System.Drawing.Point(305, 200);
            this.documentAddForm1.Name = "documentAddForm1";
            this.documentAddForm1.Size = new System.Drawing.Size(528, 359);
            this.documentAddForm1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 602);
            this.Controls.Add(this.documentAddForm1);
            this.Controls.Add(this.buttonAddDocument);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private MyLibrary.MyComponent myComponent1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource documentBindingSource;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonAddDocument;
        private MyLibrary.DocumentAddForm documentAddForm1;
    }
}

