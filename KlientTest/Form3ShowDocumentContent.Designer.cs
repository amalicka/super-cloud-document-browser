namespace KlientTest {
    partial class Form3ShowDocumentContent {
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelContent = new System.Windows.Forms.Label();
            this.labelEditabeFields = new System.Windows.Forms.Label();
            this.panelEditableElements = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(54, 39);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(47, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "--Name--";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(57, 81);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(50, 13);
            this.labelAuthor.TabIndex = 1;
            this.labelAuthor.Text = "--Author--";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(57, 129);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(43, 13);
            this.labelType.TabIndex = 2;
            this.labelType.Text = "--Type--";
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(54, 169);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(39, 13);
            this.labelSize.TabIndex = 3;
            this.labelSize.Text = "--Size--";
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(60, 212);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(56, 13);
            this.labelContent.TabIndex = 4;
            this.labelContent.Text = "--Content--";
            // 
            // labelEditabeFields
            // 
            this.labelEditabeFields.AutoSize = true;
            this.labelEditabeFields.Location = new System.Drawing.Point(57, 286);
            this.labelEditabeFields.Name = "labelEditabeFields";
            this.labelEditabeFields.Size = new System.Drawing.Size(82, 13);
            this.labelEditabeFields.TabIndex = 5;
            this.labelEditabeFields.Text = "--EditabeFields--";
            // 
            // panelEditableElements
            // 
            this.panelEditableElements.Location = new System.Drawing.Point(252, 234);
            this.panelEditableElements.Name = "panelEditableElements";
            this.panelEditableElements.Size = new System.Drawing.Size(207, 206);
            this.panelEditableElements.TabIndex = 6;
            // 
            // Form3ShowDocumentContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 452);
            this.Controls.Add(this.panelEditableElements);
            this.Controls.Add(this.labelEditabeFields);
            this.Controls.Add(this.labelContent);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelName);
            this.Name = "Form3ShowDocumentContent";
            this.Text = "Form2ShowContent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.Label labelEditabeFields;
        private System.Windows.Forms.Panel panelEditableElements;
    }
}