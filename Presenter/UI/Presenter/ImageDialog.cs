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
using System.IO;
using System.Windows.Forms;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Properties;

namespace PraiseBase.Presenter.Forms
{
    public partial class ImageDialog : Form
    {
        public IBackground Background { get; set; }

        public bool forAll
        {
            get
            {
                return checkBoxForAll.Checked;
            }
            set
            {
                checkBoxForAll.Checked = value;
            }
        }

        public ImageDialog()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (tabControlBackgroundType.SelectedIndex == 0)
            {
                if (listViewImages.SelectedItems.Count > 0)
                {
                    string image = (string)listViewImages.SelectedItems[0].Tag;
                    if (image != null && image != string.Empty)
                    {
                        Background = new ImageBackground(image);
                        DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("Kein Bild gewählt!", "Bildmanager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (tabControlBackgroundType.SelectedIndex == 1)
            {
                Background = new ColorBackground(pictureBoxColor.BackColor);
                DialogResult = DialogResult.OK;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ImageDialog_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
            imageTreeViewInit();

            if (Background != null && Background.GetType() == typeof(ImageBackground))
            {
                tabControlBackgroundType.SelectedIndex = 0;
            }
            else if (Background != null && Background.GetType() == typeof(ColorBackground))
            {
                pictureBoxColor.BackColor = ((ColorBackground)Background).Color;
                tabControlBackgroundType.SelectedIndex = 1;
            }
        }

        public void imageTreeViewInit()
        {
            string rootDir = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.ImageDir;

            Application.DoEvents();
            treeViewDirs.Nodes.Clear();
            TreeNode rootTreeNode = new TreeNode("Bilder");
            rootTreeNode.Tag = ".";
            treeViewDirs.Nodes.Add(rootTreeNode);
            PopulateTreeView(rootDir, treeViewDirs.Nodes[0]);
            if (treeViewDirs.SelectedNode == null)
            {
                treeViewDirs.SelectedNode = rootTreeNode;
            }
            treeViewDirs.Nodes[0].Expand();
            listViewImages.Focus();
        }

        public void PopulateTreeView(string directoryValue, TreeNode parentNode)
        {
            try
            {
                if (Directory.Exists(directoryValue))
                {
                    string[] directoryArray =
                    Directory.GetDirectories(directoryValue);

                    if (directoryArray.Length != 0)
                    {
                        int subLen = (Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.ImageDir + Path.DirectorySeparatorChar).Length;
                        foreach (string directory in directoryArray)
                        {
                            string dName = Path.GetFileName(directory);
                            if (dName.Substring(0, 1) != "[" && dName.Substring(0, 1) != ".")
                            {
                                TreeNode myNode = new TreeNode(dName);
                                myNode.Tag = directory.Substring(subLen);
                                parentNode.Nodes.Add(myNode);

                                if (Background != null && Background.GetType() == typeof(ImageBackground))
                                {
                                    String imagePath = ((ImageBackground)Background).ImagePath;
                                    if (imagePath != string.Empty && directory.Substring(subLen) == Path.GetDirectoryName(imagePath))
                                    {
                                        treeViewDirs.SelectedNode = myNode;
                                    }
                                }

                                PopulateTreeView(directory, myNode);
                            }
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
            } // end catch
        }

        private void treeViewDirs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listViewImages.Items.Clear();
            buttonOK.Enabled = false;
            if (listViewImages.LargeImageList != null)
            {
                listViewImages.LargeImageList.Dispose();
            }

            string relativeDir = (string)treeViewDirs.SelectedNode.Tag;
            string absoluteDir = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.ImageDir + Path.DirectorySeparatorChar + relativeDir;

            if (Directory.Exists(absoluteDir))
            {
                ImageList imList = new ImageList();
                imList.ImageSize = Settings.Default.ThumbSize;
                imList.ColorDepth = ColorDepth.Depth32Bit;

                string[] songFilePaths = Directory.GetFiles(absoluteDir, "*.jpg", SearchOption.TopDirectoryOnly);
                int i = 0;
                foreach (string file in songFilePaths)
                {
                    string relativePath = relativeDir + Path.DirectorySeparatorChar + Path.GetFileName(file);
                    Application.DoEvents();
                    ListViewItem lvi = new ListViewItem(Path.GetFileNameWithoutExtension(file));
                    lvi.Tag = relativePath;
                    lvi.ImageIndex = i;
                    listViewImages.Items.Add(lvi);
                    imList.Images.Add(ImageManager.Instance.GetThumbFromRelPath(relativePath));
                    if (Background != null && Background.GetType() == typeof (ImageBackground) && relativePath == ((ImageBackground)Background).ImagePath)
                    {
                        listViewImages.Items[i].Selected = true;
                    }
                    i++;
                }
                listViewImages.LargeImageList = imList;
            }
        }

        private void listViewImages_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewImages.SelectedItems.Count > 0)
                buttonOK.Enabled = true;
            else
                buttonOK.Enabled = false;
        }

        private void listViewImages_DoubleClick(object sender, EventArgs e)
        {
            if (listViewImages.SelectedItems.Count > 0)
                buttonOK_Click(sender, e);
        }

        private void buttonSelectColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = pictureBoxColor.BackColor;
            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                pictureBoxColor.BackColor = dlg.Color;
            }
        }

        private void pictureBoxColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = pictureBoxColor.BackColor;
            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                pictureBoxColor.BackColor = dlg.Color;
            }
        }

        private void tabControlBackgroundType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlBackgroundType.SelectedIndex == 1)
            {
                buttonOK.Enabled = true;
            }
        }
    }
}