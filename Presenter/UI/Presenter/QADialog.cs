using System;
using System.Windows.Forms;
using Pbp.Data.Song;

namespace Pbp.Forms
{
    public partial class QADialog : Form
    {
        public QADialog()
        {
            InitializeComponent();
        }

        private void QADialog_Load(object sender, EventArgs e)
        {
            textBoxComment.Text = SongManager.Instance.CurrentSong.Song.Comment;

            checkBoxQASpelling.Checked = SongManager.Instance.CurrentSong.Song.GetQA(SongQualityAssuranceIndicator.Spelling);
            checkBoxQATranslation.Checked = SongManager.Instance.CurrentSong.Song.GetQA(SongQualityAssuranceIndicator.Translation);
            checkBoxQAImages.Checked = SongManager.Instance.CurrentSong.Song.GetQA(SongQualityAssuranceIndicator.Images);
            checkBoxQASegmentation.Checked = SongManager.Instance.CurrentSong.Song.GetQA(SongQualityAssuranceIndicator.Segmentation);
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            SongManager.Instance.CurrentSong.Song.Comment = textBoxComment.Text;

            if (checkBoxQASpelling.Checked)
                SongManager.Instance.CurrentSong.Song.SetQA(SongQualityAssuranceIndicator.Spelling);
            else
                SongManager.Instance.CurrentSong.Song.RemQA(SongQualityAssuranceIndicator.Spelling);

            if (checkBoxQATranslation.Checked)
                SongManager.Instance.CurrentSong.Song.SetQA(SongQualityAssuranceIndicator.Translation);
            else
                SongManager.Instance.CurrentSong.Song.RemQA(SongQualityAssuranceIndicator.Translation);

            if (checkBoxQAImages.Checked)
                SongManager.Instance.CurrentSong.Song.SetQA(SongQualityAssuranceIndicator.Images);
            else
                SongManager.Instance.CurrentSong.Song.RemQA(SongQualityAssuranceIndicator.Images);

            if (checkBoxQASegmentation.Checked)
                SongManager.Instance.CurrentSong.Song.SetQA(SongQualityAssuranceIndicator.Segmentation);
            else
                SongManager.Instance.CurrentSong.Song.RemQA(SongQualityAssuranceIndicator.Segmentation);

            SongManager.Instance.SaveCurrentSong();

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}