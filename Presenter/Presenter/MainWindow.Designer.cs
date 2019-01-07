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
            this.toolStripMenuItemMetadataEditor = new System.Windows.Forms.ToolStripMenuItem();
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
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSongFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSongTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.importPraiseBoxDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importWorshipSystemDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.importImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.importBibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            buttonChooseDiaDir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLayerContent)).BeginInit();
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
            this.splitContainerLayerContent.Panel1.Controls.Add(this.customGroupBox2);
            // 
            // splitContainerLayerContent.Panel2
            // 
            this.splitContainerLayerContent.Panel2.Controls.Add(this.customGroupBox3);
            this.splitContainerLayerContent.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainerLayerContent_SplitterMoved);
            // 
            // customGroupBox2
            // 
            resources.ApplyResources(this.customGroupBox2, "customGroupBox2");
            this.customGroupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.customGroupBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customGroupBox2.Controls.Add(this.tabControlTextLayer);
            this.customGroupBox2.Name = "customGroupBox2";
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
            this.tabControlTextLayer.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonSongViewModeSequence);
            this.tabPage1.Controls.Add(this.buttonSongViewModeStructure);
            this.tabPage1.Controls.Add(this.songSearchTextBox);
            this.tabPage1.Controls.Add(this.listViewSongs);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.songDetailElement);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonSongViewModeSequence
            // 
            resources.ApplyResources(this.buttonSongViewModeSequence, "buttonSongViewModeSequence");
            this.buttonSongViewModeSequence.Name = "buttonSongViewModeSequence";
            this.buttonSongViewModeSequence.UseVisualStyleBackColor = true;
            this.buttonSongViewModeSequence.Click += new System.EventHandler(this.buttonSongViewModeSequence_Click);
            // 
            // buttonSongViewModeStructure
            // 
            resources.ApplyResources(this.buttonSongViewModeStructure, "buttonSongViewModeStructure");
            this.buttonSongViewModeStructure.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSongViewModeStructure.Name = "buttonSongViewModeStructure";
            this.buttonSongViewModeStructure.UseVisualStyleBackColor = true;
            this.buttonSongViewModeStructure.Click += new System.EventHandler(this.buttonToggleSongViewMode_Click);
            // 
            // songSearchTextBox
            // 
            resources.ApplyResources(this.songSearchTextBox, "songSearchTextBox");
            this.songSearchTextBox.Name = "songSearchTextBox";
            this.songSearchTextBox.OptionsMenu = this.contextMenuStrip1;
            this.songSearchTextBox.TextChanged += new PraiseBase.Presenter.Controls.SearchTextBox.TextChange(this.songSearchBox_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.titelToolStripMenuItem,
            this.titelUndTextToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // titelToolStripMenuItem
            // 
            this.titelToolStripMenuItem.Name = "titelToolStripMenuItem";
            resources.ApplyResources(this.titelToolStripMenuItem, "titelToolStripMenuItem");
            this.titelToolStripMenuItem.Click += new System.EventHandler(this.titelToolStripMenuItem_Click);
            // 
            // titelUndTextToolStripMenuItem
            // 
            this.titelUndTextToolStripMenuItem.Checked = true;
            this.titelUndTextToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.titelUndTextToolStripMenuItem.Name = "titelUndTextToolStripMenuItem";
            resources.ApplyResources(this.titelUndTextToolStripMenuItem, "titelUndTextToolStripMenuItem");
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
            this.listViewSongs.UseCompatibleStateImageBehavior = false;
            this.listViewSongs.View = System.Windows.Forms.View.Details;
            this.listViewSongs.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewSongs_KeyUp);
            this.listViewSongs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewSongs_MouseClick);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
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
            this.songDetailElement.SlideClicked += new PraiseBase.Presenter.Controls.SongDetail.SlideClick(this.songDetailElement_SlideClicked);
            this.songDetailElement.ImageClicked += new PraiseBase.Presenter.Controls.SongDetail.ImageClick(this.songDetailElement_ImageClicked);
            this.songDetailElement.PreviousSongClicked += new PraiseBase.Presenter.Controls.SongDetail.PreviousSongClick(this.songDetailElement_PreviousSongClicked);
            this.songDetailElement.NextSongClicked += new PraiseBase.Presenter.Controls.SongDetail.NextSongClick(this.songDetailElement_NextSongClicked);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonShowLiveText);
            this.tabPage2.Controls.Add(this.textBoxLiveText);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonShowLiveText
            // 
            resources.ApplyResources(this.buttonShowLiveText, "buttonShowLiveText");
            this.buttonShowLiveText.Name = "buttonShowLiveText";
            this.buttonShowLiveText.UseVisualStyleBackColor = true;
            this.buttonShowLiveText.Click += new System.EventHandler(this.buttonShowLiveText_Click);
            // 
            // textBoxLiveText
            // 
            resources.ApplyResources(this.textBoxLiveText, "textBoxLiveText");
            this.textBoxLiveText.Name = "textBoxLiveText";
            // 
            // tabPage5
            // 
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
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // checkBoxBibleAutoShowVerse
            // 
            resources.ApplyResources(this.checkBoxBibleAutoShowVerse, "checkBoxBibleAutoShowVerse");
            this.checkBoxBibleAutoShowVerse.Name = "checkBoxBibleAutoShowVerse";
            this.checkBoxBibleAutoShowVerse.UseVisualStyleBackColor = true;
            // 
            // labelBibleTextName
            // 
            resources.ApplyResources(this.labelBibleTextName, "labelBibleTextName");
            this.labelBibleTextName.Name = "labelBibleTextName";
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
            // 
            // checkBoxBibleShowVerseFromListDirectly
            // 
            resources.ApplyResources(this.checkBoxBibleShowVerseFromListDirectly, "checkBoxBibleShowVerseFromListDirectly");
            this.checkBoxBibleShowVerseFromListDirectly.Name = "checkBoxBibleShowVerseFromListDirectly";
            this.checkBoxBibleShowVerseFromListDirectly.UseVisualStyleBackColor = true;
            // 
            // buttonAddToBibleVerseList
            // 
            resources.ApplyResources(this.buttonAddToBibleVerseList, "buttonAddToBibleVerseList");
            this.buttonAddToBibleVerseList.Name = "buttonAddToBibleVerseList";
            this.buttonAddToBibleVerseList.UseVisualStyleBackColor = true;
            this.buttonAddToBibleVerseList.Click += new System.EventHandler(this.buttonAddToBibleVerseList_Click);
            // 
            // buttonRemoveFromBibleVerseList
            // 
            resources.ApplyResources(this.buttonRemoveFromBibleVerseList, "buttonRemoveFromBibleVerseList");
            this.buttonRemoveFromBibleVerseList.Name = "buttonRemoveFromBibleVerseList";
            this.buttonRemoveFromBibleVerseList.UseVisualStyleBackColor = true;
            this.buttonRemoveFromBibleVerseList.Click += new System.EventHandler(this.buttonRemoveFromBibleVerseList_Click);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // searchTextBoxBible
            // 
            resources.ApplyResources(this.searchTextBoxBible, "searchTextBoxBible");
            this.searchTextBoxBible.Name = "searchTextBoxBible";
            this.searchTextBoxBible.OptionsMenu = null;
            this.searchTextBoxBible.TextChanged += new PraiseBase.Presenter.Controls.SearchTextBox.TextChange(this.searchTextBoxBible_TextChanged);
            // 
            // listViewBibleVerseList
            // 
            this.listViewBibleVerseList.AllowDrop = true;
            this.listViewBibleVerseList.AllowRowReorder = true;
            resources.ApplyResources(this.listViewBibleVerseList, "listViewBibleVerseList");
            this.listViewBibleVerseList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listViewBibleVerseList.FullRowSelect = true;
            this.listViewBibleVerseList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewBibleVerseList.HideSelection = false;
            this.listViewBibleVerseList.MultiSelect = false;
            this.listViewBibleVerseList.Name = "listViewBibleVerseList";
            this.listViewBibleVerseList.UseCompatibleStateImageBehavior = false;
            this.listViewBibleVerseList.View = System.Windows.Forms.View.Details;
            this.listViewBibleVerseList.SelectedIndexChanged += new System.EventHandler(this.listViewBibleVerseList_SelectedIndexChanged);
            // 
            // buttonBibleTextShow
            // 
            resources.ApplyResources(this.buttonBibleTextShow, "buttonBibleTextShow");
            this.buttonBibleTextShow.Name = "buttonBibleTextShow";
            this.buttonBibleTextShow.UseVisualStyleBackColor = true;
            this.buttonBibleTextShow.Click += new System.EventHandler(this.buttonBibleTextShow_Click);
            // 
            // labelBibleVerses
            // 
            resources.ApplyResources(this.labelBibleVerses, "labelBibleVerses");
            this.labelBibleVerses.Name = "labelBibleVerses";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // listBoxBibleChapter
            // 
            resources.ApplyResources(this.listBoxBibleChapter, "listBoxBibleChapter");
            this.listBoxBibleChapter.FormattingEnabled = true;
            this.listBoxBibleChapter.Name = "listBoxBibleChapter";
            this.listBoxBibleChapter.SelectedIndexChanged += new System.EventHandler(this.listBoxBibleChapter_SelectedIndexChanged);
            // 
            // listBoxBibleBook
            // 
            resources.ApplyResources(this.listBoxBibleBook, "listBoxBibleBook");
            this.listBoxBibleBook.FormattingEnabled = true;
            this.listBoxBibleBook.Name = "listBoxBibleBook";
            this.listBoxBibleBook.SelectedIndexChanged += new System.EventHandler(this.listBoxBibleBook_SelectedIndexChanged);
            // 
            // comboBoxBible
            // 
            this.comboBoxBible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBible.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxBible, "comboBoxBible");
            this.comboBoxBible.Name = "comboBoxBible";
            this.comboBoxBible.SelectedIndexChanged += new System.EventHandler(this.comboBoxBible_SelectedIndexChanged);
            // 
            // tabPageWebVideo
            // 
            this.tabPageWebVideo.Controls.Add(this.labelWebVideoService);
            this.tabPageWebVideo.Controls.Add(this.comboBoxWebVideoService);
            this.tabPageWebVideo.Controls.Add(this.labelVideoId);
            this.tabPageWebVideo.Controls.Add(this.buttonStopWebVideo);
            this.tabPageWebVideo.Controls.Add(this.buttonPlayWebVideo);
            this.tabPageWebVideo.Controls.Add(this.textBoxWebVideoID);
            resources.ApplyResources(this.tabPageWebVideo, "tabPageWebVideo");
            this.tabPageWebVideo.Name = "tabPageWebVideo";
            this.tabPageWebVideo.UseVisualStyleBackColor = true;
            // 
            // labelWebVideoService
            // 
            resources.ApplyResources(this.labelWebVideoService, "labelWebVideoService");
            this.labelWebVideoService.Name = "labelWebVideoService";
            // 
            // comboBoxWebVideoService
            // 
            this.comboBoxWebVideoService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWebVideoService.FormattingEnabled = true;
            this.comboBoxWebVideoService.Items.AddRange(new object[] {
            resources.GetString("comboBoxWebVideoService.Items"),
            resources.GetString("comboBoxWebVideoService.Items1")});
            resources.ApplyResources(this.comboBoxWebVideoService, "comboBoxWebVideoService");
            this.comboBoxWebVideoService.Name = "comboBoxWebVideoService";
            this.comboBoxWebVideoService.SelectedIndexChanged += new System.EventHandler(this.comboBoxWebVideoService_SelectedIndexChanged);
            // 
            // labelVideoId
            // 
            resources.ApplyResources(this.labelVideoId, "labelVideoId");
            this.labelVideoId.Name = "labelVideoId";
            // 
            // buttonStopWebVideo
            // 
            resources.ApplyResources(this.buttonStopWebVideo, "buttonStopWebVideo");
            this.buttonStopWebVideo.Name = "buttonStopWebVideo";
            this.buttonStopWebVideo.UseVisualStyleBackColor = true;
            this.buttonStopWebVideo.Click += new System.EventHandler(this.buttonStopWebVideo_Click);
            // 
            // buttonPlayWebVideo
            // 
            resources.ApplyResources(this.buttonPlayWebVideo, "buttonPlayWebVideo");
            this.buttonPlayWebVideo.Image = global::PraiseBase.Presenter.Properties.Resources.leinwand16;
            this.buttonPlayWebVideo.Name = "buttonPlayWebVideo";
            this.buttonPlayWebVideo.UseVisualStyleBackColor = true;
            this.buttonPlayWebVideo.Click += new System.EventHandler(this.buttonPlayWebVideo_Click);
            // 
            // textBoxWebVideoID
            // 
            resources.ApplyResources(this.textBoxWebVideoID, "textBoxWebVideoID");
            this.textBoxWebVideoID.Name = "textBoxWebVideoID";
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
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
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
            // 
            // tabPageImageBrowser
            // 
            this.tabPageImageBrowser.Controls.Add(this.searchTextBoxImages);
            this.tabPageImageBrowser.Controls.Add(this.treeViewImageDirectories);
            this.tabPageImageBrowser.Controls.Add(this.listViewDirectoryImages);
            this.tabPageImageBrowser.Controls.Add(this.labelImgDirName);
            this.tabPageImageBrowser.Controls.Add(this.buttonClearImageHistory);
            resources.ApplyResources(this.tabPageImageBrowser, "tabPageImageBrowser");
            this.tabPageImageBrowser.Name = "tabPageImageBrowser";
            this.tabPageImageBrowser.UseVisualStyleBackColor = true;
            // 
            // searchTextBoxImages
            // 
            resources.ApplyResources(this.searchTextBoxImages, "searchTextBoxImages");
            this.searchTextBoxImages.Name = "searchTextBoxImages";
            this.searchTextBoxImages.OptionsMenu = null;
            this.searchTextBoxImages.TextChanged += new PraiseBase.Presenter.Controls.SearchTextBox.TextChange(this.searchTextBoxImages_TextChanged);
            // 
            // treeViewImageDirectories
            // 
            resources.ApplyResources(this.treeViewImageDirectories, "treeViewImageDirectories");
            this.treeViewImageDirectories.FullRowSelect = true;
            this.treeViewImageDirectories.HideSelection = false;
            this.treeViewImageDirectories.Name = "treeViewImageDirectories";
            this.treeViewImageDirectories.ShowPlusMinus = false;
            this.treeViewImageDirectories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewImageDirectories_AfterSelect);
            // 
            // listViewDirectoryImages
            // 
            resources.ApplyResources(this.listViewDirectoryImages, "listViewDirectoryImages");
            this.listViewDirectoryImages.MultiSelect = false;
            this.listViewDirectoryImages.Name = "listViewDirectoryImages";
            this.listViewDirectoryImages.UseCompatibleStateImageBehavior = false;
            this.listViewDirectoryImages.SelectedIndexChanged += new System.EventHandler(this.listViewDirectoryImages_SelectedIndexChanged);
            this.listViewDirectoryImages.Leave += new System.EventHandler(this.listViewDirectoryImages_Leave);
            // 
            // labelImgDirName
            // 
            resources.ApplyResources(this.labelImgDirName, "labelImgDirName");
            this.labelImgDirName.Name = "labelImgDirName";
            // 
            // buttonClearImageHistory
            // 
            resources.ApplyResources(this.buttonClearImageHistory, "buttonClearImageHistory");
            this.buttonClearImageHistory.Name = "buttonClearImageHistory";
            this.buttonClearImageHistory.UseVisualStyleBackColor = true;
            this.buttonClearImageHistory.Click += new System.EventHandler(this.buttonClearImageHistory_Click);
            // 
            // tabPageImageHistory
            // 
            this.tabPageImageHistory.BackColor = System.Drawing.Color.White;
            this.tabPageImageHistory.Controls.Add(this.listViewImageHistory);
            resources.ApplyResources(this.tabPageImageHistory, "tabPageImageHistory");
            this.tabPageImageHistory.Name = "tabPageImageHistory";
            // 
            // listViewImageHistory
            // 
            resources.ApplyResources(this.listViewImageHistory, "listViewImageHistory");
            this.listViewImageHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.listViewImageHistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewImageHistory.MultiSelect = false;
            this.listViewImageHistory.Name = "listViewImageHistory";
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
            this.tabPageImageFavorites.Controls.Add(this.listViewFavorites);
            resources.ApplyResources(this.tabPageImageFavorites, "tabPageImageFavorites");
            this.tabPageImageFavorites.Name = "tabPageImageFavorites";
            this.tabPageImageFavorites.UseVisualStyleBackColor = true;
            // 
            // listViewFavorites
            // 
            resources.ApplyResources(this.listViewFavorites, "listViewFavorites");
            this.listViewFavorites.MultiSelect = false;
            this.listViewFavorites.Name = "listViewFavorites";
            this.listViewFavorites.UseCompatibleStateImageBehavior = false;
            this.listViewFavorites.View = System.Windows.Forms.View.Tile;
            this.listViewFavorites.SelectedIndexChanged += new System.EventHandler(this.listViewFavorites_SelectedIndexChanged);
            this.listViewFavorites.Leave += new System.EventHandler(this.listViewFavorites_Leave);
            // 
            // tabPageSlideShow
            // 
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
            resources.ApplyResources(this.tabPageSlideShow, "tabPageSlideShow");
            this.tabPageSlideShow.Name = "tabPageSlideShow";
            this.tabPageSlideShow.UseVisualStyleBackColor = true;
            // 
            // radioButtonAutoDiaShow
            // 
            resources.ApplyResources(this.radioButtonAutoDiaShow, "radioButtonAutoDiaShow");
            this.radioButtonAutoDiaShow.Checked = true;
            this.radioButtonAutoDiaShow.Name = "radioButtonAutoDiaShow";
            this.radioButtonAutoDiaShow.TabStop = true;
            this.radioButtonAutoDiaShow.UseVisualStyleBackColor = true;
            this.radioButtonAutoDiaShow.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButtonManualDiashow
            // 
            resources.ApplyResources(this.radioButtonManualDiashow, "radioButtonManualDiashow");
            this.radioButtonManualDiashow.Name = "radioButtonManualDiashow";
            this.radioButtonManualDiashow.UseVisualStyleBackColor = true;
            this.radioButtonManualDiashow.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // listViewDias
            // 
            resources.ApplyResources(this.listViewDias, "listViewDias");
            this.listViewDias.CheckBoxes = true;
            this.listViewDias.MultiSelect = false;
            this.listViewDias.Name = "listViewDias";
            this.listViewDias.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // labelDiaDirectory
            // 
            resources.ApplyResources(this.labelDiaDirectory, "labelDiaDirectory");
            this.labelDiaDirectory.Name = "labelDiaDirectory";
            // 
            // textBoxDiaDuration
            // 
            resources.ApplyResources(this.textBoxDiaDuration, "textBoxDiaDuration");
            this.textBoxDiaDuration.Name = "textBoxDiaDuration";
            // 
            // buttonEnableAllDias
            // 
            resources.ApplyResources(this.buttonEnableAllDias, "buttonEnableAllDias");
            this.buttonEnableAllDias.Name = "buttonEnableAllDias";
            this.buttonEnableAllDias.UseVisualStyleBackColor = true;
            this.buttonEnableAllDias.Click += new System.EventHandler(this.buttonEnableAllDias_Click);
            // 
            // buttonDiaShow
            // 
            resources.ApplyResources(this.buttonDiaShow, "buttonDiaShow");
            this.buttonDiaShow.Name = "buttonDiaShow";
            this.buttonDiaShow.UseVisualStyleBackColor = true;
            this.buttonDiaShow.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonDisableAllDias
            // 
            resources.ApplyResources(this.buttonDisableAllDias, "buttonDisableAllDias");
            this.buttonDisableAllDias.Name = "buttonDisableAllDias";
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
            this.buttonResetImageQueue.UseVisualStyleBackColor = true;
            this.buttonResetImageQueue.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.präsentationToolStripMenuItem,
            this.importToolStripMenuItem,
            this.einstellungenToolStripMenuItem,
            this.toolStripMenuItem1});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liedSuchenToolStripMenuItem,
            this.liededitorToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItemMetadataEditor,
            this.toolStripMenuItemSongStatistics,
            this.toolStripSeparator5,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            resources.ApplyResources(this.dateiToolStripMenuItem, "dateiToolStripMenuItem");
            // 
            // liedSuchenToolStripMenuItem
            // 
            this.liedSuchenToolStripMenuItem.Name = "liedSuchenToolStripMenuItem";
            resources.ApplyResources(this.liedSuchenToolStripMenuItem, "liedSuchenToolStripMenuItem");
            this.liedSuchenToolStripMenuItem.Click += new System.EventHandler(this.liedSuchenToolStripMenuItem_Click);
            // 
            // liededitorToolStripMenuItem
            // 
            this.liededitorToolStripMenuItem.Name = "liededitorToolStripMenuItem";
            resources.ApplyResources(this.liededitorToolStripMenuItem, "liededitorToolStripMenuItem");
            this.liededitorToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItemMetadataEditor
            // 
            this.toolStripMenuItemMetadataEditor.Name = "toolStripMenuItemMetadataEditor";
            resources.ApplyResources(this.toolStripMenuItemMetadataEditor, "toolStripMenuItemMetadataEditor");
            this.toolStripMenuItemMetadataEditor.Click += new System.EventHandler(this.toolStripMenuItemMetadataEditor_Click);
            // 
            // toolStripMenuItemSongStatistics
            // 
            this.toolStripMenuItemSongStatistics.Name = "toolStripMenuItemSongStatistics";
            resources.ApplyResources(this.toolStripMenuItemSongStatistics, "toolStripMenuItemSongStatistics");
            this.toolStripMenuItemSongStatistics.Click += new System.EventHandler(this.toolStripMenuItemSongStatistics_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            resources.ApplyResources(this.beendenToolStripMenuItem, "beendenToolStripMenuItem");
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // präsentationToolStripMenuItem
            // 
            this.präsentationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.präsentationausToolStripMenuItem,
            this.blackoutToolStripMenuItem,
            this.präsentationeinToolStripMenuItem,
            this.toolStripSeparator16,
            this.toolStripMenuItemChromaKeying,
            this.toolStripSeparator11,
            this.bildschirmeSuchenToolStripMenuItem});
            this.präsentationToolStripMenuItem.Name = "präsentationToolStripMenuItem";
            resources.ApplyResources(this.präsentationToolStripMenuItem, "präsentationToolStripMenuItem");
            // 
            // präsentationausToolStripMenuItem
            // 
            this.präsentationausToolStripMenuItem.Name = "präsentationausToolStripMenuItem";
            resources.ApplyResources(this.präsentationausToolStripMenuItem, "präsentationausToolStripMenuItem");
            this.präsentationausToolStripMenuItem.Click += new System.EventHandler(this.ToggleProjection);
            // 
            // blackoutToolStripMenuItem
            // 
            this.blackoutToolStripMenuItem.Name = "blackoutToolStripMenuItem";
            resources.ApplyResources(this.blackoutToolStripMenuItem, "blackoutToolStripMenuItem");
            this.blackoutToolStripMenuItem.Click += new System.EventHandler(this.ToggleProjection);
            // 
            // präsentationeinToolStripMenuItem
            // 
            this.präsentationeinToolStripMenuItem.Name = "präsentationeinToolStripMenuItem";
            resources.ApplyResources(this.präsentationeinToolStripMenuItem, "präsentationeinToolStripMenuItem");
            this.präsentationeinToolStripMenuItem.Click += new System.EventHandler(this.ToggleProjection);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            resources.ApplyResources(this.toolStripSeparator16, "toolStripSeparator16");
            // 
            // toolStripMenuItemChromaKeying
            // 
            this.toolStripMenuItemChromaKeying.Name = "toolStripMenuItemChromaKeying";
            resources.ApplyResources(this.toolStripMenuItemChromaKeying, "toolStripMenuItemChromaKeying");
            this.toolStripMenuItemChromaKeying.Click += new System.EventHandler(this.toolStripMenuItemChromaKeying_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            // 
            // bildschirmeSuchenToolStripMenuItem
            // 
            this.bildschirmeSuchenToolStripMenuItem.Name = "bildschirmeSuchenToolStripMenuItem";
            resources.ApplyResources(this.bildschirmeSuchenToolStripMenuItem, "bildschirmeSuchenToolStripMenuItem");
            this.bildschirmeSuchenToolStripMenuItem.Click += new System.EventHandler(this.bildschirmeSuchenToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importSongFileToolStripMenuItem,
            this.importSongTextToolStripMenuItem,
            this.toolStripSeparator14,
            this.importPraiseBoxDatabaseToolStripMenuItem,
            this.importWorshipSystemDatabaseToolStripMenuItem,
            this.toolStripSeparator6,
            this.importImageToolStripMenuItem,
            this.toolStripSeparator15,
            this.importBibleToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            resources.ApplyResources(this.importToolStripMenuItem, "importToolStripMenuItem");
            // 
            // importSongFileToolStripMenuItem
            // 
            this.importSongFileToolStripMenuItem.Name = "importSongFileToolStripMenuItem";
            resources.ApplyResources(this.importSongFileToolStripMenuItem, "importSongFileToolStripMenuItem");
            this.importSongFileToolStripMenuItem.Click += new System.EventHandler(this.cCLISongSelectDateiToolStripMenuItem_Click);
            // 
            // importSongTextToolStripMenuItem
            // 
            this.importSongTextToolStripMenuItem.Name = "importSongTextToolStripMenuItem";
            resources.ApplyResources(this.importSongTextToolStripMenuItem, "importSongTextToolStripMenuItem");
            this.importSongTextToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemImportText_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            resources.ApplyResources(this.toolStripSeparator14, "toolStripSeparator14");
            // 
            // importPraiseBoxDatabaseToolStripMenuItem
            // 
            this.importPraiseBoxDatabaseToolStripMenuItem.Name = "importPraiseBoxDatabaseToolStripMenuItem";
            resources.ApplyResources(this.importPraiseBoxDatabaseToolStripMenuItem, "importPraiseBoxDatabaseToolStripMenuItem");
            this.importPraiseBoxDatabaseToolStripMenuItem.Click += new System.EventHandler(this.praiseBoxDatenbankToolStripMenuItem_Click);
            // 
            // importWorshipSystemDatabaseToolStripMenuItem
            // 
            this.importWorshipSystemDatabaseToolStripMenuItem.Name = "importWorshipSystemDatabaseToolStripMenuItem";
            resources.ApplyResources(this.importWorshipSystemDatabaseToolStripMenuItem, "importWorshipSystemDatabaseToolStripMenuItem");
            this.importWorshipSystemDatabaseToolStripMenuItem.Click += new System.EventHandler(this.worToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // importImageToolStripMenuItem
            // 
            this.importImageToolStripMenuItem.Name = "importImageToolStripMenuItem";
            resources.ApplyResources(this.importImageToolStripMenuItem, "importImageToolStripMenuItem");
            this.importImageToolStripMenuItem.Click += new System.EventHandler(this.importImageToolStripMenuItem_Click);
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionenToolStripMenuItem,
            this.spracheToolStripMenuItem,
            this.toolStripSeparator2,
            this.datenverzeichnisÖffnenToolStripMenuItem,
            this.toolStripSeparator9,
            this.liederlisteNeuLadenToolStripMenuItem,
            this.bilderlisteNeuLadenToolStripMenuItem,
            this.miniaturbilderPrüfenToolStripMenuItem});
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            resources.ApplyResources(this.einstellungenToolStripMenuItem, "einstellungenToolStripMenuItem");
            // 
            // optionenToolStripMenuItem
            // 
            this.optionenToolStripMenuItem.Name = "optionenToolStripMenuItem";
            resources.ApplyResources(this.optionenToolStripMenuItem, "optionenToolStripMenuItem");
            this.optionenToolStripMenuItem.Click += new System.EventHandler(this.optionenToolStripMenuItem_Click);
            // 
            // spracheToolStripMenuItem
            // 
            this.spracheToolStripMenuItem.Name = "spracheToolStripMenuItem";
            resources.ApplyResources(this.spracheToolStripMenuItem, "spracheToolStripMenuItem");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // datenverzeichnisÖffnenToolStripMenuItem
            // 
            this.datenverzeichnisÖffnenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datenverzeichnisToolStripMenuItem1,
            this.toolStripSeparator10,
            this.liederToolStripMenuItem1,
            this.bilderToolStripMenuItem1,
            this.setlistenToolStripMenuItem1});
            this.datenverzeichnisÖffnenToolStripMenuItem.Name = "datenverzeichnisÖffnenToolStripMenuItem";
            resources.ApplyResources(this.datenverzeichnisÖffnenToolStripMenuItem, "datenverzeichnisÖffnenToolStripMenuItem");
            this.datenverzeichnisÖffnenToolStripMenuItem.Click += new System.EventHandler(this.datenverzeichnisOeffnenToolStripMenuItem_Click);
            // 
            // datenverzeichnisToolStripMenuItem1
            // 
            this.datenverzeichnisToolStripMenuItem1.Name = "datenverzeichnisToolStripMenuItem1";
            resources.ApplyResources(this.datenverzeichnisToolStripMenuItem1, "datenverzeichnisToolStripMenuItem1");
            this.datenverzeichnisToolStripMenuItem1.Click += new System.EventHandler(this.datenverzeichnisOeffnenToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            // 
            // liederToolStripMenuItem1
            // 
            this.liederToolStripMenuItem1.Name = "liederToolStripMenuItem1";
            resources.ApplyResources(this.liederToolStripMenuItem1, "liederToolStripMenuItem1");
            this.liederToolStripMenuItem1.Click += new System.EventHandler(this.liederToolStripMenuItem_Click);
            // 
            // bilderToolStripMenuItem1
            // 
            this.bilderToolStripMenuItem1.Name = "bilderToolStripMenuItem1";
            resources.ApplyResources(this.bilderToolStripMenuItem1, "bilderToolStripMenuItem1");
            this.bilderToolStripMenuItem1.Click += new System.EventHandler(this.bilderToolStripMenuItem_Click);
            // 
            // setlistenToolStripMenuItem1
            // 
            this.setlistenToolStripMenuItem1.Name = "setlistenToolStripMenuItem1";
            resources.ApplyResources(this.setlistenToolStripMenuItem1, "setlistenToolStripMenuItem1");
            this.setlistenToolStripMenuItem1.Click += new System.EventHandler(this.setlistenToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // liederlisteNeuLadenToolStripMenuItem
            // 
            this.liederlisteNeuLadenToolStripMenuItem.Name = "liederlisteNeuLadenToolStripMenuItem";
            resources.ApplyResources(this.liederlisteNeuLadenToolStripMenuItem, "liederlisteNeuLadenToolStripMenuItem");
            this.liederlisteNeuLadenToolStripMenuItem.Click += new System.EventHandler(this.liederlisteNeuLadenToolStripMenuItem_Click);
            // 
            // bilderlisteNeuLadenToolStripMenuItem
            // 
            this.bilderlisteNeuLadenToolStripMenuItem.Name = "bilderlisteNeuLadenToolStripMenuItem";
            resources.ApplyResources(this.bilderlisteNeuLadenToolStripMenuItem, "bilderlisteNeuLadenToolStripMenuItem");
            this.bilderlisteNeuLadenToolStripMenuItem.Click += new System.EventHandler(this.bilderlisteNeuLadenToolStripMenuItem_Click);
            // 
            // miniaturbilderPrüfenToolStripMenuItem
            // 
            this.miniaturbilderPrüfenToolStripMenuItem.Name = "miniaturbilderPrüfenToolStripMenuItem";
            resources.ApplyResources(this.miniaturbilderPrüfenToolStripMenuItem, "miniaturbilderPrüfenToolStripMenuItem");
            this.miniaturbilderPrüfenToolStripMenuItem.Click += new System.EventHandler(this.miniaturbilderPrüfenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.fehlerMeldenToolStripMenuItem,
            this.webToolStripMenuItem,
            this.toolStripSeparator7,
            this.toolStripMenuItemLogFile,
            this.toolStripSeparator3,
            this.infoToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // fehlerMeldenToolStripMenuItem
            // 
            this.fehlerMeldenToolStripMenuItem.Name = "fehlerMeldenToolStripMenuItem";
            resources.ApplyResources(this.fehlerMeldenToolStripMenuItem, "fehlerMeldenToolStripMenuItem");
            this.fehlerMeldenToolStripMenuItem.Click += new System.EventHandler(this.fehlerMeldenToolStripMenuItem_Click);
            // 
            // webToolStripMenuItem
            // 
            this.webToolStripMenuItem.Name = "webToolStripMenuItem";
            resources.ApplyResources(this.webToolStripMenuItem, "webToolStripMenuItem");
            this.webToolStripMenuItem.Click += new System.EventHandler(this.webToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // toolStripMenuItemLogFile
            // 
            this.toolStripMenuItemLogFile.Name = "toolStripMenuItemLogFile";
            resources.ApplyResources(this.toolStripMenuItemLogFile, "toolStripMenuItemLogFile");
            this.toolStripMenuItemLogFile.Click += new System.EventHandler(this.toolStripMenuItemLogFile_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            resources.ApplyResources(this.infoToolStripMenuItem, "infoToolStripMenuItem");
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage3.Controls.Add(this.buttonOpenSetList);
            this.tabPage3.Controls.Add(this.listViewSetList);
            this.tabPage3.Controls.Add(this.buttonSaveSetList);
            this.tabPage3.Controls.Add(this.buttonSetListAdd);
            this.tabPage3.Controls.Add(this.buttonSetListUp);
            this.tabPage3.Controls.Add(this.buttonSetListClear);
            this.tabPage3.Controls.Add(this.buttonSetListDown);
            this.tabPage3.Controls.Add(this.buttonSetListRem);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
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
            this.listViewSetList.AllowDrop = true;
            this.listViewSetList.AllowRowReorder = true;
            resources.ApplyResources(this.listViewSetList, "listViewSetList");
            this.listViewSetList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.listViewSetList.FullRowSelect = true;
            this.listViewSetList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewSetList.HideSelection = false;
            this.listViewSetList.MultiSelect = false;
            this.listViewSetList.Name = "listViewSetList";
            this.listViewSetList.UseCompatibleStateImageBehavior = false;
            this.listViewSetList.View = System.Windows.Forms.View.Details;
            this.listViewSetList.SelectedIndexChanged += new System.EventHandler(this.listViewSetList_SelectedIndexChanged);
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
            this.tabPage4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage4.Controls.Add(this.listViewSongHistory);
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            // 
            // listViewSongHistory
            // 
            this.listViewSongHistory.AllowDrop = true;
            resources.ApplyResources(this.listViewSongHistory, "listViewSongHistory");
            this.listViewSongHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewSongHistory.FullRowSelect = true;
            this.listViewSongHistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewSongHistory.HideSelection = false;
            this.listViewSongHistory.MultiSelect = false;
            this.listViewSongHistory.Name = "listViewSongHistory";
            this.listViewSongHistory.UseCompatibleStateImageBehavior = false;
            this.listViewSongHistory.View = System.Windows.Forms.View.Details;
            this.listViewSongHistory.SelectedIndexChanged += new System.EventHandler(this.listViewSongHistory_SelectedIndexChanged);
            // 
            // timerElementHighlight
            // 
            this.timerElementHighlight.Interval = 250;
            this.timerElementHighlight.Tick += new System.EventHandler(this.timerSearchBoxHL_Tick);
            // 
            // toolStripButtonProjectionOff
            // 
            this.toolStripButtonProjectionOff.Checked = true;
            this.toolStripButtonProjectionOff.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonProjectionOff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonProjectionOff, "toolStripButtonProjectionOff");
            this.toolStripButtonProjectionOff.Name = "toolStripButtonProjectionOff";
            this.toolStripButtonProjectionOff.Click += new System.EventHandler(this.ToggleProjection);
            // 
            // toolStripButtonBlackout
            // 
            this.toolStripButtonBlackout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonBlackout, "toolStripButtonBlackout");
            this.toolStripButtonBlackout.Name = "toolStripButtonBlackout";
            this.toolStripButtonBlackout.Click += new System.EventHandler(this.ToggleProjection);
            // 
            // toolStripButtonProjectionOn
            // 
            this.toolStripButtonProjectionOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonProjectionOn, "toolStripButtonProjectionOn");
            this.toolStripButtonProjectionOn.Name = "toolStripButtonProjectionOn";
            this.toolStripButtonProjectionOn.Click += new System.EventHandler(this.ToggleProjection);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton5, "toolStripButton5");
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripButtonDataFolder
            // 
            this.toolStripButtonDataFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonDataFolder, "toolStripButtonDataFolder");
            this.toolStripButtonDataFolder.Name = "toolStripButtonDataFolder";
            this.toolStripButtonDataFolder.Click += new System.EventHandler(this.toolStripButtonDataFolder_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton4, "toolStripButton4");
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButtonDisplaySettings
            // 
            this.toolStripButtonDisplaySettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonDisplaySettings, "toolStripButtonDisplaySettings");
            this.toolStripButtonDisplaySettings.Name = "toolStripButtonDisplaySettings";
            this.toolStripButtonDisplaySettings.Click += new System.EventHandler(this.toolStripButtonDisplaySettings_Click);
            // 
            // toolStrip1
            // 
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
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            resources.ApplyResources(this.toolStripSeparator17, "toolStripSeparator17");
            // 
            // toolStripButtonChromaKeying
            // 
            this.toolStripButtonChromaKeying.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonChromaKeying.Image = global::PraiseBase.Presenter.Properties.Resources.greenscreen_small;
            resources.ApplyResources(this.toolStripButtonChromaKeying, "toolStripButtonChromaKeying");
            this.toolStripButtonChromaKeying.Name = "toolStripButtonChromaKeying";
            this.toolStripButtonChromaKeying.Click += new System.EventHandler(this.toolStripMenuItemChromaKeying_Click);
            // 
            // toolStripButtonImportFile
            // 
            this.toolStripButtonImportFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonImportFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripMenuItem,
            this.lieddateiToolStripMenuItem});
            this.toolStripButtonImportFile.Image = global::PraiseBase.Presenter.Properties.Resources.file_upload;
            resources.ApplyResources(this.toolStripButtonImportFile, "toolStripButtonImportFile");
            this.toolStripButtonImportFile.Name = "toolStripButtonImportFile";
            this.toolStripButtonImportFile.ButtonClick += new System.EventHandler(this.toolStripButtonImportFile_ButtonClick);
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            resources.ApplyResources(this.textToolStripMenuItem, "textToolStripMenuItem");
            this.textToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemImportText_Click);
            // 
            // lieddateiToolStripMenuItem
            // 
            this.lieddateiToolStripMenuItem.Name = "lieddateiToolStripMenuItem";
            resources.ApplyResources(this.lieddateiToolStripMenuItem, "lieddateiToolStripMenuItem");
            this.lieddateiToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonImportFile_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // toolStripButtonToggleTranslationText
            // 
            this.toolStripButtonToggleTranslationText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonToggleTranslationText, "toolStripButtonToggleTranslationText");
            this.toolStripButtonToggleTranslationText.Name = "toolStripButtonToggleTranslationText";
            this.toolStripButtonToggleTranslationText.Click += new System.EventHandler(this.toolStripButtonToggleTranslationText_Click);
            // 
            // toolStripButtonQA
            // 
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
            resources.ApplyResources(this.toolStripButtonQA, "toolStripButtonQA");
            this.toolStripButtonQA.Name = "toolStripButtonQA";
            // 
            // openSongEditorToolStripMenuItem
            // 
            this.openSongEditorToolStripMenuItem.Name = "openSongEditorToolStripMenuItem";
            resources.ApplyResources(this.openSongEditorToolStripMenuItem, "openSongEditorToolStripMenuItem");
            this.openSongEditorToolStripMenuItem.Click += new System.EventHandler(this.openSongEditorToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
            // 
            // qaSpellingToolStripMenuItem
            // 
            this.qaSpellingToolStripMenuItem.CheckOnClick = true;
            resources.ApplyResources(this.qaSpellingToolStripMenuItem, "qaSpellingToolStripMenuItem");
            this.qaSpellingToolStripMenuItem.Name = "qaSpellingToolStripMenuItem";
            this.qaSpellingToolStripMenuItem.Click += new System.EventHandler(this.qaSpellingToolStripMenuItem_Click);
            // 
            // qaTranslationToolStripMenuItem
            // 
            this.qaTranslationToolStripMenuItem.CheckOnClick = true;
            resources.ApplyResources(this.qaTranslationToolStripMenuItem, "qaTranslationToolStripMenuItem");
            this.qaTranslationToolStripMenuItem.Name = "qaTranslationToolStripMenuItem";
            this.qaTranslationToolStripMenuItem.Click += new System.EventHandler(this.qaTranslationToolStripMenuItem_Click);
            // 
            // qaImagesToolStripMenuItem
            // 
            this.qaImagesToolStripMenuItem.CheckOnClick = true;
            resources.ApplyResources(this.qaImagesToolStripMenuItem, "qaImagesToolStripMenuItem");
            this.qaImagesToolStripMenuItem.Name = "qaImagesToolStripMenuItem";
            this.qaImagesToolStripMenuItem.Click += new System.EventHandler(this.qaImagesToolStripMenuItem_Click);
            // 
            // qaSegmentationToolStripMenuItem
            // 
            this.qaSegmentationToolStripMenuItem.CheckOnClick = true;
            resources.ApplyResources(this.qaSegmentationToolStripMenuItem, "qaSegmentationToolStripMenuItem");
            this.qaSegmentationToolStripMenuItem.Name = "qaSegmentationToolStripMenuItem";
            this.qaSegmentationToolStripMenuItem.Click += new System.EventHandler(this.qaSegmentationToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            resources.ApplyResources(this.toolStripSeparator13, "toolStripSeparator13");
            // 
            // qAcommentsToolStripMenuItem
            // 
            this.qAcommentsToolStripMenuItem.Name = "qAcommentsToolStripMenuItem";
            resources.ApplyResources(this.qAcommentsToolStripMenuItem, "qAcommentsToolStripMenuItem");
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
            // 
            // labelFadeTime
            // 
            resources.ApplyResources(this.labelFadeTime, "labelFadeTime");
            this.labelFadeTime.Name = "labelFadeTime";
            // 
            // pictureBoxbeamerPreview
            // 
            resources.ApplyResources(this.pictureBoxbeamerPreview, "pictureBoxbeamerPreview");
            this.pictureBoxbeamerPreview.BackColor = System.Drawing.Color.Black;
            this.pictureBoxbeamerPreview.Name = "pictureBoxbeamerPreview";
            this.pictureBoxbeamerPreview.TabStop = false;
            // 
            // labelFadeTimeLayer1
            // 
            resources.ApplyResources(this.labelFadeTimeLayer1, "labelFadeTimeLayer1");
            this.labelFadeTimeLayer1.Name = "labelFadeTimeLayer1";
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
            // 
            // trackBarFadeTimeLayer1
            // 
            resources.ApplyResources(this.trackBarFadeTimeLayer1, "trackBarFadeTimeLayer1");
            this.trackBarFadeTimeLayer1.LargeChange = 1;
            this.trackBarFadeTimeLayer1.Name = "trackBarFadeTimeLayer1";
            this.trackBarFadeTimeLayer1.Value = 1;
            this.trackBarFadeTimeLayer1.Scroll += new System.EventHandler(this.trackBarFadeTimeLayer1_Scroll);
            // 
            // trackBarFadeTime
            // 
            resources.ApplyResources(this.trackBarFadeTime, "trackBarFadeTime");
            this.trackBarFadeTime.LargeChange = 1;
            this.trackBarFadeTime.Name = "trackBarFadeTime";
            this.trackBarFadeTime.Value = 1;
            this.trackBarFadeTime.Scroll += new System.EventHandler(this.trackBarFadeTime_Scroll);
            // 
            // importBibleToolStripMenuItem
            // 
            this.importBibleToolStripMenuItem.Name = "importBibleToolStripMenuItem";
            resources.ApplyResources(this.importBibleToolStripMenuItem, "importBibleToolStripMenuItem");
            this.importBibleToolStripMenuItem.Click += new System.EventHandler(this.importBibleToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            resources.ApplyResources(this.toolStripSeparator15, "toolStripSeparator15");
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainWindow_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainerLayerContent.Panel1.ResumeLayout(false);
            this.splitContainerLayerContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLayerContent)).EndInit();
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem datenverzeichnisToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem liederToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bilderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setlistenToolStripMenuItem1;
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
        private System.Windows.Forms.ToolStripSplitButton toolStripButtonImportFile;
        private System.Windows.Forms.ToolStripMenuItem lieddateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSongStatistics;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMetadataEditor;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSongFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSongTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem importPraiseBoxDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importWorshipSystemDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem importImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem importBibleToolStripMenuItem;
    }
}

