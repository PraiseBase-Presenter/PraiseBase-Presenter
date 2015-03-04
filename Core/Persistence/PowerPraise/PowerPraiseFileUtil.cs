using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public static class PowerPraiseFileUtil
    {
        public static Color ConvertColor(int value)
        {
            Color c = Color.FromArgb(value);
            return Color.FromArgb(c.B, c.G, c.R);
        }

        public static int ConvertColor(Color value)
        {
            Color c = Color.FromArgb(value.B, value.G, value.R);
            return c.ToArgb() + 16777216;
        }
    }
}
