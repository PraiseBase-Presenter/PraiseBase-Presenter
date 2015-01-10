using PraiseBase.Presenter.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Model;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    
    
    /// <summary>
    ///This is a test class for PowerPraiseSongFileWriterTest and is intended
    ///to contain all PowerPraiseSongFileWriterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExtendedSongFileWriterTest
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
        ///A test for Save
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            SongFileWriter target = new ExtendedSongFileWriter();
            string referenceFilename = "Resources/powerpraise/Näher, mein Gott zu Dir.ppl";
            string filename = "Resources/powerpraise/Näher, mein Gott zu Dir - neu - extended.ppl";

            Song sng = PowerPraiseTestUtil.GetExpectedSong();

            target.Save(filename, sng);

            try {
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
            SongFileWriter target = new ExtendedSongFileWriter(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetFileTypeDescription();
            Assert.AreEqual(actual, "PowerPraise Lied");
        }

        /// <summary>
        ///A test for FileExtension
        ///</summary>
        [TestMethod()]
        public void FileExtensionTest()
        {
            SongFileWriter target = new ExtendedSongFileWriter(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetFileExtension();
            Assert.AreEqual(actual, ".ppl");
        }

        [TestMethod()]
        public void WriteUsingMapperSaveTest()
        {
            SongFileMapper<PowerPraiseSong> mapper = new PowerPraiseSongFileMapper();
            ISongFileWriter<PowerPraiseSong> writer = new PowerPraiseSongFileWriter();
            string referenceFilename = "Resources/powerpraise/Näher, mein Gott zu Dir.ppl";
            string filename = "Resources/powerpraise/Näher, mein Gott zu Dir - neu - extended2.ppl";

            Song sng = PowerPraiseTestUtil.GetExpectedSong();;
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
