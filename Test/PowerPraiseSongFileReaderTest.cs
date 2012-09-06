using Pbp.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pbp.Data.Song;

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
        ///A test for PowerPraiseSongFileReader Constructor
        ///</summary>
        [TestMethod()]
        public void PowerPraiseSongFileReaderConstructorTest()
        {

        }

        /// <summary>
        ///A test for load
        ///</summary>
        [TestMethod()]
        public void loadTest()
        {
            PowerPraiseSongFileReader target = new PowerPraiseSongFileReader();
            string filename = "Jesus is my Lord.ppl";

            Song expected = new Song();
            expected.Title = "Jesus is my Lord";
            expected.Language = "Englisch";

            var part = new SongPart();
            part.Caption = "Strophe 1";
            var slide = new SongSlide(expected);
            slide.Lines.Add("Jesus is my Lord my Master & Savior");
            slide.Lines.Add("Jesus is my Lord my Master and Savior");
            slide.Lines.Add("Jesus is my Lord my Master & Savior");
            slide.Lines.Add("Now and forevermore Hallelujah");
            slide.Lines.Add("Now and forevermore.");
            part.Slides.Add(slide);
            expected.Parts.Add(part);

            part = new SongPart();
            part.Caption = "Refrain";
            slide = new SongSlide(expected);
            slide.Lines.Add("Praise You Jesus, Son of God");
            slide.Lines.Add("and n the Lamb");
            slide.Lines.Add("King of Kings and Lord of Lords");
            slide.Lines.Add("God of Abraham Hallelujah");
            slide.Lines.Add("God of Abraham");
            part.Slides.Add(slide);
            expected.Parts.Add(part);

            part = new SongPart();
            part.Caption = "Strophe 2";
            slide = new SongSlide(expected);
            slide.Lines.Add("Jesus is the one who delivers me daily");
            slide.Lines.Add("Jesus is the one who delivers me daily");
            slide.Lines.Add("Jesus is the one who delivers me daily");
            slide.Lines.Add("From my sin and shame - Hallelujah!");
            slide.Lines.Add("From my sin and shame");
            part.Slides.Add(slide);
            expected.Parts.Add(part);
            
            Song actual = target.Load(filename);
            Assert.AreEqual(expected.Title, actual.Title, "Wrong song title");
            Assert.AreEqual(expected.Language, actual.Language, "Wrong language");

            Assert.AreEqual(expected.Parts.Count, actual.Parts.Count, "Parts incomplete");
            for (int i=0; i < expected.Parts.Count; i++)
            {
                Assert.AreEqual(expected.Parts[i].Caption, actual.Parts[i].Caption, "Wrong verse name");
                Assert.AreEqual(expected.Parts[i].Slides.Count, actual.Parts[i].Slides.Count, "Slides incomplete");
                for (int j = 0; j < expected.Parts[i].Slides.Count; j++)
                {
                    Assert.AreEqual(expected.Parts[i].Slides[j].Lines.Count, actual.Parts[i].Slides[j].Lines.Count, "Slide lines incomplete");
                    for (int k = 0; k < expected.Parts[i].Slides[j].Lines.Count; k++)
                    {
                        Assert.AreEqual(expected.Parts[i].Slides[j].Lines[k], actual.Parts[i].Slides[j].Lines[k], "Wrong slide lyrics");
                    }
                }
            }

            Assert.IsTrue(actual.SearchText.Contains(expected.Title.ToLower()));
            Assert.IsTrue(actual.SearchText.Contains("forevermore"));
        }
    }
}
