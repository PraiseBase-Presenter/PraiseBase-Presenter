namespace PraiseBase.Presenter.Forms
{
    partial class SongStatsticsViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongStatsticsViewer));
            this.listViewTable = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCCLI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLatestUsed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelSongs = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelNotification = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTimeRange = new System.Windows.Forms.ToolStripStatusLabel();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelMethod = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerNotification = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewTable
            // 
            resources.ApplyResources(this.listViewTable, "listViewTable");
            this.listViewTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderAuthor,
            this.columnHeaderCCLI,
            this.columnHeaderNumber,
            this.columnHeaderLatestUsed});
            this.listViewTable.FullRowSelect = true;
            this.listViewTable.GridLines = true;
            this.listViewTable.MultiSelect = false;
            this.listViewTable.Name = "listViewTable";
            this.listViewTable.UseCompatibleStateImageBehavior = false;
            this.listViewTable.View = System.Windows.Forms.View.Details;
            this.listViewTable.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewTable_ColumnClick);
            this.listViewTable.SelectedIndexChanged += new System.EventHandler(this.listViewTable_SelectedIndexChanged);
            // 
            // columnHeaderName
            // 
            resources.ApplyResources(this.columnHeaderName, "columnHeaderName");
            // 
            // columnHeaderAuthor
            // 
            resources.ApplyResources(this.columnHeaderAuthor, "columnHeaderAuthor");
            // 
            // columnHeaderCCLI
            // 
            resources.ApplyResources(this.columnHeaderCCLI, "columnHeaderCCLI");
            // 
            // columnHeaderNumber
            // 
            resources.ApplyResources(this.columnHeaderNumber, "columnHeaderNumber");
            // 
            // columnHeaderLatestUsed
            // 
            resources.ApplyResources(this.columnHeaderLatestUsed, "columnHeaderLatestUsed");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelSongs,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabelNotification,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelTimeRange});
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
            // toolStripStatusLabelTimeRange
            // 
            this.toolStripStatusLabelTimeRange.Name = "toolStripStatusLabelTimeRange";
            resources.ApplyResources(this.toolStripStatusLabelTimeRange, "toolStripStatusLabelTimeRange");
            // 
            // dateTimePickerStart
            // 
            resources.ApplyResources(this.dateTimePickerStart, "dateTimePickerStart");
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // dateTimePickerEnd
            // 
            resources.ApplyResources(this.dateTimePickerEnd, "dateTimePickerEnd");
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePickerEnd_ValueChanged);
            // 
            // labelEndDate
            // 
            resources.ApplyResources(this.labelEndDate, "labelEndDate");
            this.labelEndDate.Name = "labelEndDate";
            // 
            // labelStartDate
            // 
            resources.ApplyResources(this.labelStartDate, "labelStartDate");
            this.labelStartDate.Name = "labelStartDate";
            // 
            // labelMethod
            // 
            resources.ApplyResources(this.labelMethod, "labelMethod");
            this.labelMethod.Name = "labelMethod";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // timerNotification
            // 
            this.timerNotification.Interval = 1000;
            this.timerNotification.Tick += new System.EventHandler(this.timerNotification_Tick);
            // 
            // SongStatsticsViewer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMethod);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listViewTable);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SongStatsticsViewer";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.SongStatsticsViewer_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewTable;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderNumber;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSongs;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTimeRange;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNotification;
        private System.Windows.Forms.Timer timerNotification;
        private System.Windows.Forms.ColumnHeader columnHeaderLatestUsed;
        private System.Windows.Forms.ColumnHeader columnHeaderCCLI;
        private System.Windows.Forms.ColumnHeader columnHeaderAuthor;
    }
}