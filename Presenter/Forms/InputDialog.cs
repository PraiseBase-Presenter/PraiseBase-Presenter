using System;
using System.Windows.Forms;

namespace PraiseBase.Presenter.Forms
{
    public partial class InputDialog : Form
    {
        public String InputValue
        {
            get { return textBoxResponseValue.Text; }
            set { textBoxResponseValue.Text = value; }
        }

        public InputDialog(string title, string text)
        {
            InitializeComponent();

            Text = title;
            labelText.Text = text;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {
            textBoxResponseValue.Focus();
        }
    }
}
