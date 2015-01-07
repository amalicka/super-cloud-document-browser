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
            this.documentAddForm1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.documentAddForm1, "documentAddForm1");
            this.documentAddForm1.Name = "documentAddForm1";
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