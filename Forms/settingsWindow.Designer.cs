namespace Pbp.Forms
{
    partial class settingsWindow
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
            this.exitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonFontSelector = new System.Windows.Forms.Button();
            this.buttonChosseBackgroundColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonChooseProjectionForeColor = new System.Windows.Forms.Button();
            this.buttonChooseProjectionBorderColor = new System.Windows.Forms.Button();
            this.checkBoxFontScaling = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(8, 193);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "&Ok";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(89, 193);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Abbrechen";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Benutzerdaten (Bilder, Lieder):";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(438, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Ordner wählen...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(199, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(233, 20);
            this.textBox1.TabIndex = 5;
            // 
            // buttonFontSelector
            // 
            this.buttonFontSelector.Location = new System.Drawing.Point(430, 37);
            this.buttonFontSelector.Name = "buttonFontSelector";
            this.buttonFontSelector.Size = new System.Drawing.Size(124, 23);
            this.buttonFontSelector.TabIndex = 31;
            this.buttonFontSelector.Text = "Schrift wählen...";
            this.buttonFontSelector.UseVisualStyleBackColor = true;
            this.buttonFontSelector.Click += new System.EventHandler(this.buttonFontSelector_Click);
            // 
            // buttonChosseBackgroundColor
            // 
            this.buttonChosseBackgroundColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChosseBackgroundColor.Location = new System.Drawing.Point(18, 19);
            this.buttonChosseBackgroundColor.Name = "buttonChosseBackgroundColor";
            this.buttonChosseBackgroundColor.Size = new System.Drawing.Size(158, 23);
            this.buttonChosseBackgroundColor.TabIndex = 30;
            this.buttonChosseBackgroundColor.Text = "Hintergrundfarbe...";
            this.buttonChosseBackgroundColor.UseVisualStyleBackColor = true;
            this.buttonChosseBackgroundColor.Click += new System.EventHandler(this.buttonChosseBackgroundColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Projektionsschrift:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "label3";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(406, 193);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 23);
            this.button2.TabIndex = 36;
            this.button2.Text = "Auf &Standard zurücksetzen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonChooseProjectionBorderColor);
            this.groupBox1.Controls.Add(this.buttonChooseProjectionForeColor);
            this.groupBox1.Controls.Add(this.buttonChosseBackgroundColor);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 57);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projektionsfarben";
            // 
            // buttonChooseProjectionForeColor
            // 
            this.buttonChooseProjectionForeColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChooseProjectionForeColor.Location = new System.Drawing.Point(207, 19);
            this.buttonChooseProjectionForeColor.Name = "buttonChooseProjectionForeColor";
            this.buttonChooseProjectionForeColor.Size = new System.Drawing.Size(142, 23);
            this.buttonChooseProjectionForeColor.TabIndex = 31;
            this.buttonChooseProjectionForeColor.Text = "Schriftfarbe...";
            this.buttonChooseProjectionForeColor.UseVisualStyleBackColor = true;
            this.buttonChooseProjectionForeColor.Click += new System.EventHandler(this.buttonChooseProjectionForeColor_Click);
            // 
            // buttonChooseProjectionBorderColor
            // 
            this.buttonChooseProjectionBorderColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChooseProjectionBorderColor.Location = new System.Drawing.Point(371, 19);
            this.buttonChooseProjectionBorderColor.Name = "buttonChooseProjectionBorderColor";
            this.buttonChooseProjectionBorderColor.Size = new System.Drawing.Size(162, 23);
            this.buttonChooseProjectionBorderColor.TabIndex = 32;
            this.buttonChooseProjectionBorderColor.Text = "Umrandungsfarbe...";
            this.buttonChooseProjectionBorderColor.UseVisualStyleBackColor = true;
            this.buttonChooseProjectionBorderColor.Click += new System.EventHandler(this.buttonChooseProjectionBorderColor_Click);
            // 
            // checkBoxFontScaling
            // 
            this.checkBoxFontScaling.AutoSize = true;
            this.checkBoxFontScaling.Location = new System.Drawing.Point(16, 130);
            this.checkBoxFontScaling.Name = "checkBoxFontScaling";
            this.checkBoxFontScaling.Size = new System.Drawing.Size(317, 17);
            this.checkBoxFontScaling.TabIndex = 38;
            this.checkBoxFontScaling.Text = "Projektionsschrift herunterskalieren falls Schriftgrösse zu gross";
            this.checkBoxFontScaling.UseVisualStyleBackColor = true;
            this.checkBoxFontScaling.CheckedChanged += new System.EventHandler(this.checkBoxFontScaling_CheckedChanged);
            // 
            // settingsWindow
            // 
            this.AcceptButton = this.exitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(566, 228);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxFontScaling);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonFontSelector);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.exitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "settingsWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.settingsWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonFontSelector;
        private System.Windows.Forms.Button buttonChosseBackgroundColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonChooseProjectionForeColor;
        private System.Windows.Forms.Button buttonChooseProjectionBorderColor;
        private System.Windows.Forms.CheckBox checkBoxFontScaling;
    }
}