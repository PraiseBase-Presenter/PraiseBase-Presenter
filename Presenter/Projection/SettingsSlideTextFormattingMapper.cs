using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Properties;

namespace PraiseBase.Presenter.Projection
{
    public class SettingsSlideTextFormattingMapper : ISlideTextFormattingMapper<Settings>
    {
        public void Map(Settings settings, ref SlideTextFormatting slideFormatting)
        {
            slideFormatting.Text = new SlideTextFormatting.MainTextFormatting()
            {
                MainText = new TextFormatting(
                    settings.ProjectionMasterFont,
                    settings.ProjectionMasterFontColor,
                    new TextOutline(settings.ProjectionMasterOutlineSize, settings.ProjectionMasterOutlineColor),
                    new TextShadow(settings.ProjectionMasterShadowDistance, settings.ProjectionMasterShadowSize,
                        settings.ProjectionMasterShadowDirection, settings.ProjectionMasterShadowColor)                    
                ),
                SubText = new TextFormatting(
                    settings.ProjectionMasterFontTranslation,
                    settings.ProjectionMasterTranslationColor,
                    new TextOutline(settings.ProjectionMasterOutlineSize, settings.ProjectionMasterOutlineColor),
                    new TextShadow(settings.ProjectionMasterShadowDistance, settings.ProjectionMasterShadowSize, 
                        settings.ProjectionMasterShadowDirection, settings.ProjectionMasterShadowColor)                    
                ),
                MainTextLineSpacing = settings.ProjectionMasterLineSpacing,
                SubTextLineSpacing = settings.ProjectionMasterTranslationLineSpacing,
                Orientation = new TextOrientation(settings.ProjectionMasterVerticalTextOrientation, settings.ProjectionMasterHorizontalTextOrientation),
                HorizontalPadding = settings.ProjectionMasterHorizontalTextPadding,
                VerticalPadding = settings.ProjectionMasterHorizontalTextPadding,
                HorizontalSubTextOffset = settings.ProjectionMasterHorizontalTranslationTextOffset
            };
            slideFormatting.Header = new SlideTextFormatting.TextBoxFormatting()
            {
                Text = new TextFormatting(
                    settings.ProjectionMasterSourceFont,
                    settings.ProjectionMasterSourceColor,
                    new TextOutline(settings.ProjectionMasterOutlineSize, settings.ProjectionMasterOutlineColor),
                    new TextShadow(settings.ProjectionMasterShadowDistance, settings.ProjectionMasterShadowSize, 
                        settings.ProjectionMasterShadowDirection, settings.ProjectionMasterShadowColor)
                ),
                HorizontalOrientation = settings.ProjectionMasterHorizontalHeaderOrientation,
                HorizontalPadding = settings.ProjectionMasterHorizontalHeaderPadding,
                VerticalPadding = settings.ProjectionMasterVerticalHeaderPadding,
            };
            slideFormatting.Footer = new SlideTextFormatting.TextBoxFormatting()
            {
                Text = new TextFormatting(
                    settings.ProjectionMasterCopyrightFont,
                    settings.ProjectionMasterCopyrightColor,
                    new TextOutline(settings.ProjectionMasterOutlineSize, settings.ProjectionMasterOutlineColor),
                    new TextShadow(settings.ProjectionMasterShadowDistance, settings.ProjectionMasterShadowSize, 
                        settings.ProjectionMasterShadowDirection, settings.ProjectionMasterShadowColor)
                ),
                HorizontalOrientation = settings.ProjectionMasterHorizontalFooterOrientation,
                HorizontalPadding = settings.ProjectionMasterHorizontalFooterPadding,
                VerticalPadding = settings.ProjectionMasterVerticalFooterPadding,
            };
            slideFormatting.OutlineEnabled = settings.ProjectionMasterOutlineEnabled;
            slideFormatting.ShadowEnabled = settings.ProjectionMasterShadowEnabled;
        }
    }
}
