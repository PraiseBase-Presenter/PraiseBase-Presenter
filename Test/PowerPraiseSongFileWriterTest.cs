using Pbp.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pbp.Data.Song;

namespace Test
{
    
    
    /// <summary>
    ///This is a test class for PowerPraiseSongFileWriterTest and is intended
    ///to contain all PowerPraiseSongFileWriterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PowerPraiseSongFileWriterTest
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
        ///A test for Save
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            PowerPraiseSongFileWriter target = new PowerPraiseSongFileWriter();
            string referenceFilename = "powerpraise/Näher, mein Gott zu Dir.ppl";
            string filename = "powerpraise/Näher, mein Gott zu Dir - neu.ppl";

            Song sng = new Song();
            sng.Title = "Näher, mein Gott, zu Dir";
            sng.Language = "Deutsch";
            sng.Themes.Add("Anbetung");
            sng.Copyright = "Text und Musik: Lowell Mason, 1792-1872";
            var sb = new SongBook();
            sb.Name = "grünes Buch 339";
            sng.SongBooks.Add(sb);

            var part = new SongPart();
            part.Caption = "Teil 1";
            var slide = new SongSlide(sng);
            slide.Lines.Add("Näher, mein Gott, zu Dir,");
            slide.Lines.Add("sei meine Bitt'!");
            slide.Lines.Add("Näher, o Herr, zu Dir");
            slide.Lines.Add("mit jedem Schritt.");
            part.Slides.Add(slide);
            slide = new SongSlide(sng);
            slide.Lines.Add("Nur an dem Herzen Dein");
            slide.Lines.Add("kann ich geborgen sein;");
            slide.Lines.Add("deshalb die Bitte mein:");
            slide.Lines.Add("Näher zu Dir!");
            part.Slides.Add(slide);
            sng.Parts.Add(part);

            part = new SongPart();
            part.Caption = "Teil 2";
            slide = new SongSlide(sng);
            slide.Lines.Add("Näher, mein Gott, zu Dir!");
            slide.Lines.Add("Ein jeder Tag");
            slide.Lines.Add("soll es neu zeigen mir,");
            slide.Lines.Add("was er vermag:");
            part.Slides.Add(slide);
            slide = new SongSlide(sng);
            slide.Lines.Add("Wie seiner Gnade Macht,");
            slide.Lines.Add("Erlösung hat gebracht,");
            slide.Lines.Add("in uns're Sündennacht.");
            slide.Lines.Add("Näher zu Dir!");
            part.Slides.Add(slide);
            sng.Parts.Add(part);

            part = new SongPart();
            part.Caption = "Teil 3";
            slide = new SongSlide(sng);
            slide = new SongSlide(sng);
            slide.Lines.Add("Näher, mein Gott, zu Dir!");
            slide.Lines.Add("Dich bet' ich an.");
            slide.Lines.Add("Wie vieles hast an mir,");
            slide.Lines.Add("Du doch getan!");
            part.Slides.Add(slide);
            slide = new SongSlide(sng);
            slide.Lines.Add("Von Banden frei und los,");
            slide.Lines.Add("ruh' ich in Deinem Schoss.");
            slide.Lines.Add("Ja, Deine Gnad' ist gross!");
            slide.Lines.Add("Näher zu Dir!");
            part.Slides.Add(slide);
            sng.Parts.Add(part);

            target.Save(filename, sng);

            try {
                Pbp.Utils.FileUtils.FileEquals(filename, referenceFilename, true);
            }
            catch (Exception e)
            {
                Assert.Fail("Written file is not the same as the original! " + e.Message);
            }
        }

        /// <summary>
        ///A test for FileTypeDescription
        ///</summary>
        [TestMethod()]
        public void FileTypeDescriptionTest()
        {
            PowerPraiseSongFileWriter target = new PowerPraiseSongFileWriter(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.FileTypeDescription;
            Assert.AreEqual(actual, "PowerPraise Lied");
        }

        /// <summary>
        ///A test for FileExtension
        ///</summary>
        [TestMethod()]
        public void FileExtensionTest()
        {
            PowerPraiseSongFileWriter target = new PowerPraiseSongFileWriter(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.FileExtension;
            Assert.AreEqual(actual, ".ppl");
        }
    }
}
