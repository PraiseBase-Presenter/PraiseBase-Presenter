namespace Pbp
{
    partial class mainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bildschirmeErneutSuchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liederlisteNeuLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelFadeInfo = new System.Windows.Forms.Label();
            this.songSearchBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.songSearchResetButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewSongs = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.radioSongSearchAll = new System.Windows.Forms.RadioButton();
            this.radioSongSearchTitle = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxUseSongImage = new System.Windows.Forms.CheckBox();
            this.songDetailImages = new System.Windows.Forms.ListView();
            this.fontSelector = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.songDetailItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.einstellungenToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1115, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.dateiToolStripMenuItem.Text = "Allgemein";
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionenToolStripMenuItem,
            this.bildschirmeErneutSuchenToolStripMenuItem,
            this.liederlisteNeuLadenToolStripMenuItem});
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.einstellungenToolStripMenuItem.Text = "Extras";
            // 
            // optionenToolStripMenuItem
            // 
            this.optionenToolStripMenuItem.Name = "optionenToolStripMenuItem";
            this.optionenToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.optionenToolStripMenuItem.Text = "Optionen...";
            this.optionenToolStripMenuItem.Click += new System.EventHandler(this.optionenToolStripMenuItem_Click);
            // 
            // bildschirmeErneutSuchenToolStripMenuItem
            // 
            this.bildschirmeErneutSuchenToolStripMenuItem.Name = "bildschirmeErneutSuchenToolStripMenuItem";
            this.bildschirmeErneutSuchenToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.bildschirmeErneutSuchenToolStripMenuItem.Text = "Bildschirme neu suchen";
            this.bildschirmeErneutSuchenToolStripMenuItem.Click += new System.EventHandler(this.bildschirmeErneutSuchenToolStripMenuItem_Click);
            // 
            // liederlisteNeuLadenToolStripMenuItem
            // 
            this.liederlisteNeuLadenToolStripMenuItem.Name = "liederlisteNeuLadenToolStripMenuItem";
            this.liederlisteNeuLadenToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.liederlisteNeuLadenToolStripMenuItem.Text = "Liederliste neu laden";
            this.liederlisteNeuLadenToolStripMenuItem.Click += new System.EventHandler(this.liederlisteNeuLadenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // labelFadeInfo
            // 
            this.labelFadeInfo.AutoSize = true;
            this.labelFadeInfo.Location = new System.Drawing.Point(148, 479);
            this.labelFadeInfo.Name = "labelFadeInfo";
            this.labelFadeInfo.Size = new System.Drawing.Size(0, 13);
            this.labelFadeInfo.TabIndex = 12;
            // 
            // songSearchBox
            // 
            this.songSearchBox.Location = new System.Drawing.Point(53, 19);
            this.songSearchBox.Name = "songSearchBox";
            this.songSearchBox.Size = new System.Drawing.Size(159, 20);
            this.songSearchBox.TabIndex = 0;
            this.songSearchBox.TextChanged += new System.EventHandler(this.songSearchBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Suche:";
            // 
            // songSearchResetButton
            // 
            this.songSearchResetButton.Location = new System.Drawing.Point(218, 16);
            this.songSearchResetButton.Name = "songSearchResetButton";
            this.songSearchResetButton.Size = new System.Drawing.Size(21, 23);
            this.songSearchResetButton.TabIndex = 18;
            this.songSearchResetButton.Text = "X";
            this.songSearchResetButton.UseVisualStyleBackColor = true;
            this.songSearchResetButton.Click += new System.EventHandler(this.songSearchResetButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewSongs);
            this.groupBox2.Controls.Add(this.radioSongSearchAll);
            this.groupBox2.Controls.Add(this.radioSongSearchTitle);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.songSearchResetButton);
            this.groupBox2.Controls.Add(this.songSearchBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 536);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Liederliste";
            // 
            // listViewSongs
            // 
            this.listViewSongs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewSongs.FullRowSelect = true;
            this.listViewSongs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewSongs.HideSelection = false;
            this.listViewSongs.Location = new System.Drawing.Point(5, 68);
            this.listViewSongs.MultiSelect = false;
            this.listViewSongs.Name = "listViewSongs";
            this.listViewSongs.Size = new System.Drawing.Size(234, 462);
            this.listViewSongs.TabIndex = 21;
            this.listViewSongs.UseCompatibleStateImageBehavior = false;
            this.listViewSongs.View = System.Windows.Forms.View.Details;
            this.listViewSongs.SelectedIndexChanged += new System.EventHandler(this.listViewSongs_SelectedIndexChanged);
            // 
            // radioSongSearchAll
            // 
            this.radioSongSearchAll.AutoSize = true;
            this.radioSongSearchAll.Checked = true;
            this.radioSongSearchAll.Location = new System.Drawing.Point(102, 45);
            this.radioSongSearchAll.Name = "radioSongSearchAll";
            this.radioSongSearchAll.Size = new System.Drawing.Size(137, 17);
            this.radioSongSearchAll.TabIndex = 20;
            this.radioSongSearchAll.TabStop = true;
            this.radioSongSearchAll.Text = "Suche im Text und Titel";
            this.radioSongSearchAll.UseVisualStyleBackColor = true;
            this.radioSongSearchAll.CheckedChanged += new System.EventHandler(this.radioSongSearchAll_CheckedChanged);
            // 
            // radioSongSearchTitle
            // 
            this.radioSongSearchTitle.AutoSize = true;
            this.radioSongSearchTitle.Location = new System.Drawing.Point(10, 45);
            this.radioSongSearchTitle.Name = "radioSongSearchTitle";
            this.radioSongSearchTitle.Size = new System.Drawing.Size(92, 17);
            this.radioSongSearchTitle.TabIndex = 19;
            this.radioSongSearchTitle.Text = "Suche im Titel";
            this.radioSongSearchTitle.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 98);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1091, 576);
            this.tabControl1.TabIndex = 20;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1083, 550);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lieder";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxUseSongImage);
            this.groupBox3.Controls.Add(this.songDetailItems);
            this.groupBox3.Controls.Add(this.songDetailImages);
            this.groupBox3.Controls.Add(this.fontSelector);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(259, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(805, 536);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lied-Details";
            // 
            // checkBoxUseSongImage
            // 
            this.checkBoxUseSongImage.AutoSize = true;
            this.checkBoxUseSongImage.Checked = true;
            this.checkBoxUseSongImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseSongImage.Location = new System.Drawing.Point(10, 22);
            this.checkBoxUseSongImage.Name = "checkBoxUseSongImage";
            this.checkBoxUseSongImage.Size = new System.Drawing.Size(189, 17);
            this.checkBoxUseSongImage.TabIndex = 25;
            this.checkBoxUseSongImage.Text = "Hintergrundbilder verwenden";
            this.checkBoxUseSongImage.UseVisualStyleBackColor = true;
            // 
            // songDetailImages
            // 
            this.songDetailImages.Location = new System.Drawing.Point(6, 476);
            this.songDetailImages.Name = "songDetailImages";
            this.songDetailImages.Size = new System.Drawing.Size(793, 54);
            this.songDetailImages.TabIndex = 24;
            this.songDetailImages.TileSize = new System.Drawing.Size(70, 50);
            this.songDetailImages.UseCompatibleStateImageBehavior = false;
            this.songDetailImages.View = System.Windows.Forms.View.Tile;
            this.songDetailImages.SelectedIndexChanged += new System.EventHandler(this.songDetailImages_SelectedIndexChanged);
            this.songDetailImages.Click += new System.EventHandler(this.songDetailImages_Click);
            // 
            // fontSelector
            // 
            this.fontSelector.Location = new System.Drawing.Point(225, 15);
            this.fontSelector.Name = "fontSelector";
            this.fontSelector.Size = new System.Drawing.Size(124, 23);
            this.fontSelector.TabIndex = 22;
            this.fontSelector.Text = "Schrift wähhlen...";
            this.fontSelector.UseVisualStyleBackColor = true;
            this.fontSelector.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1083, 550);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bilder";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1115, 71);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Checked = true;
            this.toolStripButton1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = global::Pbp.Properties.Resources.Projection_off;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(68, 68);
            this.toolStripButton1.Text = "Präsentation aus";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::Pbp.Properties.Resources.Projection_on;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(68, 68);
            this.toolStripButton3.Text = "Präsentation ein";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 71);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Pbp.Properties.Resources.Blackout_on;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(68, 68);
            this.toolStripButton2.Text = "Blackout ein/aus";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 71);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::Pbp.Properties.Resources.advancedsettings;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(68, 68);
            this.toolStripButton4.Text = "Einstellungen";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // songDetailItems
            // 
            this.songDetailItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.songDetailItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songDetailItems.FullRowSelect = true;
            this.songDetailItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.songDetailItems.HideSelection = false;
            this.songDetailItems.Location = new System.Drawing.Point(6, 84);
            this.songDetailItems.MultiSelect = false;
            this.songDetailItems.Name = "songDetailItems";
            this.songDetailItems.Size = new System.Drawing.Size(793, 386);
            this.songDetailItems.TabIndex = 23;
            this.songDetailItems.UseCompatibleStateImageBehavior = false;
            this.songDetailItems.View = System.Windows.Forms.View.Details;
            this.songDetailItems.SelectedIndexChanged += new System.EventHandler(this.songDetailItems_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Abschnitt";
            this.columnHeader1.Width = 94;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Text";
            this.columnHeader3.Width = 692;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 683);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1115, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 705);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelFadeInfo);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PraiseBase Presenter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.Label labelFadeInfo;
        private System.Windows.Forms.TextBox songSearchBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button songSearchResetButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioSongSearchAll;
        private System.Windows.Forms.RadioButton radioSongSearchTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button fontSelector;
        private System.Windows.Forms.ListView songDetailItems;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView songDetailImages;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxUseSongImage;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bildschirmeErneutSuchenToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem optionenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ListView listViewSongs;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripMenuItem liederlisteNeuLadenToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}

