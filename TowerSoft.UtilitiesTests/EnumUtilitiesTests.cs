using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerSoft.Utilities;
using TowerSoft.UtilitiesTests.Models;

namespace TowerSoft.UtilitiesTests {
    [TestClass]
    public class EnumUtilitiesTests {
        [TestMethod]
        public void GetEnumDisplayName_EnumWithDisplay_ReturnDisplayName() {
            string displayName = EnumUtilities.GetEnumDisplayName(TestEnum.Value1);

            Assert.AreEqual("Value 1", displayName);
        }

        [TestMethod]
        public void GetEnumDisplayName_EnumWithoutDisplay_ReturnName() {
            TestEnum testEnum = TestEnum.Value3;
            string displayName = EnumUtilities.GetEnumDisplayName(testEnum);

            Assert.AreEqual(testEnum.ToString(), displayName);
        }

        [TestMethod]
        public void EnumGetValues_ShouldReturnUnordered() {
            List<TestEnum> values = Enum.GetValues<TestEnum>().ToList();

            Assert.AreEqual(TestEnum.Value1, values[0]);
            Assert.AreEqual(TestEnum.Value2, values[1]);
            Assert.AreEqual(TestEnum.Value3, values[2]);
            Assert.AreEqual(TestEnum.Value5, values[3]);
            Assert.AreEqual(TestEnum.Value6, values[4]);
            Assert.AreEqual(TestEnum.Value4, values[5]);
        }

        [TestMethod]
        public void EnumGetOrderedValues_SortEnumValues() {
            List<TestEnum> values = EnumUtilities.EnumGetOrderedValues<TestEnum>();

            Assert.AreEqual(TestEnum.Value1, values[0]);
            Assert.AreEqual(TestEnum.Value2, values[1]);
            Assert.AreEqual(TestEnum.Value3, values[2]);
            Assert.AreEqual(TestEnum.Value4, values[3]);
            Assert.AreEqual(TestEnum.Value5, values[4]);
            Assert.AreEqual(TestEnum.Value6, values[5]);
        }
    }
}
