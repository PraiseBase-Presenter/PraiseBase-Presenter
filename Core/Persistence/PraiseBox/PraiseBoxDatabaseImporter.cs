using System;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PraiseBox
{
    public class PraiseBoxDatabaseImporter : AbstractDatabaseImporter
    {
        protected override string GetSelectQuery()
        {
            return "select * from SongText";
        }

        protected override Song ReadRecord(OleDbDataReader aReader)
        {
            var sng = new Song
            {
                Title = aReader.GetString(1)
            };

            var rtf = new RichTextBox
            {
                Rtf = aReader.GetString(2)
            };
            var text = rtf.Text.Trim();
            text = text.Replace("\n", Environment.NewLine);
            var prts = text.Split(new[] {Environment.NewLine + Environment.NewLine},
                StringSplitOptions.RemoveEmptyEntries);

            var rex = new Regex(".+:");
            var p = 0;
            foreach (var pri in prts)
            {
                sng.Parts.Add(new SongPart());
                sng.Parts[p].Slides.Add(new SongSlide());
                var mat = rex.Match(pri);
                sng.Parts[p].Caption = mat.Value.Substring(0, mat.Value.Length - 1);
                sng.Parts[p].Slides[0].Text = pri.Substring(mat.Value.Length + 1);
                p++;
            }

            return sng;
        }
    }
}