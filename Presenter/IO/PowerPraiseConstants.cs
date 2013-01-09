using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Pbp.Data;

namespace Pbp.IO
{
    public static class PowerPraiseConstants
    {
        public static readonly TextFormatting MainText = new TextFormatting(
            new Font("Tahoma", 30, FontStyle.Bold | FontStyle.Italic), 
            Color.FromArgb(255, Color.FromArgb(16777215)), 30, 20, 30);

        public static readonly TextFormatting TranslationText = new TextFormatting(
            new Font("Tahoma", 20, FontStyle.Regular),
            Color.FromArgb(255, Color.FromArgb(16777215)), 30, 20, 20);

        public static readonly TextFormatting CopyrightText = new TextFormatting(
            new Font("Tahoma", 14, FontStyle.Regular),
            Color.FromArgb(255, Color.FromArgb(16777215)), 30, 20, 14);

        public static readonly TextFormatting SourceText = new TextFormatting(
            new Font("Tahoma", 30, FontStyle.Regular),
            Color.FromArgb(255, Color.FromArgb(16777215)), 30, 20, 30);
    }
}
