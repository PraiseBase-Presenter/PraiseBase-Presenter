using System;
using System.Windows.Forms;

namespace PraiseBase.Presenter.Forms
{
    public partial class SimpleProgressWindow : UI.FormBase
    {
        public SimpleProgressWindow(string title) : base()
        {
            InitializeComponent();

            Text = title;
        }

        private void SimpleProgressWindow_Load(object sender, EventArgs e)
        {

        }

        public void SetLabel(string label)
        {
            label1.Text = label;
        }
    }
}
