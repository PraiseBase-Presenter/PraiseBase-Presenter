using System;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence
{
    public abstract class AbstractSongFilePlugin<T> : ISongFilePlugin where T : ISongFile, new()
    {
        // Here is the once-per-class call to initialize the log object
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected ISongFileMapper<T> Mapper;
        protected ISongFileReader<T> Reader;
        protected ISongFileWriter<T> Writer;

        protected AbstractSongFilePlugin()
        {
            log.Debug("Loaded song file plugin: " + GetType() + " (" + GetFileTypeDescription() + ")");
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
        ///     Gets a number indicating the order in which the plugin should be loaded
        /// </summary>
        /// <returns></returns>
        public abstract int LoadingOrder();

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

        public abstract bool IsImportSupported();
    }
}