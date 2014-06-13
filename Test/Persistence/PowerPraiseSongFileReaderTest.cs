using Pbp.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pbp.Model.Song;
using Pbp.Persistence.Reader;

namespace Test
{
    
    
    /// <summary>
    ///This is a test class for PowerPraiseSongFileReaderTest and is intended
    ///to contain all PowerPraiseSongFileReaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PowerPraiseSongFileReaderTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod()]
        public void LoadTest()
        {
            SongFileReader target = new PowerPraiseSongFileReader();
            string filename = "powerpraise/Näher, mein Gott zu Dir.ppl";

            Song expected = new Song();
            expected.Title = "Näher, mein Gott, zu Dir";
            expected.Language = "Deutsch";
            expected.Themes.Add("Anbetung");
            expected.Copyright = "Text und Musik: Lowell Mason, 1792-1872";
            var sb = new SongBook();
            sb.Name = "grünes Buch 339";
            expected.SongBooks.Add(sb);

            var part = new SongPart();
            part.Caption = "Teil 1";
            var slide = new SongSlide(expected);
            slide.Lines.Add("Näher, mein Gott, zu Dir,");
            slide.Lines.Add("sei meine Bitt'!");
            slide.Lines.Add("Näher, o Herr, zu Dir");
            slide.Lines.Add("mit jedem Schritt.");
            part.Slides.Add(slide);
            slide = new SongSlide(expected);
            slide.Lines.Add("Nur an dem Herzen Dein");
            slide.Lines.Add("kann ich geborgen sein;");
            slide.Lines.Add("deshalb die Bitte mein:");
            slide.Lines.Add("Näher zu Dir!");
            part.Slides.Add(slide);
            expected.Parts.Add(part);

            part = new SongPart();
            part.Caption = "Teil 2";
            slide = new SongSlide(expected);
            slide.Lines.Add("Näher, mein Gott, zu Dir!");
            slide.Lines.Add("Ein jeder Tag");
            slide.Lines.Add("soll es neu zeigen mir,");
            slide.Lines.Add("was er vermag:");
            part.Slides.Add(slide);
            slide = new SongSlide(expected);
            slide.Lines.Add("Wie seiner Gnade Macht,");
            slide.Lines.Add("Erlösung hat gebracht,");
            slide.Lines.Add("in uns're Sündennacht.");
            slide.Lines.Add("Näher zu Dir!");
            part.Slides.Add(slide);
            expected.Parts.Add(part);

            part = new SongPart();
            part.Caption = "Teil 3";
            slide = new SongSlide(expected);
            slide = new SongSlide(expected);
            slide.Lines.Add("Näher, mein Gott, zu Dir!");
            slide.Lines.Add("Dich bet' ich an.");
            slide.Lines.Add("Wie vieles hast an mir,");
            slide.Lines.Add("Du doch getan!");
            part.Slides.Add(slide);
            slide = new SongSlide(expected);
            slide.Lines.Add("Von Banden frei und los,");
            slide.Lines.Add("ruh' ich in Deinem Schoss.");
            slide.Lines.Add("Ja, Deine Gnad' ist gross!");
            slide.Lines.Add("Näher zu Dir!");
            part.Slides.Add(slide);
            expected.Parts.Add(part);

            Song actual = target.Load(filename);
            Assert.AreEqual(expected.Title, actual.Title, "Wrong song title");
            Assert.AreEqual(expected.GUID, actual.GUID, "Wrong GUID");
            Assert.AreEqual(expected.Language, actual.Language, "Wrong language");
            Assert.AreEqual(expected.Themes[0], actual.Themes[0], "Wrong theme");
            Assert.AreEqual(expected.Copyright, actual.Copyright, "Wrong copyright");
            Assert.AreEqual(expected.SongBooks[0].Name, actual.SongBooks[0].Name, "Wrong songbook");

            Assert.AreEqual(expected.Parts.Count, actual.Parts.Count, "Parts incomplete");
            for (int i = 0; i < expected.Parts.Count; i++)
            {
                Assert.AreEqual(expected.Parts[i].Caption, actual.Parts[i].Caption, "Wrong verse name in verse "+i);
                Assert.AreEqual(expected.Parts[i].Slides.Count, actual.Parts[i].Slides.Count, "Slides incomplete in verse " + i);
                for (int j = 0; j < expected.Parts[i].Slides.Count; j++)
                {
                    Assert.AreEqual(expected.Parts[i].Slides[j].Lines.Count, actual.Parts[i].Slides[j].Lines.Count, "Slide lines incomplete in verse "+i+" slide "+j);
                    for (int k = 0; k < expected.Parts[i].Slides[j].Lines.Count; k++)
                    {
                        Assert.AreEqual(expected.Parts[i].Slides[j].Lines[k], actual.Parts[i].Slides[j].Lines[k], "Wrong slide lyrics");
                    }
                }
            }

            Assert.AreEqual(1, actual.RelativeImagePaths.Count);
            Assert.AreEqual("Blumen\\Blume 3.jpg", actual.RelativeImagePaths[0]);

            Assert.IsTrue(actual.SearchText.Contains("näher mein gott zu dir"));
            Assert.IsTrue(actual.SearchText.Contains("geborgen"));
        }

        /// <summary>
        ///A test for ReadTitle
        ///</summary>
        [TestMethod()]
        public void ReadTitleTest()
        {
            SongFileReader reader = new PowerPraiseSongFileReader();
            Assert.AreEqual("Näher, mein Gott, zu Dir", reader.ReadTitle("powerpraise/Näher, mein Gott zu Dir.ppl"));
            Assert.IsNull(reader.ReadTitle("powerpraise/non-existing-file.ppl"));
        }

    }
}
