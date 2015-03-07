using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PraiseBox
{
    public class PraiseBoxDatabaseImporter : AbstractDatabaseImporter
    {
        protected override string getSelectQuery()
        {
            return "select * from SongText";
        }

        protected override Song readRecord(OleDbDataReader aReader)
        {
            Song sng = new Song();

            sng.Title = aReader.GetString(1);

            System.Windows.Forms.RichTextBox rtf = new System.Windows.Forms.RichTextBox();
            rtf.Rtf = aReader.GetString(2);
            string text = rtf.Text.ToString().Trim();
            text = text.Replace("\n", Environment.NewLine);
            string[] prts = text.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            Regex rex = new Regex(".+:");
            int p = 0;
            foreach (String pri in prts)
            {
                sng.Parts.Add(new SongPart());
                sng.Parts[p].Slides.Add(new SongSlide());
                Match mat = rex.Match(pri);
                sng.Parts[p].Caption = mat.Value.Substring(0, mat.Value.Length - 1);
                sng.Parts[p].Slides[0].Text = pri.Substring(mat.Value.Length + 1);
                p++;
            }

            return sng;
        }
    }
}
