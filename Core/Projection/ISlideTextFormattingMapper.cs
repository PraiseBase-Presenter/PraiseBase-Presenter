namespace PraiseBase.Presenter.Projection
{
    public interface ISlideTextFormattingMapper<T>
    {
        void Map(T s, ref SlideTextFormatting slideFormatting);
    }
}