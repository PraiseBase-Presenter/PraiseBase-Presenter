using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Pbp.Properties;
using Pbp.Data.Song;

namespace Pbp.Forms
{
    public partial class SongBrowserDialog : Form
    {
        public bool OpenInEditor { get; private set; }

        public SongBrowserDialog()
        {
            OpenInEditor = false;
            InitializeComponent();
        }

        private void SongDialog_Load(object sender, EventArgs e)
        {
            checkedListBoxTags.Items.Clear();
            foreach (String str in Settings.Default.Tags)
            {
                checkedListBoxTags.Items.Add(str);
            }
            fillList();
            textBoxSearch.Focus();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonUseInEditor_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in listViewItems.SelectedItems)
                {
                    SongEditor.getInstance().openSong(SongManager.Instance.SongList[(Guid)(lvi.Tag)].Filename);
                }
                OpenInEditor = true;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(Resources.StringResources.NoSongsSelected, Resources.StringResources.SongBrowser);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            fillList();
        }

        private void fillList()
        {
            listViewItems.Items.Clear();
            string searchText = textBoxSearch.Text.Trim().ToLower();
            foreach (KeyValuePair<Guid, SongManager.SongItem> kvp in SongManager.Instance.SongList)
            {
                Song sng = (Song)kvp.Value.Song;
                bool use = true;
                if (searchText != String.Empty && !sng.SearchText.Contains(searchText))
                    use = false;

                if (checkBoxHasImages.Checked && sng.RelativeImagePaths.Count > 0)
                    use = false;

                if (checkBoxHasComments.Checked && sng.Comment == string.Empty)
                    use = false;

                if (checkBoxQAImages.Checked && !sng.GetQA(SongQualityAssuranceIndicator.Images))
                    use = false;
                if (checkBoxQASegmentation.Checked && !sng.GetQA(SongQualityAssuranceIndicator.Segmentation))
                    use = false;
                if (checkBoxQASpelling.Checked && !sng.GetQA(SongQualityAssuranceIndicator.Spelling))
                    use = false;
                if (checkBoxQATranslation.Checked && !sng.GetQA(SongQualityAssuranceIndicator.Translation))
                    use = false;

                foreach (int i in checkedListBoxTags.CheckedIndices)
                {
                    if (!sng.Themes.Contains(checkedListBoxTags.Items[i].ToString()))
                        use = false;
                }

                if (use)
                {
                    ListViewItem lvi = new ListViewItem(sng.Title);
                    lvi.Tag = sng.GUID;
                    listViewItems.Items.Add(lvi);
                }
            }
            labelResults.Text = listViewItems.Items.Count.ToString() + " Treffer";
            textBoxSearch.Focus();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = String.Empty;
            checkBoxHasImages.Checked = false;
            checkBoxHasNoTranslation.Checked = false;
            checkBoxHasComments.Checked = false;
            checkBoxQAImages.Checked = false;
            checkBoxQASegmentation.Checked = false;
            checkBoxQASpelling.Checked = false;
            checkBoxQATranslation.Checked = false;
            for (int i = 0; i < checkedListBoxTags.Items.Count; i++)
            {
                checkedListBoxTags.SetItemCheckState(i, CheckState.Unchecked);
            }
            fillList();
            textBoxSearch.Focus();
        }

        private void SongDialog_Shown(object sender, EventArgs e)
        {
            textBoxSearch.Focus();
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonSearch_Click(sender, e);
        }
    }
}