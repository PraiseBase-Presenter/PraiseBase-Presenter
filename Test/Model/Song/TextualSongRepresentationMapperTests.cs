using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PraiseBase.Presenter.Model.Song
{
    [TestClass()]
    public class TextualSongRepresentationMapperTests
    {
        [TestMethod()]
        public void MapTest()
        {
            string expected = GetString();
            var m = new TextualSongRepresentationMapper();
            string actual = m.Map(GetSong());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MapTest1()
        {
            Song expected = GetSong();
            string source = GetString();
            Song actual = new Song
            {
                Title = "Näher, mein Gott, zu Dir"
            };
            var m = new TextualSongRepresentationMapper();
            m.Map(source, actual);

            Assert.AreEqual(expected.Parts.Count, actual.Parts.Count);
            for (var i = 0; i < expected.Parts.Count; i++)
            {
                Assert.AreEqual(expected.Parts[i].Caption, actual.Parts[i].Caption);
                for (var j = 0; j < expected.Parts[i].Slides.Count; j++)
                {
                    Assert.AreEqual(expected.Parts[i].Slides[j].Lines.Count, actual.Parts[i].Slides[j].Lines.Count);
                    for (var k = 0; k < expected.Parts[i].Slides[j].Lines.Count; k++)
                    {
                        Assert.AreEqual(expected.Parts[i].Slides[j].Lines[k], actual.Parts[i].Slides[j].Lines[k]);
                    }
                }
            }
            Assert.AreEqual(expected.Parts, actual.Parts);
            Assert.AreEqual(expected.PartSequence, actual.PartSequence);

            Assert.AreEqual(expected.GetHashCode(), actual.GetHashCode());
            Assert.AreEqual(expected, actual);
        }

        private static Song GetSong()
        {
            var s = new Song
            {
                Title = "Näher, mein Gott, zu Dir"
            };

            var p = new SongPart
            {
                Caption = "Teil 1"
            };
            s.Parts.Add(p);
            s.PartSequence.Add(p);
            var sl = new SongSlide();
            sl.Lines.Add("Näher, mein Gott, zu Dir,");
            sl.Lines.Add("sei meine Bitt'!");
            sl.Lines.Add("Näher, o Herr, zu Dir");
            sl.Lines.Add("mit jedem Schritt.");
            p.Slides.Add(sl);
            sl = new SongSlide();
            sl.Lines.Add("Nur an dem Herzen Dein");
            sl.Lines.Add("kann ich geborgen sein;");
            sl.Lines.Add("deshalb die Bitte mein:");
            sl.Lines.Add("Näher zu Dir!");
            p.Slides.Add(sl);

            p = new SongPart
            {
                Caption = "Teil 2"
            };
            s.Parts.Add(p);
            s.PartSequence.Add(p);
            sl = new SongSlide();
            sl.Lines.Add("Näher, mein Gott, zu Dir!");
            sl.Lines.Add("Ein jeder Tag");
            sl.Lines.Add("soll es neu zeigen mir,");
            sl.Lines.Add("was er vermag:");
            p.Slides.Add(sl);
            sl = new SongSlide();
            sl.Lines.Add("Wie seiner Gnade Macht,");
            sl.Lines.Add("Erlösung hat gebracht,");
            sl.Lines.Add("in uns're Sündennacht.");
            sl.Lines.Add("Näher zu Dir!");
            p.Slides.Add(sl);

            p = new SongPart
            {
                Caption = "Teil 3"
            };
            s.Parts.Add(p);
            s.PartSequence.Add(p);
            sl = new SongSlide();
            sl.Lines.Add("Näher, mein Gott, zu Dir!");
            sl.Lines.Add("Dich bet' ich an.");
            sl.Lines.Add("Wie vieles hast an mir,");
            sl.Lines.Add("Du doch getan!");
            p.Slides.Add(sl);
            sl = new SongSlide();
            sl.Lines.Add("Von Banden frei und los,");
            sl.Lines.Add("ruh' ich in Deinem Schoss.");
            sl.Lines.Add("Ja, Deine Gnad' ist gross!");
            sl.Lines.Add("Näher zu Dir!");
            p.Slides.Add(sl);

            return s;
        }

        private static string GetString()
        {
            return "Teil 1: Näher, mein Gott, zu Dir," + Environment.NewLine +
                   "sei meine Bitt'!" + Environment.NewLine +
                   "Näher, o Herr, zu Dir" + Environment.NewLine +
                   "mit jedem Schritt." + Environment.NewLine +
                   "--" + Environment.NewLine +
                   "Nur an dem Herzen Dein" + Environment.NewLine +
                   "kann ich geborgen sein;" + Environment.NewLine +
                   "deshalb die Bitte mein:" + Environment.NewLine +
                   "Näher zu Dir!" + Environment.NewLine +
                   "--" + Environment.NewLine +
                   "Teil 2: Näher, mein Gott, zu Dir!" + Environment.NewLine +
                   "Ein jeder Tag" + Environment.NewLine +
                   "soll es neu zeigen mir," + Environment.NewLine +
                   "was er vermag:" + Environment.NewLine +
                   "--" + Environment.NewLine +
                   "Wie seiner Gnade Macht," + Environment.NewLine +
                   "Erlösung hat gebracht," + Environment.NewLine +
                   "in uns're Sündennacht." + Environment.NewLine +
                   "Näher zu Dir!" + Environment.NewLine +
                   "--" + Environment.NewLine +
                   "Teil 3: Näher, mein Gott, zu Dir!" + Environment.NewLine +
                   "Dich bet' ich an." + Environment.NewLine +
                   "Wie vieles hast an mir," + Environment.NewLine +
                   "Du doch getan!" + Environment.NewLine +
                   "--" + Environment.NewLine +
                   "Von Banden frei und los," + Environment.NewLine +
                   "ruh' ich in Deinem Schoss." + Environment.NewLine +
                   "Ja, Deine Gnad' ist gross!" + Environment.NewLine +
                   "Näher zu Dir!" + Environment.NewLine;
        }
    }
}
