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
            this.bilderlisteNeuLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.webToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxSongComment = new System.Windows.Forms.TextBox();
            this.checkBoxUseSongImage = new System.Windows.Forms.CheckBox();
            this.songDetailItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.songDetailImages = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.listViewDirectoryImages = new System.Windows.Forms.ListView();
            this.treeViewImageDirectories = new System.Windows.Forms.TreeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.radioButtonAutoDiaShow = new System.Windows.Forms.RadioButton();
            this.radioButtonManualDiashow = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDiaDuration = new System.Windows.Forms.TextBox();
            this.buttonDiaShow = new System.Windows.Forms.Button();
            this.buttonDisableAllDias = new System.Windows.Forms.Button();
            this.buttonEnableAllDias = new System.Windows.Forms.Button();
            this.labelDiaDirectory = new System.Windows.Forms.Label();
            this.listViewDias = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1018, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.dateiToolStripMenuItem.Text = "&Allgemein";
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.beendenToolStripMenuItem.Text = "&Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionenToolStripMenuItem,
            this.bildschirmeErneutSuchenToolStripMenuItem,
            this.liederlisteNeuLadenToolStripMenuItem,
            this.bilderlisteNeuLadenToolStripMenuItem});
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.einstellungenToolStripMenuItem.Text = "&Extras";
            // 
            // optionenToolStripMenuItem
            // 
            this.optionenToolStripMenuItem.Name = "optionenToolStripMenuItem";
            this.optionenToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.optionenToolStripMenuItem.Text = "&Optionen...";
            this.optionenToolStripMenuItem.Click += new System.EventHandler(this.optionenToolStripMenuItem_Click);
            // 
            // bildschirmeErneutSuchenToolStripMenuItem
            // 
            this.bildschirmeErneutSuchenToolStripMenuItem.Name = "bildschirmeErneutSuchenToolStripMenuItem";
            this.bildschirmeErneutSuchenToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.bildschirmeErneutSuchenToolStripMenuItem.Text = "Bildschirme neu &suchen";
            this.bildschirmeErneutSuchenToolStripMenuItem.Click += new System.EventHandler(this.bildschirmeErneutSuchenToolStripMenuItem_Click);
            // 
            // liederlisteNeuLadenToolStripMenuItem
            // 
            this.liederlisteNeuLadenToolStripMenuItem.Name = "liederlisteNeuLadenToolStripMenuItem";
            this.liederlisteNeuLadenToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.liederlisteNeuLadenToolStripMenuItem.Text = "&Liederliste neu laden";
            this.liederlisteNeuLadenToolStripMenuItem.Click += new System.EventHandler(this.liederlisteNeuLadenToolStripMenuItem_Click);
            // 
            // bilderlisteNeuLadenToolStripMenuItem
            // 
            this.bilderlisteNeuLadenToolStripMenuItem.Name = "bilderlisteNeuLadenToolStripMenuItem";
            this.bilderlisteNeuLadenToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.bilderlisteNeuLadenToolStripMenuItem.Text = "&Bilderliste neu laden";
            this.bilderlisteNeuLadenToolStripMenuItem.Click += new System.EventHandler(this.bilderlisteNeuLadenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.webToolStripMenuItem,
            this.toolStripSeparator3,
            this.infoToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "&?";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.toolStripMenuItem2.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItem2.Text = "&Hilfe";
            // 
            // webToolStripMenuItem
            // 
            this.webToolStripMenuItem.Name = "webToolStripMenuItem";
            this.webToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.webToolStripMenuItem.Text = "&Web";
            this.webToolStripMenuItem.Click += new System.EventHandler(this.webToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(147, 6);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.infoToolStripMenuItem.Text = "&Info...";
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
            this.songSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songSearchBox.Location = new System.Drawing.Point(53, 19);
            this.songSearchBox.Name = "songSearchBox";
            this.songSearchBox.Size = new System.Drawing.Size(159, 20);
            this.songSearchBox.TabIndex = 0;
            this.songSearchBox.TextChanged += new System.EventHandler(this.songSearchBox_TextChanged);
            this.songSearchBox.Click += new System.EventHandler(this.songSearchBox_Click);
            this.songSearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.songSearchBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.listViewSongs);
            this.groupBox2.Controls.Add(this.radioSongSearchAll);
            this.groupBox2.Controls.Add(this.radioSongSearchTitle);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.songSearchResetButton);
            this.groupBox2.Controls.Add(this.songSearchBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 573);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Liederliste";
            // 
            // listViewSongs
            // 
            this.listViewSongs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewSongs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewSongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewSongs.FullRowSelect = true;
            this.listViewSongs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewSongs.HideSelection = false;
            this.listViewSongs.Location = new System.Drawing.Point(5, 68);
            this.listViewSongs.MultiSelect = false;
            this.listViewSongs.Name = "listViewSongs";
            this.listViewSongs.Size = new System.Drawing.Size(234, 499);
            this.listViewSongs.TabIndex = 21;
            this.listViewSongs.UseCompatibleStateImageBehavior = false;
            this.listViewSongs.View = System.Windows.Forms.View.Details;
            this.listViewSongs.SelectedIndexChanged += new System.EventHandler(this.listViewSongs_SelectedIndexChanged);
            // 
            // radioSongSearchAll
            // 
            this.radioSongSearchAll.AutoSize = true;
            this.radioSongSearchAll.Checked = true;
            this.radioSongSearchAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.radioSongSearchTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSongSearchTitle.Location = new System.Drawing.Point(10, 45);
            this.radioSongSearchTitle.Name = "radioSongSearchTitle";
            this.radioSongSearchTitle.Size = new System.Drawing.Size(92, 17);
            this.radioSongSearchTitle.TabIndex = 19;
            this.radioSongSearchTitle.Text = "Suche im Titel";
            this.radioSongSearchTitle.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 25);
            this.tabControl1.Location = new System.Drawing.Point(7, 98);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1006, 620);
            this.tabControl1.TabIndex = 20;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(998, 587);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lieder";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.checkBoxUseSongImage);
            this.groupBox3.Controls.Add(this.songDetailItems);
            this.groupBox3.Controls.Add(this.songDetailImages);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(259, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(733, 573);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lied-Details";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxSongComment);
            this.groupBox1.Location = new System.Drawing.Point(6, 506);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(721, 61);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bemerkungen";
            // 
            // textBoxSongComment
            // 
            this.textBoxSongComment.AcceptsReturn = true;
            this.textBoxSongComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSongComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBoxSongComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSongComment.Enabled = false;
            this.textBoxSongComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSongComment.ForeColor = System.Drawing.Color.Black;
            this.textBoxSongComment.Location = new System.Drawing.Point(6, 16);
            this.textBoxSongComment.Multiline = true;
            this.textBoxSongComment.Name = "textBoxSongComment";
            this.textBoxSongComment.ReadOnly = true;
            this.textBoxSongComment.Size = new System.Drawing.Size(709, 38);
            this.textBoxSongComment.TabIndex = 28;
            this.textBoxSongComment.DoubleClick += new System.EventHandler(this.textBoxSongComment_DoubleClick);
            this.textBoxSongComment.TextChanged += new System.EventHandler(this.textBoxSongComment_TextChanged);
            this.textBoxSongComment.Leave += new System.EventHandler(this.textBoxSongComment_Leave);
            this.textBoxSongComment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSongComment_KeyPress);
            // 
            // checkBoxUseSongImage
            // 
            this.checkBoxUseSongImage.AutoSize = true;
            this.checkBoxUseSongImage.Checked = true;
            this.checkBoxUseSongImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseSongImage.Location = new System.Drawing.Point(6, 447);
            this.checkBoxUseSongImage.Name = "checkBoxUseSongImage";
            this.checkBoxUseSongImage.Size = new System.Drawing.Size(189, 17);
            this.checkBoxUseSongImage.TabIndex = 27;
            this.checkBoxUseSongImage.Text = "Hintergrundbilder verwenden";
            this.checkBoxUseSongImage.UseVisualStyleBackColor = true;
            // 
            // songDetailItems
            // 
            this.songDetailItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.songDetailItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.songDetailItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songDetailItems.FullRowSelect = true;
            this.songDetailItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.songDetailItems.HideSelection = false;
            this.songDetailItems.Location = new System.Drawing.Point(6, 79);
            this.songDetailItems.MultiSelect = false;
            this.songDetailItems.Name = "songDetailItems";
            this.songDetailItems.Size = new System.Drawing.Size(721, 362);
            this.songDetailItems.TabIndex = 23;
            this.songDetailItems.UseCompatibleStateImageBehavior = false;
            this.songDetailItems.View = System.Windows.Forms.View.Details;
            this.songDetailItems.SelectedIndexChanged += new System.EventHandler(this.songDetailItems_SelectedIndexChanged);
            this.songDetailItems.Leave += new System.EventHandler(this.songDetailItems_Leave);
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
            // songDetailImages
            // 
            this.songDetailImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.songDetailImages.HideSelection = false;
            this.songDetailImages.Location = new System.Drawing.Point(6, 19);
            this.songDetailImages.Name = "songDetailImages";
            this.songDetailImages.Size = new System.Drawing.Size(721, 52);
            this.songDetailImages.TabIndex = 24;
            this.songDetailImages.TileSize = new System.Drawing.Size(70, 50);
            this.songDetailImages.UseCompatibleStateImageBehavior = false;
            this.songDetailImages.View = System.Windows.Forms.View.Tile;
            this.songDetailImages.SelectedIndexChanged += new System.EventHandler(this.songDetailImages_SelectedIndexChanged);
            this.songDetailImages.Leave += new System.EventHandler(this.songDetailImages_Leave);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.listViewDirectoryImages);
            this.tabPage2.Controls.Add(this.treeViewImageDirectories);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(998, 587);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bilder";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(241, 560);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(739, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Klicke auf ein Bild, um es zu projizieren. SHIFT-klicke auf ein Bild, um es zum H" +
                "intergrundbild des aktuellen Lieds zu machen.";
            // 
            // listViewDirectoryImages
            // 
            this.listViewDirectoryImages.Location = new System.Drawing.Point(234, 6);
            this.listViewDirectoryImages.MultiSelect = false;
            this.listViewDirectoryImages.Name = "listViewDirectoryImages";
            this.listViewDirectoryImages.Size = new System.Drawing.Size(758, 544);
            this.listViewDirectoryImages.TabIndex = 1;
            this.listViewDirectoryImages.UseCompatibleStateImageBehavior = false;
            this.listViewDirectoryImages.SelectedIndexChanged += new System.EventHandler(this.listViewDirectoryImages_SelectedIndexChanged);
            // 
            // treeViewImageDirectories
            // 
            this.treeViewImageDirectories.Location = new System.Drawing.Point(6, 6);
            this.treeViewImageDirectories.Name = "treeViewImageDirectories";
            this.treeViewImageDirectories.Size = new System.Drawing.Size(222, 575);
            this.treeViewImageDirectories.TabIndex = 0;
            this.treeViewImageDirectories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewImageDirectories_AfterSelect);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.radioButtonAutoDiaShow);
            this.tabPage3.Controls.Add(this.radioButtonManualDiashow);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.textBoxDiaDuration);
            this.tabPage3.Controls.Add(this.buttonDiaShow);
            this.tabPage3.Controls.Add(this.buttonDisableAllDias);
            this.tabPage3.Controls.Add(this.buttonEnableAllDias);
            this.tabPage3.Controls.Add(this.labelDiaDirectory);
            this.tabPage3.Controls.Add(this.listViewDias);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(998, 587);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Diaschau";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // radioButtonAutoDiaShow
            // 
            this.radioButtonAutoDiaShow.AutoSize = true;
            this.radioButtonAutoDiaShow.Checked = true;
            this.radioButtonAutoDiaShow.Location = new System.Drawing.Point(17, 95);
            this.radioButtonAutoDiaShow.Name = "radioButtonAutoDiaShow";
            this.radioButtonAutoDiaShow.Size = new System.Drawing.Size(137, 17);
            this.radioButtonAutoDiaShow.TabIndex = 9;
            this.radioButtonAutoDiaShow.TabStop = true;
            this.radioButtonAutoDiaShow.Text = "Automatischer Wechsel";
            this.radioButtonAutoDiaShow.UseVisualStyleBackColor = true;
            this.radioButtonAutoDiaShow.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButtonManualDiashow
            // 
            this.radioButtonManualDiashow.AutoSize = true;
            this.radioButtonManualDiashow.Location = new System.Drawing.Point(17, 72);
            this.radioButtonManualDiashow.Name = "radioButtonManualDiashow";
            this.radioButtonManualDiashow.Size = new System.Drawing.Size(116, 17);
            this.radioButtonManualDiashow.TabIndex = 8;
            this.radioButtonManualDiashow.Text = "Manueller Wechsel";
            this.radioButtonManualDiashow.UseVisualStyleBackColor = true;
            this.radioButtonManualDiashow.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Anzeigedauer pro Bild:";
            // 
            // textBoxDiaDuration
            // 
            this.textBoxDiaDuration.Location = new System.Drawing.Point(143, 121);
            this.textBoxDiaDuration.MaxLength = 2;
            this.textBoxDiaDuration.Name = "textBoxDiaDuration";
            this.textBoxDiaDuration.Size = new System.Drawing.Size(36, 20);
            this.textBoxDiaDuration.TabIndex = 6;
            this.textBoxDiaDuration.Text = "3";
            // 
            // buttonDiaShow
            // 
            this.buttonDiaShow.Location = new System.Drawing.Point(11, 151);
            this.buttonDiaShow.Name = "buttonDiaShow";
            this.buttonDiaShow.Size = new System.Drawing.Size(177, 23);
            this.buttonDiaShow.TabIndex = 5;
            this.buttonDiaShow.Text = "Diaschau starten";
            this.buttonDiaShow.UseVisualStyleBackColor = true;
            this.buttonDiaShow.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonDisableAllDias
            // 
            this.buttonDisableAllDias.Location = new System.Drawing.Point(106, 37);
            this.buttonDisableAllDias.Name = "buttonDisableAllDias";
            this.buttonDisableAllDias.Size = new System.Drawing.Size(82, 23);
            this.buttonDisableAllDias.TabIndex = 4;
            this.buttonDisableAllDias.Text = "Alle abwählen";
            this.buttonDisableAllDias.UseVisualStyleBackColor = true;
            this.buttonDisableAllDias.Click += new System.EventHandler(this.buttonDisableAllDias_Click);
            // 
            // buttonEnableAllDias
            // 
            this.buttonEnableAllDias.Location = new System.Drawing.Point(11, 37);
            this.buttonEnableAllDias.Name = "buttonEnableAllDias";
            this.buttonEnableAllDias.Size = new System.Drawing.Size(91, 23);
            this.buttonEnableAllDias.TabIndex = 3;
            this.buttonEnableAllDias.Text = "Alle auswählen";
            this.buttonEnableAllDias.UseVisualStyleBackColor = true;
            this.buttonEnableAllDias.Click += new System.EventHandler(this.buttonEnableAllDias_Click);
            // 
            // labelDiaDirectory
            // 
            this.labelDiaDirectory.AutoSize = true;
            this.labelDiaDirectory.Location = new System.Drawing.Point(194, 8);
            this.labelDiaDirectory.Name = "labelDiaDirectory";
            this.labelDiaDirectory.Size = new System.Drawing.Size(162, 13);
            this.labelDiaDirectory.TabIndex = 2;
            this.labelDiaDirectory.Text = "Bitte wähle ein Verzeichnis aus...";
            // 
            // listViewDias
            // 
            this.listViewDias.CheckBoxes = true;
            this.listViewDias.Location = new System.Drawing.Point(197, 31);
            this.listViewDias.MultiSelect = false;
            this.listViewDias.Name = "listViewDias";
            this.listViewDias.Size = new System.Drawing.Size(798, 545);
            this.listViewDias.TabIndex = 1;
            this.listViewDias.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Verzeichnis wählen...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton5,
            this.toolStripSeparator2,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1018, 71);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 71);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::Pbp.Properties.Resources.editor;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(68, 68);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 721);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1018, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 743);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelFadeInfo);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PraiseBase Presenter Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.ListView songDetailItems;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView songDetailImages;
        private System.Windows.Forms.GroupBox groupBox3;
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
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripMenuItem webToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.CheckBox checkBoxUseSongImage;
        private System.Windows.Forms.TextBox textBoxSongComment;
        private System.Windows.Forms.ListView listViewDirectoryImages;
        private System.Windows.Forms.TreeView treeViewImageDirectories;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem bilderlisteNeuLadenToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label labelDiaDirectory;
        private System.Windows.Forms.ListView listViewDias;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDisableAllDias;
        private System.Windows.Forms.Button buttonEnableAllDias;
        private System.Windows.Forms.Button buttonDiaShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDiaDuration;
        private System.Windows.Forms.RadioButton radioButtonAutoDiaShow;
        private System.Windows.Forms.RadioButton radioButtonManualDiashow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

