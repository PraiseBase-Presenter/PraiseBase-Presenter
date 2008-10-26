namespace Pbp.Forms
{
    partial class projectionWindow
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
			this.pictureBoxCommon = new System.Windows.Forms.PictureBox();
			this.pictureBoxBlackout = new System.Windows.Forms.PictureBox();
			this.projectionControlHost = new System.Windows.Forms.Integration.ElementHost();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCommon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlackout)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxCommon
			// 
			this.pictureBoxCommon.Location = new System.Drawing.Point(373, 23);
			this.pictureBoxCommon.Name = "pictureBoxCommon";
			this.pictureBoxCommon.Size = new System.Drawing.Size(394, 265);
			this.pictureBoxCommon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxCommon.TabIndex = 0;
			this.pictureBoxCommon.TabStop = false;
			this.pictureBoxCommon.Visible = false;
			// 
			// pictureBoxBlackout
			// 
			this.pictureBoxBlackout.Location = new System.Drawing.Point(546, 12);
			this.pictureBoxBlackout.Name = "pictureBoxBlackout";
			this.pictureBoxBlackout.Size = new System.Drawing.Size(244, 206);
			this.pictureBoxBlackout.TabIndex = 1;
			this.pictureBoxBlackout.TabStop = false;
			this.pictureBoxBlackout.Visible = false;
			// 
			// projectionControlHost
			// 
			this.projectionControlHost.Location = new System.Drawing.Point(12, 12);
			this.projectionControlHost.Name = "projectionControlHost";
			this.projectionControlHost.Size = new System.Drawing.Size(293, 237);
			this.projectionControlHost.TabIndex = 2;
			this.projectionControlHost.Text = "elementHost1";
			this.projectionControlHost.Visible = false;
			this.projectionControlHost.Child = null;
			// 
			// projectionWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(840, 641);
			this.ControlBox = false;
			this.Controls.Add(this.projectionControlHost);
			this.Controls.Add(this.pictureBoxBlackout);
			this.Controls.Add(this.pictureBoxCommon);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "projectionWindow";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "projectionWindow";
			this.Load += new System.EventHandler(this.projectionWindow_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.projectionWindow_Paint);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCommon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlackout)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCommon;
        private System.Windows.Forms.PictureBox pictureBoxBlackout;
		private System.Windows.Forms.Integration.ElementHost projectionControlHost;
    }
}