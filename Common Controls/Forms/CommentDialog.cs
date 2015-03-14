using System;
using System.Windows.Forms;

namespace PraiseBase.Presenter.Forms
{
    public partial class CommentDialog : Form
    {
        public string Comment
        {
            get
            {
                return textBoxComment.Text;
            }
            set
            {
                textBoxComment.Text = value;
            }
        }

        public CommentDialog()
        {
            InitializeComponent();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}