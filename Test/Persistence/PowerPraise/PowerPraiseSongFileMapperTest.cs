using Microsoft.VisualStudio.TestTools.UnitTesting;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Util;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    
    
    /// <summary>
    ///This is a test class for PowerPraiseSongFileReaderTest and is intended
    ///to contain all PowerPraiseSongFileReaderTest Unit Tests
    ///</summary>
    [TestClass]
    public class PowerPraiseSongFileMapperTest
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
        ///A test for Map
        ///</summary>
        [TestMethod]
        public void MapTest()
        {
            PowerPraiseSongFileMapper mapper = new PowerPraiseSongFileMapper();

            PowerPraiseSong source = PowerPraiseTestUtil.GetExpectedPowerPraiseSong();
            Song expected = PowerPraiseTestUtil.GetExpectedSong();
            Song actual = mapper.Map(source);

            Assert.AreEqual(expected.Guid, actual.Guid, "Wrong GUID");
            Assert.AreEqual(expected.ModifiedTimestamp, actual.ModifiedTimestamp, "Wrong modified timestamp");
            Assert.AreEqual(expected.CreatedIn, actual.CreatedIn, "Wrong created in");
            Assert.AreEqual(expected.ModifiedIn, actual.ModifiedIn, "Wrong modified in");
            Assert.AreEqual(expected.Title, actual.Title, "Wrong song title");
            Assert.AreEqual(expected.Language, actual.Language, "Wrong language");
            Assert.AreEqual(expected.CcliIdentifier, actual.CcliIdentifier, "Wrong CcliID");
            Assert.AreEqual(expected.Copyright, actual.Copyright, "Wrong copyright");
            Assert.AreEqual(expected.CopyrightPosition, actual.CopyrightPosition, "Wrong copyright position");
            Assert.AreEqual(expected.SourcePosition, actual.SourcePosition, "Wrong source position");
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
                    Assert.AreEqual(expected.Parts[i].Slides[j].Background, actual.Parts[i].Slides[j].Background, "Slide background incomplete in verse " + i + " slide " + j);
                    CollectionAssert.AreEqual(expected.Parts[i].Slides[j].Lines, actual.Parts[i].Slides[j].Lines, "Slide lines incomplete in verse " + i + " slide " + j);
                    CollectionAssert.AreEqual(expected.Parts[i].Slides[j].Translation, actual.Parts[i].Slides[j].Translation, "Slide translation lines incomplete in verse " + i + " slide " + j);
                }
            }
            CollectionAssert.AreEqual(expected.PartSequence, actual.PartSequence, "Wrong part sequence");

            Assert.AreEqual(expected.QualityIssues, actual.QualityIssues, "Wrong QA issues");

            Assert.AreEqual(expected.MainText.Font, actual.MainText.Font);
            Assert.AreEqual(expected.MainText.Color, actual.MainText.Color);
            Assert.AreEqual(expected.MainText.Outline.Color, actual.MainText.Outline.Color);
            Assert.AreEqual(expected.MainText.Outline.Width, actual.MainText.Outline.Width);
            Assert.AreEqual(expected.MainText.Shadow.Color, actual.MainText.Shadow.Color);
            Assert.AreEqual(expected.MainText.Shadow.Direction, actual.MainText.Shadow.Direction);
            Assert.AreEqual(expected.MainText.Shadow.Distance, actual.MainText.Shadow.Distance);
            Assert.AreEqual(expected.MainText.LineSpacing, actual.MainText.LineSpacing);

            Assert.AreEqual(expected.TranslationText.Font, actual.TranslationText.Font);
            Assert.AreEqual(expected.TranslationText.Color, actual.TranslationText.Color);
            Assert.AreEqual(expected.TranslationText.Outline.Color, actual.TranslationText.Outline.Color);
            Assert.AreEqual(expected.TranslationText.Outline.Width, actual.TranslationText.Outline.Width);
            Assert.AreEqual(expected.TranslationText.Shadow.Color, actual.TranslationText.Shadow.Color);
            Assert.AreEqual(expected.TranslationText.Shadow.Direction, actual.TranslationText.Shadow.Direction);
            Assert.AreEqual(expected.TranslationText.Shadow.Distance, actual.TranslationText.Shadow.Distance);
            Assert.AreEqual(expected.TranslationText.LineSpacing, actual.TranslationText.LineSpacing);

            Assert.AreEqual(expected.CopyrightText.Font, actual.CopyrightText.Font);
            Assert.AreEqual(expected.CopyrightText.Color, actual.CopyrightText.Color);
            Assert.AreEqual(expected.CopyrightText.Outline.Color, actual.CopyrightText.Outline.Color);
            Assert.AreEqual(expected.CopyrightText.Outline.Width, actual.CopyrightText.Outline.Width);
            Assert.AreEqual(expected.CopyrightText.Shadow.Color, actual.CopyrightText.Shadow.Color);
            Assert.AreEqual(expected.CopyrightText.Shadow.Direction, actual.CopyrightText.Shadow.Direction);
            Assert.AreEqual(expected.CopyrightText.Shadow.Distance, actual.CopyrightText.Shadow.Distance);
            Assert.AreEqual(expected.CopyrightText.LineSpacing, actual.CopyrightText.LineSpacing);

            Assert.AreEqual(expected.SourceText.Font, actual.SourceText.Font);
            Assert.AreEqual(expected.SourceText.Color, actual.SourceText.Color);
            Assert.AreEqual(expected.SourceText.Outline.Color, actual.SourceText.Outline.Color);
            Assert.AreEqual(expected.SourceText.Outline.Width, actual.SourceText.Outline.Width);
            Assert.AreEqual(expected.SourceText.Shadow.Color, actual.SourceText.Shadow.Color);
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

            Assert.IsTrue(SongSearchUtil.GetSearchableSongText(actual).Contains("näher mein gott zu dir"));
            Assert.IsTrue(SongSearchUtil.GetSearchableSongText(actual).Contains("geborgen"));
        }

        /// <summary>
        ///A test for Map
        ///</summary>
        [TestMethod]
        public void MapSongPowerPraiseSongTest()
        {
            PowerPraiseSongFileMapper mapper = new PowerPraiseSongFileMapper();

            Song source = PowerPraiseTestUtil.GetExpectedSong();
            PowerPraiseSong expected = PowerPraiseTestUtil.GetExpectedPowerPraiseSong();
            PowerPraiseSong actual = new PowerPraiseSong();
            
            mapper.Map(source, actual);

            // General
            Assert.AreEqual(expected.Title, actual.Title, "Wrong song title");
            Assert.AreEqual(expected.Language, actual.Language, "Wrong language");
            Assert.AreEqual(expected.Category, actual.Category, "Wrong category");

            // Parts
            Assert.AreEqual(expected.Parts.Count, actual.Parts.Count, "Parts incomplete");
            for (int i = 0; i < expected.Parts.Count; i++)
            {
                Assert.AreEqual(expected.Parts[i].Caption, actual.Parts[i].Caption, "Wrong verse name in verse " + i);
                Assert.AreEqual(expected.Parts[i].Slides.Count, actual.Parts[i].Slides.Count, "Slides incomplete in verse " + i);
                for (int j = 0; j < expected.Parts[i].Slides.Count; j++)
                {
                    Assert.AreEqual(expected.Parts[i].Slides[j].Background, actual.Parts[i].Slides[j].Background);
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
            Assert.AreEqual(expected.Formatting.CopyrightTextPosition, actual.Formatting.CopyrightTextPosition, "Wrong copyright text position");

            // Source
            Assert.AreEqual(expected.SourceText, actual.SourceText, "Wrong source text");
            Assert.AreEqual(expected.Formatting.SourceTextPosition, actual.Formatting.SourceTextPosition, "Wrong source text position");

            // Formatting
            Assert.AreEqual(expected.Formatting.MainText.Font, actual.Formatting.MainText.Font);
            Assert.AreEqual(expected.Formatting.MainText.Color, actual.Formatting.MainText.Color);
            Assert.AreEqual(expected.Formatting.MainText.OutlineWidth, actual.Formatting.MainText.OutlineWidth);
            Assert.AreEqual(expected.Formatting.MainText.ShadowDistance, actual.Formatting.MainText.ShadowDistance);

            Assert.AreEqual(expected.Formatting.TranslationText.Font, actual.Formatting.TranslationText.Font);
            Assert.AreEqual(expected.Formatting.TranslationText.Color, actual.Formatting.TranslationText.Color);
            Assert.AreEqual(expected.Formatting.TranslationText.OutlineWidth, actual.Formatting.TranslationText.OutlineWidth);
            Assert.AreEqual(expected.Formatting.TranslationText.ShadowDistance, actual.Formatting.TranslationText.ShadowDistance);

            Assert.AreEqual(expected.Formatting.CopyrightText.Font, actual.Formatting.CopyrightText.Font);
            Assert.AreEqual(expected.Formatting.CopyrightText.Color, actual.Formatting.CopyrightText.Color);
            Assert.AreEqual(expected.Formatting.CopyrightText.OutlineWidth, actual.Formatting.CopyrightText.OutlineWidth);
            Assert.AreEqual(expected.Formatting.CopyrightText.ShadowDistance, actual.Formatting.CopyrightText.ShadowDistance);

            Assert.AreEqual(expected.Formatting.SourceText.Font, actual.Formatting.SourceText.Font);
            Assert.AreEqual(expected.Formatting.SourceText.Color, actual.Formatting.SourceText.Color);
            Assert.AreEqual(expected.Formatting.SourceText.OutlineWidth, actual.Formatting.SourceText.OutlineWidth);
            Assert.AreEqual(expected.Formatting.SourceText.ShadowDistance, actual.Formatting.SourceText.ShadowDistance);

            Assert.AreEqual(expected.Formatting.Outline.Color, actual.Formatting.Outline.Color);
            Assert.AreEqual(expected.Formatting.Outline.Enabled, actual.Formatting.Outline.Enabled);
            
            Assert.AreEqual(expected.Formatting.Shadow.Color, actual.Formatting.Shadow.Color);
            Assert.AreEqual(expected.Formatting.Shadow.Direction, actual.Formatting.Shadow.Direction);
            Assert.AreEqual(expected.Formatting.Shadow.Enabled, actual.Formatting.Shadow.Enabled);

            // Linespacing
            Assert.AreEqual(expected.Formatting.MainLineSpacing, actual.Formatting.MainLineSpacing);
            Assert.AreEqual(expected.Formatting.TranslationLineSpacing, actual.Formatting.TranslationLineSpacing);

            // Text orientation
            Assert.AreEqual(expected.Formatting.TextOrientation, actual.Formatting.TextOrientation);
            Assert.AreEqual(expected.Formatting.TranslationPosition, actual.Formatting.TranslationPosition);

            // Borders
            Assert.AreEqual(expected.Formatting.Borders.TextLeft, actual.Formatting.Borders.TextLeft);
            Assert.AreEqual(expected.Formatting.Borders.TextTop, actual.Formatting.Borders.TextTop);
            Assert.AreEqual(expected.Formatting.Borders.TextRight, actual.Formatting.Borders.TextRight);
            Assert.AreEqual(expected.Formatting.Borders.TextBottom, actual.Formatting.Borders.TextBottom);
            Assert.AreEqual(expected.Formatting.Borders.CopyrightBottom, actual.Formatting.Borders.CopyrightBottom);
            Assert.AreEqual(expected.Formatting.Borders.SourceTop, actual.Formatting.Borders.SourceTop);
            Assert.AreEqual(expected.Formatting.Borders.SourceRight, actual.Formatting.Borders.SourceRight);

        }

    }
}
