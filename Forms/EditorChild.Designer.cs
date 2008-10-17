namespace Pbp.Forms
{
    partial class EditorChild
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorChild));
            this.treeViewContents = new System.Windows.Forms.TreeView();
            this.textBoxSongText = new System.Windows.Forms.TextBox();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.textBoxSongTitle = new System.Windows.Forms.TextBox();
            this.labelSongTitle = new System.Windows.Forms.Label();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.groupBoxSongSettings = new System.Windows.Forms.GroupBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.checkedListBoxTags = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxNewSongPart = new System.Windows.Forms.GroupBox();
            this.comboBoxSongParts = new System.Windows.Forms.ComboBox();
            this.buttonNewSongPart = new System.Windows.Forms.Button();
            this.labelNewSongPart = new System.Windows.Forms.Label();
            this.groupBoxSongPart = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSongPartCaption = new System.Windows.Forms.TextBox();
            this.groupBoxNewSlide = new System.Windows.Forms.GroupBox();
            this.buttonAddNewSlide = new System.Windows.Forms.Button();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.buttonDelItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.groupBoxSongSettings.SuspendLayout();
            this.groupBoxNewSongPart.SuspendLayout();
            this.groupBoxSongPart.SuspendLayout();
            this.groupBoxNewSlide.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewContents
            // 
            this.treeViewContents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewContents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewContents.HideSelection = false;
            this.treeViewContents.Location = new System.Drawing.Point(12, 12);
            this.treeViewContents.Name = "treeViewContents";
            this.treeViewContents.Size = new System.Drawing.Size(245, 524);
            this.treeViewContents.TabIndex = 0;
            this.treeViewContents.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewContents_AfterSelect);
            // 
            // textBoxSongText
            // 
            this.textBoxSongText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSongText.Location = new System.Drawing.Point(263, 428);
            this.textBoxSongText.Multiline = true;
            this.textBoxSongText.Name = "textBoxSongText";
            this.textBoxSongText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSongText.Size = new System.Drawing.Size(617, 135);
            this.textBoxSongText.TabIndex = 1;
            this.textBoxSongText.Visible = false;
            this.textBoxSongText.TextChanged += new System.EventHandler(this.textBoxSongText_TextChanged);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview.Location = new System.Drawing.Point(263, 12);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(617, 410);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPreview.TabIndex = 2;
            this.pictureBoxPreview.TabStop = false;
            this.pictureBoxPreview.Visible = false;
            // 
            // textBoxSongTitle
            // 
            this.textBoxSongTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSongTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSongTitle.Location = new System.Drawing.Point(97, 28);
            this.textBoxSongTitle.Name = "textBoxSongTitle";
            this.textBoxSongTitle.Size = new System.Drawing.Size(506, 26);
            this.textBoxSongTitle.TabIndex = 4;
            this.textBoxSongTitle.TextChanged += new System.EventHandler(this.textBoxSongTitle_TextChanged);
            // 
            // labelSongTitle
            // 
            this.labelSongTitle.AutoSize = true;
            this.labelSongTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSongTitle.Location = new System.Drawing.Point(8, 31);
            this.labelSongTitle.Name = "labelSongTitle";
            this.labelSongTitle.Size = new System.Drawing.Size(83, 20);
            this.labelSongTitle.TabIndex = 5;
            this.labelSongTitle.Text = "Liedname:";
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLanguage.Location = new System.Drawing.Point(8, 74);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(73, 20);
            this.labelLanguage.TabIndex = 6;
            this.labelLanguage.Text = "Sprache:";
            // 
            // groupBoxSongSettings
            // 
            this.groupBoxSongSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSongSettings.Controls.Add(this.comboBoxLanguage);
            this.groupBoxSongSettings.Controls.Add(this.checkedListBoxTags);
            this.groupBoxSongSettings.Controls.Add(this.label1);
            this.groupBoxSongSettings.Controls.Add(this.labelSongTitle);
            this.groupBoxSongSettings.Controls.Add(this.labelLanguage);
            this.groupBoxSongSettings.Controls.Add(this.textBoxSongTitle);
            this.groupBoxSongSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSongSettings.Location = new System.Drawing.Point(263, 8);
            this.groupBoxSongSettings.Name = "groupBoxSongSettings";
            this.groupBoxSongSettings.Size = new System.Drawing.Size(617, 281);
            this.groupBoxSongSettings.TabIndex = 8;
            this.groupBoxSongSettings.TabStop = false;
            this.groupBoxSongSettings.Text = "Liedeinstellungen";
            this.groupBoxSongSettings.Visible = false;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(97, 71);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(506, 28);
            this.comboBoxLanguage.TabIndex = 10;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
            // 
            // checkedListBoxTags
            // 
            this.checkedListBoxTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxTags.FormattingEnabled = true;
            this.checkedListBoxTags.Location = new System.Drawing.Point(97, 116);
            this.checkedListBoxTags.MultiColumn = true;
            this.checkedListBoxTags.Name = "checkedListBoxTags";
            this.checkedListBoxTags.Size = new System.Drawing.Size(506, 137);
            this.checkedListBoxTags.TabIndex = 9;
            this.checkedListBoxTags.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxTags_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tags:";
            // 
            // groupBoxNewSongPart
            // 
            this.groupBoxNewSongPart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxNewSongPart.Controls.Add(this.comboBoxSongParts);
            this.groupBoxNewSongPart.Controls.Add(this.buttonNewSongPart);
            this.groupBoxNewSongPart.Controls.Add(this.labelNewSongPart);
            this.groupBoxNewSongPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxNewSongPart.Location = new System.Drawing.Point(263, 295);
            this.groupBoxNewSongPart.Name = "groupBoxNewSongPart";
            this.groupBoxNewSongPart.Size = new System.Drawing.Size(617, 125);
            this.groupBoxNewSongPart.TabIndex = 9;
            this.groupBoxNewSongPart.TabStop = false;
            this.groupBoxNewSongPart.Text = "Neuer Liedteil";
            // 
            // comboBoxSongParts
            // 
            this.comboBoxSongParts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSongParts.FormattingEnabled = true;
            this.comboBoxSongParts.Location = new System.Drawing.Point(97, 33);
            this.comboBoxSongParts.Name = "comboBoxSongParts";
            this.comboBoxSongParts.Size = new System.Drawing.Size(506, 28);
            this.comboBoxSongParts.TabIndex = 11;
            // 
            // buttonNewSongPart
            // 
            this.buttonNewSongPart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewSongPart.Location = new System.Drawing.Point(435, 80);
            this.buttonNewSongPart.Name = "buttonNewSongPart";
            this.buttonNewSongPart.Size = new System.Drawing.Size(168, 28);
            this.buttonNewSongPart.TabIndex = 10;
            this.buttonNewSongPart.Text = "Hinzufügen";
            this.buttonNewSongPart.UseVisualStyleBackColor = true;
            this.buttonNewSongPart.Click += new System.EventHandler(this.buttonNewSongPart_Click);
            // 
            // labelNewSongPart
            // 
            this.labelNewSongPart.AutoSize = true;
            this.labelNewSongPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewSongPart.Location = new System.Drawing.Point(8, 36);
            this.labelNewSongPart.Name = "labelNewSongPart";
            this.labelNewSongPart.Size = new System.Drawing.Size(55, 20);
            this.labelNewSongPart.TabIndex = 8;
            this.labelNewSongPart.Text = "Name:";
            // 
            // groupBoxSongPart
            // 
            this.groupBoxSongPart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSongPart.Controls.Add(this.label3);
            this.groupBoxSongPart.Controls.Add(this.textBoxSongPartCaption);
            this.groupBoxSongPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSongPart.Location = new System.Drawing.Point(263, 8);
            this.groupBoxSongPart.Name = "groupBoxSongPart";
            this.groupBoxSongPart.Size = new System.Drawing.Size(617, 80);
            this.groupBoxSongPart.TabIndex = 10;
            this.groupBoxSongPart.TabStop = false;
            this.groupBoxSongPart.Text = "Liedteil-Einstellungen";
            this.groupBoxSongPart.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bezeichnung:";
            // 
            // textBoxSongPartCaption
            // 
            this.textBoxSongPartCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSongPartCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSongPartCaption.Location = new System.Drawing.Point(120, 28);
            this.textBoxSongPartCaption.Name = "textBoxSongPartCaption";
            this.textBoxSongPartCaption.Size = new System.Drawing.Size(483, 26);
            this.textBoxSongPartCaption.TabIndex = 4;
            this.textBoxSongPartCaption.TextChanged += new System.EventHandler(this.textBoxSongPartCaption_TextChanged);
            // 
            // groupBoxNewSlide
            // 
            this.groupBoxNewSlide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxNewSlide.Controls.Add(this.buttonAddNewSlide);
            this.groupBoxNewSlide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxNewSlide.Location = new System.Drawing.Point(263, 116);
            this.groupBoxNewSlide.Name = "groupBoxNewSlide";
            this.groupBoxNewSlide.Size = new System.Drawing.Size(617, 71);
            this.groupBoxNewSlide.TabIndex = 12;
            this.groupBoxNewSlide.TabStop = false;
            this.groupBoxNewSlide.Text = "Neue Folie";
            // 
            // buttonAddNewSlide
            // 
            this.buttonAddNewSlide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddNewSlide.Location = new System.Drawing.Point(435, 25);
            this.buttonAddNewSlide.Name = "buttonAddNewSlide";
            this.buttonAddNewSlide.Size = new System.Drawing.Size(168, 28);
            this.buttonAddNewSlide.TabIndex = 10;
            this.buttonAddNewSlide.Text = "Hinzufügen";
            this.buttonAddNewSlide.UseVisualStyleBackColor = true;
            this.buttonAddNewSlide.Click += new System.EventHandler(this.buttonAddNewSlide_Click);
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddItem.Location = new System.Drawing.Point(12, 542);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(85, 23);
            this.buttonAddItem.TabIndex = 13;
            this.buttonAddItem.Text = "Hinzufügen";
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // buttonDelItem
            // 
            this.buttonDelItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDelItem.Location = new System.Drawing.Point(169, 542);
            this.buttonDelItem.Name = "buttonDelItem";
            this.buttonDelItem.Size = new System.Drawing.Size(88, 23);
            this.buttonDelItem.TabIndex = 14;
            this.buttonDelItem.Text = "Löschen";
            this.buttonDelItem.UseVisualStyleBackColor = true;
            this.buttonDelItem.Click += new System.EventHandler(this.buttonDelItem_Click);
            // 
            // EditorChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 575);
            this.Controls.Add(this.buttonDelItem);
            this.Controls.Add(this.buttonAddItem);
            this.Controls.Add(this.groupBoxNewSongPart);
            this.Controls.Add(this.groupBoxSongPart);
            this.Controls.Add(this.textBoxSongText);
            this.Controls.Add(this.treeViewContents);
            this.Controls.Add(this.groupBoxNewSlide);
            this.Controls.Add(this.groupBoxSongSettings);
            this.Controls.Add(this.pictureBoxPreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditorChild";
            this.ShowInTaskbar = false;
            this.Text = "Liededitor";
            this.Load += new System.EventHandler(this.EditorChild_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.groupBoxSongSettings.ResumeLayout(false);
            this.groupBoxSongSettings.PerformLayout();
            this.groupBoxNewSongPart.ResumeLayout(false);
            this.groupBoxNewSongPart.PerformLayout();
            this.groupBoxSongPart.ResumeLayout(false);
            this.groupBoxSongPart.PerformLayout();
            this.groupBoxNewSlide.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewContents;
        private System.Windows.Forms.TextBox textBoxSongText;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.TextBox textBoxSongTitle;
        private System.Windows.Forms.Label labelSongTitle;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.GroupBox groupBoxSongSettings;
        private System.Windows.Forms.GroupBox groupBoxNewSongPart;
        private System.Windows.Forms.Label labelNewSongPart;
        private System.Windows.Forms.Button buttonNewSongPart;
        private System.Windows.Forms.CheckedListBox checkedListBoxTags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.ComboBox comboBoxSongParts;
        private System.Windows.Forms.GroupBox groupBoxSongPart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSongPartCaption;
        private System.Windows.Forms.GroupBox groupBoxNewSlide;
        private System.Windows.Forms.Button buttonAddNewSlide;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.Button buttonDelItem;
    }
}