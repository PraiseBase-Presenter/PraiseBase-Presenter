using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence
{
    public abstract class AbstractSongFilePlugin<T> : ISongFilePlugin where T : ISongFile, new()
    {
        protected ISongFileReader<T> reader;
        protected ISongFileMapper<T> mapper;
        protected ISongFileWriter<T> writer;

        public AbstractSongFilePlugin()
        {
            Console.WriteLine("Loaded song file plugin: " + this.GetType().ToString() + " (" + this.GetFileTypeDescription() + ")");
        }

        public abstract string GetFileExtension();

        public abstract string GetFileTypeDescription();

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

        public Boolean IsWritingSupported()
        {
            return writer != null;
        }

        public void Save(Song sng, string filePath)
        {
            if (!IsWritingSupported())
            {
                throw new NotImplementedException("Writing not supported by " + this.GetType());
            }
            
            T song = new T();
            mapper.map(sng, song);
            writer.Save(filePath, song);
        }
    }
}
