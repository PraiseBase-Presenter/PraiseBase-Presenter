using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    [TestClass()]
    public class PowerPraiseFileUtilTest
    {
        [TestMethod()]
        public void ConvertColorTest()
        {
            // PowerPraise Colors

            // Black
            Assert.AreEqual(Color.FromArgb(255, 0, 0, 0), PowerPraiseFileUtil.ConvertColor(0));

            // Red
            Assert.AreEqual(Color.FromArgb(255, 255, 0, 0), PowerPraiseFileUtil.ConvertColor(255));

            // Green
            Assert.AreEqual(Color.FromArgb(255, 0, 255, 0), PowerPraiseFileUtil.ConvertColor(65280));

            // Blue
            Assert.AreEqual(Color.FromArgb(255, 0, 0, 255), PowerPraiseFileUtil.ConvertColor(16711680));

            // White
            Assert.AreEqual(Color.FromArgb(255, 255, 255, 255), PowerPraiseFileUtil.ConvertColor(16777215));
        }

        [TestMethod()]
        public void ConvertColorTest1()
        {
            // Black
            Assert.AreEqual(0, PowerPraiseFileUtil.ConvertColor(Color.FromArgb(255, 0, 0, 0)));

            // Red
            Assert.AreEqual(255, PowerPraiseFileUtil.ConvertColor(Color.FromArgb(255, 255, 0, 0)));

            // Green
            Assert.AreEqual(65280, PowerPraiseFileUtil.ConvertColor(Color.FromArgb(255, 0, 255, 0)));

            // Blue
            Assert.AreEqual(16711680, PowerPraiseFileUtil.ConvertColor(Color.FromArgb(255, 0, 0, 255)));

            // White
            Assert.AreEqual(16777215, PowerPraiseFileUtil.ConvertColor(Color.FromArgb(255, 255, 255, 255)));
        }
    }
}
