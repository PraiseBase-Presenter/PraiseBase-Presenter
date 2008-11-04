namespace Pbp.Forms
{
	partial class PraiseBoxImporter
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
			this.listViewSongs = new System.Windows.Forms.ListView();
			this.buttonImport = new System.Windows.Forms.Button();
			this.checkBoxUseEditor = new System.Windows.Forms.CheckBox();
			this.listViewDetails = new System.Windows.Forms.ListView();
			this.column1 = new System.Windows.Forms.ColumnHeader();
			this.column2 = new System.Windows.Forms.ColumnHeader();
			this.buttonSelAll = new System.Windows.Forms.Button();
			this.buttonDSelAll = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listViewSongs
			// 
			this.listViewSongs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.listViewSongs.CheckBoxes = true;
			this.listViewSongs.FullRowSelect = true;
			this.listViewSongs.Location = new System.Drawing.Point(12, 12);
			this.listViewSongs.MultiSelect = false;
			this.listViewSongs.Name = "listViewSongs";
			this.listViewSongs.Size = new System.Drawing.Size(188, 301);
			this.listViewSongs.TabIndex = 0;
			this.listViewSongs.UseCompatibleStateImageBehavior = false;
			this.listViewSongs.View = System.Windows.Forms.View.List;
			this.listViewSongs.SelectedIndexChanged += new System.EventHandler(this.listViewSongs_SelectedIndexChanged);
			// 
			// buttonImport
			// 
			this.buttonImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonImport.Location = new System.Drawing.Point(440, 321);
			this.buttonImport.Name = "buttonImport";
			this.buttonImport.Size = new System.Drawing.Size(112, 23);
			this.buttonImport.TabIndex = 2;
			this.buttonImport.Text = "Importieren";
			this.buttonImport.UseVisualStyleBackColor = true;
			this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
			// 
			// checkBoxUseEditor
			// 
			this.checkBoxUseEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxUseEditor.AutoSize = true;
			this.checkBoxUseEditor.Location = new System.Drawing.Point(229, 325);
			this.checkBoxUseEditor.Name = "checkBoxUseEditor";
			this.checkBoxUseEditor.Size = new System.Drawing.Size(201, 17);
			this.checkBoxUseEditor.TabIndex = 3;
			this.checkBoxUseEditor.Text = "Lieder anschliessend im Editor öffnen";
			this.checkBoxUseEditor.UseVisualStyleBackColor = true;
			// 
			// listViewDetails
			// 
			this.listViewDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listViewDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column1,
            this.column2});
			this.listViewDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listViewDetails.FullRowSelect = true;
			this.listViewDetails.Location = new System.Drawing.Point(206, 12);
			this.listViewDetails.MultiSelect = false;
			this.listViewDetails.Name = "listViewDetails";
			this.listViewDetails.Size = new System.Drawing.Size(473, 301);
			this.listViewDetails.TabIndex = 4;
			this.listViewDetails.UseCompatibleStateImageBehavior = false;
			this.listViewDetails.View = System.Windows.Forms.View.Details;
			// 
			// column1
			// 
			this.column1.Text = "Abschnitt";
			this.column1.Width = 148;
			// 
			// column2
			// 
			this.column2.Text = "Text";
			this.column2.Width = 165;
			// 
			// buttonSelAll
			// 
			this.buttonSelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonSelAll.Location = new System.Drawing.Point(12, 321);
			this.buttonSelAll.Name = "buttonSelAll";
			this.buttonSelAll.Size = new System.Drawing.Size(91, 23);
			this.buttonSelAll.TabIndex = 5;
			this.buttonSelAll.Text = "Allle auswählen";
			this.buttonSelAll.UseVisualStyleBackColor = true;
			this.buttonSelAll.Click += new System.EventHandler(this.buttonSelAll_Click);
			// 
			// buttonDSelAll
			// 
			this.buttonDSelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonDSelAll.Location = new System.Drawing.Point(109, 321);
			this.buttonDSelAll.Name = "buttonDSelAll";
			this.buttonDSelAll.Size = new System.Drawing.Size(91, 23);
			this.buttonDSelAll.TabIndex = 6;
			this.buttonDSelAll.Text = "Allle abwählen";
			this.buttonDSelAll.UseVisualStyleBackColor = true;
			this.buttonDSelAll.Click += new System.EventHandler(this.buttonDSelAll_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(567, 321);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(112, 23);
			this.buttonCancel.TabIndex = 7;
			this.buttonCancel.Text = "Abbrechen";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// PraiseBoxImporter
			// 
			this.AcceptButton = this.buttonImport;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(691, 352);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonDSelAll);
			this.Controls.Add(this.buttonSelAll);
			this.Controls.Add(this.listViewDetails);
			this.Controls.Add(this.checkBoxUseEditor);
			this.Controls.Add(this.buttonImport);
			this.Controls.Add(this.listViewSongs);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(699, 379);
			this.Name = "PraiseBoxImporter";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PraiseBox Importer";
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
	}
}