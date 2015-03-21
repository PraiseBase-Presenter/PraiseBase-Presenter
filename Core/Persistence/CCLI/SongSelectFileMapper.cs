using System;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.CCLI
{
    public class SongSelectFileMapper : ISongFileMapper<SongSelectFile>
    {
        public Song Map(SongSelectFile source)
        {
            var sng = new Song
            {
                // CCLI ID
                CcliIdentifier = source.CcliIdentifier,

                // Title
                Title = source.Title,

                // Copyright
                Copyright = source.Copyright,

                // Administration / Rights management
                RightsManagement = source.Admin
            };

            // Author
            var a = new SongAuthor
            {
                Name = source.Author
            };
            sng.Author.Add(a);

            // Themes
            sng.Themes.AddRange(source.Themes);

            // Key
            sng.Key = source.Key;

            // Verses
            foreach (var v in source.Verses)
            {
                var p = new SongPart
                {
                    Caption = v.Caption
                };
                var s = new SongSlide();
                s.Lines.AddRange(v.Lines);
                p.Slides.Add(s);
                sng.Parts.Add(p);
            }

            return sng;
        }

        public void Map(Song source, SongSelectFile target)
        {
            throw new NotImplementedException("Not implemented yet");
        }
    }
}