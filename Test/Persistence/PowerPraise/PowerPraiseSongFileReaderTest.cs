using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    /// <summary>
    ///This is a test class for PowerPraiseSongFileReaderTest and is intended
    ///to contain all PowerPraiseSongFileReaderTest Unit Tests
    ///</summary>
    [TestClass]
    public class PowerPraiseSongFileReaderTest
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
            ISongFileReader<PowerPraiseSong> target = new PowerPraiseSongFileReader();
            const string filename = "Resources/powerpraise/Näher, mein Gott zu Dir.ppl";

            PowerPraiseSong expected = PowerPraiseTestUtil.GetExpectedPowerPraiseSong();
 
            PowerPraiseSong actual = target.Load(filename);

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
            Assert.AreEqual(expected.Formatting.MainText.Font, actual.Formatting.MainText.Font);
            Assert.AreEqual(expected.Formatting.MainText.Color.ToArgb(), actual.Formatting.MainText.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.MainText.OutlineWidth, actual.Formatting.MainText.OutlineWidth);
            Assert.AreEqual(expected.Formatting.MainText.ShadowDistance, actual.Formatting.MainText.ShadowDistance);

            Assert.AreEqual(expected.Formatting.TranslationText.Font, actual.Formatting.TranslationText.Font);
            Assert.AreEqual(expected.Formatting.TranslationText.Color.ToArgb(), actual.Formatting.TranslationText.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.TranslationText.OutlineWidth, actual.Formatting.TranslationText.OutlineWidth);
            Assert.AreEqual(expected.Formatting.TranslationText.ShadowDistance, actual.Formatting.TranslationText.ShadowDistance);

            Assert.AreEqual(expected.Formatting.CopyrightText.Font, actual.Formatting.CopyrightText.Font);
            Assert.AreEqual(expected.Formatting.CopyrightText.Color.ToArgb(), actual.Formatting.CopyrightText.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.CopyrightText.OutlineWidth, actual.Formatting.CopyrightText.OutlineWidth);
            Assert.AreEqual(expected.Formatting.CopyrightText.ShadowDistance, actual.Formatting.CopyrightText.ShadowDistance);

            Assert.AreEqual(expected.Formatting.SourceText.Font, actual.Formatting.SourceText.Font);
            Assert.AreEqual(expected.Formatting.SourceText.Color.ToArgb(), actual.Formatting.SourceText.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.SourceText.OutlineWidth, actual.Formatting.SourceText.OutlineWidth);
            Assert.AreEqual(expected.Formatting.SourceText.ShadowDistance, actual.Formatting.SourceText.ShadowDistance);

            Assert.AreEqual(expected.Formatting.Outline.Color.ToArgb(), actual.Formatting.Outline.Color.ToArgb());
            Assert.AreEqual(expected.Formatting.Outline.Enabled, actual.Formatting.Outline.Enabled);

            Assert.AreEqual(expected.Formatting.Shadow.Color.ToArgb(), actual.Formatting.Shadow.Color.ToArgb());
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

        /// <summary>
        ///A test for ReadTitle
        ///</summary>
        [TestMethod]
        public void ReadTitleTest()
        {
            ISongFileReader<PowerPraiseSong> reader = new PowerPraiseSongFileReader();
            Assert.AreEqual("Näher, mein Gott, zu Dir", reader.ReadTitle("Resources/powerpraise/Näher, mein Gott zu Dir.ppl"));
            Assert.IsNull(reader.ReadTitle("Resources/powerpraise/non-existing-file.ppl"));
        }

    }
}
