using System;
using System.Data.OleDb;
using System.Linq;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.WorshipSystem
{
    public class WorshipSystemDatabaseImporter : AbstractDatabaseImporter
    {
        protected override string getSelectQuery()
        {
            return "select * from Songs";
        }

        protected override Song readRecord(OleDbDataReader aReader)
        {
            var sng = new Song();

            sng.Title = aReader.GetString(1);

            var text = aReader.GetString(4);
            text = text.Replace("\r\n", Environment.NewLine);
            var prts = text.Split(new[] {Environment.NewLine + Environment.NewLine},
                StringSplitOptions.RemoveEmptyEntries);

            var p = 0;
            foreach (var pri in prts)
            {
                var transl = string.Empty;
                var txt = string.Empty;
                var priPrts = pri.Split(new[] {"<S>"}, StringSplitOptions.RemoveEmptyEntries);
                if (priPrts.Count() < 2)
                    priPrts = pri.Split(new[] {"<s>"}, StringSplitOptions.RemoveEmptyEntries);

                if (priPrts.Count() == 1)
                {
                    txt = priPrts[0];
                }
                else if (priPrts.Count() == 2)
                {
                    txt = priPrts[0];
                    transl = priPrts[1];
                }
                else
                {
                    txt = pri;
                }

                sng.Parts.Add(new SongPart());
                sng.Parts[p].Slides.Add(new SongSlide());

                //Match mat = rex.Match(pri);
                sng.Parts[p].Caption = "Teil " + (p + 1);
                sng.Parts[p].Slides[0].Text = txt;
                if (transl != string.Empty)
                {
                    sng.Parts[p].Slides[0].Text = transl;
                }
                p++;
            }

            return sng;
        }
    }
}