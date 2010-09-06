using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pbp.Components
{
    public partial class CustomGroupBox : Panel
    {
        [Description("Title of the groupbox"), Category("CustomGroupBox"), DefaultValue("Title")]
        public String Title { get { return labelTitle.Text; } set { labelTitle.Text = value;  } }

        public CustomGroupBox()
        {
            InitializeComponent();
        }

        void CustomGroupBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            this.panelTitleBG.Size = new System.Drawing.Size(this.Width, 28);
        }
    }
}
