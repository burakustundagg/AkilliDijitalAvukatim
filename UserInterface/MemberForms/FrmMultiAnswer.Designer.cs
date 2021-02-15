
namespace UserInterface.MemberForms {
    partial class FrmMultiAnswer {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMultiAnswer));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblBilgi = new System.Windows.Forms.Label();
            this.buttonsList1 = new UserInterface.ButtonsList();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(44, 86);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(710, 325);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // lblBilgi
            // 
            this.lblBilgi.AutoSize = true;
            this.lblBilgi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBilgi.Location = new System.Drawing.Point(86, 37);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(605, 25);
            this.lblBilgi.TabIndex = 2;
            this.lblBilgi.Text = "Birden çok eşleşme aldınız aradığınız yasayı seçebilir misiniz?";
            // 
            // buttonsList1
            // 
            this.buttonsList1.ParentControl = this.flowLayoutPanel1;
            this.buttonsList1.OnClick += new UserInterface.ButtonsList.Clicked(this.buttonsList1_OnClick);
            // 
            // FrmMultiAnswer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 440);
            this.Controls.Add(this.lblBilgi);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMultiAnswer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMultiAnswer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblBilgi;
        public UserInterface.ButtonsList buttonsList1;
    }
}