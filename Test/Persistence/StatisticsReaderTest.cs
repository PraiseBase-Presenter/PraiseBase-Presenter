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
        ///A test for Read
        ///</summary>
        [TestMethod]
        public void ReadTest()
        {
            StatisticsReader target = new StatisticsReader();
            string filename = "Resources/statistics/statistics.xml";
            
            Statistics expected = new Statistics();

            StatisticsDate date;
            StatisticsItem item;

            date = new StatisticsDate(2012, 12, 15);
            item = new StatisticsItem();
            item.Type = StatisticsItemType.Song;
            item.Title = "You are so faithful";
            item.Copyright = "Musik & Copyright unbekannt";
            item.CcliID = "";
            item.Count = 1;
            date.Items.Add(item.ID, item);
            expected.Dates.Add(date.ID, date);

            date = new StatisticsDate(2013, 1, 6);

            item = new StatisticsItem();
            item.Type = StatisticsItemType.Song;
            item.Title = "A Mighty Fortress Is Our God";
            item.Copyright = "Public Domain";
            item.CcliID = "42964";
            item.Count = 2;
            date.Items.Add(item.ID, item);

            item = new StatisticsItem();
            item.Type = StatisticsItemType.Song;
            item.Title = "You are so faithful";
            item.Copyright = "Musik & Copyright unbekannt";
            item.CcliID = "";
            item.Count = 1;
            date.Items.Add(item.ID, item);
            
            expected.Dates.Add(date.ID, date);

            Statistics actual = target.read(filename);

            foreach (var edate in expected.Dates)
            {
                Assert.AreEqual(edate.Value.ID, actual.Dates[edate.Key].ID);
                Assert.AreEqual(edate.Value.Year, actual.Dates[edate.Key].Year);
                Assert.AreEqual(edate.Value.Month, actual.Dates[edate.Key].Month);
                Assert.AreEqual(edate.Value.Day, actual.Dates[edate.Key].Day);
                Assert.AreEqual(edate.Value.Items.Count, actual.Dates[edate.Key].Items.Count);
                foreach (var eitem in edate.Value.Items)
                {
                    Assert.AreEqual(eitem.Value.CcliID, actual.Dates[edate.Key].Items[eitem.Key].CcliID);
                    Assert.AreEqual(eitem.Value.Title, actual.Dates[edate.Key].Items[eitem.Key].Title);
                    Assert.AreEqual(eitem.Value.Copyright, actual.Dates[edate.Key].Items[eitem.Key].Copyright);
                    Assert.AreEqual(eitem.Value.Count, actual.Dates[edate.Key].Items[eitem.Key].Count);
                    Assert.AreEqual(eitem.Value.Type, actual.Dates[edate.Key].Items[eitem.Key].Type);
                }
            }

        }
    }
}
