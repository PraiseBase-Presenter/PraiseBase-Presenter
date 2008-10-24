using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pbp.Properties;
using System.IO;

namespace Pbp.Forms
{
	public partial class ImageDialog : Form
	{
		Settings setting;
		public string imagePath  {get; private set;}

		public ImageDialog()
		{
			setting = new Settings();
			imagePath = string.Empty;
			InitializeComponent();

		}

		public ImageDialog(string defaultImagePath)
		{
			imagePath = defaultImagePath;
			setting = new Settings();
			InitializeComponent();
			Console.WriteLine("Given " + imagePath);
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (listViewImages.SelectedItems.Count > 0)
			{
				imagePath = (string)listViewImages.SelectedItems[0].Tag;
				DialogResult = DialogResult.OK;
			}
			else
			{
				MessageBox.Show("Kein Bild gewählt!", "Bildmanager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void ImageDialog_Load(object sender, EventArgs e)
		{
			imageTreeViewInit();
		}


		public void imageTreeViewInit()
		{
			string rootDir = setting.dataDirectory + Path.DirectorySeparatorChar + setting.imageDir;

			treeViewDirs.Nodes.Clear();
			TreeNode rootTreeNode = new TreeNode("Bilder");
			rootTreeNode.Tag = rootDir;
			treeViewDirs.Nodes.Add(rootTreeNode);
			PopulateTreeView(rootDir, treeViewDirs.Nodes[0]);
			treeViewDirs.Nodes[0].Expand();


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
						foreach (string directory in directoryArray)
						{
							string dName = Path.GetFileName(directory);
							if (dName.Substring(0, 1) != "[" && dName.Substring(0, 1) != ".")
							{
								TreeNode myNode = new TreeNode(dName);
								myNode.Tag = directory;
								parentNode.Nodes.Add(myNode);

								if (imagePath!= string.Empty && directory == Path.GetDirectoryName(imagePath))
								{
									treeViewDirs.SelectedNode = myNode;
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

			if (Directory.Exists((string)treeViewDirs.SelectedNode.Tag))
			{
				ImageList imList = new ImageList();
				imList.ImageSize = new Size(150, 112);
				imList.ColorDepth = ColorDepth.Depth32Bit;

				string[] songFilePaths = Directory.GetFiles((string)treeViewDirs.SelectedNode.Tag, "*.jpg", SearchOption.TopDirectoryOnly);
				int i = 0;
				foreach (string file in songFilePaths)
				{
					Application.DoEvents();
					ListViewItem lvi = new ListViewItem(Path.GetFileNameWithoutExtension(file));
					lvi.Tag = file;
					lvi.ImageIndex = i;
					listViewImages.Items.Add(lvi);
					imList.Images.Add(Image.FromFile(file));
					if (file == imagePath)
						listViewImages.Items[i].Selected = true;

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


	}
}
