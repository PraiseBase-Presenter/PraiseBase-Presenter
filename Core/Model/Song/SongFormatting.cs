namespace PraiseBase.Presenter.Model.Song
{
    public class SongFormatting
    {
        /// <summary>
        ///     Copyright position (PowerPraise)
        /// </summary>
        public AdditionalInformationPosition CopyrightPosition { get; set; }

        /// <summary>
        ///     Source position (PowerPraise)
        /// </summary>
        public AdditionalInformationPosition SourcePosition { get; set; }

        /// <summary>
        ///     Gets or sets the text font and color for the main text
        /// </summary>
        public TextFormatting MainText { get; set; }

        /// <summary>
        ///     Gets or sets the font of tanslation text
        /// </summary>
        public TextFormatting TranslationText { get; set; }

        /// <summary>
        ///     Gets or sets the font for the copyright text
        /// </summary>
        public TextFormatting CopyrightText { get; set; }

        /// <summary>
        ///     Gets or sets the font for the source text
        /// </summary>
        public TextFormatting SourceText { get; set; }

        /// <summary>
        ///     Main text line spacing
        /// </summary>
        public int MainLineSpacing { get; set; }

        /// <summary>
        ///     Translation text line spacing
        /// </summary>
        public int TranslationLineSpacing { get; set; }

        /// <summary>
        ///     Text orientation
        /// </summary>
        public TextOrientation TextOrientation { get; set; }

        /// <summary>
        ///     Position of the translation text
        /// </summary>
        public TranslationPosition TranslationPosition { get; set; }

        /// <summary>
        ///     True of the text should be outlined
        /// </summary>
        public bool TextOutlineEnabled { get; set; }

        /// <summary>
        ///     True if the text should have a shadow
        /// </summary>
        public bool TextShadowEnabled { get; set; }

        /// <summary>
        ///     Text borders (used by PowerPraise)
        /// </summary>
        public SongTextBorders TextBorders { get; set; }

        /// <summary>
        ///     Returns a hashcode of the song, used for example in the
        ///     editor to check if the file was changed
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) CopyrightPosition;
                hashCode = (hashCode*397) ^ (int) SourcePosition;
                hashCode = (hashCode*397) ^ (MainText != null ? MainText.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TranslationText != null ? TranslationText.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CopyrightText != null ? CopyrightText.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (SourceText != null ? SourceText.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ MainLineSpacing;
                hashCode = (hashCode*397) ^ TranslationLineSpacing;
                hashCode = (hashCode*397) ^ (TextOrientation != null ? TextOrientation.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) TranslationPosition;
                hashCode = (hashCode*397) ^ TextOutlineEnabled.GetHashCode();
                hashCode = (hashCode*397) ^ TextShadowEnabled.GetHashCode();
                hashCode = (hashCode*397) ^ (TextBorders != null ? TextBorders.GetHashCode() : 0);
                return hashCode;
            }
        }

        protected bool Equals(SongFormatting other)
        {
            return CopyrightPosition == other.CopyrightPosition && SourcePosition == other.SourcePosition &&
                   Equals(MainText, other.MainText) && Equals(TranslationText, other.TranslationText) &&
                   Equals(CopyrightText, other.CopyrightText) && Equals(SourceText, other.SourceText) &&
                   MainLineSpacing == other.MainLineSpacing && TranslationLineSpacing == other.TranslationLineSpacing &&
                   Equals(TextOrientation, other.TextOrientation) && TranslationPosition == other.TranslationPosition &&
                   TextOutlineEnabled == other.TextOutlineEnabled && TextShadowEnabled == other.TextShadowEnabled &&
                   Equals(TextBorders, other.TextBorders);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SongFormatting) obj);
        }
    }
}