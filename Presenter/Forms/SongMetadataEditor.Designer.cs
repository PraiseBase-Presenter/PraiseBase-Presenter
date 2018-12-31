namespace PraiseBase.Presenter.Forms
{
    partial class SongMetadataEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongMetadataEditor));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelSongs = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelNotification = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerNotification = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnSongName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCCLI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCopyright = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSongBook = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPublisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRightsManagement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelSongs,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabelNotification,
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabelSongs
            // 
            this.toolStripStatusLabelSongs.Name = "toolStripStatusLabelSongs";
            resources.ApplyResources(this.toolStripStatusLabelSongs, "toolStripStatusLabelSongs");
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            resources.ApplyResources(this.toolStripStatusLabel3, "toolStripStatusLabel3");
            this.toolStripStatusLabel3.Spring = true;
            // 
            // toolStripStatusLabelNotification
            // 
            this.toolStripStatusLabelNotification.Name = "toolStripStatusLabelNotification";
            resources.ApplyResources(this.toolStripStatusLabelNotification, "toolStripStatusLabelNotification");
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Spring = true;
            // 
            // timerNotification
            // 
            this.timerNotification.Interval = 1000;
            this.timerNotification.Tick += new System.EventHandler(this.timerNotification_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSongName,
            this.ColumnAuthor,
            this.ColumnCCLI,
            this.ColumnCopyright,
            this.ColumnSongBook,
            this.ColumnPublisher,
            this.ColumnRightsManagement});
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // ColumnSongName
            // 
            resources.ApplyResources(this.ColumnSongName, "ColumnSongName");
            this.ColumnSongName.Name = "ColumnSongName";
            // 
            // ColumnAuthor
            // 
            resources.ApplyResources(this.ColumnAuthor, "ColumnAuthor");
            this.ColumnAuthor.Name = "ColumnAuthor";
            // 
            // ColumnCCLI
            // 
            resources.ApplyResources(this.ColumnCCLI, "ColumnCCLI");
            this.ColumnCCLI.Name = "ColumnCCLI";
            // 
            // ColumnCopyright
            // 
            resources.ApplyResources(this.ColumnCopyright, "ColumnCopyright");
            this.ColumnCopyright.Name = "ColumnCopyright";
            // 
            // ColumnSongBook
            // 
            resources.ApplyResources(this.ColumnSongBook, "ColumnSongBook");
            this.ColumnSongBook.Name = "ColumnSongBook";
            // 
            // ColumnPublisher
            // 
            resources.ApplyResources(this.ColumnPublisher, "ColumnPublisher");
            this.ColumnPublisher.Name = "ColumnPublisher";
            // 
            // ColumnRightsManagement
            // 
            resources.ApplyResources(this.ColumnRightsManagement, "ColumnRightsManagement");
            this.ColumnRightsManagement.Name = "ColumnRightsManagement";
            // 
            // SongMetadataEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.MinimizeBox = false;
            this.Name = "SongMetadataEditor";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SongMetadataEditor_FormClosing);
            this.Load += new System.EventHandler(this.SongStatsticsViewer_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSongs;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNotification;
        private System.Windows.Forms.Timer timerNotification;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSongName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCCLI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCopyright;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSongBook;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPublisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRightsManagement;
    }
}