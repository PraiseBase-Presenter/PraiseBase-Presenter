namespace Pbp.Forms
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
            this.buttonNoImage = new System.Windows.Forms.Button();
            this.checkBoxForAll = new System.Windows.Forms.CheckBox();
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
            // buttonNoImage
            // 
            resources.ApplyResources(this.buttonNoImage, "buttonNoImage");
            this.buttonNoImage.Name = "buttonNoImage";
            this.buttonNoImage.UseVisualStyleBackColor = true;
            this.buttonNoImage.Click += new System.EventHandler(this.buttonNoImage_Click);
            // 
            // checkBoxForAll
            // 
            resources.ApplyResources(this.checkBoxForAll, "checkBoxForAll");
            this.checkBoxForAll.Name = "checkBoxForAll";
            this.checkBoxForAll.UseVisualStyleBackColor = true;
            // 
            // ImageDialog
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.checkBoxForAll);
            this.Controls.Add(this.buttonNoImage);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.listViewImages);
            this.Controls.Add(this.treeViewDirs);
            this.MinimizeBox = false;
            this.Name = "ImageDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.ImageDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeViewDirs;
		private System.Windows.Forms.ListView listViewImages;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonNoImage;
		private System.Windows.Forms.CheckBox checkBoxForAll;
	}
}