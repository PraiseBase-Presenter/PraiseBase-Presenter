using Microsoft.VisualStudio.TestTools.UnitTesting;
using PraiseBase.Presenter.Model.Statistics;
using PraiseBase.Presenter.Util;

namespace PraiseBase.Presenter.Persistence
{
    
    
    /// <summary>
    ///This is a test class for StatisticsWriterTest and is intended
    ///to contain all StatisticsWriterTest Unit Tests
    ///</summary>
    [TestClass]
    public class StatisticsWriterTest
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
        ///A test for Write
        ///</summary>
        [TestMethod]
        public void WriteTest()
        {
            StatisticsWriter target = new StatisticsWriter();
            string referenceFilename = "Resources/statistics/statistics.xml";
            string filename = "Resources/statistics/statistics-neu.xml";

            Statistics expected = new Statistics();

            var date = new StatisticsDate(2012, 12, 15);
            var item = new StatisticsItem
            {
                Type = StatisticsItemType.Song,
                Title = "You are so faithful",
                Copyright = "Musik & Copyright unbekannt",
                CcliId = "",
                Count = 1
            };
            date.Items.Add(item.Identifier, item);
            expected.Dates.Add(date.Identifier, date);

            date = new StatisticsDate(2013, 1, 6);

            item = new StatisticsItem
            {
                Type = StatisticsItemType.Song,
                Title = "A Mighty Fortress Is Our God",
                Copyright = "Public Domain",
                CcliId = "42964",
                Count = 2
            };
            date.Items.Add(item.Identifier, item);

            item = new StatisticsItem
            {
                Type = StatisticsItemType.Song,
                Title = "You are so faithful",
                Copyright = "Musik & Copyright unbekannt",
                CcliId = "",
                Count = 1
            };
            date.Items.Add(item.Identifier, item);

            expected.Dates.Add(date.Identifier, date);

            target.Write(filename, expected);

            Assert.IsTrue(FileUtils.FileEquals(filename, referenceFilename));

        }
    }
}
