using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PraiseBase.Presenter.Persistence.OpenLyrics
{
    
    
    /// <summary>
    ///This is a test class for OpenLyricsSongFileReaderTest and is intended
    ///to contain all OpenLyricsSongFileReaderTest Unit Tests
    ///</summary>
    [TestClass]
    public class OpenLyricsSongFileReaderTest
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
        [TestMethod]
        public void LoadSimpleTest()
        {
            ISongFileReader<OpenLyricsSong> target = new OpenLyricsSongFileReader();
            string filename = "Resources/openlyrics/simple.xml";

            OpenLyricsSong expected = new OpenLyricsSong();
            expected.Title = "Amazing Grace";
            expected.ModifiedTimestamp = "2012-04-10T22:00:00+10:00";
            expected.CreatedIn = "OpenLP 1.9.0";
            expected.ModifiedIn = "MyApp 0.0.1";

            OpenLyricsSongVerse verse = new OpenLyricsSongVerse();
            verse.Name = "v1";

            OpenLyricsSongLines lines = new OpenLyricsSongLines();
            lines.Text.Add("Amazing grace how sweet the sound");
            lines.Text.Add("that saved a wretch like me;");
            verse.Lines.Add(lines);
            expected.Verses.Add(verse);

            OpenLyricsSong actual;
            actual = target.Load(filename);
            Assert.AreEqual(expected.Title, actual.Title, "Wrong song title");
            Assert.AreEqual(expected.ModifiedTimestamp, actual.ModifiedTimestamp, "Wrong song modified date");
            Assert.AreEqual(expected.CreatedIn, actual.CreatedIn, "Wrong creator app");
            Assert.AreEqual(expected.ModifiedIn, actual.ModifiedIn, "Wrong modifier app");

            Assert.AreEqual(expected.Verses.Count, actual.Verses.Count, "Parts incomplete");
            for (int i = 0; i < expected.Verses.Count; i++)
            {
                Assert.AreEqual(expected.Verses[i].Name, actual.Verses[i].Name, "Wrong verse name");
                Assert.AreEqual(expected.Verses[i].Lines.Count, actual.Verses[i].Lines.Count, "Slides incomplete");
                for (int j = 0; j < expected.Verses[i].Lines.Count; j++)
                {
                    Assert.AreEqual(expected.Verses[i].Lines[j].Text.Count, actual.Verses[i].Lines[j].Text.Count, "Slide lines incomplete");
                    for (int k = 0; k < expected.Verses[i].Lines[j].Text.Count; k++)
                    {
                        Assert.AreEqual(expected.Verses[i].Lines[j].Text[k], actual.Verses[i].Lines[j].Text[k], "Wrong slide lyrics");
                    }
                }
            }

        }

        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod]
        public void LoadComplexTest()
        {
            ISongFileReader<OpenLyricsSong> target = new OpenLyricsSongFileReader();
            string filename = "Resources/openlyrics/complex.xml";

            OpenLyricsSong expected = new OpenLyricsSong();
            expected.Title = "Amazing Grace";
            expected.ModifiedTimestamp = "2012-04-10T22:00:00+10:00";
            expected.CreatedIn = "OpenLP 1.9.0";
            expected.ModifiedIn = "ChangingSong 0.0.1";

            expected.CcliID = "4639462";
            expected.Copyright = "public domain";
            expected.ReleaseYear = "1779";
            expected.Comments.Add("This is one of the most popular songs in our congregation.");

            OpenLyricsSongVerse verse = new OpenLyricsSongVerse();
            verse.Name = "v1";
            verse.Language = "en";
            var lines = new OpenLyricsSongLines();
            lines.Text.Add("Amazing grace how sweet the sound that saved a wretch like me;");
            verse.Lines.Add(lines);
            lines = new OpenLyricsSongLines();
            lines.Part = "women";
            lines.Text.Add("A b c");
            lines.Text.Add("D e f");
            verse.Lines.Add(lines);
            expected.Verses.Add(verse);

            verse = new OpenLyricsSongVerse();
            verse.Name = "v1";
            verse.Language = "de";
            lines = new OpenLyricsSongLines();
            lines.Text.Add("Erstaunliche Ahmut, wie");
            verse.Lines.Add(lines);
            expected.Verses.Add(verse);

            verse = new OpenLyricsSongVerse();
            verse.Name = "c";
            lines = new OpenLyricsSongLines();
            lines.Text.Add("");
            lines.Text.Add("Line content.");
            verse.Lines.Add(lines);
            expected.Verses.Add(verse);

            verse = new OpenLyricsSongVerse();
            verse.Name = "v2";
            verse.Language = "en-US";
            lines = new OpenLyricsSongLines();
            lines.Part = "men";
            lines.Text.Add("");
            lines.Text.Add("Amazing grace how sweet the sound that saved a wretch like me;");
            lines.Text.Add("");
            lines.Text.Add("Amazing grace how sweet the sound that saved a wretch like me;");
            lines.Text.Add("Amazing grace how sweet the sound that saved a wretch like me;");
            verse.Lines.Add(lines);
            lines = new OpenLyricsSongLines();
            lines.Part = "women";
            lines.Text.Add("A b c");
            lines.Text.Add("");
            lines.Text.Add("D e f");
            verse.Lines.Add(lines);
            expected.Verses.Add(verse);

            verse = new OpenLyricsSongVerse();
            verse.Name = "emptyline";
            verse.Language = "de";
            lines = new OpenLyricsSongLines();
            lines.Text.Add("");
            lines.Text.Add("");
            verse.Lines.Add(lines);
            lines = new OpenLyricsSongLines();
            lines.Text.Add("");
            lines.Text.Add("");
            lines.Text.Add("");
            lines.Text.Add("");
            lines.Text.Add("");
            verse.Lines.Add(lines);
            expected.Verses.Add(verse);

            verse = new OpenLyricsSongVerse();
            verse.Name = "e";
            verse.Language = "de";
            lines = new OpenLyricsSongLines();
            lines.Text.Add("This is text of ending.");
            verse.Lines.Add(lines);
            expected.Verses.Add(verse);

            OpenLyricsSong actual = target.Load(filename);
            Assert.AreEqual(expected.Title, actual.Title, "Wrong song title");
            Assert.AreEqual(expected.ModifiedTimestamp, actual.ModifiedTimestamp, "Wrong song modified date");
            Assert.AreEqual(expected.CreatedIn, actual.CreatedIn, "Wrong creator app");
            Assert.AreEqual(expected.ModifiedIn, actual.ModifiedIn, "Wrong modifier app");
            Assert.AreEqual(expected.Copyright, actual.Copyright, "Wrong copyright info");
            Assert.AreEqual(expected.CcliID, actual.CcliID, "Wrong CCLI number");
            Assert.AreEqual(expected.ReleaseYear, actual.ReleaseYear, "Wrong release date");
            CollectionAssert.AreEqual(expected.Comments, actual.Comments, "Wrong comments");

            Assert.AreEqual(expected.Verses.Count, actual.Verses.Count, "Verses incomplete");
            for (int i = 0; i < expected.Verses.Count; i++)
            {
                Assert.AreEqual(expected.Verses[i].Name, actual.Verses[i].Name, "Wrong verse name");
                Assert.AreEqual(expected.Verses[i].Language, actual.Verses[i].Language, "Wrong language");
                Assert.AreEqual(expected.Verses[i].Lines.Count, actual.Verses[i].Lines.Count, "Slides incomplete " + i);
                for (int j = 0; j < expected.Verses[i].Lines.Count; j++)
                {
                    Assert.AreEqual(expected.Verses[i].Lines[j].Text.Count, actual.Verses[i].Lines[j].Text.Count, "Slide lines incomplete " + i + " " + j);
                    Assert.AreEqual(expected.Verses[i].Lines[j].Part, actual.Verses[i].Lines[j].Part, "Wrong lines part name");
                    for (int k = 0; k < expected.Verses[i].Lines[j].Text.Count; k++)
                    {
                        Assert.AreEqual(expected.Verses[i].Lines[j].Text[k], actual.Verses[i].Lines[j].Text[k], "Wrong slide lyrics");
                    }
                }
            }
        }

        /// <summary>
        ///A test for ReadTitle
        ///</summary>
        [TestMethod]
        public void ReadTitleTestSimple()
        {
            ISongFileReader<OpenLyricsSong> reader = new OpenLyricsSongFileReader();
            Assert.AreEqual("Amazing Grace", reader.ReadTitle("Resources/openlyrics/simple.xml"));
            Assert.IsNull(reader.ReadTitle("Resources/openlyrics/non-existing-file.xml"));
        }

        /// <summary>
        ///A test for ReadTitle
        ///</summary>
        [TestMethod]
        public void ReadTitleTestComplex()
        {
            ISongFileReader<OpenLyricsSong> reader = new OpenLyricsSongFileReader();
            Assert.AreEqual("Amazing Grace", reader.ReadTitle("Resources/openlyrics/complex.xml"));
        }
    }
}
