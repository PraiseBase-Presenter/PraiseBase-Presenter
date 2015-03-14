using System;
using System.Diagnostics;
using System.Windows.Forms;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.Util;

namespace PraiseBase.Presenter.Forms
{
    public partial class UpdateCheckDialog : Form
    {
        public bool HideNotification { get; private set; }

        private readonly UpdateInformation _updateInformation;

        public UpdateCheckDialog(UpdateInformation updateInformation)
        {
            _updateInformation = updateInformation;

            InitializeComponent();

            if (_updateInformation.UpdateAvailable)
            {
                buttonDownload.Enabled = true;
             
                if (!String.IsNullOrEmpty(_updateInformation.AnnouncementUrl))
                {
                    linkLabelAnnouncement.Visible = true;
                }
            }
        }

        private void UpdateCheckDialog_Load(object sender, EventArgs e)
        {
            labelMessage.Text = String.Format(StringResources.UpdateAvailable, _updateInformation.OnlineVersion, _updateInformation.CurrentVersion);
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void checkBoxHideNotification_CheckedChanged(object sender, EventArgs e)
        {
            HideNotification = ((CheckBox) sender).Checked;
        }

        private void linkLabelAnnouncement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(_updateInformation.AnnouncementUrl);
        }
    }
}
