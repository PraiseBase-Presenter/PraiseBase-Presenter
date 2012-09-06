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

            checkBoxQASpelling.Checked = SongManager.Instance.CurrentSong.Song.GetQA(QualityAssuranceIndicators.Spelling);
            checkBoxQATranslation.Checked = SongManager.Instance.CurrentSong.Song.GetQA(QualityAssuranceIndicators.Translation);
            checkBoxQAImages.Checked = SongManager.Instance.CurrentSong.Song.GetQA(QualityAssuranceIndicators.Images);
            checkBoxQASegmentation.Checked = SongManager.Instance.CurrentSong.Song.GetQA(QualityAssuranceIndicators.Segmentation);
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            SongManager.Instance.CurrentSong.Song.Comment = textBoxComment.Text;

            if (checkBoxQASpelling.Checked)
                SongManager.Instance.CurrentSong.Song.SetQA(QualityAssuranceIndicators.Spelling);
            else
                SongManager.Instance.CurrentSong.Song.RemQA(QualityAssuranceIndicators.Spelling);

            if (checkBoxQATranslation.Checked)
                SongManager.Instance.CurrentSong.Song.SetQA(QualityAssuranceIndicators.Translation);
            else
                SongManager.Instance.CurrentSong.Song.RemQA(QualityAssuranceIndicators.Translation);

            if (checkBoxQAImages.Checked)
                SongManager.Instance.CurrentSong.Song.SetQA(QualityAssuranceIndicators.Images);
            else
                SongManager.Instance.CurrentSong.Song.RemQA(QualityAssuranceIndicators.Images);

            if (checkBoxQASegmentation.Checked)
                SongManager.Instance.CurrentSong.Song.SetQA(QualityAssuranceIndicators.Segmentation);
            else
                SongManager.Instance.CurrentSong.Song.RemQA(QualityAssuranceIndicators.Segmentation);

            SongManager.Instance.saveCurrentSong();

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}