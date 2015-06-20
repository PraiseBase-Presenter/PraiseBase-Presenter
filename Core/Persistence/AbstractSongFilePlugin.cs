using System;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence
{
    public abstract class AbstractSongFilePlugin<T> : ISongFilePlugin where T : ISongFile, new()
    {
        protected ISongFileMapper<T> mapper;
        protected ISongFileReader<T> reader;
        protected ISongFileWriter<T> writer;

        public AbstractSongFilePlugin()
        {
            Console.WriteLine("Loaded song file plugin: " + GetType() + " (" + GetFileTypeDescription() + ")");
        }

        public abstract string GetFileExtension();
        public abstract string GetFileTypeDescription();

        public string ReadTitle(string filePath)
        {
            return reader.ReadTitle(filePath);
        }

        public Song Load(string filePath)
        {
            var song = reader.Load(filePath);
            return mapper.Map(song);
        }

        public bool IsFileSupported(string filePath)
        {
            return reader.IsFileSupported(filePath);
        }

        public bool IsWritingSupported()
        {
            return writer != null;
        }

        public void Save(Song sng, string filePath)
        {
            if (!IsWritingSupported())
            {
                throw new NotImplementedException("Writing not supported by " + GetType());
            }

            var song = new T();
            mapper.Map(sng, song);
            writer.Save(filePath, song);
        }
    }
}