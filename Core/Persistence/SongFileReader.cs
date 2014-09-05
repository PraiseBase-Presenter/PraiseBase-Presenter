/*
 *   PraiseBase Presenter
 *   The open source lyrics and image projection software for churches
 *
 *   http://code.google.com/p/praisebasepresenter
 *
 *   This program is free software; you can redistribute it and/or
 *   modify it under the terms of the GNU General Public License
 *   as published by the Free Software Foundation; either version 2
 *   of the License, or (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program; if not, write to the Free Software
 *   Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 *
 *   Author:
 *      Nicolas Perrenoud <nicu_at_lavine.ch>
 *   Co-authors:
 *      ...
 *
 */

using System;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence
{
    public interface SongFileReader
    {
        /// <summary>
        /// Loads and instantiates a song from a file
        /// </summary>
        /// <param name="filename">Absolute path to the song file</param>
        /// <returns>Song object instance</returns>
        Song Load(string filename);

        /// <summary>
        /// Reads the title of a song from a file
        /// </summary>
        /// <param name="filename">Absolute path to the song file</param>
        /// <returns></returns>
        String ReadTitle(string filename);

        /// <summary>
        /// Tests if a given file is supported by this reader
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        bool IsFileSupported(string filename);

        /// <summary>
        /// Defines the extensions this file format uses, e.g. ".xml"
        /// </summary>
        string GetFileExtension();

        /// <summary>
        /// The common name of the file format
        /// </summary>
        string GetFileTypeDescription();
    }

    /// <summary>
    /// Thrown when the file format is invalid
    /// </summary>
    public class IncompleteSongSourceFileException : Exception
    {
    }

    /// <summary>
    /// Thrown when the file lacks important contents
    /// </summary>
    public class InvalidSongSourceFileException : Exception
    {
    }
}