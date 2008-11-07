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
	public partial class Loading : Form
	{
		public Loading()
		{
			InitializeComponent();
		}

		public void setLabel(string message)
		{
			label1.Text = message;
			Application.DoEvents();
		}

		public void setProgBarValue(int value)
		{
			progressBar.Value = value;
			Application.DoEvents();
		}

		public void setProgBarMax(int max)
		{
			progressBar.Maximum = max;
			Application.DoEvents();
		}

	}
}
