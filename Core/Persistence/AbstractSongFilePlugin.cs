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

        public AbstractSongFilePlugin()
        {
            Console.WriteLine("Loaded song file plugin: " + this.GetType().ToString());
        }
        public String ReadTitle(string filePath)
        {
            return reader.ReadTitle(filePath);
        }

        public Song Load(String filePath)
        {
            T song = reader.Load(filePath);
            return mapper.map(song);
        }

        public Boolean IsFileSupported(String filePath)
        {
            return reader.IsFileSupported(filePath);
        }

        public string GetFileExtension()
        {
            return reader.GetFileExtension();
        }
    }
}
