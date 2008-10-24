using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Pbp.Properties;

namespace Pbp.Forms
{
    public partial class EditorWindow : Form
    {
        Settings setting;
        static private EditorWindow _instance;
		
		public string fileBoxInitialDir;
		public int fileBoxFilterIndex;

        private int childFormNumber = 0;

        private EditorWindow()
        {
            setting = new Settings();
            InitializeComponent();
			fileBoxInitialDir = setting.dataDirectory + Path.DirectorySeparatorChar + setting.songDir;
			fileBoxFilterIndex = 0;
			this.WindowState = setting.editorWindowState;
			this.Text += " " + setting.version;

        }

        static public EditorWindow getInstance()
        {
            if (_instance==null)
                _instance = new EditorWindow();
            return _instance;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            EditorChild childForm = new EditorChild(null);
            childForm.MdiParent = this;
            
            
            childForm.Text = "Neues Lied " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = fileBoxInitialDir;
			openFileDialog.CheckFileExists = true;
			openFileDialog.CheckPathExists = true;
			openFileDialog.Multiselect = false;
			openFileDialog.Title = "Lied öffnen";

			openFileDialog.Filter = Song.fileType.getFilter();
			openFileDialog.FilterIndex = fileBoxFilterIndex;
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
				fileBoxInitialDir = Path.GetDirectoryName(FileName);
				fileBoxFilterIndex = openFileDialog.FilterIndex;
                EditorChild childForm = new EditorChild(FileName);
                childForm.MdiParent = this;
				if (childForm.valid)
					childForm.Show();
            }
        }



        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ActiveMdiChild != null)
			{
				if (((EditorChild)ActiveMdiChild).ActiveControl.GetType() == typeof(TextBox))
				{
					((TextBox)((EditorChild)ActiveMdiChild).ActiveControl).Cut();
				}
			}
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ActiveMdiChild != null)
			{
				if (((EditorChild)ActiveMdiChild).ActiveControl.GetType() == typeof(TextBox))
				{
					((TextBox)((EditorChild)ActiveMdiChild).ActiveControl).Copy();
				}
			}
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ActiveMdiChild != null)
			{
				if (((EditorChild)ActiveMdiChild).ActiveControl.GetType() == typeof(TextBox))
				{
					((TextBox)((EditorChild)ActiveMdiChild).ActiveControl).Paste();
				}
			}
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow ab = new AboutWindow();
            ab.ShowDialog(this);
        }

        private void webToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.nicu.ch/pbp");
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsWindow stWnd = new settingsWindow();
            if (stWnd.ShowDialog(this) == DialogResult.OK)
            {
                setting.Reload();
            }
        }


        private void EditorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
			setting.editorWindowState = this.WindowState;
			setting.Save();
            this.Hide();
            e.Cancel = true;
        }

        private void saveChild(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ((EditorChild)ActiveMdiChild).save();
            }
        }

		private void saveChildAs(object sender, EventArgs e)
		{
			if (ActiveMdiChild != null)
			{
				((EditorChild)ActiveMdiChild).saveAs();
			}
		}

        public void setStatus(string text)
        {
            toolStripStatusLabel1.Text = text;
			Timer statusTimer = new Timer();
			statusTimer.Interval = 2000;
			statusTimer.Tick += new EventHandler(statusTimer_Tick);
			statusTimer.Start();
		}
		
		void statusTimer_Tick(object sender, EventArgs e)
		{
			toolStripStatusLabel1.Text = string.Empty;
			((Timer)sender).Stop();
			((Timer)sender).Dispose();
		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ActiveMdiChild != null)
			{
				if (((EditorChild)ActiveMdiChild).ActiveControl.GetType() == typeof(TextBox))
				{
					((TextBox)((EditorChild)ActiveMdiChild).ActiveControl).SelectAll();
				}
			}
		}

		private void undoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ActiveMdiChild != null)
			{
				if (((EditorChild)ActiveMdiChild).ActiveControl.GetType() == typeof(TextBox))
				{
					((TextBox)((EditorChild)ActiveMdiChild).ActiveControl).Undo();
				}
			}
		}

		private void redoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ActiveMdiChild != null)
			{
				if (((EditorChild)ActiveMdiChild).ActiveControl.GetType() == typeof(TextBox))
				{
					((TextBox)((EditorChild)ActiveMdiChild).ActiveControl).ClearUndo();
				}
			}
		}

		private void liedSchliessenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ActiveMdiChild != null)
			{
				((EditorChild)ActiveMdiChild).Close();
			}
		}

		private void allesSchliessenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MdiChildren.Count() > 0)
			{
				foreach (EditorChild c in MdiChildren)
				{
					((EditorChild)c).Close();
				}
			}
		}

		private void EditorWindow_Load(object sender, EventArgs e)
		{

		}


    }
}
