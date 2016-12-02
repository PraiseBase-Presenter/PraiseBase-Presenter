using PraiseBase.Presenter.Controls;

namespace PraiseBase.Presenter.Presenter
{
    partial class MainWindow
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
            System.Windows.Forms.Button buttonChooseDiaDir;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.splitContainerLayerContent = new System.Windows.Forms.SplitContainer();
            this.customGroupBox2 = new PraiseBase.Presenter.Controls.CustomGroupBox();
            this.tabControlTextLayer = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonSongViewModeSequence = new System.Windows.Forms.Button();
            this.buttonSongViewModeStructure = new System.Windows.Forms.Button();
            this.songSearchTextBox = new PraiseBase.Presenter.Controls.SearchTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.titelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titelUndTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewSongs = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.songDetailElement = new PraiseBase.Presenter.Controls.SongDetail();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonShowLiveText = new System.Windows.Forms.Button();
            this.textBoxLiveText = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.checkBoxBibleAutoShowVerse = new System.Windows.Forms.CheckBox();
            this.labelBibleTextName = new System.Windows.Forms.Label();
            this.listViewBibleVerses = new System.Windows.Forms.ListView();
            this.columnHeaderVerseIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVerseText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelBibleSearchMsg = new System.Windows.Forms.Label();
            this.checkBoxBibleShowVerseFromListDirectly = new System.Windows.Forms.CheckBox();
            this.buttonAddToBibleVerseList = new System.Windows.Forms.Button();
            this.buttonRemoveFromBibleVerseList = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.searchTextBoxBible = new PraiseBase.Presenter.Controls.SearchTextBox();
            this.listViewBibleVerseList = new PraiseBase.Presenter.Controls.DragAndDropListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonBibleTextShow = new System.Windows.Forms.Button();
            this.labelBibleVerses = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxBibleChapter = new System.Windows.Forms.ListBox();
            this.listBoxBibleBook = new System.Windows.Forms.ListBox();
            this.comboBoxBible = new System.Windows.Forms.ComboBox();
            this.tabPageWebVideo = new System.Windows.Forms.TabPage();
            this.labelWebVideoService = new System.Windows.Forms.Label();
            this.comboBoxWebVideoService = new System.Windows.Forms.ComboBox();
            this.labelVideoId = new System.Windows.Forms.Label();
            this.buttonStopWebVideo = new System.Windows.Forms.Button();
            this.buttonPlayWebVideo = new System.Windows.Forms.Button();
            this.textBoxWebVideoID = new System.Windows.Forms.TextBox();
            this.customGroupBox3 = new PraiseBase.Presenter.Controls.CustomGroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPageImageBrowser = new System.Windows.Forms.TabPage();
            this.searchTextBoxImages = new PraiseBase.Presenter.Controls.SearchTextBox();
            this.treeViewImageDirectories = new System.Windows.Forms.TreeView();
            this.listViewDirectoryImages = new System.Windows.Forms.ListView();
            this.labelImgDirName = new System.Windows.Forms.Label();
            this.buttonClearImageHistory = new System.Windows.Forms.Button();
            this.tabPageImageHistory = new System.Windows.Forms.TabPage();
            this.listViewImageHistory = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageImageFavorites = new System.Windows.Forms.TabPage();
            this.listViewFavorites = new System.Windows.Forms.ListView();
            this.tabPageSlideShow = new System.Windows.Forms.TabPage();
            this.radioButtonAutoDiaShow = new System.Windows.Forms.RadioButton();
            this.radioButtonManualDiashow = new System.Windows.Forms.RadioButton();
            this.listViewDias = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDiaDirectory = new System.Windows.Forms.Label();
            this.textBoxDiaDuration = new System.Windows.Forms.TextBox();
            this.buttonEnableAllDias = new System.Windows.Forms.Button();
            this.buttonDiaShow = new System.Windows.Forms.Button();
            this.buttonDisableAllDias = new System.Windows.Forms.Button();
            this.listViewImageQueue = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonResetImageQueue = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liedSuchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liededitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSongStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.präsentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.präsentationausToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.präsentationeinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemChromaKeying = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.bildschirmeSuchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spracheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.datenverzeichnisÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datenverzeichnisToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.liederToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bilderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.setlistenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemImportCCLISongSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.cCLISongSelectDateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemImportText = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.praiseBoxDatenbankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.worToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.liederlisteNeuLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bilderlisteNeuLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miniaturbilderPrüfenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.fehlerMeldenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemLogFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonOpenSetList = new System.Windows.Forms.Button();
            this.listViewSetList = new PraiseBase.Presenter.Controls.DragAndDropListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSaveSetList = new System.Windows.Forms.Button();
            this.buttonSetListAdd = new System.Windows.Forms.Button();
            this.buttonSetListUp = new System.Windows.Forms.Button();
            this.buttonSetListClear = new System.Windows.Forms.Button();
            this.buttonSetListDown = new System.Windows.Forms.Button();
            this.buttonSetListRem = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listViewSongHistory = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timerElementHighlight = new System.Windows.Forms.Timer(this.components);
            this.toolStripButtonProjectionOff = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBlackout = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonProjectionOn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDataFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDisplaySettings = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonChromaKeying = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonImportFile = new System.Windows.Forms.ToolStripSplitButton();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lieddateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonToggleTranslationText = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonQA = new System.Windows.Forms.ToolStripDropDownButton();
            this.openSongEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.qaSpellingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qaTranslationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qaImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qaSegmentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.qAcommentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customGroupBox1 = new PraiseBase.Presenter.Controls.CustomGroupBox();
            this.labelFadeTime = new System.Windows.Forms.Label();
            this.pictureBoxbeamerPreview = new System.Windows.Forms.PictureBox();
            this.labelFadeTimeLayer1 = new System.Windows.Forms.Label();
            this.buttonToggleLayerMode = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonToggleLayer2 = new System.Windows.Forms.Button();
            this.buttonToggleLayer1 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.trackBarFadeTimeLayer1 = new System.Windows.Forms.TrackBar();
            this.trackBarFadeTime = new System.Windows.Forms.TrackBar();
            this.toolTipMyTooltip = new System.Windows.Forms.ToolTip(this.components);
            buttonChooseDiaDir = new System.Windows.Forms.Button();
            this.splitContainerLayerContent.Panel1.SuspendLayout();
            this.splitContainerLayerContent.Panel2.SuspendLayout();
            this.splitContainerLayerContent.SuspendLayout();
            this.customGroupBox2.SuspendLayout();
            this.tabControlTextLayer.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPageWebVideo.SuspendLayout();
            this.customGroupBox3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPageImageBrowser.SuspendLayout();
            this.tabPageImageHistory.SuspendLayout();
            this.tabPageImageFavorites.SuspendLayout();
            this.tabPageSlideShow.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.customGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxbeamerPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFadeTimeLayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFadeTime)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonChooseDiaDir
            // 
            resources.ApplyResources(buttonChooseDiaDir, "buttonChooseDiaDir");
            buttonChooseDiaDir.Name = "buttonChooseDiaDir";
            this.toolTipMyTooltip.SetToolTip(buttonChooseDiaDir, resources.GetString("buttonChooseDiaDir.ToolTip"));
            buttonChooseDiaDir.UseVisualStyleBackColor = true;
            buttonChooseDiaDir.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainerLayerContent
            // 
            resources.ApplyResources(this.splitContainerLayerContent, "splitContainerLayerContent");
            this.splitContainerLayerContent.Name = "splitContainerLayerContent";
            // 
            // splitContainerLayerContent.Panel1
            // 
            resources.ApplyResources(this.splitContainerLayerContent.Panel1, "splitContainerLayerContent.Panel1");
            this.splitContainerLayerContent.Panel1.Controls.Add(this.customGroupBox2);
            this.toolTipMyTooltip.SetToolTip(this.splitContainerLayerContent.Panel1, resources.GetString("splitContainerLayerContent.Panel1.ToolTip"));
            // 
            // splitContainerLayerContent.Panel2
            // 
            resources.ApplyResources(this.splitContainerLayerContent.Panel2, "splitContainerLayerContent.Panel2");
            this.splitContainerLayerContent.Panel2.Controls.Add(this.customGroupBox3);
            this.toolTipMyTooltip.SetToolTip(this.splitContainerLayerContent.Panel2, resources.GetString("splitContainerLayerContent.Panel2.ToolTip"));
            this.toolTipMyTooltip.SetToolTip(this.splitContainerLayerContent, resources.GetString("splitContainerLayerContent.ToolTip"));
            this.splitContainerLayerContent.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainerLayerContent_SplitterMoved);
            // 
            // customGroupBox2
            // 
            resources.ApplyResources(this.customGroupBox2, "customGroupBox2");
            this.customGroupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.customGroupBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customGroupBox2.Controls.Add(this.tabControlTextLayer);
            this.customGroupBox2.Name = "customGroupBox2";
            this.toolTipMyTooltip.SetToolTip(this.customGroupBox2, resources.GetString("customGroupBox2.ToolTip"));
            // 
            // tabControlTextLayer
            // 
            resources.ApplyResources(this.tabControlTextLayer, "tabControlTextLayer");
            this.tabControlTextLayer.Controls.Add(this.tabPage1);
            this.tabControlTextLayer.Controls.Add(this.tabPage2);
            this.tabControlTextLayer.Controls.Add(this.tabPage5);
            this.tabControlTextLayer.Controls.Add(this.tabPageWebVideo);
            this.tabControlTextLayer.Name = "tabControlTextLayer";
            this.tabControlTextLayer.SelectedIndex = 0;
            this.toolTipMyTooltip.SetToolTip(this.tabControlTextLayer, resources.GetString("tabControlTextLayer.ToolTip"));
            this.tabControlTextLayer.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.buttonSongViewModeSequence);
            this.tabPage1.Controls.Add(this.buttonSongViewModeStructure);
            this.tabPage1.Controls.Add(this.songSearchTextBox);
            this.tabPage1.Controls.Add(this.listViewSongs);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.songDetailElement);
            this.tabPage1.Name = "tabPage1";
            this.toolTipMyTooltip.SetToolTip(this.tabPage1, resources.GetString("tabPage1.ToolTip"));
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonSongViewModeSequence
            // 
            resources.ApplyResources(this.buttonSongViewModeSequence, "buttonSongViewModeSequence");
            this.buttonSongViewModeSequence.Name = "buttonSongViewModeSequence";
            this.toolTipMyTooltip.SetToolTip(this.buttonSongViewModeSequence, resources.GetString("buttonSongViewModeSequence.ToolTip"));
            this.buttonSongViewModeSequence.UseVisualStyleBackColor = true;
            this.buttonSongViewModeSequence.Click += new System.EventHandler(this.buttonSongViewModeSequence_Click);
            // 
            // buttonSongViewModeStructure
            // 
            resources.ApplyResources(this.buttonSongViewModeStructure, "buttonSongViewModeStructure");
            this.buttonSongViewModeStructure.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSongViewModeStructure.Name = "buttonSongViewModeStructure";
            this.toolTipMyTooltip.SetToolTip(this.buttonSongViewModeStructure, resources.GetString("buttonSongViewModeStructure.ToolTip"));
            this.buttonSongViewModeStructure.UseVisualStyleBackColor = true;
            this.buttonSongViewModeStructure.Click += new System.EventHandler(this.buttonToggleSongViewMode_Click);
            // 
            // songSearchTextBox
            // 
            resources.ApplyResources(this.songSearchTextBox, "songSearchTextBox");
            this.songSearchTextBox.Name = "songSearchTextBox";
            this.songSearchTextBox.OptionsMenu = this.contextMenuStrip1;
            this.toolTipMyTooltip.SetToolTip(this.songSearchTextBox, resources.GetString("songSearchTextBox.ToolTip"));
            this.songSearchTextBox.TextChanged += new PraiseBase.Presenter.Controls.SearchTextBox.TextChange(this.songSearchBox_TextChanged);
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.titelToolStripMenuItem,
            this.titelUndTextToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.toolTipMyTooltip.SetToolTip(this.contextMenuStrip1, resources.GetString("contextMenuStrip1.ToolTip"));
            // 
            // titelToolStripMenuItem
            // 
            resources.ApplyResources(this.titelToolStripMenuItem, "titelToolStripMenuItem");
            this.titelToolStripMenuItem.Name = "titelToolStripMenuItem";
            this.titelToolStripMenuItem.Click += new System.EventHandler(this.titelToolStripMenuItem_Click);
            // 
            // titelUndTextToolStripMenuItem
            // 
            resources.ApplyResources(this.titelUndTextToolStripMenuItem, "titelUndTextToolStripMenuItem");
            this.titelUndTextToolStripMenuItem.Checked = true;
            this.titelUndTextToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.titelUndTextToolStripMenuItem.Name = "titelUndTextToolStripMenuItem";
            this.titelUndTextToolStripMenuItem.Click += new System.EventHandler(this.titelUndTextToolStripMenuItem_Click);
            // 
            // listViewSongs
            // 
            resources.ApplyResources(this.listViewSongs, "listViewSongs");
            this.listViewSongs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewSongs.FullRowSelect = true;
            this.listViewSongs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewSongs.HideSelection = false;
            this.listViewSongs.MultiSelect = false;
            this.listViewSongs.Name = "listViewSongs";
            this.toolTipMyTooltip.SetToolTip(this.listViewSongs, resources.GetString("listViewSongs.ToolTip"));
            this.listViewSongs.UseCompatibleStateImageBehavior = false;
            this.listViewSongs.View = System.Windows.Forms.View.Details;
            this.listViewSongs.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewSongs_KeyUp);
            this.listViewSongs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewSongs_MouseClick);
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.toolTipMyTooltip.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // songDetailElement
            // 
            resources.ApplyResources(this.songDetailElement, "songDetailElement");
            this.songDetailElement.AvailableSongCaption = null;
            this.songDetailElement.BackColor = System.Drawing.Color.White;
            this.songDetailElement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.songDetailElement.ForeColor = System.Drawing.SystemColors.WindowText;
            this.songDetailElement.ImageManager = null;
            this.songDetailElement.Name = "songDetailElement";
            this.songDetailElement.NextSongIcon = ((System.Drawing.Image)(resources.GetObject("songDetailElement.NextSongIcon")));
            this.songDetailElement.PreviousSongIcon = ((System.Drawing.Image)(resources.GetObject("songDetailElement.PreviousSongIcon")));
            this.songDetailElement.SongViewMode = PraiseBase.Presenter.Manager.SongViewMode.Structure;
            this.songDetailElement.ThumbnailSize = new System.Drawing.Size(56, 42);
            this.toolTipMyTooltip.SetToolTip(this.songDetailElement, resources.GetString("songDetailElement.ToolTip"));
            this.songDetailElement.SlideClicked += new PraiseBase.Presenter.Controls.SongDetail.SlideClick(this.songDetailElement_SlideClicked);
            this.songDetailElement.ImageClicked += new PraiseBase.Presenter.Controls.SongDetail.ImageClick(this.songDetailElement_ImageClicked);
            this.songDetailElement.PreviousSongClicked += new PraiseBase.Presenter.Controls.SongDetail.PreviousSongClick(this.songDetailElement_PreviousSongClicked);
            this.songDetailElement.NextSongClicked += new PraiseBase.Presenter.Controls.SongDetail.NextSongClick(this.songDetailElement_NextSongClicked);
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.buttonShowLiveText);
            this.tabPage2.Controls.Add(this.textBoxLiveText);
            this.tabPage2.Name = "tabPage2";
            this.toolTipMyTooltip.SetToolTip(this.tabPage2, resources.GetString("tabPage2.ToolTip"));
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonShowLiveText
            // 
            resources.ApplyResources(this.buttonShowLiveText, "buttonShowLiveText");
            this.buttonShowLiveText.Name = "buttonShowLiveText";
            this.toolTipMyTooltip.SetToolTip(this.buttonShowLiveText, resources.GetString("buttonShowLiveText.ToolTip"));
            this.buttonShowLiveText.UseVisualStyleBackColor = true;
            this.buttonShowLiveText.Click += new System.EventHandler(this.buttonShowLiveText_Click);
            // 
            // textBoxLiveText
            // 
            resources.ApplyResources(this.textBoxLiveText, "textBoxLiveText");
            this.textBoxLiveText.Name = "textBoxLiveText";
            this.toolTipMyTooltip.SetToolTip(this.textBoxLiveText, resources.GetString("textBoxLiveText.ToolTip"));
            // 
            // tabPage5
            // 
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Controls.Add(this.checkBoxBibleAutoShowVerse);
            this.tabPage5.Controls.Add(this.labelBibleTextName);
            this.tabPage5.Controls.Add(this.listViewBibleVerses);
            this.tabPage5.Controls.Add(this.labelBibleSearchMsg);
            this.tabPage5.Controls.Add(this.checkBoxBibleShowVerseFromListDirectly);
            this.tabPage5.Controls.Add(this.buttonAddToBibleVerseList);
            this.tabPage5.Controls.Add(this.buttonRemoveFromBibleVerseList);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Controls.Add(this.searchTextBoxBible);
            this.tabPage5.Controls.Add(this.listViewBibleVerseList);
            this.tabPage5.Controls.Add(this.buttonBibleTextShow);
            this.tabPage5.Controls.Add(this.labelBibleVerses);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.label2);
            this.tabPage5.Controls.Add(this.listBoxBibleChapter);
            this.tabPage5.Controls.Add(this.listBoxBibleBook);
            this.tabPage5.Controls.Add(this.comboBoxBible);
            this.tabPage5.Name = "tabPage5";
            this.toolTipMyTooltip.SetToolTip(this.tabPage5, resources.GetString("tabPage5.ToolTip"));
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // checkBoxBibleAutoShowVerse
            // 
            resources.ApplyResources(this.checkBoxBibleAutoShowVerse, "checkBoxBibleAutoShowVerse");
            this.checkBoxBibleAutoShowVerse.Name = "checkBoxBibleAutoShowVerse";
            this.toolTipMyTooltip.SetToolTip(this.checkBoxBibleAutoShowVerse, resources.GetString("checkBoxBibleAutoShowVerse.ToolTip"));
            this.checkBoxBibleAutoShowVerse.UseVisualStyleBackColor = true;
            // 
            // labelBibleTextName
            // 
            resources.ApplyResources(this.labelBibleTextName, "labelBibleTextName");
            this.labelBibleTextName.Name = "labelBibleTextName";
            this.toolTipMyTooltip.SetToolTip(this.labelBibleTextName, resources.GetString("labelBibleTextName.ToolTip"));
            // 
            // listViewBibleVerses
            // 
            resources.ApplyResources(this.listViewBibleVerses, "listViewBibleVerses");
            this.listViewBibleVerses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderVerseIndex,
            this.columnHeaderVerseText});
            this.listViewBibleVerses.FullRowSelect = true;
            this.listViewBibleVerses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewBibleVerses.HideSelection = false;
            this.listViewBibleVerses.Name = "listViewBibleVerses";
            this.toolTipMyTooltip.SetToolTip(this.listViewBibleVerses, resources.GetString("listViewBibleVerses.ToolTip"));
            this.listViewBibleVerses.UseCompatibleStateImageBehavior = false;
            this.listViewBibleVerses.View = System.Windows.Forms.View.Details;
            this.listViewBibleVerses.SelectedIndexChanged += new System.EventHandler(this.listViewBibleVerses_SelectedIndexChanged);
            this.listViewBibleVerses.Resize += new System.EventHandler(this.listViewBibleVerses_Resize);
            // 
            // columnHeaderVerseIndex
            // 
            resources.ApplyResources(this.columnHeaderVerseIndex, "columnHeaderVerseIndex");
            // 
            // columnHeaderVerseText
            // 
            resources.ApplyResources(this.columnHeaderVerseText, "columnHeaderVerseText");
            // 
            // labelBibleSearchMsg
            // 
            resources.ApplyResources(this.labelBibleSearchMsg, "labelBibleSearchMsg");
            this.labelBibleSearchMsg.Name = "labelBibleSearchMsg";
            this.toolTipMyTooltip.SetToolTip(this.labelBibleSearchMsg, resources.GetString("labelBibleSearchMsg.ToolTip"));
            // 
            // checkBoxBibleShowVerseFromListDirectly
            // 
            resources.ApplyResources(this.checkBoxBibleShowVerseFromListDirectly, "checkBoxBibleShowVerseFromListDirectly");
            this.checkBoxBibleShowVerseFromListDirectly.Name = "checkBoxBibleShowVerseFromListDirectly";
            this.toolTipMyTooltip.SetToolTip(this.checkBoxBibleShowVerseFromListDirectly, resources.GetString("checkBoxBibleShowVerseFromListDirectly.ToolTip"));
            this.checkBoxBibleShowVerseFromListDirectly.UseVisualStyleBackColor = true;
            // 
            // buttonAddToBibleVerseList
            // 
            resources.ApplyResources(this.buttonAddToBibleVerseList, "buttonAddToBibleVerseList");
            this.buttonAddToBibleVerseList.Name = "buttonAddToBibleVerseList";
            this.toolTipMyTooltip.SetToolTip(this.buttonAddToBibleVerseList, resources.GetString("buttonAddToBibleVerseList.ToolTip"));
            this.buttonAddToBibleVerseList.UseVisualStyleBackColor = true;
            this.buttonAddToBibleVerseList.Click += new System.EventHandler(this.buttonAddToBibleVerseList_Click);
            // 
            // buttonRemoveFromBibleVerseList
            // 
            resources.ApplyResources(this.buttonRemoveFromBibleVerseList, "buttonRemoveFromBibleVerseList");
            this.buttonRemoveFromBibleVerseList.Name = "buttonRemoveFromBibleVerseList";
            this.toolTipMyTooltip.SetToolTip(this.buttonRemoveFromBibleVerseList, resources.GetString("buttonRemoveFromBibleVerseList.ToolTip"));
            this.buttonRemoveFromBibleVerseList.UseVisualStyleBackColor = true;
            this.buttonRemoveFromBibleVerseList.Click += new System.EventHandler(this.buttonRemoveFromBibleVerseList_Click);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            this.toolTipMyTooltip.SetToolTip(this.label12, resources.GetString("label12.ToolTip"));
            // 
            // searchTextBoxBible
            // 
            resources.ApplyResources(this.searchTextBoxBible, "searchTextBoxBible");
            this.searchTextBoxBible.Name = "searchTextBoxBible";
            this.searchTextBoxBible.OptionsMenu = null;
            this.toolTipMyTooltip.SetToolTip(this.searchTextBoxBible, resources.GetString("searchTextBoxBible.ToolTip"));
            this.searchTextBoxBible.TextChanged += new PraiseBase.Presenter.Controls.SearchTextBox.TextChange(this.searchTextBoxBible_TextChanged);
            // 
            // listViewBibleVerseList
            // 
            resources.ApplyResources(this.listViewBibleVerseList, "listViewBibleVerseList");
            this.listViewBibleVerseList.AllowDrop = true;
            this.listViewBibleVerseList.AllowRowReorder = true;
            this.listViewBibleVerseList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listViewBibleVerseList.FullRowSelect = true;
            this.listViewBibleVerseList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewBibleVerseList.HideSelection = false;
            this.listViewBibleVerseList.MultiSelect = false;
            this.listViewBibleVerseList.Name = "listViewBibleVerseList";
            this.toolTipMyTooltip.SetToolTip(this.listViewBibleVerseList, resources.GetString("listViewBibleVerseList.ToolTip"));
            this.listViewBibleVerseList.UseCompatibleStateImageBehavior = false;
            this.listViewBibleVerseList.View = System.Windows.Forms.View.Details;
            this.listViewBibleVerseList.SelectedIndexChanged += new System.EventHandler(this.listViewBibleVerseList_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // buttonBibleTextShow
            // 
            resources.ApplyResources(this.buttonBibleTextShow, "buttonBibleTextShow");
            this.buttonBibleTextShow.Name = "buttonBibleTextShow";
            this.toolTipMyTooltip.SetToolTip(this.buttonBibleTextShow, resources.GetString("buttonBibleTextShow.ToolTip"));
            this.buttonBibleTextShow.UseVisualStyleBackColor = true;
            this.buttonBibleTextShow.Click += new System.EventHandler(this.buttonBibleTextShow_Click);
            // 
            // labelBibleVerses
            // 
            resources.ApplyResources(this.labelBibleVerses, "labelBibleVerses");
            this.labelBibleVerses.Name = "labelBibleVerses";
            this.toolTipMyTooltip.SetToolTip(this.labelBibleVerses, resources.GetString("labelBibleVerses.ToolTip"));
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            this.toolTipMyTooltip.SetToolTip(this.label7, resources.GetString("label7.ToolTip"));
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.toolTipMyTooltip.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTipMyTooltip.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // listBoxBibleChapter
            // 
            resources.ApplyResources(this.listBoxBibleChapter, "listBoxBibleChapter");
            this.listBoxBibleChapter.FormattingEnabled = true;
            this.listBoxBibleChapter.Name = "listBoxBibleChapter";
            this.toolTipMyTooltip.SetToolTip(this.listBoxBibleChapter, resources.GetString("listBoxBibleChapter.ToolTip"));
            this.listBoxBibleChapter.SelectedIndexChanged += new System.EventHandler(this.listBoxBibleChapter_SelectedIndexChanged);
            // 
            // listBoxBibleBook
            // 
            resources.ApplyResources(this.listBoxBibleBook, "listBoxBibleBook");
            this.listBoxBibleBook.FormattingEnabled = true;
            this.listBoxBibleBook.Name = "listBoxBibleBook";
            this.toolTipMyTooltip.SetToolTip(this.listBoxBibleBook, resources.GetString("listBoxBibleBook.ToolTip"));
            this.listBoxBibleBook.SelectedIndexChanged += new System.EventHandler(this.listBoxBibleBook_SelectedIndexChanged);
            // 
            // comboBoxBible
            // 
            resources.ApplyResources(this.comboBoxBible, "comboBoxBible");
            this.comboBoxBible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBible.FormattingEnabled = true;
            this.comboBoxBible.Name = "comboBoxBible";
            this.toolTipMyTooltip.SetToolTip(this.comboBoxBible, resources.GetString("comboBoxBible.ToolTip"));
            this.comboBoxBible.SelectedIndexChanged += new System.EventHandler(this.comboBoxBible_SelectedIndexChanged);
            // 
            // tabPageWebVideo
            // 
            resources.ApplyResources(this.tabPageWebVideo, "tabPageWebVideo");
            this.tabPageWebVideo.Controls.Add(this.labelWebVideoService);
            this.tabPageWebVideo.Controls.Add(this.comboBoxWebVideoService);
            this.tabPageWebVideo.Controls.Add(this.labelVideoId);
            this.tabPageWebVideo.Controls.Add(this.buttonStopWebVideo);
            this.tabPageWebVideo.Controls.Add(this.buttonPlayWebVideo);
            this.tabPageWebVideo.Controls.Add(this.textBoxWebVideoID);
            this.tabPageWebVideo.Name = "tabPageWebVideo";
            this.toolTipMyTooltip.SetToolTip(this.tabPageWebVideo, resources.GetString("tabPageWebVideo.ToolTip"));
            this.tabPageWebVideo.UseVisualStyleBackColor = true;
            // 
            // labelWebVideoService
            // 
            resources.ApplyResources(this.labelWebVideoService, "labelWebVideoService");
            this.labelWebVideoService.Name = "labelWebVideoService";
            this.toolTipMyTooltip.SetToolTip(this.labelWebVideoService, resources.GetString("labelWebVideoService.ToolTip"));
            // 
            // comboBoxWebVideoService
            // 
            resources.ApplyResources(this.comboBoxWebVideoService, "comboBoxWebVideoService");
            this.comboBoxWebVideoService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWebVideoService.FormattingEnabled = true;
            this.comboBoxWebVideoService.Items.AddRange(new object[] {
            resources.GetString("comboBoxWebVideoService.Items"),
            resources.GetString("comboBoxWebVideoService.Items1")});
            this.comboBoxWebVideoService.Name = "comboBoxWebVideoService";
            this.toolTipMyTooltip.SetToolTip(this.comboBoxWebVideoService, resources.GetString("comboBoxWebVideoService.ToolTip"));
            this.comboBoxWebVideoService.SelectedIndexChanged += new System.EventHandler(this.comboBoxWebVideoService_SelectedIndexChanged);
            // 
            // labelVideoId
            // 
            resources.ApplyResources(this.labelVideoId, "labelVideoId");
            this.labelVideoId.Name = "labelVideoId";
            this.toolTipMyTooltip.SetToolTip(this.labelVideoId, resources.GetString("labelVideoId.ToolTip"));
            // 
            // buttonStopWebVideo
            // 
            resources.ApplyResources(this.buttonStopWebVideo, "buttonStopWebVideo");
            this.buttonStopWebVideo.Name = "buttonStopWebVideo";
            this.toolTipMyTooltip.SetToolTip(this.buttonStopWebVideo, resources.GetString("buttonStopWebVideo.ToolTip"));
            this.buttonStopWebVideo.UseVisualStyleBackColor = true;
            this.buttonStopWebVideo.Click += new System.EventHandler(this.buttonStopWebVideo_Click);
            // 
            // buttonPlayWebVideo
            // 
            resources.ApplyResources(this.buttonPlayWebVideo, "buttonPlayWebVideo");
            this.buttonPlayWebVideo.Image = global::PraiseBase.Presenter.Properties.Resources.leinwand16;
            this.buttonPlayWebVideo.Name = "buttonPlayWebVideo";
            this.toolTipMyTooltip.SetToolTip(this.buttonPlayWebVideo, resources.GetString("buttonPlayWebVideo.ToolTip"));
            this.buttonPlayWebVideo.UseVisualStyleBackColor = true;
            this.buttonPlayWebVideo.Click += new System.EventHandler(this.buttonPlayWebVideo_Click);
            // 
            // textBoxWebVideoID
            // 
            resources.ApplyResources(this.textBoxWebVideoID, "textBoxWebVideoID");
            this.textBoxWebVideoID.Name = "textBoxWebVideoID";
            this.toolTipMyTooltip.SetToolTip(this.textBoxWebVideoID, resources.GetString("textBoxWebVideoID.ToolTip"));
            this.textBoxWebVideoID.TextChanged += new System.EventHandler(this.textBoxWebVideoID_TextChanged);
            // 
            // customGroupBox3
            // 
            resources.ApplyResources(this.customGroupBox3, "customGroupBox3");
            this.customGroupBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.customGroupBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customGroupBox3.Controls.Add(this.label13);
            this.customGroupBox3.Controls.Add(this.tabControl2);
            this.customGroupBox3.Controls.Add(this.listViewImageQueue);
            this.customGroupBox3.Controls.Add(this.buttonResetImageQueue);
            this.customGroupBox3.Name = "customGroupBox3";
            this.toolTipMyTooltip.SetToolTip(this.customGroupBox3, resources.GetString("customGroupBox3.ToolTip"));
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            this.toolTipMyTooltip.SetToolTip(this.label13, resources.GetString("label13.ToolTip"));
            // 
            // tabControl2
            // 
            resources.ApplyResources(this.tabControl2, "tabControl2");
            this.tabControl2.Controls.Add(this.tabPageImageBrowser);
            this.tabControl2.Controls.Add(this.tabPageImageHistory);
            this.tabControl2.Controls.Add(this.tabPageImageFavorites);
            this.tabControl2.Controls.Add(this.tabPageSlideShow);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.toolTipMyTooltip.SetToolTip(this.tabControl2, resources.GetString("tabControl2.ToolTip"));
            // 
            // tabPageImageBrowser
            // 
            resources.ApplyResources(this.tabPageImageBrowser, "tabPageImageBrowser");
            this.tabPageImageBrowser.Controls.Add(this.searchTextBoxImages);
            this.tabPageImageBrowser.Controls.Add(this.treeViewImageDirectories);
            this.tabPageImageBrowser.Controls.Add(this.listViewDirectoryImages);
            this.tabPageImageBrowser.Controls.Add(this.labelImgDirName);
            this.tabPageImageBrowser.Controls.Add(this.buttonClearImageHistory);
            this.tabPageImageBrowser.Name = "tabPageImageBrowser";
            this.toolTipMyTooltip.SetToolTip(this.tabPageImageBrowser, resources.GetString("tabPageImageBrowser.ToolTip"));
            this.tabPageImageBrowser.UseVisualStyleBackColor = true;
            // 
            // searchTextBoxImages
            // 
            resources.ApplyResources(this.searchTextBoxImages, "searchTextBoxImages");
            this.searchTextBoxImages.Name = "searchTextBoxImages";
            this.searchTextBoxImages.OptionsMenu = null;
            this.toolTipMyTooltip.SetToolTip(this.searchTextBoxImages, resources.GetString("searchTextBoxImages.ToolTip"));
            this.searchTextBoxImages.TextChanged += new PraiseBase.Presenter.Controls.SearchTextBox.TextChange(this.searchTextBoxImages_TextChanged);
            // 
            // treeViewImageDirectories
            // 
            resources.ApplyResources(this.treeViewImageDirectories, "treeViewImageDirectories");
            this.treeViewImageDirectories.FullRowSelect = true;
            this.treeViewImageDirectories.HideSelection = false;
            this.treeViewImageDirectories.Name = "treeViewImageDirectories";
            this.treeViewImageDirectories.ShowPlusMinus = false;
            this.toolTipMyTooltip.SetToolTip(this.treeViewImageDirectories, resources.GetString("treeViewImageDirectories.ToolTip"));
            this.treeViewImageDirectories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewImageDirectories_AfterSelect);
            // 
            // listViewDirectoryImages
            // 
            resources.ApplyResources(this.listViewDirectoryImages, "listViewDirectoryImages");
            this.listViewDirectoryImages.MultiSelect = false;
            this.listViewDirectoryImages.Name = "listViewDirectoryImages";
            this.toolTipMyTooltip.SetToolTip(this.listViewDirectoryImages, resources.GetString("listViewDirectoryImages.ToolTip"));
            this.listViewDirectoryImages.UseCompatibleStateImageBehavior = false;
            this.listViewDirectoryImages.SelectedIndexChanged += new System.EventHandler(this.listViewDirectoryImages_SelectedIndexChanged);
            this.listViewDirectoryImages.Leave += new System.EventHandler(this.listViewDirectoryImages_Leave);
            // 
            // labelImgDirName
            // 
            resources.ApplyResources(this.labelImgDirName, "labelImgDirName");
            this.labelImgDirName.Name = "labelImgDirName";
            this.toolTipMyTooltip.SetToolTip(this.labelImgDirName, resources.GetString("labelImgDirName.ToolTip"));
            // 
            // buttonClearImageHistory
            // 
            resources.ApplyResources(this.buttonClearImageHistory, "buttonClearImageHistory");
            this.buttonClearImageHistory.Name = "buttonClearImageHistory";
            this.toolTipMyTooltip.SetToolTip(this.buttonClearImageHistory, resources.GetString("buttonClearImageHistory.ToolTip"));
            this.buttonClearImageHistory.UseVisualStyleBackColor = true;
            this.buttonClearImageHistory.Click += new System.EventHandler(this.buttonClearImageHistory_Click);
            // 
            // tabPageImageHistory
            // 
            resources.ApplyResources(this.tabPageImageHistory, "tabPageImageHistory");
            this.tabPageImageHistory.BackColor = System.Drawing.Color.White;
            this.tabPageImageHistory.Controls.Add(this.listViewImageHistory);
            this.tabPageImageHistory.Name = "tabPageImageHistory";
            this.toolTipMyTooltip.SetToolTip(this.tabPageImageHistory, resources.GetString("tabPageImageHistory.ToolTip"));
            // 
            // listViewImageHistory
            // 
            resources.ApplyResources(this.listViewImageHistory, "listViewImageHistory");
            this.listViewImageHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.listViewImageHistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewImageHistory.MultiSelect = false;
            this.listViewImageHistory.Name = "listViewImageHistory";
            this.toolTipMyTooltip.SetToolTip(this.listViewImageHistory, resources.GetString("listViewImageHistory.ToolTip"));
            this.listViewImageHistory.UseCompatibleStateImageBehavior = false;
            this.listViewImageHistory.View = System.Windows.Forms.View.Tile;
            this.listViewImageHistory.SelectedIndexChanged += new System.EventHandler(this.listViewImageHistory_SelectedIndexChanged);
            this.listViewImageHistory.Leave += new System.EventHandler(this.listViewImageHistory_Leave_1);
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // tabPageImageFavorites
            // 
            resources.ApplyResources(this.tabPageImageFavorites, "tabPageImageFavorites");
            this.tabPageImageFavorites.Controls.Add(this.listViewFavorites);
            this.tabPageImageFavorites.Name = "tabPageImageFavorites";
            this.toolTipMyTooltip.SetToolTip(this.tabPageImageFavorites, resources.GetString("tabPageImageFavorites.ToolTip"));
            this.tabPageImageFavorites.UseVisualStyleBackColor = true;
            // 
            // listViewFavorites
            // 
            resources.ApplyResources(this.listViewFavorites, "listViewFavorites");
            this.listViewFavorites.MultiSelect = false;
            this.listViewFavorites.Name = "listViewFavorites";
            this.toolTipMyTooltip.SetToolTip(this.listViewFavorites, resources.GetString("listViewFavorites.ToolTip"));
            this.listViewFavorites.UseCompatibleStateImageBehavior = false;
            this.listViewFavorites.View = System.Windows.Forms.View.Tile;
            this.listViewFavorites.SelectedIndexChanged += new System.EventHandler(this.listViewFavorites_SelectedIndexChanged);
            this.listViewFavorites.Leave += new System.EventHandler(this.listViewFavorites_Leave);
            // 
            // tabPageSlideShow
            // 
            resources.ApplyResources(this.tabPageSlideShow, "tabPageSlideShow");
            this.tabPageSlideShow.Controls.Add(this.radioButtonAutoDiaShow);
            this.tabPageSlideShow.Controls.Add(buttonChooseDiaDir);
            this.tabPageSlideShow.Controls.Add(this.radioButtonManualDiashow);
            this.tabPageSlideShow.Controls.Add(this.listViewDias);
            this.tabPageSlideShow.Controls.Add(this.label1);
            this.tabPageSlideShow.Controls.Add(this.labelDiaDirectory);
            this.tabPageSlideShow.Controls.Add(this.textBoxDiaDuration);
            this.tabPageSlideShow.Controls.Add(this.buttonEnableAllDias);
            this.tabPageSlideShow.Controls.Add(this.buttonDiaShow);
            this.tabPageSlideShow.Controls.Add(this.buttonDisableAllDias);
            this.tabPageSlideShow.Name = "tabPageSlideShow";
            this.toolTipMyTooltip.SetToolTip(this.tabPageSlideShow, resources.GetString("tabPageSlideShow.ToolTip"));
            this.tabPageSlideShow.UseVisualStyleBackColor = true;
            // 
            // radioButtonAutoDiaShow
            // 
            resources.ApplyResources(this.radioButtonAutoDiaShow, "radioButtonAutoDiaShow");
            this.radioButtonAutoDiaShow.Checked = true;
            this.radioButtonAutoDiaShow.Name = "radioButtonAutoDiaShow";
            this.radioButtonAutoDiaShow.TabStop = true;
            this.toolTipMyTooltip.SetToolTip(this.radioButtonAutoDiaShow, resources.GetString("radioButtonAutoDiaShow.ToolTip"));
            this.radioButtonAutoDiaShow.UseVisualStyleBackColor = true;
            this.radioButtonAutoDiaShow.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButtonManualDiashow
            // 
            resources.ApplyResources(this.radioButtonManualDiashow, "radioButtonManualDiashow");
            this.radioButtonManualDiashow.Name = "radioButtonManualDiashow";
            this.toolTipMyTooltip.SetToolTip(this.radioButtonManualDiashow, resources.GetString("radioButtonManualDiashow.ToolTip"));
            this.radioButtonManualDiashow.UseVisualStyleBackColor = true;
            this.radioButtonManualDiashow.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // listViewDias
            // 
            resources.ApplyResources(this.listViewDias, "listViewDias");
            this.listViewDias.CheckBoxes = true;
            this.listViewDias.MultiSelect = false;
            this.listViewDias.Name = "listViewDias";
            this.toolTipMyTooltip.SetToolTip(this.listViewDias, resources.GetString("listViewDias.ToolTip"));
            this.listViewDias.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTipMyTooltip.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // labelDiaDirectory
            // 
            resources.ApplyResources(this.labelDiaDirectory, "labelDiaDirectory");
            this.labelDiaDirectory.Name = "labelDiaDirectory";
            this.toolTipMyTooltip.SetToolTip(this.labelDiaDirectory, resources.GetString("labelDiaDirectory.ToolTip"));
            // 
            // textBoxDiaDuration
            // 
            resources.ApplyResources(this.textBoxDiaDuration, "textBoxDiaDuration");
            this.textBoxDiaDuration.Name = "textBoxDiaDuration";
            this.toolTipMyTooltip.SetToolTip(this.textBoxDiaDuration, resources.GetString("textBoxDiaDuration.ToolTip"));
            // 
            // buttonEnableAllDias
            // 
            resources.ApplyResources(this.buttonEnableAllDias, "buttonEnableAllDias");
            this.buttonEnableAllDias.Name = "buttonEnableAllDias";
            this.toolTipMyTooltip.SetToolTip(this.buttonEnableAllDias, resources.GetString("buttonEnableAllDias.ToolTip"));
            this.buttonEnableAllDias.UseVisualStyleBackColor = true;
            this.buttonEnableAllDias.Click += new System.EventHandler(this.buttonEnableAllDias_Click);
            // 
            // buttonDiaShow
            // 
            resources.ApplyResources(this.buttonDiaShow, "buttonDiaShow");
            this.buttonDiaShow.Name = "buttonDiaShow";
            this.toolTipMyTooltip.SetToolTip(this.buttonDiaShow, resources.GetString("buttonDiaShow.ToolTip"));
            this.buttonDiaShow.UseVisualStyleBackColor = true;
            this.buttonDiaShow.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonDisableAllDias
            // 
            resources.ApplyResources(this.buttonDisableAllDias, "buttonDisableAllDias");
            this.buttonDisableAllDias.Name = "buttonDisableAllDias";
            this.toolTipMyTooltip.SetToolTip(this.buttonDisableAllDias, resources.GetString("buttonDisableAllDias.ToolTip"));
            this.buttonDisableAllDias.UseVisualStyleBackColor = true;
            this.buttonDisableAllDias.Click += new System.EventHandler(this.buttonDisableAllDias_Click);
            // 
            // listViewImageQueue
            // 
            resources.ApplyResources(this.listViewImageQueue, "listViewImageQueue");
            this.listViewImageQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6});
            this.listViewImageQueue.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewImageQueue.MultiSelect = false;
            this.listViewImageQueue.Name = "listViewImageQueue";
            this.toolTipMyTooltip.SetToolTip(this.listViewImageQueue, resources.GetString("listViewImageQueue.ToolTip"));
            this.listViewImageQueue.UseCompatibleStateImageBehavior = false;
            this.listViewImageQueue.View = System.Windows.Forms.View.Tile;
            this.listViewImageQueue.SelectedIndexChanged += new System.EventHandler(this.listViewImageQueue_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            resources.ApplyResources(this.columnHeader6, "columnHeader6");
            // 
            // buttonResetImageQueue
            // 
            resources.ApplyResources(this.buttonResetImageQueue, "buttonResetImageQueue");
            this.buttonResetImageQueue.Name = "buttonResetImageQueue";
            this.toolTipMyTooltip.SetToolTip(this.buttonResetImageQueue, resources.GetString("buttonResetImageQueue.ToolTip"));
            this.buttonResetImageQueue.UseVisualStyleBackColor = true;
            this.buttonResetImageQueue.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.präsentationToolStripMenuItem,
            this.einstellungenToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Name = "menuStrip1";
            this.toolTipMyTooltip.SetToolTip(this.menuStrip1, resources.GetString("menuStrip1.ToolTip"));
            // 
            // dateiToolStripMenuItem
            // 
            resources.ApplyResources(this.dateiToolStripMenuItem, "dateiToolStripMenuItem");
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liedSuchenToolStripMenuItem,
            this.liededitorToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItemSongStatistics,
            this.toolStripSeparator5,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            // 
            // liedSuchenToolStripMenuItem
            // 
            resources.ApplyResources(this.liedSuchenToolStripMenuItem, "liedSuchenToolStripMenuItem");
            this.liedSuchenToolStripMenuItem.Name = "liedSuchenToolStripMenuItem";
            this.liedSuchenToolStripMenuItem.Click += new System.EventHandler(this.liedSuchenToolStripMenuItem_Click);
            // 
            // liededitorToolStripMenuItem
            // 
            resources.ApplyResources(this.liededitorToolStripMenuItem, "liededitorToolStripMenuItem");
            this.liededitorToolStripMenuItem.Name = "liededitorToolStripMenuItem";
            this.liededitorToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripMenuItem3
            // 
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItemSongStatistics
            // 
            resources.ApplyResources(this.toolStripMenuItemSongStatistics, "toolStripMenuItemSongStatistics");
            this.toolStripMenuItemSongStatistics.Name = "toolStripMenuItemSongStatistics";
            this.toolStripMenuItemSongStatistics.Click += new System.EventHandler(this.toolStripMenuItemSongStatistics_Click);
            // 
            // toolStripSeparator5
            // 
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            // 
            // beendenToolStripMenuItem
            // 
            resources.ApplyResources(this.beendenToolStripMenuItem, "beendenToolStripMenuItem");
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // präsentationToolStripMenuItem
            // 
            resources.ApplyResources(this.präsentationToolStripMenuItem, "präsentationToolStripMenuItem");
            this.präsentationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.präsentationausToolStripMenuItem,
            this.blackoutToolStripMenuItem,
            this.präsentationeinToolStripMenuItem,
            this.toolStripSeparator16,
            this.toolStripMenuItemChromaKeying,
            this.toolStripSeparator11,
            this.bildschirmeSuchenToolStripMenuItem});
            this.präsentationToolStripMenuItem.Name = "präsentationToolStripMenuItem";
            // 
            // präsentationausToolStripMenuItem
            // 
            resources.ApplyResources(this.präsentationausToolStripMenuItem, "präsentationausToolStripMenuItem");
            this.präsentationausToolStripMenuItem.Name = "präsentationausToolStripMenuItem";
            this.präsentationausToolStripMenuItem.Click += new System.EventHandler(this.ToggleProjection);
            // 
            // blackoutToolStripMenuItem
            // 
            resources.ApplyResources(this.blackoutToolStripMenuItem, "blackoutToolStripMenuItem");
            this.blackoutToolStripMenuItem.Name = "blackoutToolStripMenuItem";
            this.blackoutToolStripMenuItem.Click += new System.EventHandler(this.ToggleProjection);
            // 
            // präsentationeinToolStripMenuItem
            // 
            resources.ApplyResources(this.präsentationeinToolStripMenuItem, "präsentationeinToolStripMenuItem");
            this.präsentationeinToolStripMenuItem.Name = "präsentationeinToolStripMenuItem";
            this.präsentationeinToolStripMenuItem.Click += new System.EventHandler(this.ToggleProjection);
            // 
            // toolStripSeparator16
            // 
            resources.ApplyResources(this.toolStripSeparator16, "toolStripSeparator16");
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            // 
            // toolStripMenuItemChromaKeying
            // 
            resources.ApplyResources(this.toolStripMenuItemChromaKeying, "toolStripMenuItemChromaKeying");
            this.toolStripMenuItemChromaKeying.Name = "toolStripMenuItemChromaKeying";
            this.toolStripMenuItemChromaKeying.Click += new System.EventHandler(this.toolStripMenuItemChromaKeying_Click);
            // 
            // toolStripSeparator11
            // 
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            // 
            // bildschirmeSuchenToolStripMenuItem
            // 
            resources.ApplyResources(this.bildschirmeSuchenToolStripMenuItem, "bildschirmeSuchenToolStripMenuItem");
            this.bildschirmeSuchenToolStripMenuItem.Name = "bildschirmeSuchenToolStripMenuItem";
            this.bildschirmeSuchenToolStripMenuItem.Click += new System.EventHandler(this.bildschirmeSuchenToolStripMenuItem_Click);
            // 
            // einstellungenToolStripMenuItem
            // 
            resources.ApplyResources(this.einstellungenToolStripMenuItem, "einstellungenToolStripMenuItem");
            this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionenToolStripMenuItem,
            this.spracheToolStripMenuItem,
            this.toolStripSeparator2,
            this.datenverzeichnisÖffnenToolStripMenuItem,
            this.toolStripSeparator6,
            this.toolStripMenuItemImportCCLISongSelect,
            this.toolStripSeparator9,
            this.liederlisteNeuLadenToolStripMenuItem,
            this.bilderlisteNeuLadenToolStripMenuItem,
            this.miniaturbilderPrüfenToolStripMenuItem});
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            // 
            // optionenToolStripMenuItem
            // 
            resources.ApplyResources(this.optionenToolStripMenuItem, "optionenToolStripMenuItem");
            this.optionenToolStripMenuItem.Name = "optionenToolStripMenuItem";
            this.optionenToolStripMenuItem.Click += new System.EventHandler(this.optionenToolStripMenuItem_Click);
            // 
            // spracheToolStripMenuItem
            // 
            resources.ApplyResources(this.spracheToolStripMenuItem, "spracheToolStripMenuItem");
            this.spracheToolStripMenuItem.Name = "spracheToolStripMenuItem";
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // datenverzeichnisÖffnenToolStripMenuItem
            // 
            resources.ApplyResources(this.datenverzeichnisÖffnenToolStripMenuItem, "datenverzeichnisÖffnenToolStripMenuItem");
            this.datenverzeichnisÖffnenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datenverzeichnisToolStripMenuItem1,
            this.toolStripSeparator10,
            this.liederToolStripMenuItem1,
            this.bilderToolStripMenuItem1,
            this.setlistenToolStripMenuItem1});
            this.datenverzeichnisÖffnenToolStripMenuItem.Name = "datenverzeichnisÖffnenToolStripMenuItem";
            this.datenverzeichnisÖffnenToolStripMenuItem.Click += new System.EventHandler(this.datenverzeichnisOeffnenToolStripMenuItem_Click);
            // 
            // datenverzeichnisToolStripMenuItem1
            // 
            resources.ApplyResources(this.datenverzeichnisToolStripMenuItem1, "datenverzeichnisToolStripMenuItem1");
            this.datenverzeichnisToolStripMenuItem1.Name = "datenverzeichnisToolStripMenuItem1";
            this.datenverzeichnisToolStripMenuItem1.Click += new System.EventHandler(this.datenverzeichnisOeffnenToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            // 
            // liederToolStripMenuItem1
            // 
            resources.ApplyResources(this.liederToolStripMenuItem1, "liederToolStripMenuItem1");
            this.liederToolStripMenuItem1.Name = "liederToolStripMenuItem1";
            this.liederToolStripMenuItem1.Click += new System.EventHandler(this.liederToolStripMenuItem_Click);
            // 
            // bilderToolStripMenuItem1
            // 
            resources.ApplyResources(this.bilderToolStripMenuItem1, "bilderToolStripMenuItem1");
            this.bilderToolStripMenuItem1.Name = "bilderToolStripMenuItem1";
            this.bilderToolStripMenuItem1.Click += new System.EventHandler(this.bilderToolStripMenuItem_Click);
            // 
            // setlistenToolStripMenuItem1
            // 
            resources.ApplyResources(this.setlistenToolStripMenuItem1, "setlistenToolStripMenuItem1");
            this.setlistenToolStripMenuItem1.Name = "setlistenToolStripMenuItem1";
            this.setlistenToolStripMenuItem1.Click += new System.EventHandler(this.setlistenToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            // 
            // toolStripMenuItemImportCCLISongSelect
            // 
            resources.ApplyResources(this.toolStripMenuItemImportCCLISongSelect, "toolStripMenuItemImportCCLISongSelect");
            this.toolStripMenuItemImportCCLISongSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cCLISongSelectDateiToolStripMenuItem,
            this.toolStripSeparator15,
            this.toolStripMenuItemImportText,
            this.toolStripSeparator14,
            this.praiseBoxDatenbankToolStripMenuItem,
            this.worToolStripMenuItem});
            this.toolStripMenuItemImportCCLISongSelect.Name = "toolStripMenuItemImportCCLISongSelect";
            // 
            // cCLISongSelectDateiToolStripMenuItem
            // 
            resources.ApplyResources(this.cCLISongSelectDateiToolStripMenuItem, "cCLISongSelectDateiToolStripMenuItem");
            this.cCLISongSelectDateiToolStripMenuItem.Name = "cCLISongSelectDateiToolStripMenuItem";
            this.cCLISongSelectDateiToolStripMenuItem.Click += new System.EventHandler(this.cCLISongSelectDateiToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            resources.ApplyResources(this.toolStripSeparator15, "toolStripSeparator15");
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            // 
            // toolStripMenuItemImportText
            // 
            resources.ApplyResources(this.toolStripMenuItemImportText, "toolStripMenuItemImportText");
            this.toolStripMenuItemImportText.Name = "toolStripMenuItemImportText";
            this.toolStripMenuItemImportText.Click += new System.EventHandler(this.toolStripMenuItemImportText_Click);
            // 
            // toolStripSeparator14
            // 
            resources.ApplyResources(this.toolStripSeparator14, "toolStripSeparator14");
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            // 
            // praiseBoxDatenbankToolStripMenuItem
            // 
            resources.ApplyResources(this.praiseBoxDatenbankToolStripMenuItem, "praiseBoxDatenbankToolStripMenuItem");
            this.praiseBoxDatenbankToolStripMenuItem.Name = "praiseBoxDatenbankToolStripMenuItem";
            this.praiseBoxDatenbankToolStripMenuItem.Click += new System.EventHandler(this.praiseBoxDatenbankToolStripMenuItem_Click);
            // 
            // worToolStripMenuItem
            // 
            resources.ApplyResources(this.worToolStripMenuItem, "worToolStripMenuItem");
            this.worToolStripMenuItem.Name = "worToolStripMenuItem";
            this.worToolStripMenuItem.Click += new System.EventHandler(this.worToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            // 
            // liederlisteNeuLadenToolStripMenuItem
            // 
            resources.ApplyResources(this.liederlisteNeuLadenToolStripMenuItem, "liederlisteNeuLadenToolStripMenuItem");
            this.liederlisteNeuLadenToolStripMenuItem.Name = "liederlisteNeuLadenToolStripMenuItem";
            this.liederlisteNeuLadenToolStripMenuItem.Click += new System.EventHandler(this.liederlisteNeuLadenToolStripMenuItem_Click);
            // 
            // bilderlisteNeuLadenToolStripMenuItem
            // 
            resources.ApplyResources(this.bilderlisteNeuLadenToolStripMenuItem, "bilderlisteNeuLadenToolStripMenuItem");
            this.bilderlisteNeuLadenToolStripMenuItem.Name = "bilderlisteNeuLadenToolStripMenuItem";
            this.bilderlisteNeuLadenToolStripMenuItem.Click += new System.EventHandler(this.bilderlisteNeuLadenToolStripMenuItem_Click);
            // 
            // miniaturbilderPrüfenToolStripMenuItem
            // 
            resources.ApplyResources(this.miniaturbilderPrüfenToolStripMenuItem, "miniaturbilderPrüfenToolStripMenuItem");
            this.miniaturbilderPrüfenToolStripMenuItem.Name = "miniaturbilderPrüfenToolStripMenuItem";
            this.miniaturbilderPrüfenToolStripMenuItem.Click += new System.EventHandler(this.miniaturbilderPrüfenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.fehlerMeldenToolStripMenuItem,
            this.webToolStripMenuItem,
            this.toolStripSeparator7,
            this.toolStripMenuItemLogFile,
            this.toolStripSeparator3,
            this.infoToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // fehlerMeldenToolStripMenuItem
            // 
            resources.ApplyResources(this.fehlerMeldenToolStripMenuItem, "fehlerMeldenToolStripMenuItem");
            this.fehlerMeldenToolStripMenuItem.Name = "fehlerMeldenToolStripMenuItem";
            this.fehlerMeldenToolStripMenuItem.Click += new System.EventHandler(this.fehlerMeldenToolStripMenuItem_Click);
            // 
            // webToolStripMenuItem
            // 
            resources.ApplyResources(this.webToolStripMenuItem, "webToolStripMenuItem");
            this.webToolStripMenuItem.Name = "webToolStripMenuItem";
            this.webToolStripMenuItem.Click += new System.EventHandler(this.webToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            // 
            // toolStripMenuItemLogFile
            // 
            resources.ApplyResources(this.toolStripMenuItemLogFile, "toolStripMenuItemLogFile");
            this.toolStripMenuItemLogFile.Name = "toolStripMenuItemLogFile";
            this.toolStripMenuItemLogFile.Click += new System.EventHandler(this.toolStripMenuItemLogFile_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // infoToolStripMenuItem
            // 
            resources.ApplyResources(this.infoToolStripMenuItem, "infoToolStripMenuItem");
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.toolTipMyTooltip.SetToolTip(this.tabControl1, resources.GetString("tabControl1.ToolTip"));
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage3.Controls.Add(this.buttonOpenSetList);
            this.tabPage3.Controls.Add(this.listViewSetList);
            this.tabPage3.Controls.Add(this.buttonSaveSetList);
            this.tabPage3.Controls.Add(this.buttonSetListAdd);
            this.tabPage3.Controls.Add(this.buttonSetListUp);
            this.tabPage3.Controls.Add(this.buttonSetListClear);
            this.tabPage3.Controls.Add(this.buttonSetListDown);
            this.tabPage3.Controls.Add(this.buttonSetListRem);
            this.tabPage3.Name = "tabPage3";
            this.toolTipMyTooltip.SetToolTip(this.tabPage3, resources.GetString("tabPage3.ToolTip"));
            // 
            // buttonOpenSetList
            // 
            resources.ApplyResources(this.buttonOpenSetList, "buttonOpenSetList");
            this.buttonOpenSetList.Name = "buttonOpenSetList";
            this.toolTipMyTooltip.SetToolTip(this.buttonOpenSetList, resources.GetString("buttonOpenSetList.ToolTip"));
            this.buttonOpenSetList.UseVisualStyleBackColor = true;
            this.buttonOpenSetList.Click += new System.EventHandler(this.buttonOpenSetList_Click);
            // 
            // listViewSetList
            // 
            resources.ApplyResources(this.listViewSetList, "listViewSetList");
            this.listViewSetList.AllowDrop = true;
            this.listViewSetList.AllowRowReorder = true;
            this.listViewSetList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.listViewSetList.FullRowSelect = true;
            this.listViewSetList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewSetList.HideSelection = false;
            this.listViewSetList.MultiSelect = false;
            this.listViewSetList.Name = "listViewSetList";
            this.toolTipMyTooltip.SetToolTip(this.listViewSetList, resources.GetString("listViewSetList.ToolTip"));
            this.listViewSetList.UseCompatibleStateImageBehavior = false;
            this.listViewSetList.View = System.Windows.Forms.View.Details;
            this.listViewSetList.SelectedIndexChanged += new System.EventHandler(this.listViewSetList_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // buttonSaveSetList
            // 
            resources.ApplyResources(this.buttonSaveSetList, "buttonSaveSetList");
            this.buttonSaveSetList.Name = "buttonSaveSetList";
            this.toolTipMyTooltip.SetToolTip(this.buttonSaveSetList, resources.GetString("buttonSaveSetList.ToolTip"));
            this.buttonSaveSetList.UseVisualStyleBackColor = true;
            this.buttonSaveSetList.Click += new System.EventHandler(this.buttonSaveSetList_Click);
            // 
            // buttonSetListAdd
            // 
            resources.ApplyResources(this.buttonSetListAdd, "buttonSetListAdd");
            this.buttonSetListAdd.Name = "buttonSetListAdd";
            this.toolTipMyTooltip.SetToolTip(this.buttonSetListAdd, resources.GetString("buttonSetListAdd.ToolTip"));
            this.buttonSetListAdd.UseVisualStyleBackColor = true;
            this.buttonSetListAdd.Click += new System.EventHandler(this.buttonSetListAdd_Click);
            // 
            // buttonSetListUp
            // 
            resources.ApplyResources(this.buttonSetListUp, "buttonSetListUp");
            this.buttonSetListUp.Name = "buttonSetListUp";
            this.toolTipMyTooltip.SetToolTip(this.buttonSetListUp, resources.GetString("buttonSetListUp.ToolTip"));
            this.buttonSetListUp.UseVisualStyleBackColor = true;
            this.buttonSetListUp.Click += new System.EventHandler(this.buttonSetListUp_Click);
            // 
            // buttonSetListClear
            // 
            resources.ApplyResources(this.buttonSetListClear, "buttonSetListClear");
            this.buttonSetListClear.Name = "buttonSetListClear";
            this.toolTipMyTooltip.SetToolTip(this.buttonSetListClear, resources.GetString("buttonSetListClear.ToolTip"));
            this.buttonSetListClear.UseVisualStyleBackColor = true;
            this.buttonSetListClear.Click += new System.EventHandler(this.buttonSetListClear_Click);
            // 
            // buttonSetListDown
            // 
            resources.ApplyResources(this.buttonSetListDown, "buttonSetListDown");
            this.buttonSetListDown.Name = "buttonSetListDown";
            this.toolTipMyTooltip.SetToolTip(this.buttonSetListDown, resources.GetString("buttonSetListDown.ToolTip"));
            this.buttonSetListDown.UseVisualStyleBackColor = true;
            this.buttonSetListDown.Click += new System.EventHandler(this.buttonSetListDown_Click);
            // 
            // buttonSetListRem
            // 
            resources.ApplyResources(this.buttonSetListRem, "buttonSetListRem");
            this.buttonSetListRem.Name = "buttonSetListRem";
            this.toolTipMyTooltip.SetToolTip(this.buttonSetListRem, resources.GetString("buttonSetListRem.ToolTip"));
            this.buttonSetListRem.UseVisualStyleBackColor = true;
            this.buttonSetListRem.Click += new System.EventHandler(this.buttonSetListRem_Click);
            // 
            // tabPage4
            // 
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage4.Controls.Add(this.listViewSongHistory);
            this.tabPage4.Name = "tabPage4";
            this.toolTipMyTooltip.SetToolTip(this.tabPage4, resources.GetString("tabPage4.ToolTip"));
            // 
            // listViewSongHistory
            // 
            resources.ApplyResources(this.listViewSongHistory, "listViewSongHistory");
            this.listViewSongHistory.AllowDrop = true;
            this.listViewSongHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewSongHistory.FullRowSelect = true;
            this.listViewSongHistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewSongHistory.HideSelection = false;
            this.listViewSongHistory.MultiSelect = false;
            this.listViewSongHistory.Name = "listViewSongHistory";
            this.toolTipMyTooltip.SetToolTip(this.listViewSongHistory, resources.GetString("listViewSongHistory.ToolTip"));
            this.listViewSongHistory.UseCompatibleStateImageBehavior = false;
            this.listViewSongHistory.View = System.Windows.Forms.View.Details;
            this.listViewSongHistory.SelectedIndexChanged += new System.EventHandler(this.listViewSongHistory_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // timerElementHighlight
            // 
            this.timerElementHighlight.Interval = 250;
            this.timerElementHighlight.Tick += new System.EventHandler(this.timerSearchBoxHL_Tick);
            // 
            // toolStripButtonProjectionOff
            // 
            resources.ApplyResources(this.toolStripButtonProjectionOff, "toolStripButtonProjectionOff");
            this.toolStripButtonProjectionOff.Checked = true;
            this.toolStripButtonProjectionOff.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonProjectionOff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonProjectionOff.Name = "toolStripButtonProjectionOff";
            this.toolStripButtonProjectionOff.Click += new System.EventHandler(this.ToggleProjection);
            // 
            // toolStripButtonBlackout
            // 
            resources.ApplyResources(this.toolStripButtonBlackout, "toolStripButtonBlackout");
            this.toolStripButtonBlackout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBlackout.Name = "toolStripButtonBlackout";
            this.toolStripButtonBlackout.Click += new System.EventHandler(this.ToggleProjection);
            // 
            // toolStripButtonProjectionOn
            // 
            resources.ApplyResources(this.toolStripButtonProjectionOn, "toolStripButtonProjectionOn");
            this.toolStripButtonProjectionOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonProjectionOn.Name = "toolStripButtonProjectionOn";
            this.toolStripButtonProjectionOn.Click += new System.EventHandler(this.ToggleProjection);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolStripButton5
            // 
            resources.ApplyResources(this.toolStripButton5, "toolStripButton5");
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton1
            // 
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripButtonDataFolder
            // 
            resources.ApplyResources(this.toolStripButtonDataFolder, "toolStripButtonDataFolder");
            this.toolStripButtonDataFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDataFolder.Name = "toolStripButtonDataFolder";
            this.toolStripButtonDataFolder.Click += new System.EventHandler(this.toolStripButtonDataFolder_Click);
            // 
            // toolStripButton4
            // 
            resources.ApplyResources(this.toolStripButton4, "toolStripButton4");
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButtonDisplaySettings
            // 
            resources.ApplyResources(this.toolStripButtonDisplaySettings, "toolStripButtonDisplaySettings");
            this.toolStripButtonDisplaySettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDisplaySettings.Name = "toolStripButtonDisplaySettings";
            this.toolStripButtonDisplaySettings.Click += new System.EventHandler(this.toolStripButtonDisplaySettings_Click);
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonProjectionOff,
            this.toolStripButtonBlackout,
            this.toolStripButtonProjectionOn,
            this.toolStripSeparator17,
            this.toolStripButtonChromaKeying,
            this.toolStripSeparator1,
            this.toolStripButton5,
            this.toolStripButton1,
            this.toolStripButtonImportFile,
            this.toolStripSeparator4,
            this.toolStripButton4,
            this.toolStripButtonDisplaySettings,
            this.toolStripButtonDataFolder,
            this.toolStripSeparator8,
            this.toolStripButtonToggleTranslationText,
            this.toolStripButtonQA});
            this.toolStrip1.Name = "toolStrip1";
            this.toolTipMyTooltip.SetToolTip(this.toolStrip1, resources.GetString("toolStrip1.ToolTip"));
            // 
            // toolStripSeparator17
            // 
            resources.ApplyResources(this.toolStripSeparator17, "toolStripSeparator17");
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            // 
            // toolStripButtonChromaKeying
            // 
            resources.ApplyResources(this.toolStripButtonChromaKeying, "toolStripButtonChromaKeying");
            this.toolStripButtonChromaKeying.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonChromaKeying.Image = global::PraiseBase.Presenter.Properties.Resources.greenscreen_small;
            this.toolStripButtonChromaKeying.Name = "toolStripButtonChromaKeying";
            this.toolStripButtonChromaKeying.Click += new System.EventHandler(this.toolStripMenuItemChromaKeying_Click);
            // 
            // toolStripButtonImportFile
            // 
            resources.ApplyResources(this.toolStripButtonImportFile, "toolStripButtonImportFile");
            this.toolStripButtonImportFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonImportFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripMenuItem,
            this.lieddateiToolStripMenuItem});
            this.toolStripButtonImportFile.Image = global::PraiseBase.Presenter.Properties.Resources.file_upload;
            this.toolStripButtonImportFile.Name = "toolStripButtonImportFile";
            this.toolStripButtonImportFile.ButtonClick += new System.EventHandler(this.toolStripButtonImportFile_ButtonClick);
            // 
            // textToolStripMenuItem
            // 
            resources.ApplyResources(this.textToolStripMenuItem, "textToolStripMenuItem");
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemImportText_Click);
            // 
            // lieddateiToolStripMenuItem
            // 
            resources.ApplyResources(this.lieddateiToolStripMenuItem, "lieddateiToolStripMenuItem");
            this.lieddateiToolStripMenuItem.Name = "lieddateiToolStripMenuItem";
            this.lieddateiToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonImportFile_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // toolStripSeparator8
            // 
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            // 
            // toolStripButtonToggleTranslationText
            // 
            resources.ApplyResources(this.toolStripButtonToggleTranslationText, "toolStripButtonToggleTranslationText");
            this.toolStripButtonToggleTranslationText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonToggleTranslationText.Name = "toolStripButtonToggleTranslationText";
            this.toolStripButtonToggleTranslationText.Click += new System.EventHandler(this.toolStripButtonToggleTranslationText_Click);
            // 
            // toolStripButtonQA
            // 
            resources.ApplyResources(this.toolStripButtonQA, "toolStripButtonQA");
            this.toolStripButtonQA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonQA.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSongEditorToolStripMenuItem,
            this.toolStripSeparator12,
            this.qaSpellingToolStripMenuItem,
            this.qaTranslationToolStripMenuItem,
            this.qaImagesToolStripMenuItem,
            this.qaSegmentationToolStripMenuItem,
            this.toolStripSeparator13,
            this.qAcommentsToolStripMenuItem});
            this.toolStripButtonQA.Name = "toolStripButtonQA";
            // 
            // openSongEditorToolStripMenuItem
            // 
            resources.ApplyResources(this.openSongEditorToolStripMenuItem, "openSongEditorToolStripMenuItem");
            this.openSongEditorToolStripMenuItem.Name = "openSongEditorToolStripMenuItem";
            this.openSongEditorToolStripMenuItem.Click += new System.EventHandler(this.openSongEditorToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            // 
            // qaSpellingToolStripMenuItem
            // 
            resources.ApplyResources(this.qaSpellingToolStripMenuItem, "qaSpellingToolStripMenuItem");
            this.qaSpellingToolStripMenuItem.CheckOnClick = true;
            this.qaSpellingToolStripMenuItem.Name = "qaSpellingToolStripMenuItem";
            this.qaSpellingToolStripMenuItem.Click += new System.EventHandler(this.qaSpellingToolStripMenuItem_Click);
            // 
            // qaTranslationToolStripMenuItem
            // 
            resources.ApplyResources(this.qaTranslationToolStripMenuItem, "qaTranslationToolStripMenuItem");
            this.qaTranslationToolStripMenuItem.CheckOnClick = true;
            this.qaTranslationToolStripMenuItem.Name = "qaTranslationToolStripMenuItem";
            this.qaTranslationToolStripMenuItem.Click += new System.EventHandler(this.qaTranslationToolStripMenuItem_Click);
            // 
            // qaImagesToolStripMenuItem
            // 
            resources.ApplyResources(this.qaImagesToolStripMenuItem, "qaImagesToolStripMenuItem");
            this.qaImagesToolStripMenuItem.CheckOnClick = true;
            this.qaImagesToolStripMenuItem.Name = "qaImagesToolStripMenuItem";
            this.qaImagesToolStripMenuItem.Click += new System.EventHandler(this.qaImagesToolStripMenuItem_Click);
            // 
            // qaSegmentationToolStripMenuItem
            // 
            resources.ApplyResources(this.qaSegmentationToolStripMenuItem, "qaSegmentationToolStripMenuItem");
            this.qaSegmentationToolStripMenuItem.CheckOnClick = true;
            this.qaSegmentationToolStripMenuItem.Name = "qaSegmentationToolStripMenuItem";
            this.qaSegmentationToolStripMenuItem.Click += new System.EventHandler(this.qaSegmentationToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            resources.ApplyResources(this.toolStripSeparator13, "toolStripSeparator13");
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            // 
            // qAcommentsToolStripMenuItem
            // 
            resources.ApplyResources(this.qAcommentsToolStripMenuItem, "qAcommentsToolStripMenuItem");
            this.qAcommentsToolStripMenuItem.Name = "qAcommentsToolStripMenuItem";
            this.qAcommentsToolStripMenuItem.Click += new System.EventHandler(this.qAcommentsToolStripMenuItem_Click);
            // 
            // customGroupBox1
            // 
            resources.ApplyResources(this.customGroupBox1, "customGroupBox1");
            this.customGroupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.customGroupBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customGroupBox1.Controls.Add(this.labelFadeTime);
            this.customGroupBox1.Controls.Add(this.pictureBoxbeamerPreview);
            this.customGroupBox1.Controls.Add(this.labelFadeTimeLayer1);
            this.customGroupBox1.Controls.Add(this.tabControl1);
            this.customGroupBox1.Controls.Add(this.buttonToggleLayerMode);
            this.customGroupBox1.Controls.Add(this.label6);
            this.customGroupBox1.Controls.Add(this.buttonToggleLayer2);
            this.customGroupBox1.Controls.Add(this.buttonToggleLayer1);
            this.customGroupBox1.Controls.Add(this.label14);
            this.customGroupBox1.Controls.Add(this.trackBarFadeTimeLayer1);
            this.customGroupBox1.Controls.Add(this.trackBarFadeTime);
            this.customGroupBox1.Name = "customGroupBox1";
            this.toolTipMyTooltip.SetToolTip(this.customGroupBox1, resources.GetString("customGroupBox1.ToolTip"));
            // 
            // labelFadeTime
            // 
            resources.ApplyResources(this.labelFadeTime, "labelFadeTime");
            this.labelFadeTime.Name = "labelFadeTime";
            this.toolTipMyTooltip.SetToolTip(this.labelFadeTime, resources.GetString("labelFadeTime.ToolTip"));
            // 
            // pictureBoxbeamerPreview
            // 
            resources.ApplyResources(this.pictureBoxbeamerPreview, "pictureBoxbeamerPreview");
            this.pictureBoxbeamerPreview.BackColor = System.Drawing.Color.Black;
            this.pictureBoxbeamerPreview.Name = "pictureBoxbeamerPreview";
            this.pictureBoxbeamerPreview.TabStop = false;
            this.toolTipMyTooltip.SetToolTip(this.pictureBoxbeamerPreview, resources.GetString("pictureBoxbeamerPreview.ToolTip"));
            // 
            // labelFadeTimeLayer1
            // 
            resources.ApplyResources(this.labelFadeTimeLayer1, "labelFadeTimeLayer1");
            this.labelFadeTimeLayer1.Name = "labelFadeTimeLayer1";
            this.toolTipMyTooltip.SetToolTip(this.labelFadeTimeLayer1, resources.GetString("labelFadeTimeLayer1.ToolTip"));
            // 
            // buttonToggleLayerMode
            // 
            resources.ApplyResources(this.buttonToggleLayerMode, "buttonToggleLayerMode");
            this.buttonToggleLayerMode.FlatAppearance.BorderSize = 0;
            this.buttonToggleLayerMode.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.buttonToggleLayerMode.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonToggleLayerMode.Name = "buttonToggleLayerMode";
            this.toolTipMyTooltip.SetToolTip(this.buttonToggleLayerMode, resources.GetString("buttonToggleLayerMode.ToolTip"));
            this.buttonToggleLayerMode.UseVisualStyleBackColor = true;
            this.buttonToggleLayerMode.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            this.toolTipMyTooltip.SetToolTip(this.label6, resources.GetString("label6.ToolTip"));
            // 
            // buttonToggleLayer2
            // 
            resources.ApplyResources(this.buttonToggleLayer2, "buttonToggleLayer2");
            this.buttonToggleLayer2.Name = "buttonToggleLayer2";
            this.toolTipMyTooltip.SetToolTip(this.buttonToggleLayer2, resources.GetString("buttonToggleLayer2.ToolTip"));
            this.buttonToggleLayer2.UseVisualStyleBackColor = true;
            this.buttonToggleLayer2.Click += new System.EventHandler(this.buttonToggleLayer2_Click);
            // 
            // buttonToggleLayer1
            // 
            resources.ApplyResources(this.buttonToggleLayer1, "buttonToggleLayer1");
            this.buttonToggleLayer1.Name = "buttonToggleLayer1";
            this.toolTipMyTooltip.SetToolTip(this.buttonToggleLayer1, resources.GetString("buttonToggleLayer1.ToolTip"));
            this.buttonToggleLayer1.UseVisualStyleBackColor = true;
            this.buttonToggleLayer1.Click += new System.EventHandler(this.buttonToggleLayer1_Click);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            this.toolTipMyTooltip.SetToolTip(this.label14, resources.GetString("label14.ToolTip"));
            // 
            // trackBarFadeTimeLayer1
            // 
            resources.ApplyResources(this.trackBarFadeTimeLayer1, "trackBarFadeTimeLayer1");
            this.trackBarFadeTimeLayer1.LargeChange = 1;
            this.trackBarFadeTimeLayer1.Name = "trackBarFadeTimeLayer1";
            this.toolTipMyTooltip.SetToolTip(this.trackBarFadeTimeLayer1, resources.GetString("trackBarFadeTimeLayer1.ToolTip"));
            this.trackBarFadeTimeLayer1.Value = 1;
            this.trackBarFadeTimeLayer1.Scroll += new System.EventHandler(this.trackBarFadeTimeLayer1_Scroll);
            // 
            // trackBarFadeTime
            // 
            resources.ApplyResources(this.trackBarFadeTime, "trackBarFadeTime");
            this.trackBarFadeTime.LargeChange = 1;
            this.trackBarFadeTime.Name = "trackBarFadeTime";
            this.toolTipMyTooltip.SetToolTip(this.trackBarFadeTime, resources.GetString("trackBarFadeTime.ToolTip"));
            this.trackBarFadeTime.Value = 1;
            this.trackBarFadeTime.Scroll += new System.EventHandler(this.trackBarFadeTime_Scroll);
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.splitContainerLayerContent);
            this.Controls.Add(this.customGroupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.toolTipMyTooltip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainWindow_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainerLayerContent.Panel1.ResumeLayout(false);
            this.splitContainerLayerContent.Panel2.ResumeLayout(false);
            this.splitContainerLayerContent.ResumeLayout(false);
            this.customGroupBox2.ResumeLayout(false);
            this.tabControlTextLayer.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPageWebVideo.ResumeLayout(false);
            this.tabPageWebVideo.PerformLayout();
            this.customGroupBox3.ResumeLayout(false);
            this.customGroupBox3.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPageImageBrowser.ResumeLayout(false);
            this.tabPageImageBrowser.PerformLayout();
            this.tabPageImageHistory.ResumeLayout(false);
            this.tabPageImageFavorites.ResumeLayout(false);
            this.tabPageSlideShow.ResumeLayout(false);
            this.tabPageSlideShow.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.customGroupBox1.ResumeLayout(false);
            this.customGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxbeamerPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFadeTimeLayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFadeTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liederlisteNeuLadenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bilderlisteNeuLadenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem liededitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datenverzeichnisÖffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.RadioButton radioButtonAutoDiaShow;
        private System.Windows.Forms.RadioButton radioButtonManualDiashow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDiaDuration;
        private System.Windows.Forms.Button buttonDiaShow;
        private System.Windows.Forms.Button buttonDisableAllDias;
        private System.Windows.Forms.Button buttonEnableAllDias;
        private System.Windows.Forms.Label labelDiaDirectory;
        private System.Windows.Forms.ListView listViewDias;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listViewSongs;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabControl tabControlTextLayer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem fehlerMeldenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemImportCCLISongSelect;
        private System.Windows.Forms.ToolStripMenuItem praiseBoxDatenbankToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem datenverzeichnisToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem liederToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bilderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setlistenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem worToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miniaturbilderPrüfenToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPageSlideShow;
        private System.Windows.Forms.TabPage tabPageImageFavorites;
        private System.Windows.Forms.TabPage tabPageImageHistory;
        private System.Windows.Forms.ListView listViewImageHistory;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TabPage tabPageImageBrowser;
        private System.Windows.Forms.TreeView treeViewImageDirectories;
        private System.Windows.Forms.ListView listViewDirectoryImages;
        private System.Windows.Forms.Label labelImgDirName;
        private System.Windows.Forms.Button buttonClearImageHistory;
        private System.Windows.Forms.ListView listViewFavorites;
        private SongDetail songDetailElement;
        private System.Windows.Forms.Button buttonResetImageQueue;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxLiveText;
        private System.Windows.Forms.Button buttonShowLiveText;
        private System.Windows.Forms.ListView listViewImageQueue;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripMenuItem präsentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem präsentationausToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem präsentationeinToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem bildschirmeSuchenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liedSuchenToolStripMenuItem;
        private System.Windows.Forms.Timer timerElementHighlight;
        private System.Windows.Forms.Button buttonOpenSetList;
        private System.Windows.Forms.Button buttonSaveSetList;
        private System.Windows.Forms.Button buttonSetListAdd;
        private System.Windows.Forms.Button buttonSetListClear;
        private DragAndDropListView listViewSetList;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button buttonSetListRem;
        private System.Windows.Forms.Button buttonSetListDown;
        private System.Windows.Forms.Button buttonSetListUp;
        private SearchTextBox songSearchTextBox;
        private SearchTextBox searchTextBoxImages;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListView listViewSongHistory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxBibleChapter;
        private System.Windows.Forms.ListBox listBoxBibleBook;
        private System.Windows.Forms.ComboBox comboBoxBible;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelBibleVerses;
        private System.Windows.Forms.Button buttonBibleTextShow;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonAddToBibleVerseList;
        private System.Windows.Forms.Button buttonRemoveFromBibleVerseList;
        private System.Windows.Forms.CheckBox checkBoxBibleShowVerseFromListDirectly;
        private SearchTextBox searchTextBoxBible;
        private System.Windows.Forms.Label labelBibleSearchMsg;
        private System.Windows.Forms.ToolStripButton toolStripButtonProjectionOff;
        private System.Windows.Forms.ToolStripButton toolStripButtonBlackout;
        private System.Windows.Forms.ToolStripButton toolStripButtonProjectionOn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButtonDataFolder;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButtonDisplaySettings;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TrackBar trackBarFadeTimeLayer1;
        private System.Windows.Forms.Button buttonToggleLayerMode;
        private System.Windows.Forms.Button buttonToggleLayer1;
        private System.Windows.Forms.Label labelFadeTimeLayer1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonToggleLayer2;
        private System.Windows.Forms.Label labelFadeTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBarFadeTime;
        private CustomGroupBox customGroupBox1;
        private CustomGroupBox customGroupBox2;
        private CustomGroupBox customGroupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem titelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem titelUndTextToolStripMenuItem;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBoxbeamerPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem optionenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem spracheToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTipMyTooltip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolStripButtonToggleTranslationText;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonQA;
        private System.Windows.Forms.ToolStripMenuItem openSongEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem qaSpellingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qaTranslationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qaImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qaSegmentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem qAcommentsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainerLayerContent;
        private DragAndDropListView listViewBibleVerseList;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button buttonSongViewModeStructure;
        private System.Windows.Forms.Button buttonSongViewModeSequence;
        private System.Windows.Forms.ListView listViewBibleVerses;
        private System.Windows.Forms.ColumnHeader columnHeaderVerseIndex;
        private System.Windows.Forms.ColumnHeader columnHeaderVerseText;
        private System.Windows.Forms.Label labelBibleTextName;
        private System.Windows.Forms.CheckBox checkBoxBibleAutoShowVerse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLogFile;
        private System.Windows.Forms.ToolStripMenuItem cCLISongSelectDateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.TabPage tabPageWebVideo;
        private System.Windows.Forms.Button buttonPlayWebVideo;
        private System.Windows.Forms.TextBox textBoxWebVideoID;
        private System.Windows.Forms.Button buttonStopWebVideo;
        private System.Windows.Forms.Label labelVideoId;
        private System.Windows.Forms.Label labelWebVideoService;
        private System.Windows.Forms.ComboBox comboBoxWebVideoService;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemChromaKeying;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripButton toolStripButtonChromaKeying;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemImportText;
        private System.Windows.Forms.ToolStripSplitButton toolStripButtonImportFile;
        private System.Windows.Forms.ToolStripMenuItem lieddateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSongStatistics;
    }
}

