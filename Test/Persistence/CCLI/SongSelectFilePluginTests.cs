using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PraiseBase.Presenter.Persistence.CCLI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace PraiseBase.Presenter.Persistence.CCLI.Tests
{
    [TestClass()]
    public class SongSelectFilePluginTests
    {
        [TestMethod()]
        public void GetFileExtensionTest()
        {
            SongSelectFilePlugin target = new SongSelectFilePlugin();
            string actual = ".usr";
            actual = target.GetFileExtension();
            Assert.AreEqual(target.GetFileExtension(), actual);
        }

        [TestMethod()]
        public void GetFileTypeDescriptionTest()
        {
            SongSelectFilePlugin target = new SongSelectFilePlugin();
            string actual = "SongSelect Import File";
            actual = target.GetFileTypeDescription();
            Assert.AreEqual(target.GetFileTypeDescription(), actual);
        }
    }
}
