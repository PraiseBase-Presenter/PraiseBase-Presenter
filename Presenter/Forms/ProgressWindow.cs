using System;
using System.Windows.Forms;

namespace PraiseBase.Presenter.Forms
{
    public partial class ProgressWindow : UI.FormBase
    {
        public Boolean Cancelled { get; private set; }

        public ProgressWindow(string title, int maximum) : base()
        {
            InitializeComponent();
            Cancelled = false;
            Text = title;
            progressBarStatus.Maximum = maximum;
        }

        public void UpdateStatus(string message, int value)
        {
            label1.Text = message;
            progressBarStatus.Value = value;
            Application.DoEvents();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Cancelled = true;
        }
    }
}