using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PraiseBase.Presenter.Model.Song
{
    [TestClass]
    public class SongTest
    {
        [TestMethod]
        public void TestGetHashCode()
        {
            Song s1 = new Song();
            Song s2 = new Song();

            Assert.AreEqual(s1.GetHashCode(), s2.GetHashCode());

            s1.Title = "Song 1";
            s2.Title = "Song 1";

            Assert.AreEqual(s1.GetHashCode(), s2.GetHashCode());

            s1.Title = "Song 1";
            s2.Title = "Song 2";
            Assert.AreNotEqual(s1.GetHashCode(), s2.GetHashCode());

            s1.Title = "Song 1";
            s2.Title = "Song 1";
            Assert.AreEqual(s1.GetHashCode(), s2.GetHashCode());
        }

        [TestMethod]
        public void TestGetHashCode2()
        {
            Song s1 = new Song
            {
                Title = "Song 1"
            };

            var s2 = new Song
            {
                Title = "Song 1"
            };

            Assert.AreEqual(s1.GetHashCode(), s2.GetHashCode());

            SongPart p1 = new SongPart
            {
                Caption = "Verse 1"
            };
            s1.Parts.Add(p1);

            SongPart p2 = new SongPart
            {
                Caption = "Verse 1"
            };
            s2.Parts.Add(p2);

            Assert.AreEqual(s1.GetHashCode(), s2.GetHashCode());

            SongSlide sl1 = new SongSlide
            {
                Text = "abc def\nghi"
            };
            p1.Slides.Add(sl1);

            SongSlide sl2 = new SongSlide
            {
                Text = "abc def\nghi"
            };
            p2.Slides.Add(sl2);

            Assert.AreEqual(s1.GetHashCode(), s2.GetHashCode());

            SongSlide sl1b = new SongSlide
            {
                Text = "abc def\nghij"
            };
            p1.Slides.Add(sl1b);

            Assert.AreNotEqual(s1.GetHashCode(), s2.GetHashCode());

            p1.Slides.RemoveAt(0);
            Assert.AreNotEqual(s1.GetHashCode(), s2.GetHashCode());

            sl1b.Text = "abc def\nghi";

            Assert.AreEqual(s1.GetHashCode(), s2.GetHashCode());
        }
    }
}
