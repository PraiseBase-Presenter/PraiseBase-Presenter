using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PraiseBase.Presenter.UI
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();

            DarkTitleBarClass.UseImmersiveDarkMode(this.Handle, Program.isDarkMode);

            LoadAppConfig();
        }

        private void LoadAppConfig()
        {
            if (Program.isDarkMode)
            {
                this.BackColor = Color.FromArgb(40, 40, 40);
                Constants.ApplyTheme(this);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            DarkTitleBarClass.UseImmersiveDarkMode(this.Handle, Program.isDarkMode);
        }

    }
}
