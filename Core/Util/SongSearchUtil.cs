using System;
using System.Linq;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Util
{
    public static class SongSearchUtil
    {
        /// <summary>
        ///     Gets all text for searching, including the song title
        /// </summary>
        public static string GetSearchableSongText(Song song)
        {
            return PrepareSearchText(GetCompleteSongText(song));
        }

        /// <summary>
        ///     Prepares a text so it can be searched easily
        ///     Converts to lower case, removes additional space, newlines and punctuation marks
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string PrepareSearchText(string text)
        {
            text = text.Trim().ToLower();
            text = text.Replace(",", string.Empty);
            text = text.Replace(".", string.Empty);
            text = text.Replace(";", string.Empty);
            text = text.Replace(Environment.NewLine, string.Empty);
            text = text.Replace("  ", " ");
            return text;
        }

        /// <summary>
        ///     Gets the complete song text as one string
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        public static string GetCompleteSongText(Song song)
        {
            return
                (from prt in song.Parts from sld in prt.Slides from line in sld.Lines select line).Aggregate(
                    string.Empty, (current, line) => current + (line + " "));
        }
    }
}