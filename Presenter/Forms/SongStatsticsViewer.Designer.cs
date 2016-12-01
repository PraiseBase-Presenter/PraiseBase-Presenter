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
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader4,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewTable.FullRowSelect = true;
            this.listViewTable.GridLines = true;
            this.listViewTable.MultiSelect = false;
            this.listViewTable.Name = "listViewTable";
            this.listViewTable.UseCompatibleStateImageBehavior = false;
            this.listViewTable.View = System.Windows.Forms.View.Details;
            this.listViewTable.SelectedIndexChanged += new System.EventHandler(this.listViewTable_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelSongs,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabelNotification,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelTimeRange});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabelSongs
            // 
            resources.ApplyResources(this.toolStripStatusLabelSongs, "toolStripStatusLabelSongs");
            this.toolStripStatusLabelSongs.Name = "toolStripStatusLabelSongs";
            // 
            // toolStripStatusLabel3
            // 
            resources.ApplyResources(this.toolStripStatusLabel3, "toolStripStatusLabel3");
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Spring = true;
            // 
            // toolStripStatusLabelNotification
            // 
            resources.ApplyResources(this.toolStripStatusLabelNotification, "toolStripStatusLabelNotification");
            this.toolStripStatusLabelNotification.Name = "toolStripStatusLabelNotification";
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabelTimeRange
            // 
            resources.ApplyResources(this.toolStripStatusLabelTimeRange, "toolStripStatusLabelTimeRange");
            this.toolStripStatusLabelTimeRange.Name = "toolStripStatusLabelTimeRange";
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
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SongStatsticsViewer_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
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
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}