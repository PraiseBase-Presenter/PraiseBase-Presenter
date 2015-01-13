using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
