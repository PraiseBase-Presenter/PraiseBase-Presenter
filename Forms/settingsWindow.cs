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
    }
}
