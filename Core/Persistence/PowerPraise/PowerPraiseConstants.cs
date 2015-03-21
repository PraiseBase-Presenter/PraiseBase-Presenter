using System.Drawing;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public static class PowerPraiseConstants
    {
        public static readonly string NoCategory = "Keine Kategorie";
        public static readonly string Language = null;
        public static readonly IBackground DefaultBackground = new ColorBackground(PowerPraiseFileUtil.ConvertColor(8075276));
        
        public static readonly int SlideMainTextSize = 30;

        public static readonly PowerPraiseSongFormatting Format = new PowerPraiseSongFormatting
        {
            MainText = new PowerPraiseSongFormatting.FontFormatting
            {
                Font = new Font("Tahoma", 30, FontStyle.Bold),
                Color = PowerPraiseFileUtil.ConvertColor(16777215),
                OutlineWidth = 30,
                ShadowDistance = 20
            },
            TranslationText = new PowerPraiseSongFormatting.FontFormatting
            {
                Font = new Font("Tahoma", 20, FontStyle.Regular),
                Color = PowerPraiseFileUtil.ConvertColor(16777215),
                OutlineWidth = 30,
                ShadowDistance = 20
            },
            CopyrightText = new PowerPraiseSongFormatting.FontFormatting
            {
                Font = new Font("Tahoma", 14, FontStyle.Regular),
                Color = PowerPraiseFileUtil.ConvertColor(16777215),
                OutlineWidth = 30,
                ShadowDistance = 20
            },
            SourceText = new PowerPraiseSongFormatting.FontFormatting
            {
                Font = new Font("Tahoma", 30, FontStyle.Regular),
                Color = PowerPraiseFileUtil.ConvertColor(16777215),
                OutlineWidth = 30,
                ShadowDistance = 20
            },
            Outline = new PowerPraiseSongFormatting.OutlineFormatting
            {
                Enabled = false,
                Color = PowerPraiseFileUtil.ConvertColor(0)
            },
            Shadow = new PowerPraiseSongFormatting.ShadowFormatting
            {
                Enabled = true,
                Color = PowerPraiseFileUtil.ConvertColor(0),
                Direction = 125
            },
            MainLineSpacing = 30,
            TranslationLineSpacing = 20,
            TextOrientation = new TextOrientation(VerticalOrientation.Middle, HorizontalOrientation.Center),
            TranslationPosition = TranslationPosition.Inline,
            CopyrightTextPosition = PowerPraiseSongFormatting.CopyrightPosition.LastSlide,
            SourceTextEnabled = true,
            Borders = new PowerPraiseSongFormatting.TextBorders
            {
                TextLeft = 40,
                TextTop = 70,
                TextRight = 40,
                TextBottom = 80,
                CopyrightBottom = 30,
                SourceTop = 20,
                SourceRight = 40
            }
        };
    }
}