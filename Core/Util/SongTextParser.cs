using PraiseBase.Presenter.Model.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PraiseBase.Presenter.Util
{
    public class SongTextParser
    {
        private enum State
        {
            Separator,
            Verse,
            Meta
        }

        private string[] defaultPartNames = { "Verse", "Chorus", "Ending" };
        private const string defaultPartPrefix = "Teil ";

        public List<string> PartNames { get; set; } = new List<string>();

        /// <summary>
        /// Parses text to song structure
        /// Aimed to be used for CCLI SongSelect lyrics, but should work with other lyrics too
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Song Parse(string text)
        {
            string trimmed = text.Trim();
            string[] lines = trimmed.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            if (lines.Length == 0 || trimmed.Length == 0)
            {
                throw new Exception("Leeres Lied!");
            }

            Song song = new Song();
            if (lines.Length > 1 && lines[0] != string.Empty && lines[1] == string.Empty)
            {
                song.Title = lines[0];
                lines = lines.Skip(2).ToArray();
            }

            State state = State.Separator;
            SongPart part = null;
            SongSlide slide = null;
            List<string> copyright = new List<string>();
            foreach (string line in lines)
            {
                if (line != string.Empty && state == State.Separator)
                {
                    if (line.StartsWith("CCLI Song #"))
                    {
                        state = State.Meta;

                        Regex regex = new Regex(@"CCLI Song #\s*(\d+)");
                        Match match = regex.Match(line);
                        if (match.Success)
                        {
                            song.CcliIdentifier = match.Groups[1].Value;
                        }

                        continue;
                    }

                    state = State.Verse;
                    slide = new SongSlide();
                    part = new SongPart();
                    part.Slides.Add(slide);

                    var splittedLine = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                    if (defaultPartNames.Any(splittedLine[0].Contains))
                    {
                        part.Caption = line;
                    }
                    else if (PartNames.Contains(line))
                    {
                        part.Caption = line;
                    }
                    else
                    {
                        int idx = 1;
                        string partPrefix = defaultPartPrefix + idx;
                        while (song.Parts.Any(i => i.Caption == partPrefix))
                        {
                            partPrefix = defaultPartPrefix + ++idx;
                        }
                        part.Caption = partPrefix;
                        slide.Lines.Add(line);
                    }
                    continue;
                }
                if (line != string.Empty && state == State.Verse)
                {
                    slide.Lines.Add(line);
                    continue;
                }
                if (line != string.Empty && state == State.Meta)
                {
                    if (line.StartsWith("CCLI License #") || line.StartsWith("For use solely with the SongSelect"))
                    {
                        continue;
                    }
                    copyright.Add(line);
                    continue;
                }
                if (line == string.Empty && state == State.Verse)
                {
                    state = State.Separator;
                    song.Parts.Add(part);
                    song.PartSequence.Add(part);
                    continue;
                }
            }
            if (state == State.Verse)
            {
                state = State.Separator;
                song.Parts.Add(part);
                song.PartSequence.Add(part);
            }
            if (copyright.Count > 0)
            {
                song.Copyright = string.Join(Environment.NewLine, copyright.ToArray());
            }
            return song;
        }
    }
}
