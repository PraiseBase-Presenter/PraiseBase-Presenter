using PraiseBase.Presenter.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PraiseBase.Presenter.Persistence.PowerPraise.Extended
{
    
    
    /// <summary>
    ///This is a test class for PowerPraiseSongFileReaderTest and is intended
    ///to contain all PowerPraiseSongFileReaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExtendedPowerPraiseSongFileReaderTest
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
            ISongFileReader<ExtendedPowerPraiseSong> reader = new ExtendedPowerPraiseSongFileReader();
            string filename = "Resources/powerpraise/Näher, mein Gott zu Dir.ppl";

            PowerPraiseSong expected = PowerPraiseTestUtil.GetExpectedPowerPraiseSong();

            ExtendedPowerPraiseSong actual = reader.Load(filename);

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
            Assert.AreEqual(expected.CopyrightTextPosition, actual.CopyrightTextPosition, "Wrong copyright text position");

            // Source
            Assert.AreEqual(expected.SourceText, actual.SourceText, "Wrong source text");
            Assert.AreEqual(expected.SourceTextEnabled, actual.SourceTextEnabled, "Wrong source text position");

            // Formatting
            Assert.AreEqual(expected.MainTextFontFormatting.Font, actual.MainTextFontFormatting.Font);
            Assert.AreEqual(expected.MainTextFontFormatting.Color.ToArgb(), actual.MainTextFontFormatting.Color.ToArgb());
            Assert.AreEqual(expected.MainTextFontFormatting.OutlineWidth, actual.MainTextFontFormatting.OutlineWidth);
            Assert.AreEqual(expected.MainTextFontFormatting.ShadowDistance, actual.MainTextFontFormatting.ShadowDistance);

            Assert.AreEqual(expected.TranslationTextFontFormatting.Font, actual.TranslationTextFontFormatting.Font);
            Assert.AreEqual(expected.TranslationTextFontFormatting.Color.ToArgb(), actual.TranslationTextFontFormatting.Color.ToArgb());
            Assert.AreEqual(expected.TranslationTextFontFormatting.OutlineWidth, actual.TranslationTextFontFormatting.OutlineWidth);
            Assert.AreEqual(expected.TranslationTextFontFormatting.ShadowDistance, actual.TranslationTextFontFormatting.ShadowDistance);

            Assert.AreEqual(expected.CopyrightTextFontFormatting.Font, actual.CopyrightTextFontFormatting.Font);
            Assert.AreEqual(expected.CopyrightTextFontFormatting.Color.ToArgb(), actual.CopyrightTextFontFormatting.Color.ToArgb());
            Assert.AreEqual(expected.CopyrightTextFontFormatting.OutlineWidth, actual.CopyrightTextFontFormatting.OutlineWidth);
            Assert.AreEqual(expected.CopyrightTextFontFormatting.ShadowDistance, actual.CopyrightTextFontFormatting.ShadowDistance);

            Assert.AreEqual(expected.SourceTextFontFormatting.Font, actual.SourceTextFontFormatting.Font);
            Assert.AreEqual(expected.SourceTextFontFormatting.Color.ToArgb(), actual.SourceTextFontFormatting.Color.ToArgb());
            Assert.AreEqual(expected.SourceTextFontFormatting.OutlineWidth, actual.SourceTextFontFormatting.OutlineWidth);
            Assert.AreEqual(expected.SourceTextFontFormatting.ShadowDistance, actual.SourceTextFontFormatting.ShadowDistance);

            Assert.AreEqual(expected.TextOutlineFormatting.Color.ToArgb(), actual.TextOutlineFormatting.Color.ToArgb());
            Assert.AreEqual(expected.TextOutlineFormatting.Enabled, actual.TextOutlineFormatting.Enabled);

            Assert.AreEqual(expected.TextShadowFormatting.Color.ToArgb(), actual.TextShadowFormatting.Color.ToArgb());
            Assert.AreEqual(expected.TextShadowFormatting.Direction, actual.TextShadowFormatting.Direction);
            Assert.AreEqual(expected.TextShadowFormatting.Enabled, actual.TextShadowFormatting.Enabled);

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
        ///A test for Load
        ///</summary>
        [TestMethod()]
        public void LoadTest2()
        {
            ISongFileReader<ExtendedPowerPraiseSong> reader = new ExtendedPowerPraiseSongFileReader();
            string filename = "Resources/powerpraise/Näher, mein Gott zu Dir - extended.ppl";

            ExtendedPowerPraiseSong expected = ExtendedPowerPraiseTestUtil.GetExpectedExtendedPowerPraiseSong();

            ExtendedPowerPraiseSong actual = reader.Load(filename);

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
            Assert.AreEqual(expected.CopyrightTextPosition, actual.CopyrightTextPosition, "Wrong copyright text position");

            // Source
            Assert.AreEqual(expected.SourceText, actual.SourceText, "Wrong source text");
            Assert.AreEqual(expected.SourceTextEnabled, actual.SourceTextEnabled, "Wrong source text position");

            // Formatting
            Assert.AreEqual(expected.MainTextFontFormatting.Font, actual.MainTextFontFormatting.Font);
            Assert.AreEqual(expected.MainTextFontFormatting.Color.ToArgb(), actual.MainTextFontFormatting.Color.ToArgb());
            Assert.AreEqual(expected.MainTextFontFormatting.OutlineWidth, actual.MainTextFontFormatting.OutlineWidth);
            Assert.AreEqual(expected.MainTextFontFormatting.ShadowDistance, actual.MainTextFontFormatting.ShadowDistance);

            Assert.AreEqual(expected.TranslationTextFontFormatting.Font, actual.TranslationTextFontFormatting.Font);
            Assert.AreEqual(expected.TranslationTextFontFormatting.Color.ToArgb(), actual.TranslationTextFontFormatting.Color.ToArgb());
            Assert.AreEqual(expected.TranslationTextFontFormatting.OutlineWidth, actual.TranslationTextFontFormatting.OutlineWidth);
            Assert.AreEqual(expected.TranslationTextFontFormatting.ShadowDistance, actual.TranslationTextFontFormatting.ShadowDistance);

            Assert.AreEqual(expected.CopyrightTextFontFormatting.Font, actual.CopyrightTextFontFormatting.Font);
            Assert.AreEqual(expected.CopyrightTextFontFormatting.Color.ToArgb(), actual.CopyrightTextFontFormatting.Color.ToArgb());
            Assert.AreEqual(expected.CopyrightTextFontFormatting.OutlineWidth, actual.CopyrightTextFontFormatting.OutlineWidth);
            Assert.AreEqual(expected.CopyrightTextFontFormatting.ShadowDistance, actual.CopyrightTextFontFormatting.ShadowDistance);

            Assert.AreEqual(expected.SourceTextFontFormatting.Font, actual.SourceTextFontFormatting.Font);
            Assert.AreEqual(expected.SourceTextFontFormatting.Color.ToArgb(), actual.SourceTextFontFormatting.Color.ToArgb());
            Assert.AreEqual(expected.SourceTextFontFormatting.OutlineWidth, actual.SourceTextFontFormatting.OutlineWidth);
            Assert.AreEqual(expected.SourceTextFontFormatting.ShadowDistance, actual.SourceTextFontFormatting.ShadowDistance);

            Assert.AreEqual(expected.TextOutlineFormatting.Color.ToArgb(), actual.TextOutlineFormatting.Color.ToArgb());
            Assert.AreEqual(expected.TextOutlineFormatting.Enabled, actual.TextOutlineFormatting.Enabled);

            Assert.AreEqual(expected.TextShadowFormatting.Color.ToArgb(), actual.TextShadowFormatting.Color.ToArgb());
            Assert.AreEqual(expected.TextShadowFormatting.Direction, actual.TextShadowFormatting.Direction);
            Assert.AreEqual(expected.TextShadowFormatting.Enabled, actual.TextShadowFormatting.Enabled);

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


    }
}
