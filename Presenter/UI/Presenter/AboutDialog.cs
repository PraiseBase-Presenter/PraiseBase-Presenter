/*
 *   PraiseBase Presenter
 *   The open source lyrics and image projection software for churches
 *
 *   http://code.google.com/p/praisebasepresenter
 *
 *   This program is free software; you can redistribute it and/or
 *   modify it under the terms of the GNU General Public License
 *   as published by the Free Software Foundation; either version 2
 *   of the License, or (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program; if not, write to the Free Software
 *   Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 *
 *   Author:
 *      Nicolas Perrenoud <nicu_at_lavine.ch>
 *   Co-authors:
 *      ...
 *
 */

using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Pbp.Resources;

namespace Pbp.Forms
{
    public partial class AboutDialog : Form
    {
        private String updateDownloadUrl = string.Empty;

        public AboutDialog()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutWindow_Load(object sender, EventArgs e)
        {
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = AssemblyVersion;
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;

            this.textBox1.Text = global::Pbp.Resources.ImageResources.License;

            timer1.Interval = 1;
            timer1.Start();
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion Assembly Attribute Accessors

        private void timer1_Tick(object sender, EventArgs e)
        {
            Pbp.UpdateCheck.UpdateInformation ui = Pbp.UpdateCheck.getNewVersion();
            if (ui.UpdateAvailable)
            {
                linkLabel1.Text = String.Format(StringResources.UpdateAvailable, ui.OnlineVersion);
                linkLabel1.Image = Pbp.Resources.ImageResources.update16;
                linkLabel1.ForeColor = Color.DarkGreen;
                updateDownloadUrl = ui.DownloadUrl;
                buttonDownloadUpdate.Visible = true;
            }
            else
            {
                if (ui.OnlineVersion != null)
                {
                    linkLabel1.Text = StringResources.ProgramVersionUptodate;
                    linkLabel1.Image = Pbp.Resources.ImageResources.ok16;
                }
                else
                {
                    linkLabel1.Text = StringResources.ConnectionToUpdateServerFailed;
                }
                buttonDownloadUpdate.Visible = false;
            }
            timer1.Stop();
        }

        private void buttonDownloadUpdate_Click(object sender, EventArgs e)
        {
            if (updateDownloadUrl != string.Empty)
            {
                System.Diagnostics.Process.Start(updateDownloadUrl);
            }
        }
    }
}