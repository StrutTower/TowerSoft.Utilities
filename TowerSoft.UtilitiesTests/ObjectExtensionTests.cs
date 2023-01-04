using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TowerSoft.Utilities;
using TowerSoft.UtilitiesTests.Models;

namespace TowerSoft.UtilitiesTests {
    [TestClass]
    public class ObjectExtensionTests {
        [TestMethod]
        public void TrimProperties_TestObject_ShouldTrimStrings() {
            DateTime now = DateTime.Now;

            TestObject model = new() {
                String = " test ",
                Integer = 1,
                Boolean = true,
                DateTime = now
            };

            model.TrimProperties();

            Assert.AreEqual("test", model.String);
            Assert.AreEqual(null, model.NullString);
            Assert.AreEqual(1, model.Integer);
            Assert.AreEqual(true, model.Boolean);
            Assert.AreEqual(now, model.DateTime);
        }
    }
}
