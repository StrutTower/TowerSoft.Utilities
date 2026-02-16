using Microsoft.VisualStudio.TestTools.UnitTesting;
using TowerSoft.Utilities;

namespace TowerSoft.UtilitiesTests {
    [TestClass]
    public class PadNumbersComparerTests {
        [TestMethod]
        public void OrderBy_ShouldOrderWithoutLeadingZeros() {
            string[] array = ["test3", "test20", "test21", "test2", "test1"];

            var orderedArray = array.OrderBy(x => x, new PadNumbersComparer());

            Assert.AreEqual("test21", orderedArray.Last());
        }
    }
}
