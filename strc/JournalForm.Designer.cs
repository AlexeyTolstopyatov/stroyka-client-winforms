namespace strc
{
    partial class JournalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.errBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // errBox
            // 
            this.errBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errBox.Location = new System.Drawing.Point(12, 12);
            this.errBox.Multiline = true;
            this.errBox.Name = "errBox";
            this.errBox.ReadOnly = true;
            this.errBox.Size = new System.Drawing.Size(336, 194);
            this.errBox.TabIndex = 0;
            // 
            // JournalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 218);
            this.Controls.Add(this.errBox);
            this.Name = "JournalForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "JournalForm";
            this.Load += new System.EventHandler(this.JournalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox errBox;
    }
}