using System;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Editor
{
    public class SongSavedEventArgs : EventArgs
    {
        public Song Song { get; set; }
        public string FileName { get; set; }

        public SongSavedEventArgs(Song song, string fileName)
        {
            Song = song;
            FileName = fileName;
        }
    }
}