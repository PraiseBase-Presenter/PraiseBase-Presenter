using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Properties;

namespace PraiseBase.Presenter.Template
{
    public class SongTemplateMapper
    {
        private readonly Settings _settings;

        public SongTemplateMapper(Settings settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// Creates a new song with default name and one part with one slide
        /// </summary>
        /// <returns></returns>
        public Song CreateNewSong()
        {
            Song sng = new Song
            {
                Title = _settings.SongDefaultName,
                Language = _settings.SongDefaultLanguage
            };

            var part = AddSongPart(sng, _settings.SongPartDefaultName);

            sng.PartSequence.Add(part);

            return sng;
        }

        public SongPart AddSongPart(Song sng, string caption)
        {
            SongPart prt = new SongPart
            {
                Caption = caption
            };
            AddSongSlide(prt);
            sng.Parts.Add(prt);
            return prt;
        }

        public SongSlide AddSongSlide(SongPart part)
        {
            SongSlide sld = new SongSlide
            {
                Background = GetDefaultBackground()
            };
            part.Slides.Add(sld);
            return sld;
        }

        public ColorBackground GetDefaultBackground()
        {
            return new ColorBackground(_settings.ProjectionBackColor);
        }

        public void ApplyFormattingFromSettings(Song sng)
        {
            sng.Formatting.MainText = new TextFormatting(
                _settings.ProjectionMasterFont,
                _settings.ProjectionMasterFontColor,
                new TextOutline(_settings.ProjectionMasterOutlineSize, _settings.ProjectionMasterOutlineColor),
                new TextShadow(_settings.ProjectionMasterShadowDistance, _settings.ProjectionMasterShadowSize,
                    _settings.ProjectionMasterShadowDirection, _settings.ProjectionMasterShadowColor),
                _settings.ProjectionMasterLineSpacing);

            sng.Formatting.TranslationText = new TextFormatting(
                _settings.ProjectionMasterFontTranslation,
                _settings.ProjectionMasterTranslationColor,
                new TextOutline(_settings.ProjectionMasterOutlineSize, _settings.ProjectionMasterOutlineColor),
                new TextShadow(_settings.ProjectionMasterShadowDistance, _settings.ProjectionMasterShadowSize,
                    _settings.ProjectionMasterShadowDirection, _settings.ProjectionMasterShadowColor),
                _settings.ProjectionMasterLineSpacing);

            sng.Formatting.CopyrightText = new TextFormatting(
                _settings.ProjectionMasterFontTranslation,
                _settings.ProjectionMasterTranslationColor,
                new TextOutline(_settings.ProjectionMasterOutlineSize, _settings.ProjectionMasterOutlineColor),
                new TextShadow(_settings.ProjectionMasterShadowDistance, _settings.ProjectionMasterShadowSize,
                    _settings.ProjectionMasterShadowDirection, _settings.ProjectionMasterShadowColor),
                _settings.ProjectionMasterLineSpacing);

            sng.Formatting.SourceText = new TextFormatting(
               _settings.ProjectionMasterFontTranslation,
               _settings.ProjectionMasterTranslationColor,
                new TextOutline(_settings.ProjectionMasterOutlineSize, _settings.ProjectionMasterOutlineColor),
                new TextShadow(_settings.ProjectionMasterShadowDistance, _settings.ProjectionMasterShadowSize,
                    _settings.ProjectionMasterShadowDirection, _settings.ProjectionMasterShadowColor),
               _settings.ProjectionMasterLineSpacing);

            sng.Formatting.TextOrientation = new TextOrientation(_settings.ProjectionMasterVerticalTextOrientation, _settings.ProjectionMasterHorizontalTextOrientation);
            sng.Formatting.CopyrightPosition = _settings.ProjectionMasterCopyrightPosition;
            sng.Formatting.SourcePosition = _settings.ProjectionMasterSourcePosition;
            sng.Formatting.TranslationPosition = _settings.ProjectionMasteTranslationPosition;

            sng.Formatting.TextOutlineEnabled = _settings.ProjectionMasterOutlineEnabled;
            sng.Formatting.TextShadowEnabled = _settings.ProjectionMasterShadowEnabled;

            sng.Formatting.TextBorders = new SongTextBorders(
                _settings.ProjectionMasterHorizontalTextPadding,
                _settings.ProjectionMasterVerticalTextPadding,
                _settings.ProjectionMasterHorizontalTextPadding,
                _settings.ProjectionMasterVerticalTextPadding,
                _settings.ProjectionMasterVerticalFooterPadding,
                _settings.ProjectionMasterVerticalHeaderPadding,
                _settings.ProjectionMasterHorizontalHeaderPadding
            );
        }
    }
}
