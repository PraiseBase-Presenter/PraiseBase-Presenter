using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Forms;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.UI.Presenter
{
    public partial class SongBrowserDialog : Form
    {
        /// <summary>
        /// List of tags (categories)
        /// </summary>
        public StringCollection Tags { get; set; }

        /// <summary>
        /// List of songs to be opened in the editor
        /// </summary>
        public List<string> OpenInEditor { get; private set; }

        public SongBrowserDialog()
        {
            OpenInEditor = new List<string>();
            InitializeComponent();
        }

        private void SongDialog_Load(object sender, EventArgs e)
        {
            checkedListBoxTags.Items.Clear();
            foreach (String str in Tags)
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
                    string fn = SongManager.Instance.SongList[(Guid) (lvi.Tag)].Filename;
                    OpenInEditor.Add(fn);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(Properties.StringResources.NoSongsSelected, Properties.StringResources.SongBrowser);
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
            foreach (KeyValuePair<Guid, SongItem> kvp in SongManager.Instance.SongList)
            {
                Song sng = kvp.Value.Song;
                bool use = true;
                if (searchText != String.Empty && !kvp.Value.SearchText.Contains(searchText))
                    use = false;

                if (checkBoxHasImages.Checked && sng.GetNumberOfBackgroundImages() > 0)
                    use = false;

                if (checkBoxHasComments.Checked && sng.Comment == string.Empty)
                    use = false;

                if (checkBoxQAImages.Checked && !sng.HasQuailityIssue(SongQualityAssuranceIndicator.Images))
                    use = false;
                if (checkBoxQASegmentation.Checked && !sng.HasQuailityIssue(SongQualityAssuranceIndicator.Segmentation))
                    use = false;
                if (checkBoxQASpelling.Checked && !sng.HasQuailityIssue(SongQualityAssuranceIndicator.Spelling))
                    use = false;
                if (checkBoxQATranslation.Checked && !sng.HasQuailityIssue(SongQualityAssuranceIndicator.Translation))
                    use = false;

                foreach (int i in checkedListBoxTags.CheckedIndices)
                {
                    if (!sng.Themes.Contains(checkedListBoxTags.Items[i].ToString()))
                        use = false;
                }

                if (use)
                {
                    ListViewItem lvi = new ListViewItem(sng.Title);
                    lvi.Tag = sng.Guid;
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