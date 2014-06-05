using System.Drawing;
using Pbp.Model;

namespace Pbp.Persistence
{
    public static class PowerPraiseConstants
    {
        public static readonly TextFormatting MainText = new TextFormatting(
            new Font("Tahoma", 30, FontStyle.Bold | FontStyle.Italic),
            Color.FromArgb(255, Color.FromArgb(16777215)),
            new TextOutline(30, Color.Black),
            new TextShadow(10, 20, 125, Color.Black),
            30);

        public static readonly TextFormatting TranslationText = new TextFormatting(
            new Font("Tahoma", 20, FontStyle.Regular),
            Color.FromArgb(255, Color.FromArgb(16777215)),
            new TextOutline(30, Color.Black),
            new TextShadow(10, 20, 125, Color.Black),
            20);

        public static readonly TextFormatting CopyrightText = new TextFormatting(
            new Font("Tahoma", 14, FontStyle.Regular),
            Color.FromArgb(255, Color.FromArgb(16777215)),
            new TextOutline(30, Color.Black),
            new TextShadow(10, 20, 125, Color.Black),
            14);

        public static readonly TextFormatting SourceText = new TextFormatting(
            new Font("Tahoma", 30, FontStyle.Regular),
            Color.FromArgb(255, Color.FromArgb(16777215)),
            new TextOutline(30, Color.Black),
            new TextShadow(10, 20, 125, Color.Black),
            30);

        public static readonly bool TextOutlineEnabled = true;
        public static readonly bool TextShadowEnabled = true;

        public static readonly SongTextBorders TextBorders = new SongTextBorders(40, 70, 40, 80, 30, 20, 40);
    }
}