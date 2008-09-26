using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pbp.Forms
{
    public partial class settingsWindow : Form
    {
        public settingsWindow()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void settingsWindow_Load(object sender, EventArgs e)
        {
            
        }
    }
}
