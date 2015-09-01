using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence
{
    public interface ISongFileMapper<in T> where T : ISongFile
    {
        Song Map(T source);
        void Map(Song song, T target);
    }
}