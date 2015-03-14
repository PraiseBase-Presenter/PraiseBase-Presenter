using System.Drawing;
using PraiseBase.Presenter.Model;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public static class PowerPraiseConstants
    {
        public static readonly string NoCategory = "Keine Kategorie";
        public static readonly string Language = null;
        public static readonly int SlideMainTextSize = 30;

        public static readonly PowerPraiseSong.CopyrightPosition CopyrightTextPosition =
            PowerPraiseSong.CopyrightPosition.LastSlide;

        public static readonly bool SourceTextEnabled = true;

        public static readonly PowerPraiseSong.FontFormatting MainText = new PowerPraiseSong.FontFormatting
        {
            Font = new Font("Tahoma", 30, FontStyle.Bold),
            Color = PowerPraiseFileUtil.ConvertColor(16777215),
            OutlineWidth = 30,
            ShadowDistance = 20
        };

        public static readonly PowerPraiseSong.FontFormatting TranslationText = new PowerPraiseSong.FontFormatting
        {
            Font = new Font("Tahoma", 20, FontStyle.Regular),
            Color = PowerPraiseFileUtil.ConvertColor(16777215),
            OutlineWidth = 30,
            ShadowDistance = 20
        };

        public static readonly PowerPraiseSong.FontFormatting CopyrightText = new PowerPraiseSong.FontFormatting
        {
            Font = new Font("Tahoma", 14, FontStyle.Regular),
            Color = PowerPraiseFileUtil.ConvertColor(16777215),
            OutlineWidth = 30,
            ShadowDistance = 20
        };

        public static readonly PowerPraiseSong.FontFormatting SourceText = new PowerPraiseSong.FontFormatting
        {
            Font = new Font("Tahoma", 30, FontStyle.Regular),
            Color = PowerPraiseFileUtil.ConvertColor(16777215),
            OutlineWidth = 30,
            ShadowDistance = 20
        };

        public static readonly PowerPraiseSong.OutlineFormatting FontOutline = new PowerPraiseSong.OutlineFormatting
        {
            Enabled = false,
            Color = PowerPraiseFileUtil.ConvertColor(0)
        };

        public static readonly PowerPraiseSong.ShadowFormatting FontShadow = new PowerPraiseSong.ShadowFormatting
        {
            Enabled = true,
            Color = PowerPraiseFileUtil.ConvertColor(0),
            Direction = 125
        };

        public static readonly int MainLineSpacing = 30;
        public static readonly int TranslationLineSpacing = 20;

        public static readonly TextOrientation TextOrientation = new TextOrientation(VerticalOrientation.Middle,
            HorizontalOrientation.Center);

        public static readonly TranslationPosition TranslationPosition = TranslationPosition.Inline;

        public static readonly PowerPraiseSong.TextBorders TextBorders = new PowerPraiseSong.TextBorders
        {
            TextLeft = 40,
            TextTop = 70,
            TextRight = 40,
            TextBottom = 80,
            CopyrightBottom = 30,
            SourceTop = 20,
            SourceRight = 40
        };

        public static readonly string DefaultBackground = "8075276";
    }
}