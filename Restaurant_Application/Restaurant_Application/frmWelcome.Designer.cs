namespace Restaurant_Application
{
    partial class frmWelcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWelcome));
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lbluserMessage = new System.Windows.Forms.Label();
            this.cmnOptions = new System.Windows.Forms.ComboBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblWelcome.Location = new System.Drawing.Point(613, 234);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(587, 76);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome to Zizzi\'s";
            // 
            // lbluserMessage
            // 
            this.lbluserMessage.AutoSize = true;
            this.lbluserMessage.BackColor = System.Drawing.Color.Transparent;
            this.lbluserMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluserMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbluserMessage.Location = new System.Drawing.Point(618, 388);
            this.lbluserMessage.Name = "lbluserMessage";
            this.lbluserMessage.Size = new System.Drawing.Size(665, 48);
            this.lbluserMessage.TabIndex = 1;
            this.lbluserMessage.Text = "Please Enter the Number of Diners";
            // 
            // cmnOptions
            // 
            this.cmnOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmnOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmnOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmnOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnOptions.ForeColor = System.Drawing.Color.Black;
            this.cmnOptions.FormattingEnabled = true;
            this.cmnOptions.Items.AddRange(new object[] {
            "1 PERSON",
            "2 PEOPLE",
            "3 PEOPLE",
            "4 PEOPLE",
            "5 PEOPLE",
            "6 PEOPLE",
            "7 PEOPLE",
            "8 PEOPLE",
            "9 PEOPLE",
            "10 PEOPLE"});
            this.cmnOptions.Location = new System.Drawing.Point(675, 478);
            this.cmnOptions.Name = "cmnOptions";
            this.cmnOptions.Size = new System.Drawing.Size(193, 37);
            this.cmnOptions.TabIndex = 17;
            this.cmnOptions.SelectedIndexChanged += new System.EventHandler(this.cmnOptions_SelectedIndexChanged);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAccept.Enabled = false;
            this.btnAccept.Font = new System.Drawing.Font("Wide Latin", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(600, 809);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(296, 121);
            this.btnAccept.TabIndex = 18;
            this.btnAccept.Text = "BOOK";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(45, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // frmWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lbluserMessage);
            this.Controls.Add(this.cmnOptions);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWelcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lbluserMessage;
        private System.Windows.Forms.ComboBox cmnOptions;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

