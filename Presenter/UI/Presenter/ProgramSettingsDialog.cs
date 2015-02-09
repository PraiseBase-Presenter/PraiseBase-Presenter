﻿/*
 *   PraiseBase Presenter
 *   The open source lyrics and image projection software for churches
 *
 *   http://praisebase.org
 *
 *   This program is free software; you can redistribute it and/or
 *   modify it under the terms of the GNU General Public License
 *   as published by the Free Software Foundation; either version 2
 *   of the License, or (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program; if not, write to the Free Software
 *   Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 *
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using PraiseBase.Presenter.Properties;
using System.Drawing;

namespace PraiseBase.Presenter.Forms
{
    public partial class ProgramSettingsDialog : Form
    {
        public ProgramSettingsDialog()
        {
            InitializeComponent();
        }

        public void updateLabels()
        {
            textBox1.Text = Settings.Default.DataDirectory;

            checkBoxUseMasterFormat.Checked = Settings.Default.ProjectionUseMaster;
            groupBoxFonts.Enabled = Settings.Default.ProjectionUseMaster;

            trackBarProjectionShadowSize.Value = Settings.Default.ProjectionShadowSize;
            trackBarProjectionOutlineSize.Value = Settings.Default.ProjectionOutlineSize;

            labelMainTextString.Text = getFontString(Settings.Default.ProjectionMasterFont);
            buttonChooseProjectionForeColor.BackColor = Settings.Default.ProjectionMasterFontColor;

            labelTranslationTextString.Text = getFontString(Settings.Default.ProjectionMasterFontTranslation);
            buttonTranslationColor.BackColor = Settings.Default.ProjectionMasterTranslationColor;

            labelCopyrightTextString.Text = getFontString(Settings.Default.ProjectionMasterCopyrightFont);
            buttonCopyrightColor.BackColor = Settings.Default.ProjectionMasterCopyrightColor;

            labelSourceTextString.Text = getFontString(Settings.Default.ProjectionMasterSourceFont);
            buttonSourceColor.BackColor = Settings.Default.ProjectionMasterSourceColor;

            pictureBoxProjectionBackColor.BackColor = Settings.Default.ProjectionBackColor;
            pictureBoxProjectionOutlineColor.BackColor = Settings.Default.ProjectionOutlineColor;
            pictureBoxProjectionShadowColor.BackColor = Settings.Default.ProjectionShadowColor;

            trackBarProjectionPadding.Value = Settings.Default.ProjectionPadding;

            numericUpDownLineSpacing.Value = Settings.Default.ProjectionMasterLineSpacing;
            numericUpDownTranslationLineSpacing.Value = Settings.Default.ProjectionMasterTranslationLineSpacing;
            
            labelProjectionPadding.Text = Settings.Default.ProjectionPadding.ToString();

            checkBoxShowLoadingScreen.Checked = Settings.Default.ShowLoadingScreen;

            checkBoxProjectionFontScaling.Checked = Settings.Default.ProjectionFontScaling;

            List<string> strList;

            listBoxTags.Items.Clear();
            strList = new List<string>();
            foreach (string str in Settings.Default.Tags)
            {
                strList.Add(str);
            }
            strList.Sort();
            foreach (string str in strList)
            {
                listBoxTags.Items.Add(str);
            }

            listBoxLanguages.Items.Clear();
            strList = new List<string>();
            foreach (string str in Settings.Default.Languages)
            {
                strList.Add(str);
            }
            strList.Sort();
            foreach (string str in strList)
            {
                listBoxLanguages.Items.Add(str);
            }

            listBoxSongParts.Items.Clear();
            strList = new List<string>();
            foreach (string str in Settings.Default.SongParts)
            {
                strList.Add(str);
            }
            strList.Sort();
            foreach (string str in strList)
            {
                listBoxSongParts.Items.Add(str);
            }
        }

        private String getFontString(Font font)
        {
            return font.FontFamily.Name + ", " + font.Size.ToString() + ", " + font.Style.ToString();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void settingsWindow_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = Settings.Default.SettingsLastTabIndex;
            updateLabels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowNewFolderButton = true;

            if (Directory.Exists(Settings.Default.DataDirectory))
                dlg.SelectedPath = Settings.Default.DataDirectory;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                textBox1.Text = Settings.Default.DataDirectory = dlg.SelectedPath;
            }
        }

        private void buttonChosseBackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog();
            colDlg.Color = Settings.Default.ProjectionBackColor;
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionBackColor = colDlg.Color;
                updateLabels();
            }
        }

        private void buttonFontSelector_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.Font = Settings.Default.ProjectionMasterFont;
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterFont = fontDlg.Font;
                updateLabels();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.StringResources.ReallyResetFactoryDefaults, Properties.StringResources.Reset, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Settings.Default.Reset();
                updateLabels();
            }
        }

        private void buttonChooseProjectionForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog();
            colDlg.Color = Settings.Default.ProjectionMasterFontColor;
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterFontColor = colDlg.Color;
                updateLabels();
            }
        }

        private void checkBoxFontScaling_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionFontScaling = checkBoxProjectionFontScaling.Checked;
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            string str = textBoxNewTag.Text.Trim();
            if (str != "")
            {
                if (!Settings.Default.Tags.Contains(str))
                {
                    Settings.Default.Tags.Add(str);
                    textBoxNewTag.Text = "";
                    updateLabels();
                }
                else
                {
                    MessageBox.Show(Properties.StringResources.TagExistsAlready, Properties.StringResources.Settings, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(Properties.StringResources.EmptyEntriesAreNotAllowed, Properties.StringResources.Settings, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            textBoxNewTag.Focus();
        }

        private void buttonDelTags_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxTags.Items.Count; i++)
            {
                if (listBoxTags.GetSelected(i))
                {
                    Settings.Default.Tags.Remove(listBoxTags.Items[i].ToString());
                }
            }
            updateLabels();
        }

        private void buttonAddLang_Click(object sender, EventArgs e)
        {
            string str = textBoxNewLang.Text.Trim();
            if (str != "")
            {
                if (!Settings.Default.Languages.Contains(str))
                {
                    Settings.Default.Languages.Add(str);
                    textBoxNewLang.Text = "";
                    updateLabels();
                }
                else
                {
                    MessageBox.Show(Properties.StringResources.LanguageExistsAlready, Properties.StringResources.Settings, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(Properties.StringResources.EmptyEntriesAreNotAllowed, Properties.StringResources.Settings, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            textBoxNewLang.Focus();
        }

        private void buttonDelLang_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxLanguages.Items.Count; i++)
            {
                if (listBoxLanguages.GetSelected(i))
                {
                    Settings.Default.Languages.Remove(listBoxLanguages.Items[i].ToString());
                }
            }
            updateLabels();
        }

        private void buttonAddSongPart_Click(object sender, EventArgs e)
        {
            string str = textBoxNewSongPart.Text.Trim();
            if (str != "")
            {
                if (!Settings.Default.SongParts.Contains(str))
                {
                    Settings.Default.SongParts.Add(str);
                    textBoxNewSongPart.Text = "";
                    updateLabels();
                }
                else
                {
                    MessageBox.Show(Properties.StringResources.NameExistsAlready, Properties.StringResources.Settings, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(Properties.StringResources.EmptyEntriesAreNotAllowed, Properties.StringResources.Settings, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            textBoxNewSongPart.Focus();
        }

        private void buttonDelSongParts_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxSongParts.Items.Count; i++)
            {
                if (listBoxSongParts.GetSelected(i))
                {
                    Settings.Default.SongParts.Remove(listBoxSongParts.Items[i].ToString());
                }
            }
            updateLabels();
        }

        private void buttonTranslationColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog();
            colDlg.Color = Settings.Default.ProjectionMasterTranslationColor;
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterTranslationColor = colDlg.Color;
                updateLabels();
            }
        }

        private void buttonTranslationFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.Font = Settings.Default.ProjectionMasterFontTranslation;
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterFontTranslation = fontDlg.Font;
                updateLabels();
            }
        }

        private void buttonCopyrightFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.Font = Settings.Default.ProjectionMasterCopyrightFont;
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterCopyrightFont = fontDlg.Font;
                updateLabels();
            }
        }

        private void buttonCopyrightColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog();
            colDlg.Color = Settings.Default.ProjectionMasterCopyrightColor;
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterCopyrightColor = colDlg.Color;
                updateLabels();
            }
        }
        
        private void buttonSourceFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.Font = Settings.Default.ProjectionMasterSourceFont;
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterSourceFont = fontDlg.Font;
                updateLabels();
            }
        }

        private void buttonSourceColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog();
            colDlg.Color = Settings.Default.ProjectionMasterSourceColor;
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterSourceColor = colDlg.Color;
                updateLabels();
            }
        }

        private void trackBarPadding_Scroll(object sender, EventArgs e)
        {
            Settings.Default.ProjectionPadding = trackBarProjectionPadding.Value;
            updateLabels();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.SettingsLastTabIndex = tabControl1.SelectedIndex;
        }

        private void buttonProjectionShadowColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog();
            colDlg.Color = Settings.Default.ProjectionShadowColor;
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionShadowColor = colDlg.Color;
                updateLabels();
            }
        }

        private void buttonProjectionOutlineColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog();
            colDlg.Color = Settings.Default.ProjectionOutlineColor;
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionOutlineColor = colDlg.Color;
                updateLabels();
            }
        }

        private void trackBarProjectionShadowSize_Scroll(object sender, EventArgs e)
        {
            Settings.Default.ProjectionShadowSize = trackBarProjectionShadowSize.Value;
        }

        private void trackBarProjectionOutlineSize_Scroll(object sender, EventArgs e)
        {
            Settings.Default.ProjectionOutlineSize = trackBarProjectionOutlineSize.Value;
        }

        private void checkBoxUseMasterFormat_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUseMasterFormat.Checked)
            {
                groupBoxFonts.Enabled = true;
                groupBoxLineSpacings.Enabled = true;
            }
            else
            {
                groupBoxFonts.Enabled = false;
                groupBoxLineSpacings.Enabled = false;
            }
            Settings.Default.ProjectionUseMaster = checkBoxUseMasterFormat.Checked;
        }

        private void checkBoxShowLoadingScreen_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.ShowLoadingScreen = checkBoxShowLoadingScreen.Checked;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterTranslationLineSpacing = (int)numericUpDownTranslationLineSpacing.Value;
        }

        private void numericUpDownLineSpacing_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterLineSpacing = (int)numericUpDownLineSpacing.Value;
        }
    }
}