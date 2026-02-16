using Microsoft.VisualStudio.TestTools.UnitTesting;
using TowerSoft.Utilities;

namespace TowerSoft.UtilitiesTests {
    [TestClass]
    public class UriExtensionsTests {
        [TestMethod]
        public void UriExtensions_AddQuery() {
            Uri uri = new("https://www.google.com/search");
            uri = uri.AddQuery("q", "github");

            Assert.AreEqual("https://www.google.com/search?q=github", uri.ToString());

            uri = uri.AddQuery("num", 5);

            Assert.AreEqual("https://www.google.com/search?q=github&num=5", uri.ToString());
        }

        [TestMethod]
        public void UriExtensions_RemoveQueryString() {
            Uri uri = new("https://www.google.com/search?q=github&num=5");

            uri = uri.RemoveQuery("num");

            Assert.AreEqual("https://www.google.com/search?q=github", uri.ToString());

            uri = uri.RemoveQuery("q");

            Assert.AreEqual("https://www.google.com/search", uri.ToString());
        }
    }
}
