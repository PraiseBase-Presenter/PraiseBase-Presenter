using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.CCLI
{
    public class SongSelectFileMapper
    {
        public Song map(SongSelectFile source)
        {
            Song sng = new Song();

            // CCLI ID
            sng.CcliID = source.ID;
            sng.CCliIDReadonly = true;

            // Title
            sng.Title = source.Title;

            // Copyright
            sng.Copyright = source.Copyright;

            // Administration / Rights management
            sng.RightsManagement = source.Admin;

            // Author
            sng.Author = new List<SongAuthor>();
            var a = new SongAuthor();
            a.Name = source.Author;
            sng.Author.Add(a);

            // Themes
            sng.Themes.AddRange(source.Themes);

            // Key
            sng.Key = source.Key;

            // Verses
            foreach (var v in source.Verses) {
                SongPart p = new SongPart();
                p.Caption = v.Caption;
                SongSlide s = new SongSlide(sng);
                s.Lines.AddRange(v.Lines);
                p.Slides.Add(s);
                sng.Parts.Add(p);
            }

            sng.UpdateSearchText();

            return sng;
        }

        public void map(Song source, SongSelectFile target)
        {

        }
    }
}
