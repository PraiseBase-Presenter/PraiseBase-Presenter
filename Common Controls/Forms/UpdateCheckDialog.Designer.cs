namespace PraiseBase.Presenter.Forms
{
    partial class UpdateCheckDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateCheckDialog));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.checkBoxHideNotification = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonDownload
            // 
            resources.ApplyResources(this.buttonDownload, "buttonDownload");
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // labelMessage
            // 
            resources.ApplyResources(this.labelMessage, "labelMessage");
            this.labelMessage.Name = "labelMessage";
            // 
            // checkBoxHideNotification
            // 
            resources.ApplyResources(this.checkBoxHideNotification, "checkBoxHideNotification");
            this.checkBoxHideNotification.Name = "checkBoxHideNotification";
            this.checkBoxHideNotification.UseVisualStyleBackColor = true;
            this.checkBoxHideNotification.CheckedChanged += new System.EventHandler(this.checkBoxHideNotification_CheckedChanged);
            // 
            // UpdateCheckDialog
            // 
            this.AcceptButton = this.buttonDownload;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.checkBoxHideNotification);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateCheckDialog";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.UpdateCheckDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.CheckBox checkBoxHideNotification;
    }
}