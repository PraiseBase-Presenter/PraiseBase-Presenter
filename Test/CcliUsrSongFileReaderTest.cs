using Pbp.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pbp.Data.Song;
using Pbp.Persistence.Reader;

namespace Test
{
    
    
    /// <summary>
    ///This is a test class for CcliUsrSongFileReaderTest and is intended
    ///to contain all CcliUsrSongFileReaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CcliUsrSongFileReaderTest
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
        ///A test for CcliUsrSongFileReader Constructor
        ///</summary>
        [TestMethod()]
        public void CcliUsrSongFileReaderConstructorTest()
        {
            CcliUsrSongFileReader target = new CcliUsrSongFileReader();
        }

        /// <summary>
        ///A test for IsFileSupported
        ///</summary>
        [TestMethod()]
        public void IsFileSupportedTest()
        {
            CcliUsrSongFileReader target = new CcliUsrSongFileReader(); // TODO: Initialize to an appropriate value
            string filename = "ccli/Ein Lied für Gott.usr";
            bool expected = true;
            bool actual = target.IsFileSupported(filename);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod()]
        public void LoadTest()
        {
            CcliUsrSongFileReader target = new CcliUsrSongFileReader();
            string filename = "ccli/Ein Lied für Gott.usr";
            Song expected = new Song();

            expected.Title = "Ein Lied für Gott";
            expected.Themes.Add("Celebration");
            expected.Themes.Add("God's Attributes");
            expected.Themes.Add("Love");
            expected.Themes.Add("Joy");
            var aut = new SongAuthor();
            aut.Name = "Muster, Hans";
            expected.Author.Add(aut);
            expected.Copyright = "Gemeinfrei (Public Domain)";
            expected.RightsManagement = "Verlag ABC";
            expected.Key = "E";

            var part = new SongPart();
            part.Caption = "Vers 1";
            var slide = new SongSlide(expected);
            slide.Lines.Add("Lorem ipsum dolor sit amet,");
            slide.Lines.Add("consectetur adipiscing elit.");
            slide.Lines.Add("Vivamus odio massa,");
            slide.Lines.Add("lacinia in mollis quis,");
            slide.Lines.Add("vehicula sed justo");
            part.Slides.Add(slide);
            expected.Parts.Add(part);

            part = new SongPart();
            part.Caption = "Vers 2";
            slide = new SongSlide(expected);
            slide.Lines.Add("Nunc cursus libero non quam lobortis");
            slide.Lines.Add("ac pharetra leo facilisis.");
            slide.Lines.Add("Proin tortor tellus,");
            slide.Lines.Add("fermentum mattis euismod eu,");
            slide.Lines.Add("faucibus vel justo.");
            part.Slides.Add(slide);
            expected.Parts.Add(part);

            part = new SongPart();
            part.Caption = "Vers 3";
            slide = new SongSlide(expected);
            slide = new SongSlide(expected);
            slide.Lines.Add("Fusce pellentesque rhoncus felis,");
            slide.Lines.Add("eu convallis ante tempus a.");
            slide.Lines.Add("Cum sociis natoque penatibus");
            slide.Lines.Add("et magnis dis parturient montes,");
            slide.Lines.Add("nascetur ridiculus mus.");
            part.Slides.Add(slide);
            expected.Parts.Add(part);

            Song actual = target.Load(filename);
            Assert.AreEqual(expected.Title, actual.Title, "Wrong song title");
            Assert.AreEqual(expected.Language, actual.Language, "Wrong language");
            Assert.AreEqual(expected.Copyright, actual.Copyright, "Wrong copyright");
            Assert.AreEqual(expected.RightsManagement, actual.RightsManagement, "Wrong RightsManagement");
            Assert.AreEqual(expected.Key, actual.Key, "Wrong key");
            for (int i = 0; i < expected.Themes.Count; i++) 
            {
                Assert.AreEqual(expected.Themes[i], actual.Themes[i], "Wrong theme");
            }
            for (int i = 0; i < expected.Author.Count; i++)
            {
                Assert.AreEqual(expected.Author[i].Name, actual.Author[i].Name, "Wrong Author");
            }

            Assert.AreEqual(expected.Parts.Count, actual.Parts.Count, "Parts incomplete");
            for (int i = 0; i < expected.Parts.Count; i++)
            {
                Assert.AreEqual(expected.Parts[i].Caption, actual.Parts[i].Caption, "Wrong verse name in verse " + i);
                Assert.AreEqual(expected.Parts[i].Slides.Count, actual.Parts[i].Slides.Count, "Slides incomplete in verse " + i);
                for (int j = 0; j < expected.Parts[i].Slides.Count; j++)
                {
                    Assert.AreEqual(expected.Parts[i].Slides[j].Lines.Count, actual.Parts[i].Slides[j].Lines.Count, "Slide lines incomplete in verse " + i + " slide " + j);
                    for (int k = 0; k < expected.Parts[i].Slides[j].Lines.Count; k++)
                    {
                        Assert.AreEqual(expected.Parts[i].Slides[j].Lines[k], actual.Parts[i].Slides[j].Lines[k], "Wrong slide lyrics");
                    }
                }
            }
        }

        /// <summary>
        ///A test for FileExtension
        ///</summary>
        [TestMethod()]
        public void FileExtensionTest()
        {
            CcliUsrSongFileReader target = new CcliUsrSongFileReader(); // TODO: Initialize to an appropriate value
            string actual  = ".usr";
            actual = target.FileExtension;
            Assert.AreEqual(target.FileExtension, actual);
        }

        /// <summary>
        ///A test for FileTypeDescription
        ///</summary>
        [TestMethod()]
        public void FileTypeDescriptionTest()
        {
            CcliUsrSongFileReader target = new CcliUsrSongFileReader(); // TODO: Initialize to an appropriate value
            string actual = "SongSelect Import File";
            actual = target.FileTypeDescription;
            Assert.AreEqual(target.FileTypeDescription, actual);
        }
    }
}
