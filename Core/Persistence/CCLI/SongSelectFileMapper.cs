using System;
using System.Collections.Generic;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.CCLI
{
    public class SongSelectFileMapper : ISongFileMapper<SongSelectFile>
    {
        public Song map(SongSelectFile source)
        {
            Song sng = new Song
            {
                // CCLI ID
                CcliID = source.ID,
                CCliIDReadonly = true,
                
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
            foreach (var v in source.Verses) {
                SongPart p = new SongPart
                {
                    Caption = v.Caption
                };
                SongSlide s = new SongSlide();
                s.Lines.AddRange(v.Lines);
                p.Slides.Add(s);
                sng.Parts.Add(p);
            }

            sng.UpdateSearchText();

            return sng;
        }

        public void map(Song source, SongSelectFile target)
        {
            throw new NotImplementedException("Not implemented yet");
        }
    }
}
