using System;

namespace PraiseBase.Presenter.Util
{
    public class UpdateInformation
    {
        public Version CurrentVersion { get; set; }

        public Version OnlineVersion { get; set; }

        public string DownloadUrl { get; set; }

        public bool UpdateAvailable { get; set; }

        public UpdateInformation()
        {
            UpdateAvailable = false;
            DownloadUrl = string.Empty;
        }
    }
}