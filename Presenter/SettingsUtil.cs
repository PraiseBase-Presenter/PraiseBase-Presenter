using System;
using System.IO;
using PraiseBase.Presenter.Properties;

namespace PraiseBase.Presenter
{
    public static class SettingsUtil
    {
        public static bool SetDefaultDataDirIfEmpty(Settings settings)
        {
            if (Settings.Default.DataDirectory == "")
            {
                Settings.Default.DataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + Path.DirectorySeparatorChar + Settings.Default.DataDirDefaultName;
                if (Directory.Exists(Settings.Default.DataDirectory))
                {
                    Directory.CreateDirectory(Settings.Default.DataDirectory);
                }
            }
            return false;
        }

        public static string GetSongDirPath(Settings settings)
        {
            return settings.DataDirectory + Path.DirectorySeparatorChar + settings.SongDir;            
        }
    }
}