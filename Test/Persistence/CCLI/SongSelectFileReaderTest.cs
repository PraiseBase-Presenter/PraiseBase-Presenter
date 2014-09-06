using PraiseBase.Presenter.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.CCLI
{
    
    
    /// <summary>
    ///This is a test class for CcliUsrSongFileReaderTest and is intended
    ///to contain all CcliUsrSongFileReaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SongSelectFileReaderTest
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
        ///A test for IsFileSupported
        ///</summary>
        [TestMethod()]
        public void IsFileSupportedTest()
        {
            SongSelectFileReader target = new SongSelectFileReader(); // TODO: Initialize to an appropriate value
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
            SongSelectFileReader reader = new SongSelectFileReader();
            string filename = "ccli/Ein Lied für Gott.usr";

            SongSelectFile expected = new SongSelectFile();

            expected.Title = "Ein Lied für Gott";
            expected.Themes.Add("Celebration");
            expected.Themes.Add("God's Attributes");
            expected.Themes.Add("Love");
            expected.Themes.Add("Joy");
            expected.Author = "Muster, Hans";
            expected.Copyright = "Gemeinfrei (Public Domain)";
            expected.Admin = "Verlag ABC";
            expected.Key = "E";

            var part = new SongSelectVerse();
            part.Caption = "Vers 1";
            part.Lines.Add("Lorem ipsum dolor sit amet,");
            part.Lines.Add("consectetur adipiscing elit.");
            part.Lines.Add("Vivamus odio massa,");
            part.Lines.Add("lacinia in mollis quis,");
            part.Lines.Add("vehicula sed justo");
            expected.Verses.Add(part);

            part = new SongSelectVerse();
            part.Caption = "Vers 2";
            part.Lines.Add("Nunc cursus libero non quam lobortis");
            part.Lines.Add("ac pharetra leo facilisis.");
            part.Lines.Add("Proin tortor tellus,");
            part.Lines.Add("fermentum mattis euismod eu,");
            part.Lines.Add("faucibus vel justo.");
            expected.Verses.Add(part);

            part = new SongSelectVerse();
            part.Caption = "Vers 3";
            part.Lines.Add("Fusce pellentesque rhoncus felis,");
            part.Lines.Add("eu convallis ante tempus a.");
            part.Lines.Add("Cum sociis natoque penatibus");
            part.Lines.Add("et magnis dis parturient montes,");
            part.Lines.Add("nascetur ridiculus mus.");
            expected.Verses.Add(part);

            SongSelectFile actual = reader.Load(filename);
            Assert.AreEqual(expected.Title, actual.Title, "Wrong song title");
            Assert.AreEqual(expected.Author, actual.Author, "Wrong song title");
            Assert.AreEqual(expected.Copyright, actual.Copyright, "Wrong copyright");
            Assert.AreEqual(expected.Admin, actual.Admin, "Wrong RightsManagement");
            Assert.AreEqual(expected.Key, actual.Key, "Wrong key");
            CollectionAssert.AreEqual(expected.Themes, actual.Themes, "Wrong themes");

            Assert.AreEqual(expected.Verses.Count, actual.Verses.Count, "Verses incomplete");
            for (int i = 0; i < expected.Verses.Count; i++)
            {
                Assert.AreEqual(expected.Verses[i].Caption, actual.Verses[i].Caption, "Wrong verse name in verse " + i);
                CollectionAssert.AreEqual(expected.Verses[i].Lines, actual.Verses[i].Lines, "Verse lines incomplete in verse " + i);
            }
        }

        /// <summary>
        ///A test for ReadTitle
        ///</summary>
        [TestMethod()]
        public void ReadTitleTest()
        {
            SongSelectFileReader reader = new SongSelectFileReader();
            Assert.AreEqual("Ein Lied für Gott", reader.ReadTitle("ccli/Ein Lied für Gott.usr"));
            Assert.IsNull(reader.ReadTitle("ccli/non-existing-file.usr"));
        }

        /// <summary>
        ///A test for FileExtension
        ///</summary>
        [TestMethod()]
        public void FileExtensionTest()
        {
            SongSelectFileReader target = new SongSelectFileReader(); // TODO: Initialize to an appropriate value
            string actual  = ".usr";
            actual = target.GetFileExtension();
            Assert.AreEqual(target.GetFileExtension(), actual);
        }

        /// <summary>
        ///A test for FileTypeDescription
        ///</summary>
        [TestMethod()]
        public void FileTypeDescriptionTest()
        {
            SongSelectFileReader target = new SongSelectFileReader(); // TODO: Initialize to an appropriate value
            string actual = "SongSelect Import File";
            actual = target.GetFileTypeDescription();
            Assert.AreEqual(target.GetFileTypeDescription(), actual);
        }
    }
}
