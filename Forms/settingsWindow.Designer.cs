namespace Pbp.Forms
{
    partial class settingsWindow
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
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBoxUseMaster = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonProjectionMasterFont = new System.Windows.Forms.Button();
            this.labelLineSpacing = new System.Windows.Forms.Label();
            this.buttonChooseProjectionForeColor = new System.Windows.Forms.Button();
            this.trackBarLineSpacing = new System.Windows.Forms.TrackBar();
            this.buttonTranslationFont = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonTranslationColor = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxUseMasterFormat = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProjectionOutlineColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProjectionShadowColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProjectionBackColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProjectionOutlineSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProjectionShadowSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProjectionPadding)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBoxUseMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLineSpacing)).BeginInit();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(8, 330);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "&Ok";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(89, 330);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Abbrechen";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Benutzerdaten (Bilder, Lieder):";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(436, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Ordner wählen...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(197, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(233, 20);
            this.textBox1.TabIndex = 5;
            // 
            // buttonProjectionBackColor
            // 
            this.buttonProjectionBackColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProjectionBackColor.Location = new System.Drawing.Point(21, 18);
            this.buttonProjectionBackColor.Name = "buttonProjectionBackColor";
            this.buttonProjectionBackColor.Size = new System.Drawing.Size(158, 23);
            this.buttonProjectionBackColor.TabIndex = 30;
            this.buttonProjectionBackColor.Text = "Hintergrundfarbe...";
            this.buttonProjectionBackColor.UseVisualStyleBackColor = true;
            this.buttonProjectionBackColor.Click += new System.EventHandler(this.buttonChosseBackgroundColor_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(468, 330);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 23);
            this.button2.TabIndex = 36;
            this.button2.Text = "Auf &Standard zurücksetzen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonProjectionOutlineColor
            // 
            this.buttonProjectionOutlineColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProjectionOutlineColor.Location = new System.Drawing.Point(293, 190);
            this.buttonProjectionOutlineColor.Name = "buttonProjectionOutlineColor";
            this.buttonProjectionOutlineColor.Size = new System.Drawing.Size(162, 23);
            this.buttonProjectionOutlineColor.TabIndex = 32;
            this.buttonProjectionOutlineColor.Text = "Umrandungsfarbe...";
            this.buttonProjectionOutlineColor.UseVisualStyleBackColor = true;
            this.buttonProjectionOutlineColor.Click += new System.EventHandler(this.buttonProjectionOutlineColor_Click);
            // 
            // checkBoxProjectionFontScaling
            // 
            this.checkBoxProjectionFontScaling.AutoSize = true;
            this.checkBoxProjectionFontScaling.Location = new System.Drawing.Point(21, 61);
            this.checkBoxProjectionFontScaling.Name = "checkBoxProjectionFontScaling";
            this.checkBoxProjectionFontScaling.Size = new System.Drawing.Size(279, 17);
            this.checkBoxProjectionFontScaling.TabIndex = 38;
            this.checkBoxProjectionFontScaling.Text = "Schriften herunterskalieren falls Schriftgrösse zu gross";
            this.checkBoxProjectionFontScaling.UseVisualStyleBackColor = true;
            this.checkBoxProjectionFontScaling.CheckedChanged += new System.EventHandler(this.checkBoxFontScaling_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(8, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(612, 302);
            this.tabControl1.TabIndex = 39;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(604, 276);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Allgemeines";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(604, 276);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Vorgaben";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(412, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Liedteile:";
            // 
            // buttonAddSongPart
            // 
            this.buttonAddSongPart.Location = new System.Drawing.Point(522, 25);
            this.buttonAddSongPart.Name = "buttonAddSongPart";
            this.buttonAddSongPart.Size = new System.Drawing.Size(75, 23);
            this.buttonAddSongPart.TabIndex = 13;
            this.buttonAddSongPart.Text = "Hinzufügen";
            this.buttonAddSongPart.UseVisualStyleBackColor = true;
            this.buttonAddSongPart.Click += new System.EventHandler(this.buttonAddSongPart_Click);
            // 
            // textBoxNewSongPart
            // 
            this.textBoxNewSongPart.Location = new System.Drawing.Point(411, 26);
            this.textBoxNewSongPart.Name = "textBoxNewSongPart";
            this.textBoxNewSongPart.Size = new System.Drawing.Size(105, 20);
            this.textBoxNewSongPart.TabIndex = 12;
            // 
            // buttonDelSongParts
            // 
            this.buttonDelSongParts.Location = new System.Drawing.Point(411, 247);
            this.buttonDelSongParts.Name = "buttonDelSongParts";
            this.buttonDelSongParts.Size = new System.Drawing.Size(186, 23);
            this.buttonDelSongParts.TabIndex = 11;
            this.buttonDelSongParts.Text = "Markierte löschen";
            this.buttonDelSongParts.UseVisualStyleBackColor = true;
            this.buttonDelSongParts.Click += new System.EventHandler(this.buttonDelSongParts_Click);
            // 
            // listBoxSongParts
            // 
            this.listBoxSongParts.FormattingEnabled = true;
            this.listBoxSongParts.Location = new System.Drawing.Point(411, 52);
            this.listBoxSongParts.Name = "listBoxSongParts";
            this.listBoxSongParts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSongParts.Size = new System.Drawing.Size(186, 186);
            this.listBoxSongParts.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(208, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Sprachen:";
            // 
            // buttonAddLang
            // 
            this.buttonAddLang.Location = new System.Drawing.Point(318, 25);
            this.buttonAddLang.Name = "buttonAddLang";
            this.buttonAddLang.Size = new System.Drawing.Size(75, 23);
            this.buttonAddLang.TabIndex = 8;
            this.buttonAddLang.Text = "Hinzufügen";
            this.buttonAddLang.UseVisualStyleBackColor = true;
            this.buttonAddLang.Click += new System.EventHandler(this.buttonAddLang_Click);
            // 
            // textBoxNewLang
            // 
            this.textBoxNewLang.Location = new System.Drawing.Point(207, 26);
            this.textBoxNewLang.Name = "textBoxNewLang";
            this.textBoxNewLang.Size = new System.Drawing.Size(105, 20);
            this.textBoxNewLang.TabIndex = 7;
            // 
            // buttonDelLang
            // 
            this.buttonDelLang.Location = new System.Drawing.Point(207, 247);
            this.buttonDelLang.Name = "buttonDelLang";
            this.buttonDelLang.Size = new System.Drawing.Size(186, 23);
            this.buttonDelLang.TabIndex = 6;
            this.buttonDelLang.Text = "Markierte löschen";
            this.buttonDelLang.UseVisualStyleBackColor = true;
            this.buttonDelLang.Click += new System.EventHandler(this.buttonDelLang_Click);
            // 
            // listBoxLanguages
            // 
            this.listBoxLanguages.FormattingEnabled = true;
            this.listBoxLanguages.Location = new System.Drawing.Point(207, 52);
            this.listBoxLanguages.Name = "listBoxLanguages";
            this.listBoxLanguages.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxLanguages.Size = new System.Drawing.Size(186, 186);
            this.listBoxLanguages.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tags:";
            // 
            // buttonAddTag
            // 
            this.buttonAddTag.Location = new System.Drawing.Point(117, 25);
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.Size = new System.Drawing.Size(75, 23);
            this.buttonAddTag.TabIndex = 3;
            this.buttonAddTag.Text = "Hinzufügen";
            this.buttonAddTag.UseVisualStyleBackColor = true;
            this.buttonAddTag.Click += new System.EventHandler(this.buttonAddTag_Click);
            // 
            // textBoxNewTag
            // 
            this.textBoxNewTag.Location = new System.Drawing.Point(6, 26);
            this.textBoxNewTag.Name = "textBoxNewTag";
            this.textBoxNewTag.Size = new System.Drawing.Size(105, 20);
            this.textBoxNewTag.TabIndex = 2;
            // 
            // buttonDelTags
            // 
            this.buttonDelTags.Location = new System.Drawing.Point(6, 247);
            this.buttonDelTags.Name = "buttonDelTags";
            this.buttonDelTags.Size = new System.Drawing.Size(186, 23);
            this.buttonDelTags.TabIndex = 1;
            this.buttonDelTags.Text = "Markierte löschen";
            this.buttonDelTags.UseVisualStyleBackColor = true;
            this.buttonDelTags.Click += new System.EventHandler(this.buttonDelTags_Click);
            // 
            // listBoxTags
            // 
            this.listBoxTags.FormattingEnabled = true;
            this.listBoxTags.Location = new System.Drawing.Point(6, 52);
            this.listBoxTags.Name = "listBoxTags";
            this.listBoxTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxTags.Size = new System.Drawing.Size(186, 186);
            this.listBoxTags.TabIndex = 0;
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
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(604, 276);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Projektion";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBoxProjectionOutlineColor
            // 
            this.pictureBoxProjectionOutlineColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxProjectionOutlineColor.Location = new System.Drawing.Point(486, 184);
            this.pictureBoxProjectionOutlineColor.Name = "pictureBoxProjectionOutlineColor";
            this.pictureBoxProjectionOutlineColor.Size = new System.Drawing.Size(36, 36);
            this.pictureBoxProjectionOutlineColor.TabIndex = 56;
            this.pictureBoxProjectionOutlineColor.TabStop = false;
            // 
            // pictureBoxProjectionShadowColor
            // 
            this.pictureBoxProjectionShadowColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxProjectionShadowColor.Location = new System.Drawing.Point(486, 136);
            this.pictureBoxProjectionShadowColor.Name = "pictureBoxProjectionShadowColor";
            this.pictureBoxProjectionShadowColor.Size = new System.Drawing.Size(36, 36);
            this.pictureBoxProjectionShadowColor.TabIndex = 55;
            this.pictureBoxProjectionShadowColor.TabStop = false;
            // 
            // pictureBoxProjectionBackColor
            // 
            this.pictureBoxProjectionBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxProjectionBackColor.Location = new System.Drawing.Point(198, 12);
            this.pictureBoxProjectionBackColor.Name = "pictureBoxProjectionBackColor";
            this.pictureBoxProjectionBackColor.Size = new System.Drawing.Size(36, 36);
            this.pictureBoxProjectionBackColor.TabIndex = 54;
            this.pictureBoxProjectionBackColor.TabStop = false;
            // 
            // trackBarProjectionOutlineSize
            // 
            this.trackBarProjectionOutlineSize.LargeChange = 1;
            this.trackBarProjectionOutlineSize.Location = new System.Drawing.Point(110, 191);
            this.trackBarProjectionOutlineSize.Maximum = 5;
            this.trackBarProjectionOutlineSize.Name = "trackBarProjectionOutlineSize";
            this.trackBarProjectionOutlineSize.Size = new System.Drawing.Size(156, 42);
            this.trackBarProjectionOutlineSize.TabIndex = 53;
            this.trackBarProjectionOutlineSize.Value = 1;
            this.trackBarProjectionOutlineSize.Scroll += new System.EventHandler(this.trackBarProjectionOutlineSize_Scroll);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(18, 195);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 52;
            this.label13.Text = "Umrandung:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 148);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 51;
            this.label12.Text = "Schatten:";
            // 
            // trackBarProjectionShadowSize
            // 
            this.trackBarProjectionShadowSize.LargeChange = 1;
            this.trackBarProjectionShadowSize.Location = new System.Drawing.Point(110, 143);
            this.trackBarProjectionShadowSize.Name = "trackBarProjectionShadowSize";
            this.trackBarProjectionShadowSize.Size = new System.Drawing.Size(156, 42);
            this.trackBarProjectionShadowSize.TabIndex = 50;
            this.trackBarProjectionShadowSize.Value = 5;
            this.trackBarProjectionShadowSize.Scroll += new System.EventHandler(this.trackBarProjectionShadowSize_Scroll);
            // 
            // buttonProjectionShadowColor
            // 
            this.buttonProjectionShadowColor.Location = new System.Drawing.Point(293, 143);
            this.buttonProjectionShadowColor.Name = "buttonProjectionShadowColor";
            this.buttonProjectionShadowColor.Size = new System.Drawing.Size(162, 23);
            this.buttonProjectionShadowColor.TabIndex = 49;
            this.buttonProjectionShadowColor.Text = "Schattenfarbe...";
            this.buttonProjectionShadowColor.UseVisualStyleBackColor = true;
            this.buttonProjectionShadowColor.Click += new System.EventHandler(this.buttonProjectionShadowColor_Click);
            // 
            // labelProjectionPadding
            // 
            this.labelProjectionPadding.AutoSize = true;
            this.labelProjectionPadding.Location = new System.Drawing.Point(290, 100);
            this.labelProjectionPadding.Name = "labelProjectionPadding";
            this.labelProjectionPadding.Size = new System.Drawing.Size(10, 13);
            this.labelProjectionPadding.TabIndex = 48;
            this.labelProjectionPadding.Text = "-";
            // 
            // trackBarProjectionPadding
            // 
            this.trackBarProjectionPadding.Location = new System.Drawing.Point(110, 95);
            this.trackBarProjectionPadding.Maximum = 200;
            this.trackBarProjectionPadding.Name = "trackBarProjectionPadding";
            this.trackBarProjectionPadding.Size = new System.Drawing.Size(156, 42);
            this.trackBarProjectionPadding.TabIndex = 46;
            this.trackBarProjectionPadding.TickFrequency = 10;
            this.trackBarProjectionPadding.Scroll += new System.EventHandler(this.trackBarPadding_Scroll);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Randabstand:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(604, 276);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Editor";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(316, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Momentan sind noch keine Einstellungsmöglichkeiten vorhanden!";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBoxUseMaster);
            this.tabPage5.Controls.Add(this.checkBoxUseMasterFormat);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(604, 276);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Masterformatierung";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBoxUseMaster
            // 
            this.groupBoxUseMaster.Controls.Add(this.label2);
            this.groupBoxUseMaster.Controls.Add(this.buttonProjectionMasterFont);
            this.groupBoxUseMaster.Controls.Add(this.labelLineSpacing);
            this.groupBoxUseMaster.Controls.Add(this.buttonChooseProjectionForeColor);
            this.groupBoxUseMaster.Controls.Add(this.trackBarLineSpacing);
            this.groupBoxUseMaster.Controls.Add(this.buttonTranslationFont);
            this.groupBoxUseMaster.Controls.Add(this.label10);
            this.groupBoxUseMaster.Controls.Add(this.buttonTranslationColor);
            this.groupBoxUseMaster.Controls.Add(this.label9);
            this.groupBoxUseMaster.Controls.Add(this.label3);
            this.groupBoxUseMaster.Controls.Add(this.label8);
            this.groupBoxUseMaster.Location = new System.Drawing.Point(6, 42);
            this.groupBoxUseMaster.Name = "groupBoxUseMaster";
            this.groupBoxUseMaster.Size = new System.Drawing.Size(579, 119);
            this.groupBoxUseMaster.TabIndex = 56;
            this.groupBoxUseMaster.TabStop = false;
            this.groupBoxUseMaster.Text = "Masterformatierung";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Projektionsschrift:";
            // 
            // buttonProjectionMasterFont
            // 
            this.buttonProjectionMasterFont.Location = new System.Drawing.Point(320, 16);
            this.buttonProjectionMasterFont.Name = "buttonProjectionMasterFont";
            this.buttonProjectionMasterFont.Size = new System.Drawing.Size(124, 23);
            this.buttonProjectionMasterFont.TabIndex = 44;
            this.buttonProjectionMasterFont.Text = "Schrift wählen...";
            this.buttonProjectionMasterFont.UseVisualStyleBackColor = true;
            this.buttonProjectionMasterFont.Click += new System.EventHandler(this.buttonFontSelector_Click);
            // 
            // labelLineSpacing
            // 
            this.labelLineSpacing.AutoSize = true;
            this.labelLineSpacing.Location = new System.Drawing.Point(267, 79);
            this.labelLineSpacing.Name = "labelLineSpacing";
            this.labelLineSpacing.Size = new System.Drawing.Size(10, 13);
            this.labelLineSpacing.TabIndex = 54;
            this.labelLineSpacing.Text = "-";
            // 
            // buttonChooseProjectionForeColor
            // 
            this.buttonChooseProjectionForeColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChooseProjectionForeColor.Location = new System.Drawing.Point(450, 16);
            this.buttonChooseProjectionForeColor.Name = "buttonChooseProjectionForeColor";
            this.buttonChooseProjectionForeColor.Size = new System.Drawing.Size(119, 23);
            this.buttonChooseProjectionForeColor.TabIndex = 43;
            this.buttonChooseProjectionForeColor.Text = "Schriftfarbe...";
            this.buttonChooseProjectionForeColor.UseVisualStyleBackColor = true;
            this.buttonChooseProjectionForeColor.Click += new System.EventHandler(this.buttonChooseProjectionForeColor_Click);
            // 
            // trackBarLineSpacing
            // 
            this.trackBarLineSpacing.Location = new System.Drawing.Point(120, 75);
            this.trackBarLineSpacing.Maximum = 50;
            this.trackBarLineSpacing.Name = "trackBarLineSpacing";
            this.trackBarLineSpacing.Size = new System.Drawing.Size(141, 42);
            this.trackBarLineSpacing.TabIndex = 53;
            this.trackBarLineSpacing.TickFrequency = 5;
            this.trackBarLineSpacing.Scroll += new System.EventHandler(this.trackBarLineSpacing_Scroll);
            // 
            // buttonTranslationFont
            // 
            this.buttonTranslationFont.Location = new System.Drawing.Point(320, 45);
            this.buttonTranslationFont.Name = "buttonTranslationFont";
            this.buttonTranslationFont.Size = new System.Drawing.Size(124, 23);
            this.buttonTranslationFont.TabIndex = 45;
            this.buttonTranslationFont.Text = "Schrift wählen...";
            this.buttonTranslationFont.UseVisualStyleBackColor = true;
            this.buttonTranslationFont.Click += new System.EventHandler(this.buttonTranslationFont_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(23, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 52;
            this.label10.Text = "Zeilenabstand:";
            // 
            // buttonTranslationColor
            // 
            this.buttonTranslationColor.Location = new System.Drawing.Point(450, 45);
            this.buttonTranslationColor.Name = "buttonTranslationColor";
            this.buttonTranslationColor.Size = new System.Drawing.Size(119, 23);
            this.buttonTranslationColor.TabIndex = 46;
            this.buttonTranslationColor.Text = "Schriftfarbe...";
            this.buttonTranslationColor.UseVisualStyleBackColor = true;
            this.buttonTranslationColor.Click += new System.EventHandler(this.buttonTranslationColor_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(149, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "label9";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "label3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Übersetzungsschrift:";
            // 
            // checkBoxUseMasterFormat
            // 
            this.checkBoxUseMasterFormat.AutoSize = true;
            this.checkBoxUseMasterFormat.Location = new System.Drawing.Point(18, 19);
            this.checkBoxUseMasterFormat.Name = "checkBoxUseMasterFormat";
            this.checkBoxUseMasterFormat.Size = new System.Drawing.Size(172, 17);
            this.checkBoxUseMasterFormat.TabIndex = 55;
            this.checkBoxUseMasterFormat.Text = "Masterformatierung verwenden";
            this.checkBoxUseMasterFormat.UseVisualStyleBackColor = true;
            this.checkBoxUseMasterFormat.CheckedChanged += new System.EventHandler(this.checkBoxUseMasterFormat_CheckedChanged);
            // 
            // settingsWindow
            // 
            this.AcceptButton = this.exitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(626, 365);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.exitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "settingsWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.settingsWindow_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBoxUseMaster.ResumeLayout(false);
            this.groupBoxUseMaster.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLineSpacing)).EndInit();
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
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar trackBarProjectionPadding;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label labelProjectionPadding;
        private System.Windows.Forms.Label labelLineSpacing;
        private System.Windows.Forms.TrackBar trackBarLineSpacing;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
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
        private System.Windows.Forms.GroupBox groupBoxUseMaster;
    }
}