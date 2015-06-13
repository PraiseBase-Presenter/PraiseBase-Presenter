using System;
using System.Drawing;
using System.Text.RegularExpressions;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public static class PowerPraiseFileUtil
    {
        public static Color ConvertColor(int value)
        {
            var c = Color.FromArgb(value);
            return Color.FromArgb(c.B, c.G, c.R);
        }

        public static int ConvertColor(Color value)
        {
            var c = Color.FromArgb(value.B, value.G, value.R);
            return c.ToArgb() + 16777216;
        }

        public static string MapBackground(IBackground bg)
        {
            if (bg != null)
            {
                if (bg.GetType() == typeof(ImageBackground))
                {
                    return ((ImageBackground)bg).ImagePath;
                }
                if (bg.GetType() == typeof(ColorBackground))
                {
                    return ConvertColor(((ColorBackground)bg).Color).ToString();
                }
            }
            return null;
        }

        public static IBackground ParseBackground(string bg)
        {
            if (Regex.IsMatch(bg, @"^\d+$"))
            {
                int trySize;
                if (int.TryParse(bg, out trySize))
                {
                    try
                    {
                        return new ColorBackground(PowerPraiseFileUtil.ConvertColor(trySize));
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                }
            }
            else if (bg.Trim() != String.Empty)
            {
                return new ImageBackground(bg);
            }
            return null;
        }
    }
}