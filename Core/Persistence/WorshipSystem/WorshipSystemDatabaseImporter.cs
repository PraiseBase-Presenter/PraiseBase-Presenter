using System;
using System.Data.OleDb;
using System.Linq;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PraiseBox
{
    public class WorshipSystemDatabaseImporter : AbstractDatabaseImporter
    {
        protected override string getSelectQuery()
        {
            return "select * from Songs";
        }

        protected override Song readRecord(OleDbDataReader aReader)
        {
            Song sng = new Song();

            sng.Title = aReader.GetString(1);

            string text = aReader.GetString(4);
            text = text.Replace("\r\n", Environment.NewLine);
            string[] prts = text.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int p = 0;
            foreach (String pri in prts)
            {
                string transl = string.Empty;
                string txt = string.Empty;
                string[] priPrts = pri.Split(new string[] { "<S>" }, StringSplitOptions.RemoveEmptyEntries);
                if (priPrts.Count() < 2)
                    priPrts = pri.Split(new string[] { "<s>" }, StringSplitOptions.RemoveEmptyEntries);

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
                sng.Parts[p].Caption = "Teil " + (p + 1).ToString();
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
