using PraiseBase.Presenter.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PowerPraise.Extended
{
    
    
    /// <summary>
    ///This is a test class for PowerPraiseSongFileReaderTest and is intended
    ///to contain all PowerPraiseSongFileReaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExtendedPowerPraiseSongFilePluginTest
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
            ISongFilePlugin target = new ExtendedPowerPraiseSongFilePlugin();
            string filename = "Resources/powerpraise/Näher, mein Gott zu Dir.ppl";

            Song expected = PowerPraiseTestUtil.GetExpectedSong();
            Song actual = target.Load(filename);

            Assert.AreEqual(expected.GUID, actual.GUID, "Wrong GUID");
            Assert.AreEqual(expected.ModifiedTimestamp, actual.ModifiedTimestamp, "Wrong modified timestamp");
            Assert.AreEqual(expected.CreatedIn, actual.CreatedIn, "Wrong created in");
            Assert.AreEqual(expected.ModifiedIn, actual.ModifiedIn, "Wrong modified in");
            Assert.AreEqual(expected.Title, actual.Title, "Wrong song title");
            Assert.AreEqual(expected.Language, actual.Language, "Wrong language");
            Assert.AreEqual(expected.CcliID, actual.CcliID, "Wrong CcliID");
            Assert.AreEqual(expected.Copyright, actual.Copyright, "Wrong copyright");
            Assert.AreEqual(expected.CopyrightPosition, actual.CopyrightPosition, "Wrong copyright position");
            Assert.AreEqual(expected.SourcePosition, actual.SourcePosition, "Wrong source position");
            Assert.AreEqual(expected.ReleaseYear, actual.ReleaseYear, "Wrong release year");
            CollectionAssert.AreEqual(expected.Author, actual.Author, "Wrong author");
            Assert.AreEqual(expected.RightsManagement, actual.RightsManagement, "Wrong rights Management");
            Assert.AreEqual(expected.Publisher, actual.Publisher, "Wrong publisher");
            Assert.AreEqual(expected.Version, actual.Version, "Wrong version");
            Assert.AreEqual(expected.Key, actual.Key, "Wrong key");
            Assert.AreEqual(expected.Transposition, actual.Transposition, "Wrong transposition");
            Assert.AreEqual(expected.Tempo, actual.Tempo, "Wrong tempo");
            Assert.AreEqual(expected.Variant, actual.Variant, "Wrong variant");
            Assert.AreEqual(expected.Themes[0], actual.Themes[0], "Wrong theme");
            Assert.AreEqual(expected.Comment, actual.Comment, "Wrong comment");
            Assert.AreEqual(expected.SongBooks[0].Name, actual.SongBooks[0].Name, "Wrong songbook");

            Assert.AreEqual(expected.Parts.Count, actual.Parts.Count, "Parts incomplete");
            for (int i = 0; i < expected.Parts.Count; i++)
            {
                Assert.AreEqual(expected.Parts[i].Caption, actual.Parts[i].Caption, "Wrong verse name in verse " + i);
                Assert.AreEqual(expected.Parts[i].Slides.Count, actual.Parts[i].Slides.Count, "Slides incomplete in verse " + i);
                for (int j = 0; j < expected.Parts[i].Slides.Count; j++)
                {
                    Assert.AreEqual(expected.Parts[i].Slides[j].Background, actual.Parts[i].Slides[j].Background, "Wrong image paths");
                    CollectionAssert.AreEqual(expected.Parts[i].Slides[j].Lines, actual.Parts[i].Slides[j].Lines, "Slide lines incomplete in verse " + i + " slide " + j);
                    CollectionAssert.AreEqual(expected.Parts[i].Slides[j].Translation, actual.Parts[i].Slides[j].Translation, "Slide translation lines incomplete in verse " + i + " slide " + j);
                }
            }
            CollectionAssert.AreEqual(expected.PartSequence, actual.PartSequence, "Wrong part sequence");

            CollectionAssert.AreEqual(expected.QualityIssues, actual.QualityIssues, "Wrong QA issues");

            Assert.AreEqual(expected.MainText.Font, actual.MainText.Font);
            Assert.AreEqual(expected.MainText.Color.ToArgb(), actual.MainText.Color.ToArgb());
            Assert.AreEqual(expected.MainText.Outline.Color.ToArgb(), actual.MainText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.MainText.Outline.Width, actual.MainText.Outline.Width);
            Assert.AreEqual(expected.MainText.Shadow.Color.ToArgb(), actual.MainText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.MainText.Shadow.Direction, actual.MainText.Shadow.Direction);
            Assert.AreEqual(expected.MainText.Shadow.Distance, actual.MainText.Shadow.Distance);
            Assert.AreEqual(expected.MainText.LineSpacing, actual.MainText.LineSpacing);

            Assert.AreEqual(expected.TranslationText.Font, actual.TranslationText.Font);
            Assert.AreEqual(expected.TranslationText.Color.ToArgb(), actual.TranslationText.Color.ToArgb());
            Assert.AreEqual(expected.TranslationText.Outline.Color.ToArgb(), actual.TranslationText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.TranslationText.Outline.Width, actual.TranslationText.Outline.Width);
            Assert.AreEqual(expected.TranslationText.Shadow.Color.ToArgb(), actual.TranslationText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.TranslationText.Shadow.Direction, actual.TranslationText.Shadow.Direction);
            Assert.AreEqual(expected.TranslationText.Shadow.Distance, actual.TranslationText.Shadow.Distance);
            Assert.AreEqual(expected.TranslationText.LineSpacing, actual.TranslationText.LineSpacing);

            Assert.AreEqual(expected.CopyrightText.Font, actual.CopyrightText.Font);
            Assert.AreEqual(expected.CopyrightText.Color.ToArgb(), actual.CopyrightText.Color.ToArgb());
            Assert.AreEqual(expected.CopyrightText.Outline.Color.ToArgb(), actual.CopyrightText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.CopyrightText.Outline.Width, actual.CopyrightText.Outline.Width);
            Assert.AreEqual(expected.CopyrightText.Shadow.Color.ToArgb(), actual.CopyrightText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.CopyrightText.Shadow.Direction, actual.CopyrightText.Shadow.Direction);
            Assert.AreEqual(expected.CopyrightText.Shadow.Distance, actual.CopyrightText.Shadow.Distance);
            Assert.AreEqual(expected.CopyrightText.LineSpacing, actual.CopyrightText.LineSpacing);

            Assert.AreEqual(expected.SourceText.Font, actual.SourceText.Font);
            Assert.AreEqual(expected.SourceText.Color.ToArgb(), actual.SourceText.Color.ToArgb());
            Assert.AreEqual(expected.SourceText.Outline.Color.ToArgb(), actual.SourceText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.SourceText.Outline.Width, actual.SourceText.Outline.Width);
            Assert.AreEqual(expected.SourceText.Shadow.Color.ToArgb(), actual.SourceText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.SourceText.Shadow.Direction, actual.SourceText.Shadow.Direction);
            Assert.AreEqual(expected.SourceText.Shadow.Distance, actual.SourceText.Shadow.Distance);
            Assert.AreEqual(expected.SourceText.LineSpacing, actual.SourceText.LineSpacing);

            Assert.AreEqual(expected.TextOrientation, actual.TextOrientation);
            Assert.AreEqual(expected.TextOutlineEnabled, actual.TextOutlineEnabled);
            Assert.AreEqual(expected.TextShadowEnabled, actual.TextShadowEnabled);

            Assert.AreEqual(expected.TextBorders.TextLeft, actual.TextBorders.TextLeft);
            Assert.AreEqual(expected.TextBorders.TextTop, actual.TextBorders.TextTop);
            Assert.AreEqual(expected.TextBorders.TextRight, actual.TextBorders.TextRight);
            Assert.AreEqual(expected.TextBorders.TextBottom, actual.TextBorders.TextBottom);
            Assert.AreEqual(expected.TextBorders.CopyrightBottom, actual.TextBorders.CopyrightBottom);
            Assert.AreEqual(expected.TextBorders.SourceRight, actual.TextBorders.SourceRight);
            Assert.AreEqual(expected.TextBorders.SourceTop, actual.TextBorders.SourceTop);

            Assert.IsTrue(actual.GetSearchableText().Contains("näher mein gott zu dir"));
            Assert.IsTrue(actual.GetSearchableText().Contains("geborgen"));
        }

        /// <summary>
        ///A test for ReadTitle
        ///</summary>
        [TestMethod()]
        public void ReadTitleTest()
        {
            ISongFilePlugin reader = new ExtendedPowerPraiseSongFilePlugin();
            Assert.AreEqual("Näher, mein Gott, zu Dir", reader.ReadTitle("Resources/powerpraise/Näher, mein Gott zu Dir.ppl"));
            Assert.IsNull(reader.ReadTitle("Resources/powerpraise/non-existing-file.ppl"));
        }

        [TestMethod()]
        public void ReadUsingLoadMapperTest()
        {
            ISongFileReader<PowerPraiseSong> reader = new PowerPraiseSongFileReader();
            ISongFileMapper<PowerPraiseSong> mapper = new PowerPraiseSongFileMapper();
            string filename = "Resources/powerpraise/Näher, mein Gott zu Dir.ppl";
            Song actual = mapper.map(reader.Load(filename));
            Song expected = PowerPraiseTestUtil.GetExpectedSong();

            Assert.AreEqual(expected.GUID, actual.GUID, "Wrong GUID");
            Assert.AreEqual(expected.ModifiedTimestamp, actual.ModifiedTimestamp, "Wrong modified timestamp");
            Assert.AreEqual(expected.CreatedIn, actual.CreatedIn, "Wrong created in");
            Assert.AreEqual(expected.ModifiedIn, actual.ModifiedIn, "Wrong modified in");
            Assert.AreEqual(expected.Title, actual.Title, "Wrong song title");
            Assert.AreEqual(expected.Language, actual.Language, "Wrong language");
            Assert.AreEqual(expected.CcliID, actual.CcliID, "Wrong CcliID");
            Assert.AreEqual(expected.Copyright, actual.Copyright, "Wrong copyright");
            Assert.AreEqual(expected.CopyrightPosition, actual.CopyrightPosition, "Wrong copyright position");
            Assert.AreEqual(expected.SourcePosition, actual.SourcePosition, "Wrong source position");
            Assert.AreEqual(expected.ReleaseYear, actual.ReleaseYear, "Wrong release year");
            CollectionAssert.AreEqual(expected.Author, actual.Author, "Wrong author");
            Assert.AreEqual(expected.RightsManagement, actual.RightsManagement, "Wrong rights Management");
            Assert.AreEqual(expected.Publisher, actual.Publisher, "Wrong publisher");
            Assert.AreEqual(expected.Version, actual.Version, "Wrong version");
            Assert.AreEqual(expected.Key, actual.Key, "Wrong key");
            Assert.AreEqual(expected.Transposition, actual.Transposition, "Wrong transposition");
            Assert.AreEqual(expected.Tempo, actual.Tempo, "Wrong tempo");
            Assert.AreEqual(expected.Variant, actual.Variant, "Wrong variant");
            Assert.AreEqual(expected.Themes[0], actual.Themes[0], "Wrong theme");
            Assert.AreEqual(expected.Comment, actual.Comment, "Wrong comment");
            Assert.AreEqual(expected.SongBooks[0].Name, actual.SongBooks[0].Name, "Wrong songbook");

            Assert.AreEqual(expected.Parts.Count, actual.Parts.Count, "Parts incomplete");
            for (int i = 0; i < expected.Parts.Count; i++)
            {
                Assert.AreEqual(expected.Parts[i].Caption, actual.Parts[i].Caption, "Wrong verse name in verse " + i);
                Assert.AreEqual(expected.Parts[i].Slides.Count, actual.Parts[i].Slides.Count, "Slides incomplete in verse " + i);
                for (int j = 0; j < expected.Parts[i].Slides.Count; j++)
                {
                    Assert.AreEqual(expected.Parts[i].Slides[j].Background, actual.Parts[i].Slides[j].Background, "Wrong image paths");
                    CollectionAssert.AreEqual(expected.Parts[i].Slides[j].Lines, actual.Parts[i].Slides[j].Lines, "Slide lines incomplete in verse " + i + " slide " + j);
                    CollectionAssert.AreEqual(expected.Parts[i].Slides[j].Translation, actual.Parts[i].Slides[j].Translation, "Slide translation lines incomplete in verse " + i + " slide " + j);
                }
            }
            CollectionAssert.AreEqual(expected.PartSequence, actual.PartSequence, "Wrong part sequence");

            CollectionAssert.AreEqual(expected.QualityIssues, actual.QualityIssues, "Wrong QA issues");

            Assert.AreEqual(expected.MainText.Font, actual.MainText.Font);
            Assert.AreEqual(expected.MainText.Color.ToArgb(), actual.MainText.Color.ToArgb());
            Assert.AreEqual(expected.MainText.Outline.Color.ToArgb(), actual.MainText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.MainText.Outline.Width, actual.MainText.Outline.Width);
            Assert.AreEqual(expected.MainText.Shadow.Color.ToArgb(), actual.MainText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.MainText.Shadow.Direction, actual.MainText.Shadow.Direction);
            Assert.AreEqual(expected.MainText.Shadow.Distance, actual.MainText.Shadow.Distance);
            Assert.AreEqual(expected.MainText.LineSpacing, actual.MainText.LineSpacing);

            Assert.AreEqual(expected.TranslationText.Font, actual.TranslationText.Font);
            Assert.AreEqual(expected.TranslationText.Color.ToArgb(), actual.TranslationText.Color.ToArgb());
            Assert.AreEqual(expected.TranslationText.Outline.Color.ToArgb(), actual.TranslationText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.TranslationText.Outline.Width, actual.TranslationText.Outline.Width);
            Assert.AreEqual(expected.TranslationText.Shadow.Color.ToArgb(), actual.TranslationText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.TranslationText.Shadow.Direction, actual.TranslationText.Shadow.Direction);
            Assert.AreEqual(expected.TranslationText.Shadow.Distance, actual.TranslationText.Shadow.Distance);
            Assert.AreEqual(expected.TranslationText.LineSpacing, actual.TranslationText.LineSpacing);

            Assert.AreEqual(expected.CopyrightText.Font, actual.CopyrightText.Font);
            Assert.AreEqual(expected.CopyrightText.Color.ToArgb(), actual.CopyrightText.Color.ToArgb());
            Assert.AreEqual(expected.CopyrightText.Outline.Color.ToArgb(), actual.CopyrightText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.CopyrightText.Outline.Width, actual.CopyrightText.Outline.Width);
            Assert.AreEqual(expected.CopyrightText.Shadow.Color.ToArgb(), actual.CopyrightText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.CopyrightText.Shadow.Direction, actual.CopyrightText.Shadow.Direction);
            Assert.AreEqual(expected.CopyrightText.Shadow.Distance, actual.CopyrightText.Shadow.Distance);
            Assert.AreEqual(expected.CopyrightText.LineSpacing, actual.CopyrightText.LineSpacing);

            Assert.AreEqual(expected.SourceText.Font, actual.SourceText.Font);
            Assert.AreEqual(expected.SourceText.Color.ToArgb(), actual.SourceText.Color.ToArgb());
            Assert.AreEqual(expected.SourceText.Outline.Color.ToArgb(), actual.SourceText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.SourceText.Outline.Width, actual.SourceText.Outline.Width);
            Assert.AreEqual(expected.SourceText.Shadow.Color.ToArgb(), actual.SourceText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.SourceText.Shadow.Direction, actual.SourceText.Shadow.Direction);
            Assert.AreEqual(expected.SourceText.Shadow.Distance, actual.SourceText.Shadow.Distance);
            Assert.AreEqual(expected.SourceText.LineSpacing, actual.SourceText.LineSpacing);

            Assert.AreEqual(expected.TextOrientation, actual.TextOrientation);
            Assert.AreEqual(expected.TextOutlineEnabled, actual.TextOutlineEnabled);
            Assert.AreEqual(expected.TextShadowEnabled, actual.TextShadowEnabled);

            Assert.AreEqual(expected.TextBorders.TextLeft, actual.TextBorders.TextLeft);
            Assert.AreEqual(expected.TextBorders.TextTop, actual.TextBorders.TextTop);
            Assert.AreEqual(expected.TextBorders.TextRight, actual.TextBorders.TextRight);
            Assert.AreEqual(expected.TextBorders.TextBottom, actual.TextBorders.TextBottom);
            Assert.AreEqual(expected.TextBorders.CopyrightBottom, actual.TextBorders.CopyrightBottom);
            Assert.AreEqual(expected.TextBorders.SourceRight, actual.TextBorders.SourceRight);
            Assert.AreEqual(expected.TextBorders.SourceTop, actual.TextBorders.SourceTop);

            Assert.IsTrue(actual.GetSearchableText().Contains("näher mein gott zu dir"));
            Assert.IsTrue(actual.GetSearchableText().Contains("geborgen"));

        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            ISongFilePlugin target = new ExtendedPowerPraiseSongFilePlugin();
            string referenceFilename = "Resources/powerpraise/Näher, mein Gott zu Dir.ppl";
            string filename = "Resources/powerpraise/Näher, mein Gott zu Dir - neu - extended.ppl";

            Song sng = PowerPraiseTestUtil.GetExpectedSong();

            target.Save(sng, filename);

            try
            {
                PraiseBase.Presenter.Util.FileUtils.FileEquals(filename, referenceFilename, true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        ///A test for FileTypeDescription
        ///</summary>
        [TestMethod()]
        public void FileTypeDescriptionTest()
        {
            ISongFilePlugin target = new ExtendedPowerPraiseSongFilePlugin(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetFileTypeDescription();
            Assert.AreEqual(actual, "PowerPraise Lied (erweitert)");
        }

        /// <summary>
        ///A test for FileExtension
        ///</summary>
        [TestMethod()]
        public void FileExtensionTest()
        {
            ISongFilePlugin target = new ExtendedPowerPraiseSongFilePlugin(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetFileExtension();
            Assert.AreEqual(actual, ".ppl");
        }

        [TestMethod()]
        public void WriteUsingMapperSaveTest()
        {
            ISongFileMapper<PowerPraiseSong> mapper = new PowerPraiseSongFileMapper();
            ISongFileWriter<PowerPraiseSong> writer = new PowerPraiseSongFileWriter();
            string referenceFilename = "Resources/powerpraise/Näher, mein Gott zu Dir.ppl";
            string filename = "Resources/powerpraise/Näher, mein Gott zu Dir - neu - extended2.ppl";

            Song sng = PowerPraiseTestUtil.GetExpectedSong(); ;
            PowerPraiseSong ppl = new PowerPraiseSong();
            mapper.map(sng, ppl);
            writer.Save(filename, ppl);

            try
            {
                PraiseBase.Presenter.Util.FileUtils.FileEquals(filename, referenceFilename, true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

    }
}
