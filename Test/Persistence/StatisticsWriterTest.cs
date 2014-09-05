using PraiseBase.Presenter.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PraiseBase.Presenter.Model.Statistics;
using System.IO;

namespace PraiseBase.Presenter.Persistence
{
    
    
    /// <summary>
    ///This is a test class for StatisticsWriterTest and is intended
    ///to contain all StatisticsWriterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StatisticsWriterTest
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
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            StatisticsWriter target = new StatisticsWriter();
            string referenceFilename = "statistics/statistics.xml";
            string filename = "statistics/statistics-neu.xml";

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

            target.Write(filename, expected);

            Assert.IsTrue(PraiseBase.Presenter.Util.FileUtils.FileEquals(filename, referenceFilename));

        }
    }
}
