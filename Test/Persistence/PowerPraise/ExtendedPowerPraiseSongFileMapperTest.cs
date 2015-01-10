using PraiseBase.Presenter.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PraiseBase.Presenter.Model.Song;
using System.Drawing;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    
    
    /// <summary>
    ///This is a test class for PowerPraiseSongFileReaderTest and is intended
    ///to contain all PowerPraiseSongFileReaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExtendedPowerPraiseSongFileMapperTest
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
        ///A test for Map
        ///</summary>
        [TestMethod()]
        public void MapTest()
        {
            ExtendedPowerPraiseSongFileMapper mapper = new ExtendedPowerPraiseSongFileMapper();

            ExtendedPowerPraiseSong source = PowerPraiseTestUtil.GetExpectedExtendedPowerPraiseSong();
            Song expected = PowerPraiseTestUtil.GetExpectedSongExtended();
            Song actual = mapper.map(source);

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
                    CollectionAssert.AreEqual(expected.Parts[i].Slides[j].Lines, actual.Parts[i].Slides[j].Lines, "Slide lines incomplete in verse " + i + " slide " + j);
                    CollectionAssert.AreEqual(expected.Parts[i].Slides[j].Translation, actual.Parts[i].Slides[j].Translation, "Slide translation lines incomplete in verse " + i + " slide " + j);
                }
            }
            CollectionAssert.AreEqual(expected.PartSequence, actual.PartSequence, "Wrong part sequence");

            CollectionAssert.AreEqual(expected.RelativeImagePaths, actual.RelativeImagePaths, "Wrong image paths");

            CollectionAssert.AreEqual(expected.QualityIssues, actual.QualityIssues, "Wrong QA issues");

            Assert.AreEqual(expected.MainText.Font, actual.MainText.Font);
            Assert.AreEqual(expected.MainText.Color, actual.MainText.Color);
            Assert.AreEqual(expected.MainText.Outline.Color, actual.MainText.Outline.Color);
            Assert.AreEqual(expected.MainText.Outline.Width, actual.MainText.Outline.Width);
            Assert.AreEqual(expected.MainText.Shadow.Color, actual.MainText.Shadow.Color);
            Assert.AreEqual(expected.MainText.Shadow.Direction, actual.MainText.Shadow.Direction);
            Assert.AreEqual(expected.MainText.Shadow.Distance, actual.MainText.Shadow.Distance);
            Assert.AreEqual(expected.MainText.Shadow.Size, actual.MainText.Shadow.Size);
            Assert.AreEqual(expected.MainText.LineSpacing, actual.MainText.LineSpacing);

            Assert.AreEqual(expected.TranslationText.Font, actual.TranslationText.Font);
            Assert.AreEqual(expected.TranslationText.Color, actual.TranslationText.Color);
            Assert.AreEqual(expected.TranslationText.Outline.Color, actual.TranslationText.Outline.Color);
            Assert.AreEqual(expected.TranslationText.Outline.Width, actual.TranslationText.Outline.Width);
            Assert.AreEqual(expected.TranslationText.Shadow.Color, actual.TranslationText.Shadow.Color);
            Assert.AreEqual(expected.TranslationText.Shadow.Direction, actual.TranslationText.Shadow.Direction);
            Assert.AreEqual(expected.TranslationText.Shadow.Distance, actual.TranslationText.Shadow.Distance);
            Assert.AreEqual(expected.TranslationText.Shadow.Size, actual.TranslationText.Shadow.Size);
            Assert.AreEqual(expected.TranslationText.LineSpacing, actual.TranslationText.LineSpacing);

            Assert.AreEqual(expected.CopyrightText.Font, actual.CopyrightText.Font);
            Assert.AreEqual(expected.CopyrightText.Color, actual.CopyrightText.Color);
            Assert.AreEqual(expected.CopyrightText.Outline.Color, actual.CopyrightText.Outline.Color);
            Assert.AreEqual(expected.CopyrightText.Outline.Width, actual.CopyrightText.Outline.Width);
            Assert.AreEqual(expected.CopyrightText.Shadow.Color, actual.CopyrightText.Shadow.Color);
            Assert.AreEqual(expected.CopyrightText.Shadow.Direction, actual.CopyrightText.Shadow.Direction);
            Assert.AreEqual(expected.CopyrightText.Shadow.Distance, actual.CopyrightText.Shadow.Distance);
            Assert.AreEqual(expected.CopyrightText.Shadow.Size, actual.CopyrightText.Shadow.Size);
            Assert.AreEqual(expected.CopyrightText.LineSpacing, actual.CopyrightText.LineSpacing);

            Assert.AreEqual(expected.SourceText.Font, actual.SourceText.Font);
            Assert.AreEqual(expected.SourceText.Color, actual.SourceText.Color);
            Assert.AreEqual(expected.SourceText.Outline.Color, actual.SourceText.Outline.Color);
            Assert.AreEqual(expected.SourceText.Outline.Width, actual.SourceText.Outline.Width);
            Assert.AreEqual(expected.SourceText.Shadow.Color, actual.SourceText.Shadow.Color);
            Assert.AreEqual(expected.SourceText.Shadow.Direction, actual.SourceText.Shadow.Direction);
            Assert.AreEqual(expected.SourceText.Shadow.Distance, actual.SourceText.Shadow.Distance);
            Assert.AreEqual(expected.SourceText.Shadow.Size, actual.SourceText.Shadow.Size);
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

            Assert.IsTrue(actual.SearchText.Contains("näher mein gott zu dir"));
            Assert.IsTrue(actual.SearchText.Contains("geborgen"));
        }

        /// <summary>
        ///A test for Map
        ///</summary>
        [TestMethod()]
        public void MapSongPowerPraiseSongTest()
        {
            ExtendedPowerPraiseSongFileMapper mapper = new ExtendedPowerPraiseSongFileMapper();

            Song source = PowerPraiseTestUtil.GetExpectedSongExtended();
            ExtendedPowerPraiseSong expected = PowerPraiseTestUtil.GetExpectedExtendedPowerPraiseSong();
            ExtendedPowerPraiseSong actual = new ExtendedPowerPraiseSong();
            
            mapper.map(source, actual);

            // General
            Assert.AreEqual(expected.Title, actual.Title, "Wrong song title");
            Assert.AreEqual(expected.Language, actual.Language, "Wrong language");
            Assert.AreEqual(expected.Category, actual.Category, "Wrong category");

            // Additional fields
            Assert.AreEqual(expected.Comment, actual.Comment, "Wrong comment");
            CollectionAssert.AreEqual(expected.QualityIssues, actual.QualityIssues, "Wrong Quality Issues");
            Assert.AreEqual(expected.CcliID, actual.CcliID, "Wrong CCLI id");
            CollectionAssert.AreEqual(expected.Author, actual.Author, "Wrong author");
            Assert.AreEqual(expected.RightsManagement, actual.RightsManagement, "Wrong Rights Management");
            Assert.AreEqual(expected.Publisher, actual.Publisher, "Wrong Publisher");
            Assert.AreEqual(expected.GUID, actual.GUID, "Wrong GUID");

            // Parts
            Assert.AreEqual(expected.Parts.Count, actual.Parts.Count, "Parts incomplete");
            for (int i = 0; i < expected.Parts.Count; i++)
            {
                Assert.AreEqual(expected.Parts[i].Caption, actual.Parts[i].Caption, "Wrong verse name in verse " + i);
                Assert.AreEqual(expected.Parts[i].Slides.Count, actual.Parts[i].Slides.Count, "Slides incomplete in verse " + i);
                for (int j = 0; j < expected.Parts[i].Slides.Count; j++)
                {
                    Assert.AreEqual(expected.Parts[i].Slides[j].BackgroundNr, actual.Parts[i].Slides[j].BackgroundNr);
                    Assert.AreEqual(expected.Parts[i].Slides[j].MainSize, actual.Parts[i].Slides[j].MainSize);
                    CollectionAssert.AreEqual(expected.Parts[i].Slides[j].Lines, actual.Parts[i].Slides[j].Lines, "Slide lines incomplete in verse " + i + " slide " + j);
                    CollectionAssert.AreEqual(expected.Parts[i].Slides[j].Translation, actual.Parts[i].Slides[j].Translation, "Slide translation incomplete in verse " + i + " slide " + j);
                }
            }

            // Order
            Assert.AreEqual(expected.Order.Count, actual.Order.Count, "Order incomplete");
            for (int i = 0; i < expected.Order.Count; i++) 
            {
                Assert.AreEqual(expected.Order[i].Caption, actual.Order[i].Caption, "Wrong verse name in verse " + i);
            }

            // Copyright
            CollectionAssert.AreEqual(expected.CopyrightText, actual.CopyrightText, "Wrong copyright");
            Assert.AreEqual(expected.CopyrightTextPosition, actual.CopyrightTextPosition, "Wrong copyright text position");

            // Source
            Assert.AreEqual(expected.SourceText, actual.SourceText, "Wrong source text");
            Assert.AreEqual(expected.SourceTextEnabled, actual.SourceTextEnabled, "Wrong source text position");

            // Formatting
            Assert.AreEqual(expected.MainTextFontFormatting.Font, actual.MainTextFontFormatting.Font);
            Assert.AreEqual(expected.MainTextFontFormatting.Color, actual.MainTextFontFormatting.Color);
            Assert.AreEqual(expected.MainTextFontFormatting.OutlineWidth, actual.MainTextFontFormatting.OutlineWidth);
            Assert.AreEqual(expected.MainTextFontFormatting.ShadowDistance, actual.MainTextFontFormatting.ShadowDistance);

            Assert.AreEqual(expected.TranslationTextFontFormatting.Font, actual.TranslationTextFontFormatting.Font);
            Assert.AreEqual(expected.TranslationTextFontFormatting.Color, actual.TranslationTextFontFormatting.Color);
            Assert.AreEqual(expected.TranslationTextFontFormatting.OutlineWidth, actual.TranslationTextFontFormatting.OutlineWidth);
            Assert.AreEqual(expected.TranslationTextFontFormatting.ShadowDistance, actual.TranslationTextFontFormatting.ShadowDistance);

            Assert.AreEqual(expected.CopyrightTextFontFormatting.Font, actual.CopyrightTextFontFormatting.Font);
            Assert.AreEqual(expected.CopyrightTextFontFormatting.Color, actual.CopyrightTextFontFormatting.Color);
            Assert.AreEqual(expected.CopyrightTextFontFormatting.OutlineWidth, actual.CopyrightTextFontFormatting.OutlineWidth);
            Assert.AreEqual(expected.CopyrightTextFontFormatting.ShadowDistance, actual.CopyrightTextFontFormatting.ShadowDistance);

            Assert.AreEqual(expected.SourceTextFontFormatting.Font, actual.SourceTextFontFormatting.Font);
            Assert.AreEqual(expected.SourceTextFontFormatting.Color, actual.SourceTextFontFormatting.Color);
            Assert.AreEqual(expected.SourceTextFontFormatting.OutlineWidth, actual.SourceTextFontFormatting.OutlineWidth);
            Assert.AreEqual(expected.SourceTextFontFormatting.ShadowDistance, actual.SourceTextFontFormatting.ShadowDistance);

            Assert.AreEqual(expected.TextOutlineFormatting.Color, actual.TextOutlineFormatting.Color);
            Assert.AreEqual(expected.TextOutlineFormatting.Enabled, actual.TextOutlineFormatting.Enabled);
            
            Assert.AreEqual(expected.TextShadowFormatting.Color, actual.TextShadowFormatting.Color);
            Assert.AreEqual(expected.TextShadowFormatting.Direction, actual.TextShadowFormatting.Direction);
            Assert.AreEqual(expected.TextShadowFormatting.Enabled, actual.TextShadowFormatting.Enabled);

            // Background
            CollectionAssert.AreEqual(expected.BackgroundImages, actual.BackgroundImages);

            // Linespacing
            Assert.AreEqual(expected.MainLineSpacing, actual.MainLineSpacing);
            Assert.AreEqual(expected.TranslationLineSpacing, actual.TranslationLineSpacing);

            // Text orientation
            Assert.AreEqual(expected.TextOrientation, actual.TextOrientation);
            Assert.AreEqual(expected.TranslationTextPosition, actual.TranslationTextPosition);

            // Borders
            Assert.AreEqual(expected.Borders.TextLeft, actual.Borders.TextLeft);
            Assert.AreEqual(expected.Borders.TextTop, actual.Borders.TextTop);
            Assert.AreEqual(expected.Borders.TextRight, actual.Borders.TextRight);
            Assert.AreEqual(expected.Borders.TextBottom, actual.Borders.TextBottom);
            Assert.AreEqual(expected.Borders.CopyrightBottom, actual.Borders.CopyrightBottom);
            Assert.AreEqual(expected.Borders.SourceTop, actual.Borders.SourceTop);
            Assert.AreEqual(expected.Borders.SourceRight, actual.Borders.SourceRight);

        }

        /// <summary>
        /// Combined read and map
        /// </summary>
        [TestMethod()]
        public void ReadAndMapTest()
        {
            string filename = "Resources/powerpraise/Näher, mein Gott zu Dir - extended.ppl";

            ISongFileReader<ExtendedPowerPraiseSong> reader = new ExtendedPowerPraiseSongFileReader();
            ExtendedPowerPraiseSongFileMapper mapper = new ExtendedPowerPraiseSongFileMapper();

            Song expected = PowerPraiseTestUtil.GetExpectedSongExtended();

            ExtendedPowerPraiseSong source = reader.Load(filename);
            Song actual = mapper.map(source);

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
                    CollectionAssert.AreEqual(expected.Parts[i].Slides[j].Lines, actual.Parts[i].Slides[j].Lines, "Slide lines incomplete in verse " + i + " slide " + j);
                    CollectionAssert.AreEqual(expected.Parts[i].Slides[j].Translation, actual.Parts[i].Slides[j].Translation, "Slide translation lines incomplete in verse " + i + " slide " + j);
                }
            }
            CollectionAssert.AreEqual(expected.PartSequence, actual.PartSequence, "Wrong part sequence");

            CollectionAssert.AreEqual(expected.RelativeImagePaths, actual.RelativeImagePaths, "Wrong image paths");

            CollectionAssert.AreEqual(expected.QualityIssues, actual.QualityIssues, "Wrong QA issues");

            Assert.AreEqual(expected.MainText.Font, actual.MainText.Font);
            Assert.AreEqual(expected.MainText.Color.ToArgb(), actual.MainText.Color.ToArgb());
            Assert.AreEqual(expected.MainText.Outline.Color.ToArgb(), actual.MainText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.MainText.Outline.Width, actual.MainText.Outline.Width);
            Assert.AreEqual(expected.MainText.Shadow.Color.ToArgb(), actual.MainText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.MainText.Shadow.Direction, actual.MainText.Shadow.Direction);
            Assert.AreEqual(expected.MainText.Shadow.Distance, actual.MainText.Shadow.Distance);
            Assert.AreEqual(expected.MainText.Shadow.Size, actual.MainText.Shadow.Size);
            Assert.AreEqual(expected.MainText.LineSpacing, actual.MainText.LineSpacing);

            Assert.AreEqual(expected.TranslationText.Font, actual.TranslationText.Font);
            Assert.AreEqual(expected.TranslationText.Color.ToArgb(), actual.TranslationText.Color.ToArgb());
            Assert.AreEqual(expected.TranslationText.Outline.Color.ToArgb(), actual.TranslationText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.TranslationText.Outline.Width, actual.TranslationText.Outline.Width);
            Assert.AreEqual(expected.TranslationText.Shadow.Color.ToArgb(), actual.TranslationText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.TranslationText.Shadow.Direction, actual.TranslationText.Shadow.Direction);
            Assert.AreEqual(expected.TranslationText.Shadow.Distance, actual.TranslationText.Shadow.Distance);
            Assert.AreEqual(expected.TranslationText.Shadow.Size, actual.TranslationText.Shadow.Size);
            Assert.AreEqual(expected.TranslationText.LineSpacing, actual.TranslationText.LineSpacing);

            Assert.AreEqual(expected.CopyrightText.Font, actual.CopyrightText.Font);
            Assert.AreEqual(expected.CopyrightText.Color.ToArgb(), actual.CopyrightText.Color.ToArgb());
            Assert.AreEqual(expected.CopyrightText.Outline.Color.ToArgb(), actual.CopyrightText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.CopyrightText.Outline.Width, actual.CopyrightText.Outline.Width);
            Assert.AreEqual(expected.CopyrightText.Shadow.Color.ToArgb(), actual.CopyrightText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.CopyrightText.Shadow.Direction, actual.CopyrightText.Shadow.Direction);
            Assert.AreEqual(expected.CopyrightText.Shadow.Distance, actual.CopyrightText.Shadow.Distance);
            Assert.AreEqual(expected.CopyrightText.Shadow.Size, actual.CopyrightText.Shadow.Size);
            Assert.AreEqual(expected.CopyrightText.LineSpacing, actual.CopyrightText.LineSpacing);

            Assert.AreEqual(expected.SourceText.Font, actual.SourceText.Font);
            Assert.AreEqual(expected.SourceText.Color.ToArgb(), actual.SourceText.Color.ToArgb());
            Assert.AreEqual(expected.SourceText.Outline.Color.ToArgb(), actual.SourceText.Outline.Color.ToArgb());
            Assert.AreEqual(expected.SourceText.Outline.Width, actual.SourceText.Outline.Width);
            Assert.AreEqual(expected.SourceText.Shadow.Color.ToArgb(), actual.SourceText.Shadow.Color.ToArgb());
            Assert.AreEqual(expected.SourceText.Shadow.Direction, actual.SourceText.Shadow.Direction);
            Assert.AreEqual(expected.SourceText.Shadow.Distance, actual.SourceText.Shadow.Distance);
            Assert.AreEqual(expected.SourceText.Shadow.Size, actual.SourceText.Shadow.Size);
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

            Assert.IsTrue(actual.SearchText.Contains("näher mein gott zu dir"));
            Assert.IsTrue(actual.SearchText.Contains("geborgen"));
        }

        /// <summary>
        /// Combined map and write
        /// </summary>
        [TestMethod()]
        public void MapAndWriteTest()
        {
            string referenceFilename = "Resources/powerpraise/Näher, mein Gott zu Dir - extended.ppl";
            string filename = "Resources/powerpraise/Näher, mein Gott zu Dir - extended - out.ppl";

            ExtendedPowerPraiseSongFileMapper mapper = new ExtendedPowerPraiseSongFileMapper();
            ISongFileWriter<ExtendedPowerPraiseSong> target = new ExtendedPowerPraiseSongFileWriter();

            Song source = PowerPraiseTestUtil.GetExpectedSongExtended();
            ExtendedPowerPraiseSong sng = new ExtendedPowerPraiseSong();
            mapper.map(source, sng);
            target.Save(filename, sng);

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
