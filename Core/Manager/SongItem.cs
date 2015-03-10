using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Persistence;

namespace PraiseBase.Presenter
{
    /// <summary>
    /// Song item structure
    /// </summary>
    public class SongItem
    {
        private Song _song;
        public Song Song
        {
            get { return _song; }
            set
            {
                _song = value;
                SearchText = value.GetSearchableText();
            }
        }

        public string Filename { get; set; }
        public ISongFilePlugin Plugin { get; set; }
        public bool SwitchTextAndTranlation { get; set; }

        /// <summary>
        /// Gets the whole songtext improved for full-text search
        /// </summary>
        public string SearchText { get; private set; }
    }
}