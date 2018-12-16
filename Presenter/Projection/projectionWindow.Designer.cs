﻿namespace PraiseBase.Presenter.Projection
{
    partial class ProjectionWindow
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
            this.projectionControlHost = new System.Windows.Forms.Integration.ElementHost();
            this.SuspendLayout();
            // 
            // projectionControlHost
            // 
            this.projectionControlHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectionControlHost.Location = new System.Drawing.Point(0, 0);
            this.projectionControlHost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.projectionControlHost.Name = "projectionControlHost";
            this.projectionControlHost.Size = new System.Drawing.Size(853, 591);
            this.projectionControlHost.TabIndex = 2;
            this.projectionControlHost.Text = "elementHost1";
            this.projectionControlHost.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.projectionControlHost_ChildChanged);
            this.projectionControlHost.Child = null;
            // 
            // ProjectionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(853, 591);
            this.ControlBox = false;
            this.Controls.Add(this.projectionControlHost);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectionWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "projectionWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost projectionControlHost;
    }
}