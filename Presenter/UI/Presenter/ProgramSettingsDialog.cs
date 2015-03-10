/*
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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Properties;

namespace PraiseBase.Presenter.UI.Presenter
{
    public partial class ProgramSettingsDialog : Form
    {
        public ProgramSettingsDialog()
        {
            InitializeComponent();
        }

        private void UpdateLabels()
        {
            textBox1.Text = Settings.Default.DataDirectory;

            checkBoxUseMasterFormat.Checked = Settings.Default.ProjectionUseMaster;
            EnableMasterFormattingGroupBoxes(Settings.Default.ProjectionUseMaster);

            labelMainTextString.Text = getFontString(Settings.Default.ProjectionMasterFont);
            buttonChooseProjectionForeColor.BackColor = Settings.Default.ProjectionMasterFontColor;

            labelTranslationTextString.Text = getFontString(Settings.Default.ProjectionMasterFontTranslation);
            buttonTranslationColor.BackColor = Settings.Default.ProjectionMasterTranslationColor;

            labelCopyrightTextString.Text = getFontString(Settings.Default.ProjectionMasterCopyrightFont);
            buttonCopyrightColor.BackColor = Settings.Default.ProjectionMasterCopyrightColor;

            labelSourceTextString.Text = getFontString(Settings.Default.ProjectionMasterSourceFont);
            buttonSourceColor.BackColor = Settings.Default.ProjectionMasterSourceColor;

            buttonProjectionBackgroundColor.BackColor = Settings.Default.ProjectionBackColor;

            // Outline
            UpdateOutlineLabels();

            // Shadow
            UpdateShadowLabels();

            // Padding / Borders
            UpdatePaddingBorders();

            // Line spacing
            UpdateLineSpacing();
            
            // Text orientation
            UpdateOrientation();

            // Additional information
            comboBoxSourcePosition.SelectedIndex = (int)Settings.Default.ProjectionMasterSourcePosition;
            comboBoxCopyrightPosition.SelectedIndex = (int)Settings.Default.ProjectionMasterCopyrightPosition;

            checkBoxShowLoadingScreen.Checked = Settings.Default.ShowLoadingScreen;

            checkBoxProjectionFontScaling.Checked = Settings.Default.ProjectionFontScaling;
            checkBoxSmoothShadow.Checked = Settings.Default.ProjectionSmoothShadow;

            listBoxTags.Items.Clear();
            var strList = Settings.Default.Tags.Cast<string>().ToList();
            strList.Sort();
            foreach (string str in strList)
            {
                listBoxTags.Items.Add(str);
            }

            listBoxLanguages.Items.Clear();
            strList = Settings.Default.Languages.Cast<string>().ToList();
            strList.Sort();
            foreach (string str in strList)
            {
                listBoxLanguages.Items.Add(str);
            }

            listBoxSongParts.Items.Clear();
            strList = Settings.Default.SongParts.Cast<string>().ToList();
            strList.Sort();
            foreach (string str in strList)
            {
                listBoxSongParts.Items.Add(str);
            }
        }

        private void UpdateOutlineLabels()
        {
            checkBoxOutlineEnabled.Checked = Settings.Default.ProjectionMasterOutlineEnabled;
            numericUpDownOutlineSize.Value = Settings.Default.ProjectionMasterOutlineSize;
            buttonOutlineColor.BackColor = Settings.Default.ProjectionMasterOutlineColor;
            EnableOutlineFormElements(Settings.Default.ProjectionMasterOutlineEnabled);
        }

        private void UpdateShadowLabels()
        {
            checkBoxShadowEnabled.Checked = Settings.Default.ProjectionMasterShadowEnabled;
            numericUpDownShadowDistance.Value = Settings.Default.ProjectionMasterShadowDistance;
            numericUpDownShadowSize.Value = Settings.Default.ProjectionMasterShadowSize;
            numericUpDownShadowDirection.Value = Settings.Default.ProjectionMasterShadowDirection;
            buttonShadowColor.BackColor = Settings.Default.ProjectionMasterShadowColor;
            EnableShadowFormElements(Settings.Default.ProjectionMasterShadowEnabled);
        }

        private void UpdatePaddingBorders()
        {
            numericUpDownHorizontalTextPadding.Value = Settings.Default.ProjectionMasterHorizontalTextPadding;
            numericUpDownVerticalTextPadding.Value = Settings.Default.ProjectionMasterVerticalTextPadding;
            numericUpDownHorizontalHeaderPadding.Value = Settings.Default.ProjectionMasterHorizontalHeaderPadding;
            numericUpDownVerticalHeaderPadding.Value = Settings.Default.ProjectionMasterVerticalHeaderPadding;
            numericUpDownHorizontalFooterPadding.Value = Settings.Default.ProjectionMasterHorizontalFooterPadding;
            numericUpDownVerticalFooterPadding.Value = Settings.Default.ProjectionMasterVerticalFooterPadding;
        }

        private void UpdateLineSpacing()
        {
            numericUpDownLineSpacing.Value = Settings.Default.ProjectionMasterLineSpacing;
            numericUpDownTranslationLineSpacing.Value = Settings.Default.ProjectionMasterTranslationLineSpacing;
            numericUpDownHorizontalTranslationTextOffset.Value = Settings.Default.ProjectionMasterHorizontalTranslationTextOffset;
        }

        private void UpdateOrientation()
        {
            comboBoxHorizontalTextOrientation.SelectedIndex = getIndexByHorizontalOrientation(Settings.Default.ProjectionMasterHorizontalTextOrientation);
            comboBoxVerticalTextOrientation.SelectedIndex = getIndexByVerticalOrientation(Settings.Default.ProjectionMasterVerticalTextOrientation);
            comboBoxHeaderOrientation.SelectedIndex = getIndexByHorizontalOrientation(Settings.Default.ProjectionMasterHorizontalHeaderOrientation);
            comboBoxFooterOrientation.SelectedIndex = getIndexByHorizontalOrientation(Settings.Default.ProjectionMasterHorizontalFooterOrientation);
            comboBoxTranslationPosition.SelectedIndex = Settings.Default.ProjectionMasteTranslationPosition == TranslationPosition.Block ? 1 : 0;
        }

        private String getFontString(Font font)
        {
            return font.FontFamily.Name + ", " + font.Size + ", " + font.Style;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Settings.Default.Reload();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void settingsWindow_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = Settings.Default.SettingsLastTabIndex;
            UpdateLabels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };

            if (Directory.Exists(Settings.Default.DataDirectory))
                dlg.SelectedPath = Settings.Default.DataDirectory;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                textBox1.Text = Settings.Default.DataDirectory = dlg.SelectedPath;
            }
        }

        private void buttonFontSelector_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog
            {
                Font = Settings.Default.ProjectionMasterFont
            };
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterFont = fontDlg.Font;
                UpdateLabels();
            }
        }

        private void buttonResetFactoryDefaults_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(StringResources.ReallyResetFactoryDefaults, StringResources.Reset, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Settings.Default.Reset();
                UpdateLabels();
            }
        }

        private void buttonChooseProjectionForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog
            {
                Color = Settings.Default.ProjectionMasterFontColor
            };
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterFontColor = colDlg.Color;
                UpdateLabels();
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
                    UpdateLabels();
                }
                else
                {
                    MessageBox.Show(StringResources.TagExistsAlready, StringResources.Settings, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(StringResources.EmptyEntriesAreNotAllowed, StringResources.Settings, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            UpdateLabels();
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
                    UpdateLabels();
                }
                else
                {
                    MessageBox.Show(StringResources.LanguageExistsAlready, StringResources.Settings, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(StringResources.EmptyEntriesAreNotAllowed, StringResources.Settings, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            UpdateLabels();
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
                    UpdateLabels();
                }
                else
                {
                    MessageBox.Show(StringResources.NameExistsAlready, StringResources.Settings, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(StringResources.EmptyEntriesAreNotAllowed, StringResources.Settings, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            UpdateLabels();
        }

        private void buttonTranslationColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog
            {
                Color = Settings.Default.ProjectionMasterTranslationColor
            };
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterTranslationColor = colDlg.Color;
                UpdateLabels();
            }
        }

        private void buttonTranslationFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog
            {
                Font = Settings.Default.ProjectionMasterFontTranslation
            };
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterFontTranslation = fontDlg.Font;
                UpdateLabels();
            }
        }

        private void buttonCopyrightFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog
            {
                Font = Settings.Default.ProjectionMasterCopyrightFont
            };
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterCopyrightFont = fontDlg.Font;
                UpdateLabels();
            }
        }

        private void buttonCopyrightColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog
            {
                Color = Settings.Default.ProjectionMasterCopyrightColor
            };
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterCopyrightColor = colDlg.Color;
                UpdateLabels();
            }
        }
        
        private void buttonSourceFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog
            {
                Font = Settings.Default.ProjectionMasterSourceFont
            };
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterSourceFont = fontDlg.Font;
                UpdateLabels();
            }
        }

        private void buttonSourceColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog
            {
                Color = Settings.Default.ProjectionMasterSourceColor
            };
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterSourceColor = colDlg.Color;
                UpdateLabels();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.SettingsLastTabIndex = tabControl1.SelectedIndex;
        }

        private void checkBoxUseMasterFormat_CheckedChanged(object sender, EventArgs e)
        {
            EnableMasterFormattingGroupBoxes(checkBoxUseMasterFormat.Checked);
            Settings.Default.ProjectionUseMaster = checkBoxUseMasterFormat.Checked;
        }

        private void EnableMasterFormattingGroupBoxes(bool enable)
        {
            groupBoxFonts.Enabled = enable;
            groupBoxLineSpacings.Enabled = enable;
            groupBoxBorders.Enabled = enable;
            groupBoxOutline.Enabled = enable;
            groupBoxShadow.Enabled = enable;
            groupBoxTextOrientation.Enabled = enable;
            groupBoxAdditionalInfo.Enabled = enable;
        }

        private void checkBoxShowLoadingScreen_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.ShowLoadingScreen = checkBoxShowLoadingScreen.Checked;
        }

        private void numericUpDownTranslationLineSpacing_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterTranslationLineSpacing = (int)numericUpDownTranslationLineSpacing.Value;
        }

        private void numericUpDownLineSpacing_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterLineSpacing = (int)numericUpDownLineSpacing.Value;
        }
        
        private void checkBoxOutlineEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterOutlineEnabled = ((CheckBox)sender).Checked;
            EnableOutlineFormElements(Settings.Default.ProjectionMasterOutlineEnabled);
        }

        private void EnableOutlineFormElements(bool enable)
        {
            labelOutlineSize.Enabled = enable;
            numericUpDownOutlineSize.Enabled = enable;
            label1OutlineColor.Enabled = enable;
            buttonOutlineColor.Enabled = enable;
        }

        private void buttonOutlineColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog
            {
                Color = Settings.Default.ProjectionMasterOutlineColor
            };
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterOutlineColor = colDlg.Color;
                UpdateLabels();
            }
        }

        private void numericUpDownOutlineSize_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterOutlineSize = (int)((NumericUpDown)sender).Value;
        }
        
        private void checkBoxShadowEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterShadowEnabled = ((CheckBox)sender).Checked;
            EnableShadowFormElements(Settings.Default.ProjectionMasterShadowEnabled);
        }

        private void EnableShadowFormElements(bool enable)
        {
            labelShadowDistance.Enabled = enable;
            numericUpDownShadowDistance.Enabled = enable;
            labelShadowColor.Enabled = enable;
            buttonShadowColor.Enabled = enable;
            labelShadowDirection.Enabled = enable;
            numericUpDownShadowDirection.Enabled = enable;
            labelShadowSize.Enabled = enable;
            numericUpDownShadowSize.Enabled = enable;
        }

        private void buttonShadowColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog
            {
                Color = Settings.Default.ProjectionMasterShadowColor
            };
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionMasterShadowColor = colDlg.Color;
                UpdateLabels();
            }
        }

        private void numericUpDownShadowDistance_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterShadowDistance = (int)((NumericUpDown)sender).Value;
        }

        private void numericUpDownShadowSize_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterShadowSize = (int)((NumericUpDown)sender).Value;
        }

        private void numericUpDownShadowDirection_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterShadowDirection = (int)((NumericUpDown)sender).Value;
        }

        private void buttonProjectionBackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog
            {
                Color = Settings.Default.ProjectionBackColor
            };
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ProjectionBackColor = colDlg.Color;
                UpdateLabels();
            }
        }

        private void numericUpDownHorizontalTextPadding_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterHorizontalTextPadding = (int)((NumericUpDown)sender).Value;
        }

        private void numericUpDownVerticalTextPadding_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterVerticalTextPadding = (int)((NumericUpDown)sender).Value;
        }

        private void numericUpDownHorizontalHeaderPadding_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterHorizontalHeaderPadding = (int)((NumericUpDown)sender).Value;
        }

        private void numericUpDownVerticalHeaderPadding_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterVerticalHeaderPadding = (int)((NumericUpDown)sender).Value;
        }

        private void numericUpDownHorizontalFooterPadding_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterHorizontalFooterPadding = (int)((NumericUpDown)sender).Value;
        }

        private void numericUpDownVerticalFooterPadding_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterVerticalFooterPadding = (int)((NumericUpDown)sender).Value;
        }

        private void comboBoxTextOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            Settings.Default.ProjectionMasterHorizontalTextOrientation = getHorizontalOrientationByIndex(index);
        }

        private void comboBoxVerticalTextOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            Settings.Default.ProjectionMasterVerticalTextOrientation = getVerticalTextOrientationByIndex(index);
        }
        
        private void comboBoxHeaderOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            Settings.Default.ProjectionMasterHorizontalHeaderOrientation = getHorizontalOrientationByIndex(index);
        }

        private void comboBoxFooterOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            Settings.Default.ProjectionMasterHorizontalFooterOrientation = getHorizontalOrientationByIndex(index);
        }

        private int getIndexByHorizontalOrientation(HorizontalOrientation horizontal)
        {
            switch (horizontal)
            {
                case HorizontalOrientation.Left:
                    return 0;
                case HorizontalOrientation.Center:
                    return 1;
                case HorizontalOrientation.Right:
                    return 2;
            }
            return 0;
        }

        private int getIndexByVerticalOrientation(VerticalOrientation vertical)
        {
            switch (vertical)
            {
                case VerticalOrientation.Top:
                    return 0;
                case VerticalOrientation.Middle:
                    return 1;
                case VerticalOrientation.Bottom:
                    return 2;
            }
            return 0;
        }

        private HorizontalOrientation getHorizontalOrientationByIndex(int index)
        {
            if (index == 0)
            {
                return HorizontalOrientation.Left;
            }
            if (index == 1)
            {
                return HorizontalOrientation.Center;
            }
            if (index == 2)
            {
                return HorizontalOrientation.Right;
            }
            return HorizontalOrientation.Left;
        }

        private VerticalOrientation getVerticalTextOrientationByIndex(int index)
        {
            if (index == 0)
            {
                return VerticalOrientation.Top;
            }
            if (index == 1)
            {
                return VerticalOrientation.Middle;
            }
            if (index == 2)
            {
                return VerticalOrientation.Bottom;
            }
            return VerticalOrientation.Top;
        }

        private void comboBoxSourcePosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterSourcePosition = (AdditionalInformationPosition)comboBoxSourcePosition.SelectedIndex;
        }

        private void comboBoxCopyrightPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterCopyrightPosition = (AdditionalInformationPosition)comboBoxCopyrightPosition.SelectedIndex;
        }

        private void comboBoxTranslationPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasteTranslationPosition = comboBoxTranslationPosition.SelectedIndex == 1 ? TranslationPosition.Block : TranslationPosition.Inline;
        }

        private void checkBoxSmoothShadow_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionSmoothShadow = checkBoxSmoothShadow.Checked;
        }

        private void numericUpDownHorizontalTranslationTextOffset_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.ProjectionMasterHorizontalTranslationTextOffset = (int)((NumericUpDown)sender).Value;
        }

    }
}