using PraiseBase.Presenter.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PraiseBase.Presenter.Model;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    
    
    /// <summary>
    ///This is a test class for PowerPraiseSongFileWriterTest and is intended
    ///to contain all PowerPraiseSongFileWriterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExtendedPowerPraiseSongFileWriterTest
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
            ISongFileWriter<ExtendedPowerPraiseSong> target = new ExtendedPowerPraiseSongFileWriter();
            string referenceFilename = "powerpraise/Näher, mein Gott zu Dir - extended.ppl";
            string filename = "powerpraise/Näher, mein Gott zu Dir - extended - out.ppl";

            ExtendedPowerPraiseSong sng = PowerPraiseTestUtil.GetExpectedExtendedPowerPraiseSong();

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
            ISongFileWriter<ExtendedPowerPraiseSong> target = new ExtendedPowerPraiseSongFileWriter();
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
            ISongFileWriter<ExtendedPowerPraiseSong> target = new ExtendedPowerPraiseSongFileWriter();
            string actual;
            actual = target.GetFileExtension();
            Assert.AreEqual(actual, ".ppl");
        }
    }
}
