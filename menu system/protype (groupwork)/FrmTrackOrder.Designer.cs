namespace protype__groupwork_
{
    partial class FrmTrackOrder
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
            this.lblOrderMessage = new System.Windows.Forms.Label();
            this.trackTimer = new System.Windows.Forms.Timer(this.components);
            this.picOrderActive = new System.Windows.Forms.PictureBox();
            this.picOrderCooking = new System.Windows.Forms.PictureBox();
            this.picOrderComplete = new System.Windows.Forms.PictureBox();
            this.tmrRelapseTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picOrderActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOrderCooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOrderComplete)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOrderMessage
            // 
            this.lblOrderMessage.AutoSize = true;
            this.lblOrderMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderMessage.Location = new System.Drawing.Point(79, 90);
            this.lblOrderMessage.Name = "lblOrderMessage";
            this.lblOrderMessage.Size = new System.Drawing.Size(494, 39);
            this.lblOrderMessage.TabIndex = 0;
            this.lblOrderMessage.Text = "Thank you for placing you order";
            // 
            // trackTimer
            // 
            this.trackTimer.Interval = 1000;
            this.trackTimer.Tick += new System.EventHandler(this.trackTimer_Tick);
            // 
            // picOrderActive
            // 
            this.picOrderActive.Location = new System.Drawing.Point(162, 241);
            this.picOrderActive.Name = "picOrderActive";
            this.picOrderActive.Size = new System.Drawing.Size(150, 150);
            this.picOrderActive.TabIndex = 1;
            this.picOrderActive.TabStop = false;
            // 
            // picOrderCooking
            // 
            this.picOrderCooking.Location = new System.Drawing.Point(317, 241);
            this.picOrderCooking.Name = "picOrderCooking";
            this.picOrderCooking.Size = new System.Drawing.Size(150, 150);
            this.picOrderCooking.TabIndex = 2;
            this.picOrderCooking.TabStop = false;
            // 
            // picOrderComplete
            // 
            this.picOrderComplete.Location = new System.Drawing.Point(473, 241);
            this.picOrderComplete.Name = "picOrderComplete";
            this.picOrderComplete.Size = new System.Drawing.Size(150, 150);
            this.picOrderComplete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOrderComplete.TabIndex = 3;
            this.picOrderComplete.TabStop = false;
            // 
            // tmrRelapseTimer
            // 
            this.tmrRelapseTimer.Interval = 1000;
            this.tmrRelapseTimer.Tick += new System.EventHandler(this.tmrRelapseTimer_Tick);
            // 
            // FrmTrackOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 520);
            this.Controls.Add(this.picOrderComplete);
            this.Controls.Add(this.picOrderCooking);
            this.Controls.Add(this.picOrderActive);
            this.Controls.Add(this.lblOrderMessage);
            this.Name = "FrmTrackOrder";
            this.Text = "FrmTrackOrder";
            this.Load += new System.EventHandler(this.FrmTrackOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOrderActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOrderCooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOrderComplete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrderMessage;
        private System.Windows.Forms.Timer trackTimer;
        private System.Windows.Forms.PictureBox picOrderActive;
        private System.Windows.Forms.PictureBox picOrderCooking;
        private System.Windows.Forms.PictureBox picOrderComplete;
        private System.Windows.Forms.Timer tmrRelapseTimer;
    }
}