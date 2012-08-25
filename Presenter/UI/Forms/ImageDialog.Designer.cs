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
			this.treeViewDirs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.treeViewDirs.HideSelection = false;
			this.treeViewDirs.Location = new System.Drawing.Point(3, 12);
			this.treeViewDirs.Name = "treeViewDirs";
			this.treeViewDirs.Size = new System.Drawing.Size(204, 510);
			this.treeViewDirs.TabIndex = 0;
			this.treeViewDirs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDirs_AfterSelect);
			// 
			// listViewImages
			// 
			this.listViewImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listViewImages.HideSelection = false;
			this.listViewImages.Location = new System.Drawing.Point(213, 12);
			this.listViewImages.MultiSelect = false;
			this.listViewImages.Name = "listViewImages";
			this.listViewImages.Size = new System.Drawing.Size(615, 476);
			this.listViewImages.TabIndex = 1;
			this.listViewImages.UseCompatibleStateImageBehavior = false;
			this.listViewImages.DoubleClick += new System.EventHandler(this.listViewImages_DoubleClick);
			this.listViewImages.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewImages_ItemSelectionChanged);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(753, 499);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Abbrechen";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Enabled = false;
			this.buttonOK.Location = new System.Drawing.Point(529, 499);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(106, 23);
			this.buttonOK.TabIndex = 3;
			this.buttonOK.Text = "Bild verwenden";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonNoImage
			// 
			this.buttonNoImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonNoImage.Location = new System.Drawing.Point(641, 499);
			this.buttonNoImage.Name = "buttonNoImage";
			this.buttonNoImage.Size = new System.Drawing.Size(106, 23);
			this.buttonNoImage.TabIndex = 4;
			this.buttonNoImage.Text = "Kein Bild";
			this.buttonNoImage.UseVisualStyleBackColor = true;
			this.buttonNoImage.Click += new System.EventHandler(this.buttonNoImage_Click);
			// 
			// checkBoxForAll
			// 
			this.checkBoxForAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxForAll.AutoSize = true;
			this.checkBoxForAll.Location = new System.Drawing.Point(223, 503);
			this.checkBoxForAll.Name = "checkBoxForAll";
			this.checkBoxForAll.Size = new System.Drawing.Size(153, 17);
			this.checkBoxForAll.TabIndex = 5;
			this.checkBoxForAll.Text = "Für alle Folien übernehmen";
			this.checkBoxForAll.UseVisualStyleBackColor = true;
			// 
			// ImageDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(840, 534);
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
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bild wählen...";
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