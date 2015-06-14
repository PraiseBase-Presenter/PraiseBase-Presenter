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

namespace PraiseBase.Presenter.Forms
{
    public partial class ProgramSettingsDialog : Form
    {
        private readonly Settings _settings;

        public ProgramSettingsDialog(Settings settings)
        {
            _settings = settings;

            InitializeComponent();
        }

        private void UpdateLabels()
        {
            textBox1.Text = _settings.DataDirectory;

            checkBoxUseMasterFormat.Checked = _settings.ProjectionUseMaster;
            EnableMasterFormattingGroupBoxes(_settings.ProjectionUseMaster);

            labelMainTextString.Text = getFontString(_settings.ProjectionMasterFont);
            buttonChooseProjectionForeColor.BackColor = _settings.ProjectionMasterFontColor;

            labelTranslationTextString.Text = getFontString(_settings.ProjectionMasterFontTranslation);
            buttonTranslationColor.BackColor = _settings.ProjectionMasterTranslationColor;

            labelCopyrightTextString.Text = getFontString(_settings.ProjectionMasterCopyrightFont);
            buttonCopyrightColor.BackColor = _settings.ProjectionMasterCopyrightColor;

            labelSourceTextString.Text = getFontString(_settings.ProjectionMasterSourceFont);
            buttonSourceColor.BackColor = _settings.ProjectionMasterSourceColor;

            buttonProjectionBackgroundColor.BackColor = _settings.ProjectionBackColor;

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
            comboBoxSourcePosition.SelectedIndex = (int)_settings.ProjectionMasterSourcePosition;
            comboBoxCopyrightPosition.SelectedIndex = (int)_settings.ProjectionMasterCopyrightPosition;

            checkBoxShowLoadingScreen.Checked = _settings.ShowLoadingScreen;

            checkBoxProjectionFontScaling.Checked = _settings.ProjectionFontScaling;
            checkBoxSmoothShadow.Checked = _settings.ProjectionSmoothShadow;

            listBoxTags.Items.Clear();
            var strList = _settings.Tags.Cast<string>().ToList();
            strList.Sort();
            foreach (string str in strList)
            {
                listBoxTags.Items.Add(str);
            }

            listBoxLanguages.Items.Clear();
            strList = _settings.Languages.Cast<string>().ToList();
            strList.Sort();
            foreach (string str in strList)
            {
                listBoxLanguages.Items.Add(str);
            }

            listBoxSongParts.Items.Clear();
            strList = _settings.SongParts.Cast<string>().ToList();
            strList.Sort();
            foreach (string str in strList)
            {
                listBoxSongParts.Items.Add(str);
            }
        }

        private void UpdateOutlineLabels()
        {
            checkBoxOutlineEnabled.Checked = _settings.ProjectionMasterOutlineEnabled;
            numericUpDownOutlineSize.Value = _settings.ProjectionMasterOutlineSize;
            buttonOutlineColor.BackColor = _settings.ProjectionMasterOutlineColor;
            EnableOutlineFormElements(_settings.ProjectionMasterOutlineEnabled);
        }

        private void UpdateShadowLabels()
        {
            checkBoxShadowEnabled.Checked = _settings.ProjectionMasterShadowEnabled;
            numericUpDownShadowDistance.Value = _settings.ProjectionMasterShadowDistance;
            numericUpDownShadowSize.Value = _settings.ProjectionMasterShadowSize;
            numericUpDownShadowDirection.Value = _settings.ProjectionMasterShadowDirection;
            buttonShadowColor.BackColor = _settings.ProjectionMasterShadowColor;
            EnableShadowFormElements(_settings.ProjectionMasterShadowEnabled);
        }

        private void UpdatePaddingBorders()
        {
            numericUpDownHorizontalTextPadding.Value = _settings.ProjectionMasterHorizontalTextPadding;
            numericUpDownVerticalTextPadding.Value = _settings.ProjectionMasterVerticalTextPadding;
            numericUpDownHorizontalHeaderPadding.Value = _settings.ProjectionMasterHorizontalHeaderPadding;
            numericUpDownVerticalHeaderPadding.Value = _settings.ProjectionMasterVerticalHeaderPadding;
            numericUpDownHorizontalFooterPadding.Value = _settings.ProjectionMasterHorizontalFooterPadding;
            numericUpDownVerticalFooterPadding.Value = _settings.ProjectionMasterVerticalFooterPadding;
        }

        private void UpdateLineSpacing()
        {
            numericUpDownLineSpacing.Value = _settings.ProjectionMasterLineSpacing;
            numericUpDownTranslationLineSpacing.Value = _settings.ProjectionMasterTranslationLineSpacing;
            numericUpDownHorizontalTranslationTextOffset.Value = _settings.ProjectionMasterHorizontalTranslationTextOffset;
        }

        private void UpdateOrientation()
        {
            comboBoxHorizontalTextOrientation.SelectedIndex = getIndexByHorizontalOrientation(_settings.ProjectionMasterHorizontalTextOrientation);
            comboBoxVerticalTextOrientation.SelectedIndex = getIndexByVerticalOrientation(_settings.ProjectionMasterVerticalTextOrientation);
            comboBoxHeaderOrientation.SelectedIndex = getIndexByHorizontalOrientation(_settings.ProjectionMasterHorizontalHeaderOrientation);
            comboBoxFooterOrientation.SelectedIndex = getIndexByHorizontalOrientation(_settings.ProjectionMasterHorizontalFooterOrientation);
            comboBoxTranslationPosition.SelectedIndex = _settings.ProjectionMasteTranslationPosition == TranslationPosition.Block ? 1 : 0;
        }

        private String getFontString(Font font)
        {
            return font.FontFamily.Name + ", " + font.Size + ", " + font.Style;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _settings.Reload();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            _settings.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void settingsWindow_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = _settings.SettingsLastTabIndex;
            UpdateLabels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };

            if (Directory.Exists(_settings.DataDirectory))
                dlg.SelectedPath = _settings.DataDirectory;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                textBox1.Text = _settings.DataDirectory = dlg.SelectedPath;
            }
        }

        private void buttonFontSelector_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog
            {
                Font = _settings.ProjectionMasterFont
            };
            try
            {
                if (fontDlg.ShowDialog() == DialogResult.OK)
                {
                    _settings.ProjectionMasterFont = fontDlg.Font;
                    UpdateLabels();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, StringResources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonResetFactoryDefaults_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(StringResources.ReallyResetFactoryDefaults, StringResources.Reset, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _settings.Reset();
                SettingsUtil.SetDefaultDataDirIfEmpty(_settings);
                UpdateLabels();
            }
        }

        private void buttonChooseProjectionForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog
            {
                Color = _settings.ProjectionMasterFontColor
            };
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                _settings.ProjectionMasterFontColor = colDlg.Color;
                UpdateLabels();
            }
        }

        private void checkBoxFontScaling_CheckedChanged(object sender, EventArgs e)
        {
            _settings.ProjectionFontScaling = checkBoxProjectionFontScaling.Checked;
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            string str = textBoxNewTag.Text.Trim();
            if (str != "")
            {
                if (!_settings.Tags.Contains(str))
                {
                    _settings.Tags.Add(str);
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
                    _settings.Tags.Remove(listBoxTags.Items[i].ToString());
                }
            }
            UpdateLabels();
        }

        private void buttonAddLang_Click(object sender, EventArgs e)
        {
            string str = textBoxNewLang.Text.Trim();
            if (str != "")
            {
                if (!_settings.Languages.Contains(str))
                {
                    _settings.Languages.Add(str);
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
                    _settings.Languages.Remove(listBoxLanguages.Items[i].ToString());
                }
            }
            UpdateLabels();
        }

        private void buttonAddSongPart_Click(object sender, EventArgs e)
        {
            string str = textBoxNewSongPart.Text.Trim();
            if (str != "")
            {
                if (!_settings.SongParts.Contains(str))
                {
                    _settings.SongParts.Add(str);
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
                    _settings.SongParts.Remove(listBoxSongParts.Items[i].ToString());
                }
            }
            UpdateLabels();
        }

        private void buttonTranslationColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog
            {
                Color = _settings.ProjectionMasterTranslationColor
            };
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                _settings.ProjectionMasterTranslationColor = colDlg.Color;
                UpdateLabels();
            }
        }

        private void buttonTranslationFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog
            {
                Font = _settings.ProjectionMasterFontTranslation
            };
            try
            {
                if (fontDlg.ShowDialog() == DialogResult.OK)
                {
                    _settings.ProjectionMasterFontTranslation = fontDlg.Font;
                    UpdateLabels();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, StringResources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCopyrightFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog
            {
                Font = _settings.ProjectionMasterCopyrightFont
            };
            try
            {
                if (fontDlg.ShowDialog() == DialogResult.OK)
                {
                    _settings.ProjectionMasterCopyrightFont = fontDlg.Font;
                    UpdateLabels();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, StringResources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCopyrightColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog
            {
                Color = _settings.ProjectionMasterCopyrightColor
            };
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                _settings.ProjectionMasterCopyrightColor = colDlg.Color;
                UpdateLabels();
            }
        }
        
        private void buttonSourceFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog
            {
                Font = _settings.ProjectionMasterSourceFont
            };
            try
            {
                if (fontDlg.ShowDialog() == DialogResult.OK)
                {
                    _settings.ProjectionMasterSourceFont = fontDlg.Font;
                    UpdateLabels();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, StringResources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSourceColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog
            {
                Color = _settings.ProjectionMasterSourceColor
            };
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                _settings.ProjectionMasterSourceColor = colDlg.Color;
                UpdateLabels();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _settings.SettingsLastTabIndex = tabControl1.SelectedIndex;
        }

        private void checkBoxUseMasterFormat_CheckedChanged(object sender, EventArgs e)
        {
            EnableMasterFormattingGroupBoxes(checkBoxUseMasterFormat.Checked);
            _settings.ProjectionUseMaster = checkBoxUseMasterFormat.Checked;
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
            _settings.ShowLoadingScreen = checkBoxShowLoadingScreen.Checked;
        }

        private void numericUpDownTranslationLineSpacing_ValueChanged(object sender, EventArgs e)
        {
            _settings.ProjectionMasterTranslationLineSpacing = (int)numericUpDownTranslationLineSpacing.Value;
        }

        private void numericUpDownLineSpacing_ValueChanged(object sender, EventArgs e)
        {
            _settings.ProjectionMasterLineSpacing = (int)numericUpDownLineSpacing.Value;
        }
        
        private void checkBoxOutlineEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _settings.ProjectionMasterOutlineEnabled = ((CheckBox)sender).Checked;
            EnableOutlineFormElements(_settings.ProjectionMasterOutlineEnabled);
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
                Color = _settings.ProjectionMasterOutlineColor
            };
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                _settings.ProjectionMasterOutlineColor = colDlg.Color;
                UpdateLabels();
            }
        }

        private void numericUpDownOutlineSize_ValueChanged(object sender, EventArgs e)
        {
            _settings.ProjectionMasterOutlineSize = (int)((NumericUpDown)sender).Value;
        }
        
        private void checkBoxShadowEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _settings.ProjectionMasterShadowEnabled = ((CheckBox)sender).Checked;
            EnableShadowFormElements(_settings.ProjectionMasterShadowEnabled);
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
                Color = _settings.ProjectionMasterShadowColor
            };
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                _settings.ProjectionMasterShadowColor = colDlg.Color;
                UpdateLabels();
            }
        }

        private void numericUpDownShadowDistance_ValueChanged(object sender, EventArgs e)
        {
            _settings.ProjectionMasterShadowDistance = (int)((NumericUpDown)sender).Value;
        }

        private void numericUpDownShadowSize_ValueChanged(object sender, EventArgs e)
        {
            _settings.ProjectionMasterShadowSize = (int)((NumericUpDown)sender).Value;
        }

        private void numericUpDownShadowDirection_ValueChanged(object sender, EventArgs e)
        {
            _settings.ProjectionMasterShadowDirection = (int)((NumericUpDown)sender).Value;
        }

        private void buttonProjectionBackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog
            {
                Color = _settings.ProjectionBackColor
            };
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                _settings.ProjectionBackColor = colDlg.Color;
                UpdateLabels();
            }
        }

        private void numericUpDownHorizontalTextPadding_ValueChanged(object sender, EventArgs e)
        {
            _settings.ProjectionMasterHorizontalTextPadding = (int)((NumericUpDown)sender).Value;
        }

        private void numericUpDownVerticalTextPadding_ValueChanged(object sender, EventArgs e)
        {
            _settings.ProjectionMasterVerticalTextPadding = (int)((NumericUpDown)sender).Value;
        }

        private void numericUpDownHorizontalHeaderPadding_ValueChanged(object sender, EventArgs e)
        {
            _settings.ProjectionMasterHorizontalHeaderPadding = (int)((NumericUpDown)sender).Value;
        }

        private void numericUpDownVerticalHeaderPadding_ValueChanged(object sender, EventArgs e)
        {
            _settings.ProjectionMasterVerticalHeaderPadding = (int)((NumericUpDown)sender).Value;
        }

        private void numericUpDownHorizontalFooterPadding_ValueChanged(object sender, EventArgs e)
        {
            _settings.ProjectionMasterHorizontalFooterPadding = (int)((NumericUpDown)sender).Value;
        }

        private void numericUpDownVerticalFooterPadding_ValueChanged(object sender, EventArgs e)
        {
            _settings.ProjectionMasterVerticalFooterPadding = (int)((NumericUpDown)sender).Value;
        }

        private void comboBoxTextOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            _settings.ProjectionMasterHorizontalTextOrientation = getHorizontalOrientationByIndex(index);
        }

        private void comboBoxVerticalTextOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            _settings.ProjectionMasterVerticalTextOrientation = getVerticalTextOrientationByIndex(index);
        }
        
        private void comboBoxHeaderOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            _settings.ProjectionMasterHorizontalHeaderOrientation = getHorizontalOrientationByIndex(index);
        }

        private void comboBoxFooterOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            _settings.ProjectionMasterHorizontalFooterOrientation = getHorizontalOrientationByIndex(index);
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
            _settings.ProjectionMasterSourcePosition = (AdditionalInformationPosition)comboBoxSourcePosition.SelectedIndex;
        }

        private void comboBoxCopyrightPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            _settings.ProjectionMasterCopyrightPosition = (AdditionalInformationPosition)comboBoxCopyrightPosition.SelectedIndex;
        }

        private void comboBoxTranslationPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            _settings.ProjectionMasteTranslationPosition = comboBoxTranslationPosition.SelectedIndex == 1 ? TranslationPosition.Block : TranslationPosition.Inline;
        }

        private void checkBoxSmoothShadow_CheckedChanged(object sender, EventArgs e)
        {
            _settings.ProjectionSmoothShadow = checkBoxSmoothShadow.Checked;
        }

        private void numericUpDownHorizontalTranslationTextOffset_ValueChanged(object sender, EventArgs e)
        {
            _settings.ProjectionMasterHorizontalTranslationTextOffset = (int)((NumericUpDown)sender).Value;
        }

    }
}