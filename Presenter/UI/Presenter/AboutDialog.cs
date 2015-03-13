/*
 *   PraiseBase Presenter
 *   The open source lyrics and image projection software for churches
 *
 *   http://praisebase.org
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
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.Util;

namespace PraiseBase.Presenter.UI.Presenter
{
    public partial class AboutDialog : Form
    {
        private String _updateDownloadUrl = string.Empty;

        public AboutDialog()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutWindow_Load(object sender, EventArgs e)
        {
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = AssemblyVersion;
            labelCopyright.Text = AssemblyCopyright;
            labelCompanyName.Text = AssemblyCompany;

            textBox1.Text = FileResources.License;

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
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
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
            UpdateChecker uc = new UpdateChecker();
            UpdateInformation ui = uc.GetNewVersion(Settings.Default.UpdateCheckUrl);
            if (ui.UpdateAvailable)
            {
                linkLabel1.Text = String.Format(StringResources.UpdateAvailable, ui.OnlineVersion, ui.CurrentVersion);
                linkLabel1.Image = Resources.update16;
                linkLabel1.ForeColor = Color.DarkGreen;
                _updateDownloadUrl = ui.DownloadUrl;
                buttonDownloadUpdate.Visible = true;
            }
            else
            {
                if (ui.OnlineVersion != null)
                {
                    linkLabel1.Text = StringResources.ProgramVersionUptodate;
                    linkLabel1.Image = Resources.ok16;
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
            if (_updateDownloadUrl != string.Empty)
            {
                Process.Start(_updateDownloadUrl);
            }
        }
    }
}