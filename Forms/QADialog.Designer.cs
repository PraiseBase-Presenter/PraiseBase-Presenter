namespace Pbp.Forms
{
	partial class QADialog
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
			this.checkBoxQASegmentation = new System.Windows.Forms.CheckBox();
			this.checkBoxQAImages = new System.Windows.Forms.CheckBox();
			this.checkBoxQATranslation = new System.Windows.Forms.CheckBox();
			this.checkBoxQASpelling = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxComment = new System.Windows.Forms.TextBox();
			this.buttonAccept = new System.Windows.Forms.Button();
			this.buttonCancl = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// checkBoxQASegmentation
			// 
			this.checkBoxQASegmentation.AutoSize = true;
			this.checkBoxQASegmentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxQASegmentation.Location = new System.Drawing.Point(257, 168);
			this.checkBoxQASegmentation.Name = "checkBoxQASegmentation";
			this.checkBoxQASegmentation.Size = new System.Drawing.Size(155, 17);
			this.checkBoxQASegmentation.TabIndex = 32;
			this.checkBoxQASegmentation.Text = "Textaufteilung nicht optimal";
			this.checkBoxQASegmentation.UseVisualStyleBackColor = true;
			// 
			// checkBoxQAImages
			// 
			this.checkBoxQAImages.AutoSize = true;
			this.checkBoxQAImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxQAImages.Location = new System.Drawing.Point(15, 168);
			this.checkBoxQAImages.Name = "checkBoxQAImages";
			this.checkBoxQAImages.Size = new System.Drawing.Size(236, 17);
			this.checkBoxQAImages.TabIndex = 31;
			this.checkBoxQAImages.Text = "Bild(er) fehlen oder müssen geändert werden";
			this.checkBoxQAImages.UseVisualStyleBackColor = true;
			// 
			// checkBoxQATranslation
			// 
			this.checkBoxQATranslation.AutoSize = true;
			this.checkBoxQATranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxQATranslation.Location = new System.Drawing.Point(257, 144);
			this.checkBoxQATranslation.Name = "checkBoxQATranslation";
			this.checkBoxQATranslation.Size = new System.Drawing.Size(189, 17);
			this.checkBoxQATranslation.TabIndex = 30;
			this.checkBoxQATranslation.Text = "Übersetzung fehlt/ist unvollständig";
			this.checkBoxQATranslation.UseVisualStyleBackColor = true;
			// 
			// checkBoxQASpelling
			// 
			this.checkBoxQASpelling.AutoSize = true;
			this.checkBoxQASpelling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxQASpelling.Location = new System.Drawing.Point(15, 145);
			this.checkBoxQASpelling.Name = "checkBoxQASpelling";
			this.checkBoxQASpelling.Size = new System.Drawing.Size(114, 17);
			this.checkBoxQASpelling.TabIndex = 29;
			this.checkBoxQASpelling.Text = "Text enthält Fehler";
			this.checkBoxQASpelling.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(140, 13);
			this.label1.TabIndex = 34;
			this.label1.Text = "Kommentar / Bemerkungen:";
			// 
			// textBoxComment
			// 
			this.textBoxComment.Location = new System.Drawing.Point(12, 34);
			this.textBoxComment.Multiline = true;
			this.textBoxComment.Name = "textBoxComment";
			this.textBoxComment.Size = new System.Drawing.Size(439, 94);
			this.textBoxComment.TabIndex = 35;
			// 
			// buttonAccept
			// 
			this.buttonAccept.Location = new System.Drawing.Point(288, 199);
			this.buttonAccept.Name = "buttonAccept";
			this.buttonAccept.Size = new System.Drawing.Size(75, 23);
			this.buttonAccept.TabIndex = 36;
			this.buttonAccept.Text = "Speichern";
			this.buttonAccept.UseVisualStyleBackColor = true;
			this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
			// 
			// buttonCancl
			// 
			this.buttonCancl.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancl.Location = new System.Drawing.Point(371, 199);
			this.buttonCancl.Name = "buttonCancl";
			this.buttonCancl.Size = new System.Drawing.Size(75, 23);
			this.buttonCancl.TabIndex = 37;
			this.buttonCancl.Text = "Abbrechen";
			this.buttonCancl.UseVisualStyleBackColor = true;
			// 
			// QADialog
			// 
			this.AcceptButton = this.buttonAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancl;
			this.ClientSize = new System.Drawing.Size(463, 234);
			this.ControlBox = false;
			this.Controls.Add(this.buttonCancl);
			this.Controls.Add(this.buttonAccept);
			this.Controls.Add(this.textBoxComment);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.checkBoxQASpelling);
			this.Controls.Add(this.checkBoxQATranslation);
			this.Controls.Add(this.checkBoxQASegmentation);
			this.Controls.Add(this.checkBoxQAImages);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "QADialog";
			this.Text = "Qualitätssicherung & Bemerkungen";
			this.Load += new System.EventHandler(this.QADialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxQASegmentation;
		private System.Windows.Forms.CheckBox checkBoxQAImages;
		private System.Windows.Forms.CheckBox checkBoxQATranslation;
		private System.Windows.Forms.CheckBox checkBoxQASpelling;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxComment;
		private System.Windows.Forms.Button buttonAccept;
		private System.Windows.Forms.Button buttonCancl;
	}
}