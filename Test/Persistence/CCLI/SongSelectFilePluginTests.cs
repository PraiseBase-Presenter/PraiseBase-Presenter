using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PraiseBase.Presenter.Persistence.CCLI
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
