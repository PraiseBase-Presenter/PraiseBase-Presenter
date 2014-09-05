namespace PraiseBase.Presenter.Forms
{
	partial class SongImporter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongImporter));
            this.listViewSongs = new System.Windows.Forms.ListView();
            this.buttonImport = new System.Windows.Forms.Button();
            this.checkBoxUseEditor = new System.Windows.Forms.CheckBox();
            this.listViewDetails = new System.Windows.Forms.ListView();
            this.column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSelAll = new System.Windows.Forms.Button();
            this.buttonDSelAll = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewSongs
            // 
            resources.ApplyResources(this.listViewSongs, "listViewSongs");
            this.listViewSongs.CheckBoxes = true;
            this.listViewSongs.FullRowSelect = true;
            this.listViewSongs.MultiSelect = false;
            this.listViewSongs.Name = "listViewSongs";
            this.listViewSongs.UseCompatibleStateImageBehavior = false;
            this.listViewSongs.View = System.Windows.Forms.View.List;
            this.listViewSongs.SelectedIndexChanged += new System.EventHandler(this.listViewSongs_SelectedIndexChanged);
            // 
            // buttonImport
            // 
            resources.ApplyResources(this.buttonImport, "buttonImport");
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // checkBoxUseEditor
            // 
            resources.ApplyResources(this.checkBoxUseEditor, "checkBoxUseEditor");
            this.checkBoxUseEditor.Name = "checkBoxUseEditor";
            this.checkBoxUseEditor.UseVisualStyleBackColor = true;
            // 
            // listViewDetails
            // 
            resources.ApplyResources(this.listViewDetails, "listViewDetails");
            this.listViewDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column1,
            this.column2});
            this.listViewDetails.FullRowSelect = true;
            this.listViewDetails.MultiSelect = false;
            this.listViewDetails.Name = "listViewDetails";
            this.listViewDetails.UseCompatibleStateImageBehavior = false;
            this.listViewDetails.View = System.Windows.Forms.View.Details;
            // 
            // column1
            // 
            resources.ApplyResources(this.column1, "column1");
            // 
            // column2
            // 
            resources.ApplyResources(this.column2, "column2");
            // 
            // buttonSelAll
            // 
            resources.ApplyResources(this.buttonSelAll, "buttonSelAll");
            this.buttonSelAll.Name = "buttonSelAll";
            this.buttonSelAll.UseVisualStyleBackColor = true;
            this.buttonSelAll.Click += new System.EventHandler(this.buttonSelAll_Click);
            // 
            // buttonDSelAll
            // 
            resources.ApplyResources(this.buttonDSelAll, "buttonDSelAll");
            this.buttonDSelAll.Name = "buttonDSelAll";
            this.buttonDSelAll.UseVisualStyleBackColor = true;
            this.buttonDSelAll.Click += new System.EventHandler(this.buttonDSelAll_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // SongImporter
            // 
            this.AcceptButton = this.buttonImport;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDSelAll);
            this.Controls.Add(this.buttonSelAll);
            this.Controls.Add(this.listViewDetails);
            this.Controls.Add(this.checkBoxUseEditor);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.listViewSongs);
            this.MinimizeBox = false;
            this.Name = "SongImporter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.PraiseBoxImporter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listViewSongs;
		private System.Windows.Forms.Button buttonImport;
		private System.Windows.Forms.CheckBox checkBoxUseEditor;
		private System.Windows.Forms.ListView listViewDetails;
		private System.Windows.Forms.ColumnHeader column1;
		private System.Windows.Forms.ColumnHeader column2;
		private System.Windows.Forms.Button buttonSelAll;
		private System.Windows.Forms.Button buttonDSelAll;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}