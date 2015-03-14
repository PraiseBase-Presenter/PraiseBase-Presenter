using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Projection
{
    public class SongSlideTextFormattingMapper : ISlideTextFormattingMapper<Song>
    {
        public void Map(Song s, ref SlideTextFormatting slideFormatting)
        {
            slideFormatting.Text = new SlideTextFormatting.MainTextFormatting()
            {
                // TODO respect specific slide text size
                MainText = (TextFormatting)s.MainText.Clone(),
                SubText = (TextFormatting)s.TranslationText.Clone(),
                Orientation = (TextOrientation)s.TextOrientation.Clone(),
                HorizontalPadding = s.TextBorders.TextLeft,
                VerticalPadding = s.TextBorders.TextTop,
                // TODO Parametrize hard-coded value
                HorizontalSubTextOffset  = 10
            };
            slideFormatting.Header = new SlideTextFormatting.TextBoxFormatting()
            {
                Text = (TextFormatting)s.SourceText.Clone(),
                // TODO Parametrize hard-coded value
                HorizontalOrientation = HorizontalOrientation.Right,
                HorizontalPadding = s.TextBorders.SourceRight,
                VerticalPadding = s.TextBorders.SourceTop,
            };
            slideFormatting.Footer = new SlideTextFormatting.TextBoxFormatting()
            {
                Text = (TextFormatting)s.CopyrightText.Clone(),
                // TODO Parametrize hard-coded value
                HorizontalOrientation = HorizontalOrientation.Left,
                HorizontalPadding = s.TextBorders.CopyrightBottom,
                VerticalPadding = s.TextBorders.CopyrightBottom,
            };
            slideFormatting.OutlineEnabled = s.TextOutlineEnabled;
            slideFormatting.ShadowEnabled = s.TextShadowEnabled;
        }
    }
}
