namespace PraiseBase.Presenter.Forms
{
	partial class ImageDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageDialog));
            this.treeViewDirs = new System.Windows.Forms.TreeView();
            this.listViewImages = new System.Windows.Forms.ListView();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.checkBoxForAll = new System.Windows.Forms.CheckBox();
            this.tabControlBackgroundType = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonSelectColor = new System.Windows.Forms.Button();
            this.pictureBoxColor = new System.Windows.Forms.PictureBox();
            this.tabControlBackgroundType.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewDirs
            // 
            resources.ApplyResources(this.treeViewDirs, "treeViewDirs");
            this.treeViewDirs.HideSelection = false;
            this.treeViewDirs.Name = "treeViewDirs";
            this.treeViewDirs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDirs_AfterSelect);
            // 
            // listViewImages
            // 
            resources.ApplyResources(this.listViewImages, "listViewImages");
            this.listViewImages.HideSelection = false;
            this.listViewImages.MultiSelect = false;
            this.listViewImages.Name = "listViewImages";
            this.listViewImages.UseCompatibleStateImageBehavior = false;
            this.listViewImages.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewImages_ItemSelectionChanged);
            this.listViewImages.DoubleClick += new System.EventHandler(this.listViewImages_DoubleClick);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // checkBoxForAll
            // 
            resources.ApplyResources(this.checkBoxForAll, "checkBoxForAll");
            this.checkBoxForAll.Name = "checkBoxForAll";
            this.checkBoxForAll.UseVisualStyleBackColor = true;
            // 
            // tabControlBackgroundType
            // 
            this.tabControlBackgroundType.Controls.Add(this.tabPage1);
            this.tabControlBackgroundType.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControlBackgroundType, "tabControlBackgroundType");
            this.tabControlBackgroundType.Name = "tabControlBackgroundType";
            this.tabControlBackgroundType.SelectedIndex = 0;
            this.tabControlBackgroundType.SelectedIndexChanged += new System.EventHandler(this.tabControlBackgroundType_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeViewDirs);
            this.tabPage1.Controls.Add(this.listViewImages);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonSelectColor);
            this.tabPage2.Controls.Add(this.pictureBoxColor);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonSelectColor
            // 
            resources.ApplyResources(this.buttonSelectColor, "buttonSelectColor");
            this.buttonSelectColor.Name = "buttonSelectColor";
            this.buttonSelectColor.UseVisualStyleBackColor = true;
            this.buttonSelectColor.Click += new System.EventHandler(this.buttonSelectColor_Click);
            // 
            // pictureBoxColor
            // 
            this.pictureBoxColor.BackColor = System.Drawing.Color.Black;
            this.pictureBoxColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxColor.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.pictureBoxColor, "pictureBoxColor");
            this.pictureBoxColor.Name = "pictureBoxColor";
            this.pictureBoxColor.TabStop = false;
            this.pictureBoxColor.Click += new System.EventHandler(this.pictureBoxColor_Click);
            // 
            // ImageDialog
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.tabControlBackgroundType);
            this.Controls.Add(this.checkBoxForAll);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.MinimizeBox = false;
            this.Name = "ImageDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.ImageDialog_Load);
            this.tabControlBackgroundType.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeViewDirs;
		private System.Windows.Forms.ListView listViewImages;
		private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.CheckBox checkBoxForAll;
        private System.Windows.Forms.TabControl tabControlBackgroundType;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonSelectColor;
        private System.Windows.Forms.PictureBox pictureBoxColor;
	}
}