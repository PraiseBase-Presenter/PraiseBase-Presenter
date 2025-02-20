using System;
using System.Windows.Forms;

namespace PraiseBase.Presenter.Forms
{
    public partial class CommentDialog : UI.FormBase
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

        public CommentDialog() : base()
        {
            InitializeComponent();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CommentDialog_Load(object sender, EventArgs e)
        {

        }
    }
}