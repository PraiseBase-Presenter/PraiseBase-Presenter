using System;
using System.Windows.Forms;

namespace Pbp.Forms
{
    public partial class ProgressWindow : Form
    {
        public Boolean Cancelled { get; private set; }

        public ProgressWindow(string title, int maximum)
        {
            InitializeComponent();
            Cancelled = false;
            this.Text = title;
            progressBarStatus.Maximum = maximum;
        }

        private void ProgressWindow_Load(object sender, EventArgs e)
        {
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