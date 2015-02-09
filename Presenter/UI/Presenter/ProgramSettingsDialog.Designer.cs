namespace PraiseBase.Presenter.Forms
{
    partial class ProgramSettingsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramSettingsDialog));
            this.exitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonProjectionBackColor = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonProjectionOutlineColor = new System.Windows.Forms.Button();
            this.checkBoxProjectionFontScaling = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxShowLoadingScreen = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAddSongPart = new System.Windows.Forms.Button();
            this.textBoxNewSongPart = new System.Windows.Forms.TextBox();
            this.buttonDelSongParts = new System.Windows.Forms.Button();
            this.listBoxSongParts = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAddLang = new System.Windows.Forms.Button();
            this.textBoxNewLang = new System.Windows.Forms.TextBox();
            this.buttonDelLang = new System.Windows.Forms.Button();
            this.listBoxLanguages = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddTag = new System.Windows.Forms.Button();
            this.textBoxNewTag = new System.Windows.Forms.TextBox();
            this.buttonDelTags = new System.Windows.Forms.Button();
            this.listBoxTags = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBoxProjectionOutlineColor = new System.Windows.Forms.PictureBox();
            this.pictureBoxProjectionShadowColor = new System.Windows.Forms.PictureBox();
            this.pictureBoxProjectionBackColor = new System.Windows.Forms.PictureBox();
            this.trackBarProjectionOutlineSize = new System.Windows.Forms.TrackBar();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.trackBarProjectionShadowSize = new System.Windows.Forms.TrackBar();
            this.buttonProjectionShadowColor = new System.Windows.Forms.Button();
            this.labelProjectionPadding = new System.Windows.Forms.Label();
            this.trackBarProjectionPadding = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBoxLineSpacings = new System.Windows.Forms.GroupBox();
            this.numericUpDownLineSpacing = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTranslationLineSpacing = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBoxFonts = new System.Windows.Forms.GroupBox();
            this.labelSourceTextString = new System.Windows.Forms.Label();
            this.labelCopyrightTextString = new System.Windows.Forms.Label();
            this.labelSourceText = new System.Windows.Forms.Label();
            this.buttonSourceFont = new System.Windows.Forms.Button();
            this.buttonSourceColor = new System.Windows.Forms.Button();
            this.labelCopyrightText = new System.Windows.Forms.Label();
            this.buttonCopyrightFont = new System.Windows.Forms.Button();
            this.buttonCopyrightColor = new System.Windows.Forms.Button();
            this.labelMainText = new System.Windows.Forms.Label();
            this.buttonProjectionMasterFont = new System.Windows.Forms.Button();
            this.buttonChooseProjectionForeColor = new System.Windows.Forms.Button();
            this.buttonTranslationFont = new System.Windows.Forms.Button();
            this.buttonTranslationColor = new System.Windows.Forms.Button();
            this.labelTranslationTextString = new System.Windows.Forms.Label();
            this.labelMainTextString = new System.Windows.Forms.Label();
            this.labelTranslationText = new System.Windows.Forms.Label();
            this.checkBoxUseMasterFormat = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProjectionOutlineColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProjectionShadowColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProjectionBackColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProjectionOutlineSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProjectionShadowSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProjectionPadding)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBoxLineSpacings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineSpacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTranslationLineSpacing)).BeginInit();
            this.groupBoxFonts.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            resources.ApplyResources(this.exitButton, "exitButton");
            this.exitButton.Name = "exitButton";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // buttonProjectionBackColor
            // 
            resources.ApplyResources(this.buttonProjectionBackColor, "buttonProjectionBackColor");
            this.buttonProjectionBackColor.Name = "buttonProjectionBackColor";
            this.buttonProjectionBackColor.UseVisualStyleBackColor = true;
            this.buttonProjectionBackColor.Click += new System.EventHandler(this.buttonChosseBackgroundColor_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonProjectionOutlineColor
            // 
            resources.ApplyResources(this.buttonProjectionOutlineColor, "buttonProjectionOutlineColor");
            this.buttonProjectionOutlineColor.Name = "buttonProjectionOutlineColor";
            this.buttonProjectionOutlineColor.UseVisualStyleBackColor = true;
            this.buttonProjectionOutlineColor.Click += new System.EventHandler(this.buttonProjectionOutlineColor_Click);
            // 
            // checkBoxProjectionFontScaling
            // 
            resources.ApplyResources(this.checkBoxProjectionFontScaling, "checkBoxProjectionFontScaling");
            this.checkBoxProjectionFontScaling.Name = "checkBoxProjectionFontScaling";
            this.checkBoxProjectionFontScaling.UseVisualStyleBackColor = true;
            this.checkBoxProjectionFontScaling.CheckedChanged += new System.EventHandler(this.checkBoxFontScaling_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxShowLoadingScreen);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // checkBoxShowLoadingScreen
            // 
            resources.ApplyResources(this.checkBoxShowLoadingScreen, "checkBoxShowLoadingScreen");
            this.checkBoxShowLoadingScreen.Name = "checkBoxShowLoadingScreen";
            this.checkBoxShowLoadingScreen.UseVisualStyleBackColor = true;
            this.checkBoxShowLoadingScreen.CheckedChanged += new System.EventHandler(this.checkBoxShowLoadingScreen_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Info;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.buttonAddSongPart);
            this.tabPage3.Controls.Add(this.textBoxNewSongPart);
            this.tabPage3.Controls.Add(this.buttonDelSongParts);
            this.tabPage3.Controls.Add(this.listBoxSongParts);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.buttonAddLang);
            this.tabPage3.Controls.Add(this.textBoxNewLang);
            this.tabPage3.Controls.Add(this.buttonDelLang);
            this.tabPage3.Controls.Add(this.listBoxLanguages);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.buttonAddTag);
            this.tabPage3.Controls.Add(this.textBoxNewTag);
            this.tabPage3.Controls.Add(this.buttonDelTags);
            this.tabPage3.Controls.Add(this.listBoxTags);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // buttonAddSongPart
            // 
            resources.ApplyResources(this.buttonAddSongPart, "buttonAddSongPart");
            this.buttonAddSongPart.Name = "buttonAddSongPart";
            this.buttonAddSongPart.UseVisualStyleBackColor = true;
            this.buttonAddSongPart.Click += new System.EventHandler(this.buttonAddSongPart_Click);
            // 
            // textBoxNewSongPart
            // 
            resources.ApplyResources(this.textBoxNewSongPart, "textBoxNewSongPart");
            this.textBoxNewSongPart.Name = "textBoxNewSongPart";
            // 
            // buttonDelSongParts
            // 
            resources.ApplyResources(this.buttonDelSongParts, "buttonDelSongParts");
            this.buttonDelSongParts.Name = "buttonDelSongParts";
            this.buttonDelSongParts.UseVisualStyleBackColor = true;
            this.buttonDelSongParts.Click += new System.EventHandler(this.buttonDelSongParts_Click);
            // 
            // listBoxSongParts
            // 
            this.listBoxSongParts.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxSongParts, "listBoxSongParts");
            this.listBoxSongParts.Name = "listBoxSongParts";
            this.listBoxSongParts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // buttonAddLang
            // 
            resources.ApplyResources(this.buttonAddLang, "buttonAddLang");
            this.buttonAddLang.Name = "buttonAddLang";
            this.buttonAddLang.UseVisualStyleBackColor = true;
            this.buttonAddLang.Click += new System.EventHandler(this.buttonAddLang_Click);
            // 
            // textBoxNewLang
            // 
            resources.ApplyResources(this.textBoxNewLang, "textBoxNewLang");
            this.textBoxNewLang.Name = "textBoxNewLang";
            // 
            // buttonDelLang
            // 
            resources.ApplyResources(this.buttonDelLang, "buttonDelLang");
            this.buttonDelLang.Name = "buttonDelLang";
            this.buttonDelLang.UseVisualStyleBackColor = true;
            this.buttonDelLang.Click += new System.EventHandler(this.buttonDelLang_Click);
            // 
            // listBoxLanguages
            // 
            this.listBoxLanguages.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxLanguages, "listBoxLanguages");
            this.listBoxLanguages.Name = "listBoxLanguages";
            this.listBoxLanguages.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // buttonAddTag
            // 
            resources.ApplyResources(this.buttonAddTag, "buttonAddTag");
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.UseVisualStyleBackColor = true;
            this.buttonAddTag.Click += new System.EventHandler(this.buttonAddTag_Click);
            // 
            // textBoxNewTag
            // 
            resources.ApplyResources(this.textBoxNewTag, "textBoxNewTag");
            this.textBoxNewTag.Name = "textBoxNewTag";
            // 
            // buttonDelTags
            // 
            resources.ApplyResources(this.buttonDelTags, "buttonDelTags");
            this.buttonDelTags.Name = "buttonDelTags";
            this.buttonDelTags.UseVisualStyleBackColor = true;
            this.buttonDelTags.Click += new System.EventHandler(this.buttonDelTags_Click);
            // 
            // listBoxTags
            // 
            this.listBoxTags.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxTags, "listBoxTags");
            this.listBoxTags.Name = "listBoxTags";
            this.listBoxTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBoxProjectionOutlineColor);
            this.tabPage2.Controls.Add(this.pictureBoxProjectionShadowColor);
            this.tabPage2.Controls.Add(this.pictureBoxProjectionBackColor);
            this.tabPage2.Controls.Add(this.trackBarProjectionOutlineSize);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.trackBarProjectionShadowSize);
            this.tabPage2.Controls.Add(this.buttonProjectionShadowColor);
            this.tabPage2.Controls.Add(this.buttonProjectionOutlineColor);
            this.tabPage2.Controls.Add(this.labelProjectionPadding);
            this.tabPage2.Controls.Add(this.buttonProjectionBackColor);
            this.tabPage2.Controls.Add(this.trackBarProjectionPadding);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.checkBoxProjectionFontScaling);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBoxProjectionOutlineColor
            // 
            this.pictureBoxProjectionOutlineColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pictureBoxProjectionOutlineColor, "pictureBoxProjectionOutlineColor");
            this.pictureBoxProjectionOutlineColor.Name = "pictureBoxProjectionOutlineColor";
            this.pictureBoxProjectionOutlineColor.TabStop = false;
            // 
            // pictureBoxProjectionShadowColor
            // 
            this.pictureBoxProjectionShadowColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pictureBoxProjectionShadowColor, "pictureBoxProjectionShadowColor");
            this.pictureBoxProjectionShadowColor.Name = "pictureBoxProjectionShadowColor";
            this.pictureBoxProjectionShadowColor.TabStop = false;
            // 
            // pictureBoxProjectionBackColor
            // 
            this.pictureBoxProjectionBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pictureBoxProjectionBackColor, "pictureBoxProjectionBackColor");
            this.pictureBoxProjectionBackColor.Name = "pictureBoxProjectionBackColor";
            this.pictureBoxProjectionBackColor.TabStop = false;
            // 
            // trackBarProjectionOutlineSize
            // 
            this.trackBarProjectionOutlineSize.BackColor = System.Drawing.SystemColors.Window;
            this.trackBarProjectionOutlineSize.LargeChange = 1;
            resources.ApplyResources(this.trackBarProjectionOutlineSize, "trackBarProjectionOutlineSize");
            this.trackBarProjectionOutlineSize.Maximum = 5;
            this.trackBarProjectionOutlineSize.Name = "trackBarProjectionOutlineSize";
            this.trackBarProjectionOutlineSize.Value = 1;
            this.trackBarProjectionOutlineSize.Scroll += new System.EventHandler(this.trackBarProjectionOutlineSize_Scroll);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // trackBarProjectionShadowSize
            // 
            this.trackBarProjectionShadowSize.BackColor = System.Drawing.SystemColors.Window;
            this.trackBarProjectionShadowSize.LargeChange = 1;
            resources.ApplyResources(this.trackBarProjectionShadowSize, "trackBarProjectionShadowSize");
            this.trackBarProjectionShadowSize.Name = "trackBarProjectionShadowSize";
            this.trackBarProjectionShadowSize.Value = 5;
            this.trackBarProjectionShadowSize.Scroll += new System.EventHandler(this.trackBarProjectionShadowSize_Scroll);
            // 
            // buttonProjectionShadowColor
            // 
            resources.ApplyResources(this.buttonProjectionShadowColor, "buttonProjectionShadowColor");
            this.buttonProjectionShadowColor.Name = "buttonProjectionShadowColor";
            this.buttonProjectionShadowColor.UseVisualStyleBackColor = true;
            this.buttonProjectionShadowColor.Click += new System.EventHandler(this.buttonProjectionShadowColor_Click);
            // 
            // labelProjectionPadding
            // 
            resources.ApplyResources(this.labelProjectionPadding, "labelProjectionPadding");
            this.labelProjectionPadding.Name = "labelProjectionPadding";
            // 
            // trackBarProjectionPadding
            // 
            this.trackBarProjectionPadding.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.trackBarProjectionPadding, "trackBarProjectionPadding");
            this.trackBarProjectionPadding.Maximum = 200;
            this.trackBarProjectionPadding.Name = "trackBarProjectionPadding";
            this.trackBarProjectionPadding.TickFrequency = 10;
            this.trackBarProjectionPadding.Scroll += new System.EventHandler(this.trackBarPadding_Scroll);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBoxLineSpacings);
            this.tabPage5.Controls.Add(this.groupBoxFonts);
            this.tabPage5.Controls.Add(this.checkBoxUseMasterFormat);
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBoxLineSpacings
            // 
            this.groupBoxLineSpacings.Controls.Add(this.numericUpDownLineSpacing);
            this.groupBoxLineSpacings.Controls.Add(this.numericUpDownTranslationLineSpacing);
            this.groupBoxLineSpacings.Controls.Add(this.label7);
            this.groupBoxLineSpacings.Controls.Add(this.label14);
            resources.ApplyResources(this.groupBoxLineSpacings, "groupBoxLineSpacings");
            this.groupBoxLineSpacings.Name = "groupBoxLineSpacings";
            this.groupBoxLineSpacings.TabStop = false;
            // 
            // numericUpDownLineSpacing
            // 
            resources.ApplyResources(this.numericUpDownLineSpacing, "numericUpDownLineSpacing");
            this.numericUpDownLineSpacing.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownLineSpacing.Name = "numericUpDownLineSpacing";
            this.numericUpDownLineSpacing.ValueChanged += new System.EventHandler(this.numericUpDownLineSpacing_ValueChanged);
            // 
            // numericUpDownTranslationLineSpacing
            // 
            resources.ApplyResources(this.numericUpDownTranslationLineSpacing, "numericUpDownTranslationLineSpacing");
            this.numericUpDownTranslationLineSpacing.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownTranslationLineSpacing.Name = "numericUpDownTranslationLineSpacing";
            this.numericUpDownTranslationLineSpacing.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // groupBoxFonts
            // 
            resources.ApplyResources(this.groupBoxFonts, "groupBoxFonts");
            this.groupBoxFonts.Controls.Add(this.labelSourceTextString);
            this.groupBoxFonts.Controls.Add(this.labelCopyrightTextString);
            this.groupBoxFonts.Controls.Add(this.labelSourceText);
            this.groupBoxFonts.Controls.Add(this.buttonSourceFont);
            this.groupBoxFonts.Controls.Add(this.buttonSourceColor);
            this.groupBoxFonts.Controls.Add(this.labelCopyrightText);
            this.groupBoxFonts.Controls.Add(this.buttonCopyrightFont);
            this.groupBoxFonts.Controls.Add(this.buttonCopyrightColor);
            this.groupBoxFonts.Controls.Add(this.labelMainText);
            this.groupBoxFonts.Controls.Add(this.buttonProjectionMasterFont);
            this.groupBoxFonts.Controls.Add(this.buttonChooseProjectionForeColor);
            this.groupBoxFonts.Controls.Add(this.buttonTranslationFont);
            this.groupBoxFonts.Controls.Add(this.buttonTranslationColor);
            this.groupBoxFonts.Controls.Add(this.labelTranslationTextString);
            this.groupBoxFonts.Controls.Add(this.labelMainTextString);
            this.groupBoxFonts.Controls.Add(this.labelTranslationText);
            this.groupBoxFonts.Name = "groupBoxFonts";
            this.groupBoxFonts.TabStop = false;
            // 
            // labelSourceTextString
            // 
            resources.ApplyResources(this.labelSourceTextString, "labelSourceTextString");
            this.labelSourceTextString.Name = "labelSourceTextString";
            // 
            // labelCopyrightTextString
            // 
            resources.ApplyResources(this.labelCopyrightTextString, "labelCopyrightTextString");
            this.labelCopyrightTextString.Name = "labelCopyrightTextString";
            // 
            // labelSourceText
            // 
            resources.ApplyResources(this.labelSourceText, "labelSourceText");
            this.labelSourceText.Name = "labelSourceText";
            // 
            // buttonSourceFont
            // 
            resources.ApplyResources(this.buttonSourceFont, "buttonSourceFont");
            this.buttonSourceFont.Name = "buttonSourceFont";
            this.buttonSourceFont.UseVisualStyleBackColor = true;
            this.buttonSourceFont.Click += new System.EventHandler(this.buttonSourceFont_Click);
            // 
            // buttonSourceColor
            // 
            resources.ApplyResources(this.buttonSourceColor, "buttonSourceColor");
            this.buttonSourceColor.Name = "buttonSourceColor";
            this.buttonSourceColor.UseVisualStyleBackColor = true;
            this.buttonSourceColor.Click += new System.EventHandler(this.buttonSourceColor_Click);
            // 
            // labelCopyrightText
            // 
            resources.ApplyResources(this.labelCopyrightText, "labelCopyrightText");
            this.labelCopyrightText.Name = "labelCopyrightText";
            // 
            // buttonCopyrightFont
            // 
            resources.ApplyResources(this.buttonCopyrightFont, "buttonCopyrightFont");
            this.buttonCopyrightFont.Name = "buttonCopyrightFont";
            this.buttonCopyrightFont.UseVisualStyleBackColor = true;
            this.buttonCopyrightFont.Click += new System.EventHandler(this.buttonCopyrightFont_Click);
            // 
            // buttonCopyrightColor
            // 
            resources.ApplyResources(this.buttonCopyrightColor, "buttonCopyrightColor");
            this.buttonCopyrightColor.Name = "buttonCopyrightColor";
            this.buttonCopyrightColor.UseVisualStyleBackColor = true;
            this.buttonCopyrightColor.Click += new System.EventHandler(this.buttonCopyrightColor_Click);
            // 
            // labelMainText
            // 
            resources.ApplyResources(this.labelMainText, "labelMainText");
            this.labelMainText.Name = "labelMainText";
            // 
            // buttonProjectionMasterFont
            // 
            resources.ApplyResources(this.buttonProjectionMasterFont, "buttonProjectionMasterFont");
            this.buttonProjectionMasterFont.Name = "buttonProjectionMasterFont";
            this.buttonProjectionMasterFont.UseVisualStyleBackColor = true;
            this.buttonProjectionMasterFont.Click += new System.EventHandler(this.buttonFontSelector_Click);
            // 
            // buttonChooseProjectionForeColor
            // 
            resources.ApplyResources(this.buttonChooseProjectionForeColor, "buttonChooseProjectionForeColor");
            this.buttonChooseProjectionForeColor.Name = "buttonChooseProjectionForeColor";
            this.buttonChooseProjectionForeColor.UseVisualStyleBackColor = true;
            this.buttonChooseProjectionForeColor.Click += new System.EventHandler(this.buttonChooseProjectionForeColor_Click);
            // 
            // buttonTranslationFont
            // 
            resources.ApplyResources(this.buttonTranslationFont, "buttonTranslationFont");
            this.buttonTranslationFont.Name = "buttonTranslationFont";
            this.buttonTranslationFont.UseVisualStyleBackColor = true;
            this.buttonTranslationFont.Click += new System.EventHandler(this.buttonTranslationFont_Click);
            // 
            // buttonTranslationColor
            // 
            resources.ApplyResources(this.buttonTranslationColor, "buttonTranslationColor");
            this.buttonTranslationColor.Name = "buttonTranslationColor";
            this.buttonTranslationColor.UseVisualStyleBackColor = true;
            this.buttonTranslationColor.Click += new System.EventHandler(this.buttonTranslationColor_Click);
            // 
            // labelTranslationTextString
            // 
            resources.ApplyResources(this.labelTranslationTextString, "labelTranslationTextString");
            this.labelTranslationTextString.Name = "labelTranslationTextString";
            // 
            // labelMainTextString
            // 
            resources.ApplyResources(this.labelMainTextString, "labelMainTextString");
            this.labelMainTextString.Name = "labelMainTextString";
            // 
            // labelTranslationText
            // 
            resources.ApplyResources(this.labelTranslationText, "labelTranslationText");
            this.labelTranslationText.Name = "labelTranslationText";
            // 
            // checkBoxUseMasterFormat
            // 
            resources.ApplyResources(this.checkBoxUseMasterFormat, "checkBoxUseMasterFormat");
            this.checkBoxUseMasterFormat.Name = "checkBoxUseMasterFormat";
            this.checkBoxUseMasterFormat.UseVisualStyleBackColor = true;
            this.checkBoxUseMasterFormat.CheckedChanged += new System.EventHandler(this.checkBoxUseMasterFormat_CheckedChanged);
            // 
            // ProgramSettingsDialog
            // 
            this.AcceptButton = this.exitButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.exitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProgramSettingsDialog";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.settingsWindow_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProjectionOutlineColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProjectionShadowColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProjectionBackColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProjectionOutlineSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProjectionShadowSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProjectionPadding)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBoxLineSpacings.ResumeLayout(false);
            this.groupBoxLineSpacings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineSpacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTranslationLineSpacing)).EndInit();
            this.groupBoxFonts.ResumeLayout(false);
            this.groupBoxFonts.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonProjectionBackColor;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonProjectionOutlineColor;
        private System.Windows.Forms.CheckBox checkBoxProjectionFontScaling;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddTag;
        private System.Windows.Forms.TextBox textBoxNewTag;
        private System.Windows.Forms.Button buttonDelTags;
        private System.Windows.Forms.ListBox listBoxTags;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAddLang;
        private System.Windows.Forms.TextBox textBoxNewLang;
        private System.Windows.Forms.Button buttonDelLang;
        private System.Windows.Forms.ListBox listBoxLanguages;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAddSongPart;
        private System.Windows.Forms.TextBox textBoxNewSongPart;
        private System.Windows.Forms.Button buttonDelSongParts;
		private System.Windows.Forms.ListBox listBoxSongParts;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar trackBarProjectionPadding;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label labelProjectionPadding;
        private System.Windows.Forms.Label labelTranslationTextString;
        private System.Windows.Forms.Label labelTranslationText;
        private System.Windows.Forms.Label labelMainText;
        private System.Windows.Forms.Label labelMainTextString;
        private System.Windows.Forms.Button buttonTranslationColor;
        private System.Windows.Forms.Button buttonTranslationFont;
        private System.Windows.Forms.Button buttonChooseProjectionForeColor;
        private System.Windows.Forms.Button buttonProjectionMasterFont;
        private System.Windows.Forms.TrackBar trackBarProjectionOutlineSize;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar trackBarProjectionShadowSize;
        private System.Windows.Forms.Button buttonProjectionShadowColor;
        private System.Windows.Forms.PictureBox pictureBoxProjectionBackColor;
        private System.Windows.Forms.PictureBox pictureBoxProjectionOutlineColor;
        private System.Windows.Forms.PictureBox pictureBoxProjectionShadowColor;
        private System.Windows.Forms.CheckBox checkBoxUseMasterFormat;
		private System.Windows.Forms.GroupBox groupBoxFonts;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.CheckBox checkBoxShowLoadingScreen;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBoxLineSpacings;
        private System.Windows.Forms.NumericUpDown numericUpDownTranslationLineSpacing;
        private System.Windows.Forms.NumericUpDown numericUpDownLineSpacing;
        private System.Windows.Forms.Label labelSourceText;
        private System.Windows.Forms.Button buttonSourceFont;
        private System.Windows.Forms.Button buttonSourceColor;
        private System.Windows.Forms.Label labelCopyrightText;
        private System.Windows.Forms.Button buttonCopyrightFont;
        private System.Windows.Forms.Button buttonCopyrightColor;
        private System.Windows.Forms.Label labelSourceTextString;
        private System.Windows.Forms.Label labelCopyrightTextString;
    }
}