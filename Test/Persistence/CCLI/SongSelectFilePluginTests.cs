using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PraiseBase.Presenter.Persistence.CCLI
{
    [TestClass]
    public class SongSelectFilePluginTests
    {
        [TestMethod]
        public void GetFileExtensionTest()
        {
            SongSelectFilePlugin target = new SongSelectFilePlugin();
            const string expected = ".usr";
            string actual = target.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileTypeDescriptionTest()
        {
            SongSelectFilePlugin target = new SongSelectFilePlugin();
            const string expected = "SongSelect Import File";
            string actual = target.GetFileTypeDescription();
            Assert.AreEqual(expected, actual);
        }
    }
}
