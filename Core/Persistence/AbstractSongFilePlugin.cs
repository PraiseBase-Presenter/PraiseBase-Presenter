using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence
{
    public abstract class AbstractSongFilePlugin<T> : ISongFilePlugin where T : PersistentSong
    {
        protected ISongFileReader<T> reader;
        protected SongFileMapper<T> mapper;

        public Song Load(String filePath)
        {
            T song = reader.Load(filePath);
            return mapper.map(song);
        }

        public Boolean IsSupported(String filePath)
        {
            return reader.IsFileSupported(filePath);
        }
    }
}
