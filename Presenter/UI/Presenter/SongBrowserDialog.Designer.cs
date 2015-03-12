namespace PraiseBase.Presenter.UI.Presenter
{
	partial class SongBrowserDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongBrowserDialog));
            this.listViewItems = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedListBoxTags = new System.Windows.Forms.CheckedListBox();
            this.checkBoxQASegmentation = new System.Windows.Forms.CheckBox();
            this.checkBoxQAImages = new System.Windows.Forms.CheckBox();
            this.checkBoxQATranslation = new System.Windows.Forms.CheckBox();
            this.checkBoxQASpelling = new System.Windows.Forms.CheckBox();
            this.checkBoxHasComments = new System.Windows.Forms.CheckBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxHasNoTranslation = new System.Windows.Forms.CheckBox();
            this.checkBoxHasImages = new System.Windows.Forms.CheckBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonUseInEditor = new System.Windows.Forms.Button();
            this.buttonUseInSetlist = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelResults = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewItems
            // 
            resources.ApplyResources(this.listViewItems, "listViewItems");
            this.listViewItems.FullRowSelect = true;
            this.listViewItems.HideSelection = false;
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.View = System.Windows.Forms.View.List;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.checkedListBoxTags);
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
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // checkedListBoxTags
            // 
            resources.ApplyResources(this.checkedListBoxTags, "checkedListBoxTags");
            this.checkedListBoxTags.CheckOnClick = true;
            this.checkedListBoxTags.FormattingEnabled = true;
            this.checkedListBoxTags.MultiColumn = true;
            this.checkedListBoxTags.Name = "checkedListBoxTags";
            // 
            // checkBoxQASegmentation
            // 
            resources.ApplyResources(this.checkBoxQASegmentation, "checkBoxQASegmentation");
            this.checkBoxQASegmentation.Name = "checkBoxQASegmentation";
            this.checkBoxQASegmentation.UseVisualStyleBackColor = true;
            // 
            // checkBoxQAImages
            // 
            resources.ApplyResources(this.checkBoxQAImages, "checkBoxQAImages");
            this.checkBoxQAImages.Name = "checkBoxQAImages";
            this.checkBoxQAImages.UseVisualStyleBackColor = true;
            // 
            // checkBoxQATranslation
            // 
            resources.ApplyResources(this.checkBoxQATranslation, "checkBoxQATranslation");
            this.checkBoxQATranslation.Name = "checkBoxQATranslation";
            this.checkBoxQATranslation.UseVisualStyleBackColor = true;
            // 
            // checkBoxQASpelling
            // 
            resources.ApplyResources(this.checkBoxQASpelling, "checkBoxQASpelling");
            this.checkBoxQASpelling.Name = "checkBoxQASpelling";
            this.checkBoxQASpelling.UseVisualStyleBackColor = true;
            // 
            // checkBoxHasComments
            // 
            resources.ApplyResources(this.checkBoxHasComments, "checkBoxHasComments");
            this.checkBoxHasComments.Name = "checkBoxHasComments";
            this.checkBoxHasComments.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            resources.ApplyResources(this.buttonReset, "buttonReset");
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonSearch
            // 
            resources.ApplyResources(this.buttonSearch, "buttonSearch");
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // checkBoxHasNoTranslation
            // 
            resources.ApplyResources(this.checkBoxHasNoTranslation, "checkBoxHasNoTranslation");
            this.checkBoxHasNoTranslation.Name = "checkBoxHasNoTranslation";
            this.checkBoxHasNoTranslation.UseVisualStyleBackColor = true;
            // 
            // checkBoxHasImages
            // 
            resources.ApplyResources(this.checkBoxHasImages, "checkBoxHasImages");
            this.checkBoxHasImages.Name = "checkBoxHasImages";
            this.checkBoxHasImages.UseVisualStyleBackColor = true;
            // 
            // textBoxSearch
            // 
            resources.ApplyResources(this.textBoxSearch, "textBoxSearch");
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyUp);
            // 
            // buttonUseInEditor
            // 
            resources.ApplyResources(this.buttonUseInEditor, "buttonUseInEditor");
            this.buttonUseInEditor.Name = "buttonUseInEditor";
            this.buttonUseInEditor.UseVisualStyleBackColor = true;
            this.buttonUseInEditor.Click += new System.EventHandler(this.buttonUseInEditor_Click);
            // 
            // buttonUseInSetlist
            // 
            resources.ApplyResources(this.buttonUseInSetlist, "buttonUseInSetlist");
            this.buttonUseInSetlist.Name = "buttonUseInSetlist";
            this.buttonUseInSetlist.UseVisualStyleBackColor = true;
            this.buttonUseInSetlist.Click += new System.EventHandler(this.buttonUseInSetlist_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelResults
            // 
            resources.ApplyResources(this.labelResults, "labelResults");
            this.labelResults.Name = "labelResults";
            // 
            // SongBrowserDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.labelResults);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonUseInSetlist);
            this.Controls.Add(this.buttonUseInEditor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listViewItems);
            this.MinimizeBox = false;
            this.Name = "SongBrowserDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
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
		private System.Windows.Forms.CheckedListBox checkedListBoxTags;
	}
}