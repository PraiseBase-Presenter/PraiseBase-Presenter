namespace Pbp.Components
{
    partial class CustomGroupBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTitleBG = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelTitleBG.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitleBG
            // 
            this.panelTitleBG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))));
            this.panelTitleBG.BackgroundImage = global::Pbp.Properties.Resources.fade1blue;
            this.panelTitleBG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTitleBG.Controls.Add(this.labelTitle);
            this.panelTitleBG.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBG.Name = "panelTitleBG";
            this.panelTitleBG.Size = new System.Drawing.Size(this.Width, 28);
            this.panelTitleBG.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(4, 5);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(39, 16);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Title";
            // 
            // CustomGroupBox
            // 
            this.Controls.Add(this.panelTitleBG);
            this.Name = "CustomGroupBox";
            this.panelTitleBG.ResumeLayout(false);
            this.panelTitleBG.PerformLayout();
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResumeLayout(false);
            this.Paint += new System.Windows.Forms.PaintEventHandler(CustomGroupBox_Paint);
        }

        #endregion

        private System.Windows.Forms.Panel panelTitleBG;
        private System.Windows.Forms.Label labelTitle;
    }
}
