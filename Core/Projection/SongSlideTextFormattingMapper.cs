using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Projection
{
    public class SongSlideTextFormattingMapper : ISlideTextFormattingMapper<Song>
    {
        public void Map(Song s, ref SlideTextFormatting slideFormatting)
        {
            slideFormatting.Text = new SlideTextFormatting.MainTextFormatting
            {
                // TODO respect specific slide text size
                MainText = (TextFormatting) s.Formatting.MainText.Clone(),
                SubText = (TextFormatting) s.Formatting.TranslationText.Clone(),
                Orientation = (TextOrientation) s.Formatting.TextOrientation.Clone(),
                HorizontalPadding = s.Formatting.TextBorders.TextLeft,
                VerticalPadding = s.Formatting.TextBorders.TextTop,
                // TODO Parametrize hard-coded value
                HorizontalSubTextOffset = 10
            };
            slideFormatting.Header = new SlideTextFormatting.TextBoxFormatting
            {
                Text = (TextFormatting) s.Formatting.SourceText.Clone(),
                // TODO Parametrize hard-coded value
                HorizontalOrientation = HorizontalOrientation.Right,
                HorizontalPadding = s.Formatting.TextBorders.SourceRight,
                VerticalPadding = s.Formatting.TextBorders.SourceTop
            };
            slideFormatting.Footer = new SlideTextFormatting.TextBoxFormatting
            {
                Text = (TextFormatting) s.Formatting.CopyrightText.Clone(),
                // TODO Parametrize hard-coded value
                HorizontalOrientation = HorizontalOrientation.Left,
                HorizontalPadding = s.Formatting.TextBorders.CopyrightBottom,
                VerticalPadding = s.Formatting.TextBorders.CopyrightBottom
            };
            slideFormatting.OutlineEnabled = s.Formatting.TextOutlineEnabled;
            slideFormatting.ShadowEnabled = s.Formatting.TextShadowEnabled;
        }
    }
}