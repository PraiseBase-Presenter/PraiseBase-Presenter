/*
 *   PraiseBase Presenter 
 *   The open source lyrics and image projection software for churches
 *   
 *   http://code.google.com/p/praisebasepresenter
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
 *   Author:
 *      Nicolas Perrenoud <nicu_at_lavine.ch>
 *   Co-authors:
 *      ...
 *
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Pbp.Properties;

namespace Pbp.Forms
{
    public partial class settingsWindow : Form
    {
        public settingsWindow()
        {
            InitializeComponent();
        }

        public void updateLabels()
        {
			textBox1.Text = Settings.Instance.DataDirectory;

			checkBoxUseMasterFormat.Checked = Settings.Instance.ProjectionUseMaster;
			groupBoxUseMaster.Enabled = Settings.Instance.ProjectionUseMaster;

			trackBarProjectionShadowSize.Value = Settings.Instance.ProjectionShadowSize;
			trackBarProjectionOutlineSize.Value = Settings.Instance.ProjectionOutlineSize;

			label3.Text = Settings.Instance.ProjectionMasterFont.FontFamily.Name + ", " + Settings.Instance.ProjectionMasterFont.Size.ToString() + ", " + Settings.Instance.ProjectionMasterFont.Style.ToString();
			label3.ForeColor = Settings.Instance.ProjectionMasterFontColor;

			label9.Text = Settings.Instance.ProjectionMasterFontTranslation.FontFamily.Name + ", " + Settings.Instance.ProjectionMasterFontTranslation.Size.ToString() + ", " + Settings.Instance.ProjectionMasterFontTranslation.Style.ToString();
			label9.ForeColor = Settings.Instance.ProjectionMasterTranslationColor;


			pictureBoxProjectionBackColor.BackColor = Settings.Instance.ProjectionBackColor;
			pictureBoxProjectionOutlineColor.BackColor = Settings.Instance.ProjectionOutlineColor;
			pictureBoxProjectionShadowColor.BackColor = Settings.Instance.ProjectionShadowColor;

			trackBarProjectionPadding.Value = Settings.Instance.ProjectionPadding;
			trackBarLineSpacing.Value = Settings.Instance.ProjectionMasterLineSpacing;
			labelLineSpacing.Text = Settings.Instance.ProjectionMasterLineSpacing.ToString();
            labelProjectionPadding.Text = Settings.Instance.ProjectionPadding.ToString();

			checkBoxShowLoadingScreen.Checked = Settings.Instance.ShowLoadingScreen;

			checkBoxProjectionFontScaling.Checked = Settings.Instance.ProjectionFontScaling;

            List<string> strList;
            
            listBoxTags.Items.Clear();
            strList = new List<string>();
			foreach (string str in Settings.Instance.Tags)
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
			foreach (string str in Settings.Instance.Languages)
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
			foreach (string str in Settings.Instance.SongParts)
            {
                strList.Add(str);
            }
            strList.Sort();
            foreach (string str in strList)
            {
                listBoxSongParts.Items.Add(str);
            }           

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
			Settings.Instance.Save();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void settingsWindow_Load(object sender, EventArgs e)
        {
			tabControl1.SelectedIndex = Settings.Instance.SettingsLastTabIndex;
            updateLabels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowNewFolderButton = true;

			if (Directory.Exists(Settings.Instance.DataDirectory))
				dlg.SelectedPath = Settings.Instance.DataDirectory;
            
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
				textBox1.Text = Settings.Instance.DataDirectory = dlg.SelectedPath;
            }
        }

        private void buttonChosseBackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog();
			colDlg.Color = Settings.Instance.ProjectionBackColor;
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
				Settings.Instance.ProjectionBackColor = colDlg.Color;
                updateLabels();
            }
        }

        private void buttonFontSelector_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
			fontDlg.Font = Settings.Instance.ProjectionMasterFont;
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
				Settings.Instance.ProjectionMasterFont = fontDlg.Font;
                updateLabels();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sollen die Standardwerte wirklich geladen werden?","Reset",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
				Settings.Instance.Reset();
                updateLabels();
            }
        }

        private void buttonChooseProjectionForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog();
			colDlg.Color = Settings.Instance.ProjectionMasterFontColor;
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
				Settings.Instance.ProjectionMasterFontColor = colDlg.Color;
                updateLabels();
            }
        }



        private void checkBoxFontScaling_CheckedChanged(object sender, EventArgs e)
        {
			Settings.Instance.ProjectionFontScaling = checkBoxProjectionFontScaling.Checked;
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            string str = textBoxNewTag.Text.Trim();
            if (str != "")
            {
				if (!Settings.Instance.Tags.Contains(str))
                {
					Settings.Instance.Tags.Add(str);
                    textBoxNewTag.Text = "";
                    updateLabels();
                }
                else
                {
                    MessageBox.Show("Tag bereits vorhanden!", "Einstellungen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Leere Einträge sind nicht erlaubt!", "Einstellungen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            textBoxNewTag.Focus();
        }

        private void buttonDelTags_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxTags.Items.Count; i++)
            {
                if (listBoxTags.GetSelected(i))
                {
					Settings.Instance.Tags.Remove(listBoxTags.Items[i].ToString());
                }
            }
            updateLabels();
        }

        private void buttonAddLang_Click(object sender, EventArgs e)
        {
            string str = textBoxNewLang.Text.Trim();
            if (str != "")
            {
				if (!Settings.Instance.Languages.Contains(str))
                {
					Settings.Instance.Languages.Add(str);
                    textBoxNewLang.Text = "";
                    updateLabels();
                }
                else
                {
                    MessageBox.Show("Sprache bereits vorhanden!", "Einstellungen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Leere Einträge sind nicht erlaubt!", "Einstellungen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            textBoxNewLang.Focus();
        }

        private void buttonDelLang_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxLanguages.Items.Count; i++)
            {
                if (listBoxLanguages.GetSelected(i))
                {
					Settings.Instance.Languages.Remove(listBoxLanguages.Items[i].ToString());
                }
            }
            updateLabels();
        }

        private void buttonAddSongPart_Click(object sender, EventArgs e)
        {
            string str = textBoxNewSongPart.Text.Trim();
            if (str != "")
            {
				if (!Settings.Instance.SongParts.Contains(str))
                {
					Settings.Instance.SongParts.Add(str);
                    textBoxNewSongPart.Text = "";
                    updateLabels();
                }
                else
                {
                    MessageBox.Show("Name bereits vorhanden!", "Einstellungen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Leere Einträge sind nicht erlaubt!", "Einstellungen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            textBoxNewSongPart.Focus();
            
        }

        private void buttonDelSongParts_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxSongParts.Items.Count; i++)
            {
                if (listBoxSongParts.GetSelected(i))
                {
					Settings.Instance.SongParts.Remove(listBoxSongParts.Items[i].ToString());
                }
            }
            updateLabels();
            
        }

        private void buttonTranslationColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog();
			colDlg.Color = Settings.Instance.ProjectionMasterTranslationColor;
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
				Settings.Instance.ProjectionMasterTranslationColor = colDlg.Color;
                updateLabels();
            }
        }

        private void buttonTranslationFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
			fontDlg.Font = Settings.Instance.ProjectionMasterFontTranslation;
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
				Settings.Instance.ProjectionMasterFontTranslation = fontDlg.Font;
                updateLabels();
            }
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void trackBarLineSpacing_Scroll(object sender, EventArgs e)
        {
			Settings.Instance.ProjectionMasterLineSpacing = trackBarLineSpacing.Value;
            updateLabels();
        }

        private void trackBarPadding_Scroll(object sender, EventArgs e)
        {
			Settings.Instance.ProjectionPadding = trackBarProjectionPadding.Value;
            updateLabels();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
			Settings.Instance.SettingsLastTabIndex = tabControl1.SelectedIndex;
        }

        private void buttonProjectionShadowColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog();
			colDlg.Color = Settings.Instance.ProjectionShadowColor;
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
				Settings.Instance.ProjectionShadowColor = colDlg.Color;
                updateLabels();
            }
        }

        private void buttonProjectionOutlineColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog();
			colDlg.Color = Settings.Instance.ProjectionOutlineColor;
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
				Settings.Instance.ProjectionOutlineColor = colDlg.Color;
                updateLabels();
            }
        }

        private void trackBarProjectionShadowSize_Scroll(object sender, EventArgs e)
        {
			Settings.Instance.ProjectionShadowSize = trackBarProjectionShadowSize.Value;
        }

        private void trackBarProjectionOutlineSize_Scroll(object sender, EventArgs e)
        {
			Settings.Instance.ProjectionOutlineSize = trackBarProjectionOutlineSize.Value;
        }

        private void checkBoxUseMasterFormat_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUseMasterFormat.Checked)
                groupBoxUseMaster.Enabled = true;
            else
                groupBoxUseMaster.Enabled = false;
			Settings.Instance.ProjectionUseMaster = checkBoxUseMasterFormat.Checked;
        }

		private void checkBoxShowLoadingScreen_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Instance.ShowLoadingScreen = checkBoxShowLoadingScreen.Checked;
		}


    }
}
