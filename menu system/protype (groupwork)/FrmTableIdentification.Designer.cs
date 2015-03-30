namespace protype__groupwork_
{
    partial class FrmTableIdentification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTableIdentification));
            this.btnMenus = new System.Windows.Forms.Button();
            this.lblTableNumber = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMenus
            // 
            this.btnMenus.Location = new System.Drawing.Point(73, 287);
            this.btnMenus.Name = "btnMenus";
            this.btnMenus.Size = new System.Drawing.Size(138, 51);
            this.btnMenus.TabIndex = 0;
            this.btnMenus.Text = "See Menus";
            this.btnMenus.UseVisualStyleBackColor = true;
            this.btnMenus.Click += new System.EventHandler(this.btnMenus_Click);
            // 
            // lblTableNumber
            // 
            this.lblTableNumber.AutoSize = true;
            this.lblTableNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 200F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableNumber.Location = new System.Drawing.Point(379, 56);
            this.lblTableNumber.Name = "lblTableNumber";
            this.lblTableNumber.Size = new System.Drawing.Size(344, 378);
            this.lblTableNumber.TabIndex = 1;
            this.lblTableNumber.Text = "1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(59, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // FrmTableIdentification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 507);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTableNumber);
            this.Controls.Add(this.btnMenus);
            this.Name = "FrmTableIdentification";
            this.Text = "FrmTableIdentification";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMenus;
        private System.Windows.Forms.Label lblTableNumber;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}