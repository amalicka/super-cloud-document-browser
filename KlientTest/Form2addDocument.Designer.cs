namespace KlientTest {
    partial class Form2addDocument {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2addDocument));
            this.documentAddForm1 = new MyLibrary.DocumentAddForm();
            this.SuspendLayout();
            // 
            // documentAddForm1
            // 
            this.documentAddForm1.Author = "";
            this.documentAddForm1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.documentAddForm1.Content = "";
            this.documentAddForm1.DocumentName = "";
            this.documentAddForm1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            resources.ApplyResources(this.documentAddForm1, "documentAddForm1");
            this.documentAddForm1.Name = "documentAddForm1";
            this.documentAddForm1.Type = "";
            // 
            // Form2addDocument
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.documentAddForm1);
            this.Name = "Form2addDocument";
            this.ResumeLayout(false);

        }

        #endregion

        private MyLibrary.DocumentAddForm documentAddForm1;









    }
}