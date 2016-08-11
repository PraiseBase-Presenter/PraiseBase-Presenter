using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.Util;
using System;
using System.Windows.Forms;

namespace PraiseBase.Presenter.Forms
{
    public partial class TextImportDialog : Form
    {
        public Song ImportedSong { get; private set; }

        private Settings _settings;

        public TextImportDialog(Settings settings)
        {
            _settings = settings;
            InitializeComponent();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            SongTextParser parser = new SongTextParser();
            foreach (string s in _settings.SongParts)
            {
                parser.PartNames.Add(s);
            }
            try
            {
                ImportedSong = parser.Parse(textBoxContent.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, StringResources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContent.Focus();
            }
        }

        private void TextImportDialog_Load(object sender, EventArgs e)
        {
            string clipBoard = Clipboard.GetText();
            if (!string.IsNullOrEmpty(clipBoard))
            {
                textBoxContent.Text = clipBoard;
            }
            textBoxContent.Focus();
        }
    }
}
