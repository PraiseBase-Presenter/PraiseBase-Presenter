using System.Drawing;
using Pbp.Model;
using Pbp.Model.Song.PowerPraise;

namespace Pbp.Persistence
{
    public static class PowerPraiseConstants
    {
        public static readonly string Category = "Keine Kategorie";

        public static readonly string Language = null;

        public static readonly int SlideMainTextSize = 30;

        public static readonly PowerPraiseSong.AnnotationTextPosition CopyrightTextPosition = PowerPraiseSong.AnnotationTextPosition.LastSlide;

        public static readonly bool SourceTextEnabled = true;

        public static readonly PowerPraiseSong.TextFormatting MainText = new PowerPraiseSong.TextFormatting
        {
            Font = new Font("Tahoma", 30, FontStyle.Bold),
            Color = Color.FromArgb(255, Color.FromArgb(16777215)),
            OutlineWidth = 30,
            ShadowDistance = 20
        };
        
        public static readonly PowerPraiseSong.TextFormatting TranslationText = new PowerPraiseSong.TextFormatting
        {
            Font = new Font("Tahoma", 20, FontStyle.Regular),
            Color = Color.FromArgb(255, Color.FromArgb(16777215)),
            OutlineWidth = 30,
            ShadowDistance = 20
        };

        public static readonly PowerPraiseSong.TextFormatting CopyrightText = new PowerPraiseSong.TextFormatting
        {
            Font = new Font("Tahoma", 14, FontStyle.Regular),
            Color = Color.FromArgb(255, Color.FromArgb(16777215)),
            OutlineWidth = 30,
            ShadowDistance = 20
        };

        public static readonly PowerPraiseSong.TextFormatting SourceText = new PowerPraiseSong.TextFormatting
        {
            Font = new Font("Tahoma", 30, FontStyle.Regular),
            Color = Color.FromArgb(255, Color.FromArgb(16777215)),
            OutlineWidth = 30,
            ShadowDistance = 20
        };

        public static readonly PowerPraiseSong.TextOutline FontOutline = new PowerPraiseSong.TextOutline
        {
            Enabled = false,
            Color = Color.FromArgb(0, Color.FromArgb(16777215)),
        };

        public static readonly PowerPraiseSong.TextShadow FontShadow = new PowerPraiseSong.TextShadow
        {
            Enabled = true,
            Color = Color.FromArgb(0, Color.FromArgb(16777215)),
            Direction = 125
        };

        public static readonly int MainLineSpacing = 30;

        public static readonly int TranslationLineSpacing = 20;

        public static readonly TextOrientation TextOrientation = new TextOrientation(VerticalOrientation.Middle, HorizontalOrientation.Center);

        public static readonly PowerPraiseSong.TextDisplayMode TranslationPosition = PowerPraiseSong.TextDisplayMode.Inline;

        public static readonly PowerPraiseSong.TextBorders TextBorders = new PowerPraiseSong.TextBorders { 
            TextLeft = 40,
            TextTop = 70,
            TextRight = 40,
            TextBottom = 80,
            CopyrightBottom = 30,
            SourceTop = 20,
            SourceRight = 40            
        };
    }
}