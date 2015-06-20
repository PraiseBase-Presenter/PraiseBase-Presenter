using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Util;

namespace PraiseBase.Presenter.Persistence.PowerPraise.Extended
{
    
    
    /// <summary>
    ///This is a test class for PowerPraiseSongFileReaderTest and is intended
    ///to contain all PowerPraiseSongFileReaderTest Unit Tests
    ///</summary>
    [TestClass]
    public class ExtendedPowerPraiseSongFilePluginTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

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
        [TestMethod]
        public void LoadTest()
        {
            ISongFilePlugin target = new ExtendedPowerPraiseSongFilePlugin();
            const string filename = "Resources/powerpraise/Näher, mein Gott zu Dir.ppl";

            Song expected = PowerPraiseTestUtil.GetExpectedSong();
            Song actual = target.Load(filename);

            Assert.AreEqual(expected.Guid, actual.Guid, "Wrong GUID");
            Assert.AreEqual(expected.ModifiedTimestamp, actual.ModifiedTimestamp, "Wrong modified timestamp");
            Assert.AreEqual(expected.CreatedIn, actual.CreatedIn, "Wrong created in");
            Assert.AreEqual(expected.ModifiedIn, actual.ModifiedIn, "Wrong modified in");
            Assert.AreEqual(expected.Title, actual.Title, "Wrong song title");
            Assert.AreEqual(expected.Language, actual.Language, "Wrong language");
            Assert.AreEqual(expected.CcliIdentifier, actual.CcliIdentifier, "Wrong CcliID");
            Assert.AreEqual(expected.Copyright, actual.Copyright, "Wrong copyright");
            Assert.AreEqual(expected.Formatting.CopyrightPosition, actual.Formatting.CopyrightPosition, "Wrong copyright position");
            Assert.AreEqual(expected.Formatting.SourcePosition, actual.Formatting.SourcePosition, "Wrong source position");
            Assert.AreEqual(expected.ReleaseYear, actual.ReleaseYear, "Wrong release year");
            CollectionAssert.AreEqual(expected.Authors, actual.Authors, "Wrong author");
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

            Assert.AreEqual(expected.QualityIssues, actual.QualityIssues, "Wrong QA issues");

            Assert.AreEqual(expected.Formatting.MainText.Font, actual.Formatting.MainText.Font);
            Assert.AreEqual(expected.Formatting.MainText.Color.ToArgb(), actual.Formatting.MainText.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.MainText.Outline.Color.ToArgb(), actual.Formatting.MainText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.MainText.Outline.Width, actual.Formatting.MainText.Outline.Width);
            Assert.AreEqual(expected.Formatting.MainText.Shadow.Color.ToArgb(), actual.Formatting.MainText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.MainText.Shadow.Direction, actual.Formatting.MainText.Shadow.Direction);
            Assert.AreEqual(expected.Formatting.MainText.Shadow.Distance, actual.Formatting.MainText.Shadow.Distance);
            Assert.AreEqual(expected.Formatting.MainText.LineSpacing, actual.Formatting.MainText.LineSpacing);

            Assert.AreEqual(expected.Formatting.TranslationText.Font, actual.Formatting.TranslationText.Font);
            Assert.AreEqual(expected.Formatting.TranslationText.Color.ToArgb(), actual.Formatting.TranslationText.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.TranslationText.Outline.Color.ToArgb(), actual.Formatting.TranslationText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.TranslationText.Outline.Width, actual.Formatting.TranslationText.Outline.Width);
            Assert.AreEqual(expected.Formatting.TranslationText.Shadow.Color.ToArgb(), actual.Formatting.TranslationText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.TranslationText.Shadow.Direction, actual.Formatting.TranslationText.Shadow.Direction);
            Assert.AreEqual(expected.Formatting.TranslationText.Shadow.Distance, actual.Formatting.TranslationText.Shadow.Distance);
            Assert.AreEqual(expected.Formatting.TranslationText.LineSpacing, actual.Formatting.TranslationText.LineSpacing);

            Assert.AreEqual(expected.Formatting.CopyrightText.Font, actual.Formatting.CopyrightText.Font);
            Assert.AreEqual(expected.Formatting.CopyrightText.Color.ToArgb(), actual.Formatting.CopyrightText.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.CopyrightText.Outline.Color.ToArgb(), actual.Formatting.CopyrightText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.CopyrightText.Outline.Width, actual.Formatting.CopyrightText.Outline.Width);
            Assert.AreEqual(expected.Formatting.CopyrightText.Shadow.Color.ToArgb(), actual.Formatting.CopyrightText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.CopyrightText.Shadow.Direction, actual.Formatting.CopyrightText.Shadow.Direction);
            Assert.AreEqual(expected.Formatting.CopyrightText.Shadow.Distance, actual.Formatting.CopyrightText.Shadow.Distance);
            Assert.AreEqual(expected.Formatting.CopyrightText.LineSpacing, actual.Formatting.CopyrightText.LineSpacing);

            Assert.AreEqual(expected.Formatting.SourceText.Font, actual.Formatting.SourceText.Font);
            Assert.AreEqual(expected.Formatting.SourceText.Color.ToArgb(), actual.Formatting.SourceText.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.SourceText.Outline.Color.ToArgb(), actual.Formatting.SourceText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.SourceText.Outline.Width, actual.Formatting.SourceText.Outline.Width);
            Assert.AreEqual(expected.Formatting.SourceText.Shadow.Color.ToArgb(), actual.Formatting.SourceText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.SourceText.Shadow.Direction, actual.Formatting.SourceText.Shadow.Direction);
            Assert.AreEqual(expected.Formatting.SourceText.Shadow.Distance, actual.Formatting.SourceText.Shadow.Distance);
            Assert.AreEqual(expected.Formatting.SourceText.LineSpacing, actual.Formatting.SourceText.LineSpacing);

            Assert.AreEqual(expected.Formatting.TextOrientation, actual.Formatting.TextOrientation);
            Assert.AreEqual(expected.Formatting.TextOutlineEnabled, actual.Formatting.TextOutlineEnabled);
            Assert.AreEqual(expected.Formatting.TextShadowEnabled, actual.Formatting.TextShadowEnabled);

            Assert.AreEqual(expected.Formatting.TextBorders.TextLeft, actual.Formatting.TextBorders.TextLeft);
            Assert.AreEqual(expected.Formatting.TextBorders.TextTop, actual.Formatting.TextBorders.TextTop);
            Assert.AreEqual(expected.Formatting.TextBorders.TextRight, actual.Formatting.TextBorders.TextRight);
            Assert.AreEqual(expected.Formatting.TextBorders.TextBottom, actual.Formatting.TextBorders.TextBottom);
            Assert.AreEqual(expected.Formatting.TextBorders.CopyrightBottom, actual.Formatting.TextBorders.CopyrightBottom);
            Assert.AreEqual(expected.Formatting.TextBorders.SourceRight, actual.Formatting.TextBorders.SourceRight);
            Assert.AreEqual(expected.Formatting.TextBorders.SourceTop, actual.Formatting.TextBorders.SourceTop);

            Assert.IsTrue(SongSearchUtil.GetSearchableSongText(actual).Contains("näher mein gott zu dir"));
            Assert.IsTrue(SongSearchUtil.GetSearchableSongText(actual).Contains("geborgen"));
        }

        /// <summary>
        ///A test for ReadTitle
        ///</summary>
        [TestMethod]
        public void ReadTitleTest()
        {
            ISongFilePlugin reader = new ExtendedPowerPraiseSongFilePlugin();
            Assert.AreEqual("Näher, mein Gott, zu Dir", reader.ReadTitle("Resources/powerpraise/Näher, mein Gott zu Dir.ppl"));
            Assert.IsNull(reader.ReadTitle("Resources/powerpraise/non-existing-file.ppl"));
        }

        [TestMethod]
        public void ReadUsingLoadMapperTest()
        {
            ISongFileReader<PowerPraiseSong> reader = new PowerPraiseSongFileReader();
            ISongFileMapper<PowerPraiseSong> mapper = new PowerPraiseSongFileMapper();
            const string filename = "Resources/powerpraise/Näher, mein Gott zu Dir.ppl";
            Song actual = mapper.Map(reader.Load(filename));
            Song expected = PowerPraiseTestUtil.GetExpectedSong();

            Assert.AreEqual(expected.Guid, actual.Guid, "Wrong GUID");
            Assert.AreEqual(expected.ModifiedTimestamp, actual.ModifiedTimestamp, "Wrong modified timestamp");
            Assert.AreEqual(expected.CreatedIn, actual.CreatedIn, "Wrong created in");
            Assert.AreEqual(expected.ModifiedIn, actual.ModifiedIn, "Wrong modified in");
            Assert.AreEqual(expected.Title, actual.Title, "Wrong song title");
            Assert.AreEqual(expected.Language, actual.Language, "Wrong language");
            Assert.AreEqual(expected.CcliIdentifier, actual.CcliIdentifier, "Wrong CcliID");
            Assert.AreEqual(expected.Copyright, actual.Copyright, "Wrong copyright");
            Assert.AreEqual(expected.Formatting.CopyrightPosition, actual.Formatting.CopyrightPosition, "Wrong copyright position");
            Assert.AreEqual(expected.Formatting.SourcePosition, actual.Formatting.SourcePosition, "Wrong source position");
            Assert.AreEqual(expected.ReleaseYear, actual.ReleaseYear, "Wrong release year");
            CollectionAssert.AreEqual(expected.Authors, actual.Authors, "Wrong author");
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

            Assert.AreEqual(expected.QualityIssues, actual.QualityIssues, "Wrong QA issues");

            Assert.AreEqual(expected.Formatting.MainText.Font, actual.Formatting.MainText.Font);
            Assert.AreEqual(expected.Formatting.MainText.Color.ToArgb(), actual.Formatting.MainText.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.MainText.Outline.Color.ToArgb(), actual.Formatting.MainText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.MainText.Outline.Width, actual.Formatting.MainText.Outline.Width);
            Assert.AreEqual(expected.Formatting.MainText.Shadow.Color.ToArgb(), actual.Formatting.MainText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.MainText.Shadow.Direction, actual.Formatting.MainText.Shadow.Direction);
            Assert.AreEqual(expected.Formatting.MainText.Shadow.Distance, actual.Formatting.MainText.Shadow.Distance);
            Assert.AreEqual(expected.Formatting.MainText.LineSpacing, actual.Formatting.MainText.LineSpacing);

            Assert.AreEqual(expected.Formatting.TranslationText.Font, actual.Formatting.TranslationText.Font);
            Assert.AreEqual(expected.Formatting.TranslationText.Color.ToArgb(), actual.Formatting.TranslationText.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.TranslationText.Outline.Color.ToArgb(), actual.Formatting.TranslationText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.TranslationText.Outline.Width, actual.Formatting.TranslationText.Outline.Width);
            Assert.AreEqual(expected.Formatting.TranslationText.Shadow.Color.ToArgb(), actual.Formatting.TranslationText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.TranslationText.Shadow.Direction, actual.Formatting.TranslationText.Shadow.Direction);
            Assert.AreEqual(expected.Formatting.TranslationText.Shadow.Distance, actual.Formatting.TranslationText.Shadow.Distance);
            Assert.AreEqual(expected.Formatting.TranslationText.LineSpacing, actual.Formatting.TranslationText.LineSpacing);

            Assert.AreEqual(expected.Formatting.CopyrightText.Font, actual.Formatting.CopyrightText.Font);
            Assert.AreEqual(expected.Formatting.CopyrightText.Color.ToArgb(), actual.Formatting.CopyrightText.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.CopyrightText.Outline.Color.ToArgb(), actual.Formatting.CopyrightText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.CopyrightText.Outline.Width, actual.Formatting.CopyrightText.Outline.Width);
            Assert.AreEqual(expected.Formatting.CopyrightText.Shadow.Color.ToArgb(), actual.Formatting.CopyrightText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.CopyrightText.Shadow.Direction, actual.Formatting.CopyrightText.Shadow.Direction);
            Assert.AreEqual(expected.Formatting.CopyrightText.Shadow.Distance, actual.Formatting.CopyrightText.Shadow.Distance);
            Assert.AreEqual(expected.Formatting.CopyrightText.LineSpacing, actual.Formatting.CopyrightText.LineSpacing);

            Assert.AreEqual(expected.Formatting.SourceText.Font, actual.Formatting.SourceText.Font);
            Assert.AreEqual(expected.Formatting.SourceText.Color.ToArgb(), actual.Formatting.SourceText.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.SourceText.Outline.Color.ToArgb(), actual.Formatting.SourceText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.SourceText.Outline.Width, actual.Formatting.SourceText.Outline.Width);
            Assert.AreEqual(expected.Formatting.SourceText.Shadow.Color.ToArgb(), actual.Formatting.SourceText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.SourceText.Shadow.Direction, actual.Formatting.SourceText.Shadow.Direction);
            Assert.AreEqual(expected.Formatting.SourceText.Shadow.Distance, actual.Formatting.SourceText.Shadow.Distance);
            Assert.AreEqual(expected.Formatting.SourceText.LineSpacing, actual.Formatting.SourceText.LineSpacing);

            Assert.AreEqual(expected.Formatting.TextOrientation, actual.Formatting.TextOrientation);
            Assert.AreEqual(expected.Formatting.TextOutlineEnabled, actual.Formatting.TextOutlineEnabled);
            Assert.AreEqual(expected.Formatting.TextShadowEnabled, actual.Formatting.TextShadowEnabled);

            Assert.AreEqual(expected.Formatting.TextBorders.TextLeft, actual.Formatting.TextBorders.TextLeft);
            Assert.AreEqual(expected.Formatting.TextBorders.TextTop, actual.Formatting.TextBorders.TextTop);
            Assert.AreEqual(expected.Formatting.TextBorders.TextRight, actual.Formatting.TextBorders.TextRight);
            Assert.AreEqual(expected.Formatting.TextBorders.TextBottom, actual.Formatting.TextBorders.TextBottom);
            Assert.AreEqual(expected.Formatting.TextBorders.CopyrightBottom, actual.Formatting.TextBorders.CopyrightBottom);
            Assert.AreEqual(expected.Formatting.TextBorders.SourceRight, actual.Formatting.TextBorders.SourceRight);
            Assert.AreEqual(expected.Formatting.TextBorders.SourceTop, actual.Formatting.TextBorders.SourceTop);

            Assert.IsTrue(SongSearchUtil.GetSearchableSongText(actual).Contains("näher mein gott zu dir"));
            Assert.IsTrue(SongSearchUtil.GetSearchableSongText(actual).Contains("geborgen"));

        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod]
        public void SaveTest()
        {
            ISongFilePlugin target = new ExtendedPowerPraiseSongFilePlugin();
            const string referenceFilename = "Resources/powerpraise/Näher, mein Gott zu Dir.ppl";
            const string filename = "Resources/powerpraise/Näher, mein Gott zu Dir - neu - extended.ppl";

            Song sng = PowerPraiseTestUtil.GetExpectedSong();

            target.Save(sng, filename);

            try
            {
                FileUtils.FileEquals(filename, referenceFilename, true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        ///A test for FileTypeDescription
        ///</summary>
        [TestMethod]
        public void FileTypeDescriptionTest()
        {
            ISongFilePlugin target = new ExtendedPowerPraiseSongFilePlugin(); // TODO: Initialize to an appropriate value
            var actual = target.GetFileTypeDescription();
            Assert.AreEqual(actual, "PowerPraise Lied (erweitert)");
        }

        /// <summary>
        ///A test for FileExtension
        ///</summary>
        [TestMethod]
        public void FileExtensionTest()
        {
            ISongFilePlugin target = new ExtendedPowerPraiseSongFilePlugin(); // TODO: Initialize to an appropriate value
            var actual = target.GetFileExtension();
            Assert.AreEqual(actual, ".ppl");
        }

        [TestMethod]
        public void WriteUsingMapperSaveTest()
        {
            ISongFileMapper<PowerPraiseSong> mapper = new PowerPraiseSongFileMapper();
            ISongFileWriter<PowerPraiseSong> writer = new PowerPraiseSongFileWriter();
            const string referenceFilename = "Resources/powerpraise/Näher, mein Gott zu Dir.ppl";
            const string filename = "Resources/powerpraise/Näher, mein Gott zu Dir - neu - extended2.ppl";

            Song sng = PowerPraiseTestUtil.GetExpectedSong();
            PowerPraiseSong ppl = new PowerPraiseSong();
            mapper.Map(sng, ppl);
            writer.Save(filename, ppl);

            try
            {
                FileUtils.FileEquals(filename, referenceFilename, true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

    }
}
