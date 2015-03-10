using System;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence
{
    public interface ISongFilePlugin
    {
        /// <summary>
        /// Loads and instantiates a song from a file
        /// </summary>
        /// <param name="filename">Absolute path to the song file</param>
        /// <returns>Song object instance</returns>
        Song Load(String filePath);

        /// <summary>
        /// Reads the title of a song from a file
        /// </summary>
        /// <param name="filename">Absolute path to the song file</param>
        /// <returns></returns>
        String ReadTitle(string filePath);

        /// <summary>
        /// Tests if a given file is supported by this reader
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Boolean IsFileSupported(String filePath);

        /// <summary>
        /// Defines the extensions this file format uses, e.g. ".xml"
        /// </summary>
        string GetFileExtension();

        /// <summary>
        /// The common name of the file format
        /// </summary>
        string GetFileTypeDescription();

        /// <summary>
        /// Returns true if writing files is supported
        /// </summary>
        /// <returns></returns>
        Boolean IsWritingSupported();

        /// <summary>
        /// Writes a song to the specified path
        /// </summary>
        /// <param name="sng">Absolute path to the song file</param>
        /// <param name="filePath"></param>
        void Save(Song sng, string filePath);
    }
}
