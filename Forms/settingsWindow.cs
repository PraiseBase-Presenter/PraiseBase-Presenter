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
        Settings stn;

        public settingsWindow()
        {
            stn = new Settings();
            InitializeComponent();
        }

        public void updateLabels()
        {
            textBox1.Text = stn.dataDirectory;
            label3.Text = stn.projectionFont.FontFamily.Name + ", " + stn.projectionFont.Size.ToString() + ", " + stn.projectionFont.Style.ToString();
            buttonChosseBackgroundColor.ForeColor = stn.projectionBackColor;
            buttonChooseProjectionForeColor.ForeColor = stn.projectionForeColor;
            buttonChooseProjectionBorderColor.ForeColor = stn.projectionFontBorderColor;
            checkBoxFontScaling.Checked = stn.projectionFontScaling;

            List<string> strList;
            
            listBoxTags.Items.Clear();
            strList = new List<string>();
            foreach (string str in stn.tags)
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
            foreach (string str in stn.languages)
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
            foreach (string str in stn.songParts)
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
            stn.Save();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void settingsWindow_Load(object sender, EventArgs e)
        {
            updateLabels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowNewFolderButton = true;

            if (Directory.Exists(stn.dataDirectory))
                dlg.SelectedPath = stn.dataDirectory;
            
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                 textBox1.Text = stn.dataDirectory = dlg.SelectedPath;
            }
        }

        private void buttonChosseBackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog();
            colDlg.Color = stn.projectionBackColor;
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                stn.projectionBackColor = colDlg.Color;
                updateLabels();
            }
        }

        private void buttonFontSelector_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.Font = stn.projectionFont;
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                stn.projectionFont = fontDlg.Font;
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
                stn.Reset();
                updateLabels();
            }
        }

        private void buttonChooseProjectionForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog();
            colDlg.Color = stn.projectionForeColor;
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                stn.projectionForeColor = colDlg.Color;
                updateLabels();
            }
        }

        private void buttonChooseProjectionBorderColor_Click(object sender, EventArgs e)
        {
            ColorDialog colDlg = new ColorDialog();
            colDlg.Color = stn.projectionFontBorderColor;
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                stn.projectionFontBorderColor = colDlg.Color;
                updateLabels();
            }
        }

        private void checkBoxFontScaling_CheckedChanged(object sender, EventArgs e)
        {
            stn.projectionFontScaling = checkBoxFontScaling.Checked;
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            string str = textBoxNewTag.Text.Trim();
            if (str != "")
            {
                if (!stn.tags.Contains(str))
                {
                    stn.tags.Add(str);
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
                    stn.tags.Remove(listBoxTags.Items[i].ToString());
                }
            }
            updateLabels();
        }

        private void buttonAddLang_Click(object sender, EventArgs e)
        {
            string str = textBoxNewLang.Text.Trim();
            if (str != "")
            {
                if (!stn.languages.Contains(str))
                {
                    stn.languages.Add(str);
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
                    stn.languages.Remove(listBoxLanguages.Items[i].ToString());
                }
            }
            updateLabels();
        }

        private void buttonAddSongPart_Click(object sender, EventArgs e)
        {
            string str = textBoxNewSongPart.Text.Trim();
            if (str != "")
            {
                if (!stn.songParts.Contains(str))
                {
                    stn.songParts.Add(str);
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
                    stn.songParts.Remove(listBoxSongParts.Items[i].ToString());
                }
            }
            updateLabels();
            
        }
    }
}
