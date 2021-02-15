
namespace UserInterface.MemberForms {
    partial class FrmMemberDashboard {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && ( components != null )) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMemberDashboard));
            this.BtnSor = new System.Windows.Forms.Button();
            this.RichTxtCevap = new System.Windows.Forms.RichTextBox();
            this.RichTxtSoru = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // BtnSor
            // 
            this.BtnSor.Location = new System.Drawing.Point(443, 274);
            this.BtnSor.Name = "BtnSor";
            this.BtnSor.Size = new System.Drawing.Size(103, 45);
            this.BtnSor.TabIndex = 2;
            this.BtnSor.Text = "Sor";
            this.BtnSor.UseVisualStyleBackColor = true;
            this.BtnSor.Click += new System.EventHandler(this.BtnSor_Click);
            // 
            // RichTxtCevap
            // 
            this.RichTxtCevap.Location = new System.Drawing.Point(22, 175);
            this.RichTxtCevap.Name = "RichTxtCevap";
            this.RichTxtCevap.ReadOnly = true;
            this.RichTxtCevap.Size = new System.Drawing.Size(402, 144);
            this.RichTxtCevap.TabIndex = 1;
            this.RichTxtCevap.Text = "";
            // 
            // RichTxtSoru
            // 
            this.RichTxtSoru.Location = new System.Drawing.Point(22, 12);
            this.RichTxtSoru.Name = "RichTxtSoru";
            this.RichTxtSoru.Size = new System.Drawing.Size(402, 144);
            this.RichTxtSoru.TabIndex = 0;
            this.RichTxtSoru.Text = "";
            // 
            // FrmMemberDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 356);
            this.Controls.Add(this.BtnSor);
            this.Controls.Add(this.RichTxtCevap);
            this.Controls.Add(this.RichTxtSoru);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMemberDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Akıllı Avukatım\'a Hoşgeldiniz";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnSor;
        private System.Windows.Forms.RichTextBox RichTxtCevap;
        private System.Windows.Forms.RichTextBox RichTxtSoru;
    }
}