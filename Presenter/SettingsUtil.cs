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
            String path = settings.DataDirectory + Path.DirectorySeparatorChar + settings.SongDir;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public static string GetImageDirPath(Settings settings)
        {
            String path = settings.DataDirectory + Path.DirectorySeparatorChar + settings.ImageDir;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public static string GetThumbDirPath(Settings settings)
        {
            String path = settings.DataDirectory + Path.DirectorySeparatorChar + settings.ThumbDir;
            if (!Directory.Exists(path))
            {
                var di = Directory.CreateDirectory(path);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
            return path;
        }

        public static string GetBibleDirPath(Settings settings)
        {
            String path = settings.DataDirectory + Path.DirectorySeparatorChar + "Bibles";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
    }
}