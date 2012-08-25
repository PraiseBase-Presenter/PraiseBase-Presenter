using System;
using System.Windows.Forms;

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

            checkBoxQASpelling.Checked = SongManager.Instance.CurrentSong.Song.getQA(QualityAssuranceIndicators.Spelling);
            checkBoxQATranslation.Checked = SongManager.Instance.CurrentSong.Song.getQA(QualityAssuranceIndicators.Translation);
            checkBoxQAImages.Checked = SongManager.Instance.CurrentSong.Song.getQA(QualityAssuranceIndicators.Images);
            checkBoxQASegmentation.Checked = SongManager.Instance.CurrentSong.Song.getQA(QualityAssuranceIndicators.Segmentation);
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            SongManager.Instance.CurrentSong.Song.Comment = textBoxComment.Text;

            if (checkBoxQASpelling.Checked)
                SongManager.Instance.CurrentSong.Song.setQA(QualityAssuranceIndicators.Spelling);
            else
                SongManager.Instance.CurrentSong.Song.remQA(QualityAssuranceIndicators.Spelling);

            if (checkBoxQATranslation.Checked)
                SongManager.Instance.CurrentSong.Song.setQA(QualityAssuranceIndicators.Translation);
            else
                SongManager.Instance.CurrentSong.Song.remQA(QualityAssuranceIndicators.Translation);

            if (checkBoxQAImages.Checked)
                SongManager.Instance.CurrentSong.Song.setQA(QualityAssuranceIndicators.Images);
            else
                SongManager.Instance.CurrentSong.Song.remQA(QualityAssuranceIndicators.Images);

            if (checkBoxQASegmentation.Checked)
                SongManager.Instance.CurrentSong.Song.setQA(QualityAssuranceIndicators.Segmentation);
            else
                SongManager.Instance.CurrentSong.Song.remQA(QualityAssuranceIndicators.Segmentation);

            SongManager.Instance.saveCurrentSong();

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}