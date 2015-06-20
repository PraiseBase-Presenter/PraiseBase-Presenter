using System;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence
{
    public abstract class AbstractSongFilePlugin<T> : ISongFilePlugin where T : ISongFile, new()
    {
        protected ISongFileMapper<T> Mapper;
        protected ISongFileReader<T> Reader;
        protected ISongFileWriter<T> Writer;

        protected AbstractSongFilePlugin()
        {
            Console.WriteLine("Loaded song file plugin: " + GetType() + " (" + GetFileTypeDescription() + ")");
        }

        /// <summary>
        ///     Gets the file extension
        /// </summary>
        /// <returns></returns>
        public abstract string GetFileExtension();

        /// <summary>
        ///     Gets the file type descriptions
        /// </summary>
        /// <returns></returns>
        public abstract string GetFileTypeDescription();

        /// <summary>
        ///     Reads the title from the file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string ReadTitle(string filePath)
        {
            return Reader.ReadTitle(filePath);
        }

        /// <summary>
        ///     Loads the file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public Song Load(string filePath)
        {
            var song = Reader.Load(filePath);
            return Mapper.Map(song);
        }

        public bool IsFileSupported(string filePath)
        {
            return Reader.IsFileSupported(filePath);
        }

        public bool IsWritingSupported()
        {
            return Writer != null;
        }

        public void Save(Song sng, string filePath)
        {
            if (!IsWritingSupported())
            {
                throw new NotImplementedException("Writing not supported by " + GetType());
            }

            var song = new T();
            Mapper.Map(sng, song);
            Writer.Save(filePath, song);
        }
    }
}