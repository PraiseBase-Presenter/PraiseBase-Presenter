using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PraiseBase.Presenter.Model.Song
{
    /// <summary>
    ///     Creates a textual representation of a song text (and vice-versa)
    /// </summary>
    public class TextualSongRepresentationMapper
    {
        public string Map(Song s)
        {
            var list = new List<string>();
            foreach (var p in s.Parts)
            {
                for (var i = 0; i < p.Slides.Count; i++)
                {
                    var sl = p.Slides[i];
                    var str = string.Empty;
                    if (i == 0)
                    {
                        str += p.Caption + ": ";
                    }
                    str = sl.Lines.Aggregate(str, (current, l) => current + (l + Environment.NewLine));
                    list.Add(str);
                }
            }
            return string.Join("--" + Environment.NewLine, list.ToArray());
        }

        public void Map(string text, Song s)
        {
            s.Parts.Clear();
            s.PartSequence.Clear();
            var lines = text.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
            SongPart p = null;
            SongSlide sl = null;
            foreach (var l in lines)
            {
                var line = l;
                string caption = null;
                if (sl == null)
                {
                    var match = Regex.Match(line, "^(.+): ", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        caption = match.Groups[1].Value;
                        line = line.Substring(match.Groups[0].Value.Length);
                    }
                }

                if (p == null || caption != null)
                {
                    p = new SongPart
                    {
                        Caption = caption
                    };
                    s.Parts.Add(p);
                    s.PartSequence.Add(p);
                }
                if (sl == null)
                {
                    sl = new SongSlide();
                    p.Slides.Add(sl);
                }
                if (line.StartsWith("--"))
                {
                    sl = null;
                    continue;
                }
                sl.Lines.Add(line);
            }

            foreach (var part in s.Parts)
            {
                foreach (var slide in part.Slides)
                {
                    RemoveEmptyLineAtEnd(slide.Lines);
                }
            }
        }

        private void RemoveEmptyLineAtEnd(List<string> lines)
        {
            var cnt = lines.Count;
            if (cnt == 0) return;
            if (lines[cnt - 1].Trim() == string.Empty)
            {
                lines.RemoveAt(cnt - 1);
                RemoveEmptyLineAtEnd(lines);
            }
        }
    }
}