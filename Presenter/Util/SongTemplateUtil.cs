using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Properties;

namespace PraiseBase.Presenter.Util
{
    public static class SongTemplateUtil
    {
        public static void ApplyFormattingFromSettings(Settings settings, Song sng)
        {
            sng.MainText = new TextFormatting(
                settings.ProjectionMasterFont,
                settings.ProjectionMasterFontColor,
                new TextOutline(settings.ProjectionMasterOutlineSize, settings.ProjectionMasterOutlineColor),
                new TextShadow(settings.ProjectionMasterShadowDistance, settings.ProjectionMasterShadowSize,
                    settings.ProjectionMasterShadowDirection, settings.ProjectionMasterShadowColor),
                settings.ProjectionMasterLineSpacing);

            sng.TranslationText = new TextFormatting(
                settings.ProjectionMasterFontTranslation,
                settings.ProjectionMasterTranslationColor,
                new TextOutline(settings.ProjectionMasterOutlineSize, settings.ProjectionMasterOutlineColor),
                new TextShadow(settings.ProjectionMasterShadowDistance, settings.ProjectionMasterShadowSize,
                    settings.ProjectionMasterShadowDirection, settings.ProjectionMasterShadowColor),
                settings.ProjectionMasterLineSpacing);

            sng.CopyrightText = new TextFormatting(
                settings.ProjectionMasterFontTranslation,
                settings.ProjectionMasterTranslationColor,
                new TextOutline(settings.ProjectionMasterOutlineSize, settings.ProjectionMasterOutlineColor),
                new TextShadow(settings.ProjectionMasterShadowDistance, settings.ProjectionMasterShadowSize,
                    settings.ProjectionMasterShadowDirection, settings.ProjectionMasterShadowColor),
                settings.ProjectionMasterLineSpacing);

            sng.SourceText = new TextFormatting(
               settings.ProjectionMasterFontTranslation,
               settings.ProjectionMasterTranslationColor,
                new TextOutline(settings.ProjectionMasterOutlineSize, settings.ProjectionMasterOutlineColor),
                new TextShadow(settings.ProjectionMasterShadowDistance, settings.ProjectionMasterShadowSize,
                    settings.ProjectionMasterShadowDirection, settings.ProjectionMasterShadowColor),
               settings.ProjectionMasterLineSpacing);

            sng.TextOrientation = new TextOrientation(settings.ProjectionMasterVerticalTextOrientation, settings.ProjectionMasterHorizontalTextOrientation);
            sng.TranslationPosition = settings.ProjectionMasteTranslationPosition;

            sng.TextOutlineEnabled = settings.ProjectionMasterOutlineEnabled;
            sng.TextShadowEnabled = settings.ProjectionMasterShadowEnabled;

            sng.TextBorders = new SongTextBorders(
                settings.ProjectionMasterHorizontalTextPadding,
                settings.ProjectionMasterVerticalTextPadding,
                settings.ProjectionMasterHorizontalTextPadding,
                settings.ProjectionMasterVerticalTextPadding,
                settings.ProjectionMasterVerticalFooterPadding,
                settings.ProjectionMasterVerticalHeaderPadding,
                settings.ProjectionMasterHorizontalHeaderPadding
            );
        }
    }
}
