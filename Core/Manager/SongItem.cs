using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Persistence;

namespace PraiseBase.Presenter.Manager
{
    /// <summary>
    ///     Song item structure
    /// </summary>
    public class SongItem
    {
        /// <summary>
        ///     Song
        /// </summary>
        public Song Song { get; set; }

        /// <summary>
        ///     Filename (absolute path)
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        ///     Song file plugin
        /// </summary>
        public ISongFilePlugin Plugin { get; set; }

        /// <summary>
        ///     If true, song text and translaton are swapped
        /// </summary>
        public bool SwitchTextAndTranlation { get; set; }

        /// <summary>
        ///     Gets the whole songtext improved for full-text search
        /// </summary>
        public string SearchText { get; set; }
    }
}