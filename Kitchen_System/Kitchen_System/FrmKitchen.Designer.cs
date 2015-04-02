namespace Kitchen_System
{
    partial class FrmKitchen
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.lstbData = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(132, 247);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(122, 53);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lstbData
            // 
            this.lstbData.FormattingEnabled = true;
            this.lstbData.ItemHeight = 16;
            this.lstbData.Location = new System.Drawing.Point(88, 45);
            this.lstbData.Name = "lstbData";
            this.lstbData.Size = new System.Drawing.Size(224, 164);
            this.lstbData.TabIndex = 1;
            // 
            // FrmKitchen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 375);
            this.Controls.Add(this.lstbData);
            this.Controls.Add(this.btnConnect);
            this.Name = "FrmKitchen";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ListBox lstbData;
    }
}

