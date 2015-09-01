namespace PraiseBase.Presenter.Projection
{
    public interface ISlideTextFormattingMapper<in T>
    {
        void Map(T s, ref SlideTextFormatting slideFormatting);
    }
}