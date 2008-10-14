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
            this.buttonChooseProjectionBorderColor = new System.Windows.Forms.Button();
            this.buttonChooseProjectionForeColor = new System.Windows.Forms.Button();
            this.checkBoxFontScaling = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listBoxTags = new System.Windows.Forms.ListBox();
            this.buttonDelTags = new System.Windows.Forms.Button();
            this.textBoxNewTag = new System.Windows.Forms.TextBox();
            this.buttonAddTag = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAddLang = new System.Windows.Forms.Button();
            this.textBoxNewLang = new System.Windows.Forms.TextBox();
            this.buttonDelLang = new System.Windows.Forms.Button();
            this.listBoxLanguages = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAddSongPart = new System.Windows.Forms.Button();
            this.textBoxNewSongPart = new System.Windows.Forms.TextBox();
            this.buttonDelSongParts = new System.Windows.Forms.Button();
            this.listBoxSongParts = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(8, 330);
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
            this.cancelButton.Location = new System.Drawing.Point(89, 330);
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
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Benutzerdaten (Bilder, Lieder):";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(436, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Ordner wählen...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(197, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(233, 20);
            this.textBox1.TabIndex = 5;
            // 
            // buttonFontSelector
            // 
            this.buttonFontSelector.Location = new System.Drawing.Point(432, 11);
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
            this.label2.Location = new System.Drawing.Point(15, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Projektionsschrift:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "label3";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(468, 330);
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
            this.groupBox1.Location = new System.Drawing.Point(10, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 57);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projektionsfarben";
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
            // checkBoxFontScaling
            // 
            this.checkBoxFontScaling.AutoSize = true;
            this.checkBoxFontScaling.Location = new System.Drawing.Point(18, 118);
            this.checkBoxFontScaling.Name = "checkBoxFontScaling";
            this.checkBoxFontScaling.Size = new System.Drawing.Size(317, 17);
            this.checkBoxFontScaling.TabIndex = 38;
            this.checkBoxFontScaling.Text = "Projektionsschrift herunterskalieren falls Schriftgrösse zu gross";
            this.checkBoxFontScaling.UseVisualStyleBackColor = true;
            this.checkBoxFontScaling.CheckedChanged += new System.EventHandler(this.checkBoxFontScaling_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(8, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(612, 302);
            this.tabControl1.TabIndex = 39;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(604, 276);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Allgemeines";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.checkBoxFontScaling);
            this.tabPage2.Controls.Add(this.buttonFontSelector);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(604, 276);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Projektion";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.buttonAddSongPart);
            this.tabPage3.Controls.Add(this.textBoxNewSongPart);
            this.tabPage3.Controls.Add(this.buttonDelSongParts);
            this.tabPage3.Controls.Add(this.listBoxSongParts);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.buttonAddLang);
            this.tabPage3.Controls.Add(this.textBoxNewLang);
            this.tabPage3.Controls.Add(this.buttonDelLang);
            this.tabPage3.Controls.Add(this.listBoxLanguages);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.buttonAddTag);
            this.tabPage3.Controls.Add(this.textBoxNewTag);
            this.tabPage3.Controls.Add(this.buttonDelTags);
            this.tabPage3.Controls.Add(this.listBoxTags);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(604, 276);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Vorgaben";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listBoxTags
            // 
            this.listBoxTags.FormattingEnabled = true;
            this.listBoxTags.Location = new System.Drawing.Point(6, 52);
            this.listBoxTags.Name = "listBoxTags";
            this.listBoxTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxTags.Size = new System.Drawing.Size(186, 186);
            this.listBoxTags.TabIndex = 0;
            // 
            // buttonDelTags
            // 
            this.buttonDelTags.Location = new System.Drawing.Point(6, 247);
            this.buttonDelTags.Name = "buttonDelTags";
            this.buttonDelTags.Size = new System.Drawing.Size(186, 23);
            this.buttonDelTags.TabIndex = 1;
            this.buttonDelTags.Text = "Markierte löschen";
            this.buttonDelTags.UseVisualStyleBackColor = true;
            this.buttonDelTags.Click += new System.EventHandler(this.buttonDelTags_Click);
            // 
            // textBoxNewTag
            // 
            this.textBoxNewTag.Location = new System.Drawing.Point(6, 26);
            this.textBoxNewTag.Name = "textBoxNewTag";
            this.textBoxNewTag.Size = new System.Drawing.Size(105, 20);
            this.textBoxNewTag.TabIndex = 2;
            // 
            // buttonAddTag
            // 
            this.buttonAddTag.Location = new System.Drawing.Point(117, 25);
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.Size = new System.Drawing.Size(75, 23);
            this.buttonAddTag.TabIndex = 3;
            this.buttonAddTag.Text = "Hinzufügen";
            this.buttonAddTag.UseVisualStyleBackColor = true;
            this.buttonAddTag.Click += new System.EventHandler(this.buttonAddTag_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tags:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(208, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Sprachen:";
            // 
            // buttonAddLang
            // 
            this.buttonAddLang.Location = new System.Drawing.Point(318, 25);
            this.buttonAddLang.Name = "buttonAddLang";
            this.buttonAddLang.Size = new System.Drawing.Size(75, 23);
            this.buttonAddLang.TabIndex = 8;
            this.buttonAddLang.Text = "Hinzufügen";
            this.buttonAddLang.UseVisualStyleBackColor = true;
            this.buttonAddLang.Click += new System.EventHandler(this.buttonAddLang_Click);
            // 
            // textBoxNewLang
            // 
            this.textBoxNewLang.Location = new System.Drawing.Point(207, 26);
            this.textBoxNewLang.Name = "textBoxNewLang";
            this.textBoxNewLang.Size = new System.Drawing.Size(105, 20);
            this.textBoxNewLang.TabIndex = 7;
            // 
            // buttonDelLang
            // 
            this.buttonDelLang.Location = new System.Drawing.Point(207, 247);
            this.buttonDelLang.Name = "buttonDelLang";
            this.buttonDelLang.Size = new System.Drawing.Size(186, 23);
            this.buttonDelLang.TabIndex = 6;
            this.buttonDelLang.Text = "Markierte löschen";
            this.buttonDelLang.UseVisualStyleBackColor = true;
            this.buttonDelLang.Click += new System.EventHandler(this.buttonDelLang_Click);
            // 
            // listBoxLanguages
            // 
            this.listBoxLanguages.FormattingEnabled = true;
            this.listBoxLanguages.Location = new System.Drawing.Point(207, 52);
            this.listBoxLanguages.Name = "listBoxLanguages";
            this.listBoxLanguages.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxLanguages.Size = new System.Drawing.Size(186, 186);
            this.listBoxLanguages.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(412, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Liedteile:";
            // 
            // buttonAddSongPart
            // 
            this.buttonAddSongPart.Location = new System.Drawing.Point(522, 25);
            this.buttonAddSongPart.Name = "buttonAddSongPart";
            this.buttonAddSongPart.Size = new System.Drawing.Size(75, 23);
            this.buttonAddSongPart.TabIndex = 13;
            this.buttonAddSongPart.Text = "Hinzufügen";
            this.buttonAddSongPart.UseVisualStyleBackColor = true;
            this.buttonAddSongPart.Click += new System.EventHandler(this.buttonAddSongPart_Click);
            // 
            // textBoxNewSongPart
            // 
            this.textBoxNewSongPart.Location = new System.Drawing.Point(411, 26);
            this.textBoxNewSongPart.Name = "textBoxNewSongPart";
            this.textBoxNewSongPart.Size = new System.Drawing.Size(105, 20);
            this.textBoxNewSongPart.TabIndex = 12;
            // 
            // buttonDelSongParts
            // 
            this.buttonDelSongParts.Location = new System.Drawing.Point(411, 247);
            this.buttonDelSongParts.Name = "buttonDelSongParts";
            this.buttonDelSongParts.Size = new System.Drawing.Size(186, 23);
            this.buttonDelSongParts.TabIndex = 11;
            this.buttonDelSongParts.Text = "Markierte löschen";
            this.buttonDelSongParts.UseVisualStyleBackColor = true;
            this.buttonDelSongParts.Click += new System.EventHandler(this.buttonDelSongParts_Click);
            // 
            // listBoxSongParts
            // 
            this.listBoxSongParts.FormattingEnabled = true;
            this.listBoxSongParts.Location = new System.Drawing.Point(411, 52);
            this.listBoxSongParts.Name = "listBoxSongParts";
            this.listBoxSongParts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSongParts.Size = new System.Drawing.Size(186, 186);
            this.listBoxSongParts.TabIndex = 10;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(604, 276);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Editor";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(316, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Momentan sind noch keine Einstellungsmöglichkeiten vorhanden!";
            // 
            // settingsWindow
            // 
            this.AcceptButton = this.exitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(626, 365);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.exitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "settingsWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.settingsWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddTag;
        private System.Windows.Forms.TextBox textBoxNewTag;
        private System.Windows.Forms.Button buttonDelTags;
        private System.Windows.Forms.ListBox listBoxTags;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAddLang;
        private System.Windows.Forms.TextBox textBoxNewLang;
        private System.Windows.Forms.Button buttonDelLang;
        private System.Windows.Forms.ListBox listBoxLanguages;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAddSongPart;
        private System.Windows.Forms.TextBox textBoxNewSongPart;
        private System.Windows.Forms.Button buttonDelSongParts;
        private System.Windows.Forms.ListBox listBoxSongParts;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label7;
    }
}