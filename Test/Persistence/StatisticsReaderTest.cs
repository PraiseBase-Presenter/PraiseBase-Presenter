using Microsoft.VisualStudio.TestTools.UnitTesting;
using PraiseBase.Presenter.Model.Statistics;

namespace PraiseBase.Presenter.Persistence
{
    
    
    /// <summary>
    ///This is a test class for StatisticsReaderTest and is intended
    ///to contain all StatisticsReaderTest Unit Tests
    ///</summary>
    [TestClass]
    public class StatisticsReaderTest
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
        ///A test for Read
        ///</summary>
        [TestMethod]
        public void ReadTest()
        {
            StatisticsReader target = new StatisticsReader();
            string filename = "Resources/statistics/statistics.xml";
            
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

            Statistics actual = target.read(filename);

            foreach (var edate in expected.Dates)
            {
                Assert.AreEqual(edate.Value.Identifier, actual.Dates[edate.Key].Identifier);
                Assert.AreEqual(edate.Value.Year, actual.Dates[edate.Key].Year);
                Assert.AreEqual(edate.Value.Month, actual.Dates[edate.Key].Month);
                Assert.AreEqual(edate.Value.Day, actual.Dates[edate.Key].Day);
                Assert.AreEqual(edate.Value.Items.Count, actual.Dates[edate.Key].Items.Count);
                foreach (var eitem in edate.Value.Items)
                {
                    Assert.AreEqual(eitem.Value.CcliId, actual.Dates[edate.Key].Items[eitem.Key].CcliId);
                    Assert.AreEqual(eitem.Value.Title, actual.Dates[edate.Key].Items[eitem.Key].Title);
                    Assert.AreEqual(eitem.Value.Copyright, actual.Dates[edate.Key].Items[eitem.Key].Copyright);
                    Assert.AreEqual(eitem.Value.Count, actual.Dates[edate.Key].Items[eitem.Key].Count);
                    Assert.AreEqual(eitem.Value.Type, actual.Dates[edate.Key].Items[eitem.Key].Type);
                }
            }

        }
    }
}
