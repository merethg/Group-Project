namespace Kitchen_Application
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
            this.components = new System.ComponentModel.Container();
            this.lstOrderOne = new System.Windows.Forms.ListBox();
            this.lstOrderTwo = new System.Windows.Forms.ListBox();
            this.lstOrderThree = new System.Windows.Forms.ListBox();
            this.lstOrderFour = new System.Windows.Forms.ListBox();
            this.lstOrderFive = new System.Windows.Forms.ListBox();
            this.lstOrderSix = new System.Windows.Forms.ListBox();
            this.btnCooking1 = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.tmrActiveOrder = new System.Windows.Forms.Timer(this.components);
            this.btnComplete2 = new System.Windows.Forms.Button();
            this.btnCooking2 = new System.Windows.Forms.Button();
            this.btnComplete3 = new System.Windows.Forms.Button();
            this.btnCooking3 = new System.Windows.Forms.Button();
            this.btnComplete4 = new System.Windows.Forms.Button();
            this.btnCooking4 = new System.Windows.Forms.Button();
            this.btnComplete5 = new System.Windows.Forms.Button();
            this.btnCooking5 = new System.Windows.Forms.Button();
            this.btnComplete6 = new System.Windows.Forms.Button();
            this.btnCooking6 = new System.Windows.Forms.Button();
            this.tmrRemoveTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lstOrderOne
            // 
            this.lstOrderOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOrderOne.FormattingEnabled = true;
            this.lstOrderOne.ItemHeight = 25;
            this.lstOrderOne.Location = new System.Drawing.Point(38, 40);
            this.lstOrderOne.Name = "lstOrderOne";
            this.lstOrderOne.Size = new System.Drawing.Size(400, 479);
            this.lstOrderOne.TabIndex = 0;
            // 
            // lstOrderTwo
            // 
            this.lstOrderTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOrderTwo.FormattingEnabled = true;
            this.lstOrderTwo.ItemHeight = 25;
            this.lstOrderTwo.Location = new System.Drawing.Point(696, 39);
            this.lstOrderTwo.Name = "lstOrderTwo";
            this.lstOrderTwo.Size = new System.Drawing.Size(400, 479);
            this.lstOrderTwo.TabIndex = 1;
            // 
            // lstOrderThree
            // 
            this.lstOrderThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOrderThree.FormattingEnabled = true;
            this.lstOrderThree.ItemHeight = 25;
            this.lstOrderThree.Location = new System.Drawing.Point(1351, 40);
            this.lstOrderThree.Name = "lstOrderThree";
            this.lstOrderThree.Size = new System.Drawing.Size(400, 479);
            this.lstOrderThree.TabIndex = 2;
            // 
            // lstOrderFour
            // 
            this.lstOrderFour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOrderFour.FormattingEnabled = true;
            this.lstOrderFour.ItemHeight = 25;
            this.lstOrderFour.Location = new System.Drawing.Point(38, 547);
            this.lstOrderFour.Name = "lstOrderFour";
            this.lstOrderFour.Size = new System.Drawing.Size(400, 479);
            this.lstOrderFour.TabIndex = 3;
            // 
            // lstOrderFive
            // 
            this.lstOrderFive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOrderFive.FormattingEnabled = true;
            this.lstOrderFive.ItemHeight = 25;
            this.lstOrderFive.Location = new System.Drawing.Point(696, 555);
            this.lstOrderFive.Name = "lstOrderFive";
            this.lstOrderFive.Size = new System.Drawing.Size(400, 479);
            this.lstOrderFive.TabIndex = 4;
            // 
            // lstOrderSix
            // 
            this.lstOrderSix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOrderSix.FormattingEnabled = true;
            this.lstOrderSix.ItemHeight = 25;
            this.lstOrderSix.Location = new System.Drawing.Point(1351, 555);
            this.lstOrderSix.Name = "lstOrderSix";
            this.lstOrderSix.Size = new System.Drawing.Size(400, 479);
            this.lstOrderSix.TabIndex = 5;
            // 
            // btnCooking1
            // 
            this.btnCooking1.BackColor = System.Drawing.SystemColors.Control;
            this.btnCooking1.Enabled = false;
            this.btnCooking1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCooking1.ForeColor = System.Drawing.Color.Black;
            this.btnCooking1.Location = new System.Drawing.Point(488, 191);
            this.btnCooking1.Name = "btnCooking1";
            this.btnCooking1.Size = new System.Drawing.Size(150, 79);
            this.btnCooking1.TabIndex = 7;
            this.btnCooking1.Text = "Cooking";
            this.btnCooking1.UseVisualStyleBackColor = false;
            this.btnCooking1.Click += new System.EventHandler(this.btnCooking1_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.SystemColors.Control;
            this.btnComplete.Enabled = false;
            this.btnComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete.ForeColor = System.Drawing.Color.Black;
            this.btnComplete.Location = new System.Drawing.Point(488, 285);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(150, 79);
            this.btnComplete.TabIndex = 8;
            this.btnComplete.Text = "Complete";
            this.btnComplete.UseVisualStyleBackColor = false;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // tmrActiveOrder
            // 
            this.tmrActiveOrder.Interval = 1000;
            this.tmrActiveOrder.Tick += new System.EventHandler(this.tmrActiveOrder_Tick);
            // 
            // btnComplete2
            // 
            this.btnComplete2.BackColor = System.Drawing.SystemColors.Control;
            this.btnComplete2.Enabled = false;
            this.btnComplete2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete2.ForeColor = System.Drawing.Color.Black;
            this.btnComplete2.Location = new System.Drawing.Point(1145, 291);
            this.btnComplete2.Name = "btnComplete2";
            this.btnComplete2.Size = new System.Drawing.Size(150, 79);
            this.btnComplete2.TabIndex = 10;
            this.btnComplete2.Text = "Complete";
            this.btnComplete2.UseVisualStyleBackColor = false;
            this.btnComplete2.Click += new System.EventHandler(this.btnComplete2_Click);
            // 
            // btnCooking2
            // 
            this.btnCooking2.BackColor = System.Drawing.SystemColors.Control;
            this.btnCooking2.Enabled = false;
            this.btnCooking2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCooking2.ForeColor = System.Drawing.Color.Black;
            this.btnCooking2.Location = new System.Drawing.Point(1145, 197);
            this.btnCooking2.Name = "btnCooking2";
            this.btnCooking2.Size = new System.Drawing.Size(150, 79);
            this.btnCooking2.TabIndex = 9;
            this.btnCooking2.Text = "Cooking";
            this.btnCooking2.UseVisualStyleBackColor = false;
            this.btnCooking2.Click += new System.EventHandler(this.btnCooking2_Click);
            // 
            // btnComplete3
            // 
            this.btnComplete3.BackColor = System.Drawing.SystemColors.Control;
            this.btnComplete3.Enabled = false;
            this.btnComplete3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete3.ForeColor = System.Drawing.Color.Black;
            this.btnComplete3.Location = new System.Drawing.Point(1803, 291);
            this.btnComplete3.Name = "btnComplete3";
            this.btnComplete3.Size = new System.Drawing.Size(150, 79);
            this.btnComplete3.TabIndex = 12;
            this.btnComplete3.Text = "Complete";
            this.btnComplete3.UseVisualStyleBackColor = false;
            this.btnComplete3.Click += new System.EventHandler(this.btnComplete3_Click);
            // 
            // btnCooking3
            // 
            this.btnCooking3.BackColor = System.Drawing.SystemColors.Control;
            this.btnCooking3.Enabled = false;
            this.btnCooking3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCooking3.ForeColor = System.Drawing.Color.Black;
            this.btnCooking3.Location = new System.Drawing.Point(1803, 191);
            this.btnCooking3.Name = "btnCooking3";
            this.btnCooking3.Size = new System.Drawing.Size(150, 79);
            this.btnCooking3.TabIndex = 11;
            this.btnCooking3.Text = "Cooking";
            this.btnCooking3.UseVisualStyleBackColor = false;
            this.btnCooking3.Click += new System.EventHandler(this.btnCooking3_Click);
            // 
            // btnComplete4
            // 
            this.btnComplete4.BackColor = System.Drawing.SystemColors.Control;
            this.btnComplete4.Enabled = false;
            this.btnComplete4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete4.ForeColor = System.Drawing.Color.Black;
            this.btnComplete4.Location = new System.Drawing.Point(488, 798);
            this.btnComplete4.Name = "btnComplete4";
            this.btnComplete4.Size = new System.Drawing.Size(150, 79);
            this.btnComplete4.TabIndex = 14;
            this.btnComplete4.Text = "Complete";
            this.btnComplete4.UseVisualStyleBackColor = false;
            this.btnComplete4.Click += new System.EventHandler(this.btnComplete4_Click);
            // 
            // btnCooking4
            // 
            this.btnCooking4.BackColor = System.Drawing.SystemColors.Control;
            this.btnCooking4.Enabled = false;
            this.btnCooking4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCooking4.ForeColor = System.Drawing.Color.Black;
            this.btnCooking4.Location = new System.Drawing.Point(488, 704);
            this.btnCooking4.Name = "btnCooking4";
            this.btnCooking4.Size = new System.Drawing.Size(150, 79);
            this.btnCooking4.TabIndex = 13;
            this.btnCooking4.Text = "Cooking";
            this.btnCooking4.UseVisualStyleBackColor = false;
            this.btnCooking4.Click += new System.EventHandler(this.btnCooking4_Click);
            // 
            // btnComplete5
            // 
            this.btnComplete5.BackColor = System.Drawing.SystemColors.Control;
            this.btnComplete5.Enabled = false;
            this.btnComplete5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete5.ForeColor = System.Drawing.Color.Black;
            this.btnComplete5.Location = new System.Drawing.Point(1145, 804);
            this.btnComplete5.Name = "btnComplete5";
            this.btnComplete5.Size = new System.Drawing.Size(150, 79);
            this.btnComplete5.TabIndex = 16;
            this.btnComplete5.Text = "Complete";
            this.btnComplete5.UseVisualStyleBackColor = false;
            this.btnComplete5.Click += new System.EventHandler(this.btnComplete5_Click);
            // 
            // btnCooking5
            // 
            this.btnCooking5.BackColor = System.Drawing.SystemColors.Control;
            this.btnCooking5.Enabled = false;
            this.btnCooking5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCooking5.ForeColor = System.Drawing.Color.Black;
            this.btnCooking5.Location = new System.Drawing.Point(1145, 706);
            this.btnCooking5.Name = "btnCooking5";
            this.btnCooking5.Size = new System.Drawing.Size(150, 79);
            this.btnCooking5.TabIndex = 15;
            this.btnCooking5.Text = "Cooking";
            this.btnCooking5.UseVisualStyleBackColor = false;
            this.btnCooking5.Click += new System.EventHandler(this.btnCooking5_Click);
            // 
            // btnComplete6
            // 
            this.btnComplete6.BackColor = System.Drawing.SystemColors.Control;
            this.btnComplete6.Enabled = false;
            this.btnComplete6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete6.ForeColor = System.Drawing.Color.Black;
            this.btnComplete6.Location = new System.Drawing.Point(1803, 806);
            this.btnComplete6.Name = "btnComplete6";
            this.btnComplete6.Size = new System.Drawing.Size(150, 79);
            this.btnComplete6.TabIndex = 18;
            this.btnComplete6.Text = "Complete";
            this.btnComplete6.UseVisualStyleBackColor = false;
            this.btnComplete6.Click += new System.EventHandler(this.btnComplete6_Click);
            // 
            // btnCooking6
            // 
            this.btnCooking6.BackColor = System.Drawing.SystemColors.Control;
            this.btnCooking6.Enabled = false;
            this.btnCooking6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCooking6.ForeColor = System.Drawing.Color.Black;
            this.btnCooking6.Location = new System.Drawing.Point(1803, 706);
            this.btnCooking6.Name = "btnCooking6";
            this.btnCooking6.Size = new System.Drawing.Size(150, 79);
            this.btnCooking6.TabIndex = 17;
            this.btnCooking6.Text = "Cooking";
            this.btnCooking6.UseVisualStyleBackColor = false;
            this.btnCooking6.Click += new System.EventHandler(this.btnCooking6_Click);
            // 
            // tmrRemoveTimer
            // 
            this.tmrRemoveTimer.Interval = 1000;
            this.tmrRemoveTimer.Tick += new System.EventHandler(this.tmrRemoveTimer_Tick);
            // 
            // FrmKitchen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1932, 1092);
            this.Controls.Add(this.btnComplete6);
            this.Controls.Add(this.btnCooking6);
            this.Controls.Add(this.btnComplete5);
            this.Controls.Add(this.btnCooking5);
            this.Controls.Add(this.btnComplete4);
            this.Controls.Add(this.btnCooking4);
            this.Controls.Add(this.btnComplete3);
            this.Controls.Add(this.btnCooking3);
            this.Controls.Add(this.btnComplete2);
            this.Controls.Add(this.btnCooking2);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnCooking1);
            this.Controls.Add(this.lstOrderSix);
            this.Controls.Add(this.lstOrderFive);
            this.Controls.Add(this.lstOrderFour);
            this.Controls.Add(this.lstOrderThree);
            this.Controls.Add(this.lstOrderTwo);
            this.Controls.Add(this.lstOrderOne);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmKitchen";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmKitchen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstOrderOne;
        private System.Windows.Forms.ListBox lstOrderTwo;
        private System.Windows.Forms.ListBox lstOrderThree;
        private System.Windows.Forms.ListBox lstOrderFour;
        private System.Windows.Forms.ListBox lstOrderFive;
        private System.Windows.Forms.ListBox lstOrderSix;
        private System.Windows.Forms.Button btnCooking1;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Timer tmrActiveOrder;
        private System.Windows.Forms.Button btnComplete2;
        private System.Windows.Forms.Button btnCooking2;
        private System.Windows.Forms.Button btnComplete3;
        private System.Windows.Forms.Button btnCooking3;
        private System.Windows.Forms.Button btnComplete4;
        private System.Windows.Forms.Button btnCooking4;
        private System.Windows.Forms.Button btnComplete5;
        private System.Windows.Forms.Button btnCooking5;
        private System.Windows.Forms.Button btnComplete6;
        private System.Windows.Forms.Button btnCooking6;
        private System.Windows.Forms.Timer tmrRemoveTimer;
    }
}

