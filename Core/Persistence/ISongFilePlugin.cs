using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence
{
    public interface ISongFilePlugin
    {
        /// <summary>
        ///     Loads and instantiates a song from a file
        /// </summary>
        /// <param name="filePath">Absolute path to the song file</param>
        /// <returns>Song object instance</returns>
        Song Load(string filePath);

        /// <summary>
        ///     Reads the title of a song from a file
        /// </summary>
        /// <param name="filePath">Absolute path to the song file</param>
        /// <returns></returns>
        string ReadTitle(string filePath);

        /// <summary>
        ///     Tests if a given file is supported by this reader
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        bool IsFileSupported(string filePath);

        /// <summary>
        ///     Gets a number indicating the order in which the plugin should be loaded
        /// </summary>
        /// <returns></returns>
        int LoadingOrder();

        /// <summary>
        ///     Defines the extensions this file format uses, e.g. ".xml"
        /// </summary>
        string GetFileExtension();

        /// <summary>
        ///     The common name of the file format
        /// </summary>
        string GetFileTypeDescription();

        /// <summary>
        ///     Returns true if writing files is supported
        /// </summary>
        /// <returns></returns>
        bool IsWritingSupported();

        /// <summary>
        ///     Returns true if it can be used in importer
        /// </summary>
        /// <returns></returns>
        bool IsImportSupported();

        /// <summary>
        ///     Writes a song to the specified path
        /// </summary>
        /// <param name="sng">Absolute path to the song file</param>
        /// <param name="filePath"></param>
        void Save(Song sng, string filePath);
    }
}