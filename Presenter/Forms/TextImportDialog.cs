using System;
using System.Windows.Forms;

namespace PraiseBase.Presenter.Forms
{
    public partial class TextImportDialog : Form
    {
        public string ImportedText { get { return textBoxContent.Text.Trim(); } }

        public TextImportDialog()
        {
            InitializeComponent();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
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
