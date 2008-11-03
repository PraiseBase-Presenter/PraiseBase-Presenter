namespace Pbp.Forms
{
	partial class SongDialog
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
			this.listViewItems = new System.Windows.Forms.ListView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBoxSearch = new System.Windows.Forms.TextBox();
			this.checkBoxHasImages = new System.Windows.Forms.CheckBox();
			this.checkBoxHasNoTranslation = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonSearch = new System.Windows.Forms.Button();
			this.buttonReset = new System.Windows.Forms.Button();
			this.buttonUseInEditor = new System.Windows.Forms.Button();
			this.buttonUseInSetlist = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelResults = new System.Windows.Forms.Label();
			this.checkBoxHasComments = new System.Windows.Forms.CheckBox();
			this.checkBoxQASpelling = new System.Windows.Forms.CheckBox();
			this.checkBoxQATranslation = new System.Windows.Forms.CheckBox();
			this.checkBoxQAImages = new System.Windows.Forms.CheckBox();
			this.checkBoxQASegmentation = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listViewItems
			// 
			this.listViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listViewItems.Location = new System.Drawing.Point(12, 114);
			this.listViewItems.Name = "listViewItems";
			this.listViewItems.Size = new System.Drawing.Size(633, 270);
			this.listViewItems.TabIndex = 0;
			this.listViewItems.UseCompatibleStateImageBehavior = false;
			this.listViewItems.View = System.Windows.Forms.View.List;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.checkBoxQASegmentation);
			this.groupBox1.Controls.Add(this.checkBoxQAImages);
			this.groupBox1.Controls.Add(this.checkBoxQATranslation);
			this.groupBox1.Controls.Add(this.checkBoxQASpelling);
			this.groupBox1.Controls.Add(this.checkBoxHasComments);
			this.groupBox1.Controls.Add(this.buttonReset);
			this.groupBox1.Controls.Add(this.buttonSearch);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.checkBoxHasNoTranslation);
			this.groupBox1.Controls.Add(this.checkBoxHasImages);
			this.groupBox1.Controls.Add(this.textBoxSearch);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(633, 96);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filter";
			// 
			// textBoxSearch
			// 
			this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxSearch.Location = new System.Drawing.Point(62, 19);
			this.textBoxSearch.Name = "textBoxSearch";
			this.textBoxSearch.Size = new System.Drawing.Size(556, 22);
			this.textBoxSearch.TabIndex = 0;
			// 
			// checkBoxHasImages
			// 
			this.checkBoxHasImages.AutoSize = true;
			this.checkBoxHasImages.Location = new System.Drawing.Point(18, 47);
			this.checkBoxHasImages.Name = "checkBoxHasImages";
			this.checkBoxHasImages.Size = new System.Drawing.Size(101, 17);
			this.checkBoxHasImages.TabIndex = 1;
			this.checkBoxHasImages.Text = "Hat keine Bilder";
			this.checkBoxHasImages.UseVisualStyleBackColor = true;
			// 
			// checkBoxHasNoTranslation
			// 
			this.checkBoxHasNoTranslation.AutoSize = true;
			this.checkBoxHasNoTranslation.Location = new System.Drawing.Point(147, 47);
			this.checkBoxHasNoTranslation.Name = "checkBoxHasNoTranslation";
			this.checkBoxHasNoTranslation.Size = new System.Drawing.Size(135, 17);
			this.checkBoxHasNoTranslation.TabIndex = 2;
			this.checkBoxHasNoTranslation.Text = "Hat keine Übersetzung";
			this.checkBoxHasNoTranslation.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Suche:";
			// 
			// buttonSearch
			// 
			this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSearch.Location = new System.Drawing.Point(444, 66);
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.Size = new System.Drawing.Size(75, 23);
			this.buttonSearch.TabIndex = 5;
			this.buttonSearch.Text = "Suchen";
			this.buttonSearch.UseVisualStyleBackColor = true;
			this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
			// 
			// buttonReset
			// 
			this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonReset.Location = new System.Drawing.Point(525, 66);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(93, 23);
			this.buttonReset.TabIndex = 6;
			this.buttonReset.Text = "Zurücksetzen";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
			// 
			// buttonUseInEditor
			// 
			this.buttonUseInEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUseInEditor.Location = new System.Drawing.Point(312, 390);
			this.buttonUseInEditor.Name = "buttonUseInEditor";
			this.buttonUseInEditor.Size = new System.Drawing.Size(123, 23);
			this.buttonUseInEditor.TabIndex = 2;
			this.buttonUseInEditor.Text = "In den Editor laden";
			this.buttonUseInEditor.UseVisualStyleBackColor = true;
			this.buttonUseInEditor.Click += new System.EventHandler(this.buttonUseInEditor_Click);
			// 
			// buttonUseInSetlist
			// 
			this.buttonUseInSetlist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUseInSetlist.Location = new System.Drawing.Point(441, 390);
			this.buttonUseInSetlist.Name = "buttonUseInSetlist";
			this.buttonUseInSetlist.Size = new System.Drawing.Size(123, 23);
			this.buttonUseInSetlist.TabIndex = 3;
			this.buttonUseInSetlist.Text = "In die Setliste laden";
			this.buttonUseInSetlist.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(570, 390);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Abbrechen";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelResults
			// 
			this.labelResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelResults.AutoSize = true;
			this.labelResults.Location = new System.Drawing.Point(13, 394);
			this.labelResults.Name = "labelResults";
			this.labelResults.Size = new System.Drawing.Size(10, 13);
			this.labelResults.TabIndex = 5;
			this.labelResults.Text = "-";
			// 
			// checkBoxHasComments
			// 
			this.checkBoxHasComments.AutoSize = true;
			this.checkBoxHasComments.Location = new System.Drawing.Point(300, 47);
			this.checkBoxHasComments.Name = "checkBoxHasComments";
			this.checkBoxHasComments.Size = new System.Drawing.Size(105, 17);
			this.checkBoxHasComments.TabIndex = 6;
			this.checkBoxHasComments.Text = "Hat Kommentare";
			this.checkBoxHasComments.UseVisualStyleBackColor = true;
			// 
			// checkBoxQASpelling
			// 
			this.checkBoxQASpelling.AutoSize = true;
			this.checkBoxQASpelling.Location = new System.Drawing.Point(18, 72);
			this.checkBoxQASpelling.Name = "checkBoxQASpelling";
			this.checkBoxQASpelling.Size = new System.Drawing.Size(128, 17);
			this.checkBoxQASpelling.TabIndex = 7;
			this.checkBoxQASpelling.Text = "QA: Rechtschreibung";
			this.checkBoxQASpelling.UseVisualStyleBackColor = true;
			// 
			// checkBoxQATranslation
			// 
			this.checkBoxQATranslation.AutoSize = true;
			this.checkBoxQATranslation.Location = new System.Drawing.Point(152, 72);
			this.checkBoxQATranslation.Name = "checkBoxQATranslation";
			this.checkBoxQATranslation.Size = new System.Drawing.Size(107, 17);
			this.checkBoxQATranslation.TabIndex = 8;
			this.checkBoxQATranslation.Text = "QA: Übersetzung";
			this.checkBoxQATranslation.UseVisualStyleBackColor = true;
			// 
			// checkBoxQAImages
			// 
			this.checkBoxQAImages.AutoSize = true;
			this.checkBoxQAImages.Location = new System.Drawing.Point(265, 72);
			this.checkBoxQAImages.Name = "checkBoxQAImages";
			this.checkBoxQAImages.Size = new System.Drawing.Size(73, 17);
			this.checkBoxQAImages.TabIndex = 9;
			this.checkBoxQAImages.Text = "QA: Bilder";
			this.checkBoxQAImages.UseVisualStyleBackColor = true;
			// 
			// checkBoxQASegmentation
			// 
			this.checkBoxQASegmentation.AutoSize = true;
			this.checkBoxQASegmentation.Location = new System.Drawing.Point(344, 72);
			this.checkBoxQASegmentation.Name = "checkBoxQASegmentation";
			this.checkBoxQASegmentation.Size = new System.Drawing.Size(94, 17);
			this.checkBoxQASegmentation.TabIndex = 10;
			this.checkBoxQASegmentation.Text = "QA: Aufteilung";
			this.checkBoxQASegmentation.UseVisualStyleBackColor = true;
			// 
			// SongDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(657, 419);
			this.Controls.Add(this.labelResults);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonUseInSetlist);
			this.Controls.Add(this.buttonUseInEditor);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.listViewItems);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(665, 446);
			this.Name = "SongDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Liederbrowser";
			this.Load += new System.EventHandler(this.SongDialog_Load);
			this.Shown += new System.EventHandler(this.SongDialog_Shown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listViewItems;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBoxSearch;
		private System.Windows.Forms.CheckBox checkBoxHasNoTranslation;
		private System.Windows.Forms.CheckBox checkBoxHasImages;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonReset;
		private System.Windows.Forms.Button buttonSearch;
		private System.Windows.Forms.Button buttonUseInEditor;
		private System.Windows.Forms.Button buttonUseInSetlist;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelResults;
		private System.Windows.Forms.CheckBox checkBoxHasComments;
		private System.Windows.Forms.CheckBox checkBoxQASegmentation;
		private System.Windows.Forms.CheckBox checkBoxQAImages;
		private System.Windows.Forms.CheckBox checkBoxQATranslation;
		private System.Windows.Forms.CheckBox checkBoxQASpelling;
	}
}