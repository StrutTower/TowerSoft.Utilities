using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TowerSoft.Utilities;
using TowerSoft.UtilitiesTests.Models;

namespace TowerSoft.UtilitiesTests {
    [TestClass]
    public class EnumerableExtensionTests {
        [TestMethod]
        public void SafeAny_FilledList_ShouldReturnTrue() {
            List<string> list = new() { "test1", "test2" };

            bool result = list.SafeAny();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SafeAny_EmptyList_ShouldReturnFalse() {
            List<string> list = new();

            bool result = list.SafeAny();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SafeAny_NullList_ShouldReturnFalse() {
            List<string>? list = null;

            bool result = list.SafeAny();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SafeAnyPredicate_ShouldReturnTrue() {
            var testObjects = GetTestObjects();

            Assert.IsTrue(testObjects.SafeAny(x => !x.Boolean));
            Assert.IsTrue(testObjects.SafeAny(x => x.DateTime.Ticks == new DateTime(2020, 1, 1).Ticks));
            Assert.IsTrue(testObjects.SafeAny(x => x.Integer == 1));
        }

        [TestMethod]
        public void SafeAnyPredicate_ShouldReturnFalse() {
            var testObjects = GetTestObjects();

            Assert.IsFalse(testObjects.SafeAny(x => x.Boolean));
            Assert.IsFalse(testObjects.SafeAny(x => x.DateTime == new DateTime(1900, 1, 1)));
            Assert.IsFalse(testObjects.SafeAny(x => x.Integer == -5));
        }

        [TestMethod]
        public void Batch_50_ShouldReturn10Batches() {
            var testObjects = GetTestObjects(480);

            var batches = testObjects.Batch(50);

            Assert.AreEqual(10, batches.Count());
        }

        [TestMethod]
        public void IsOfType_ShouldMatch() {
            List<TestObject> list = new List<TestObject>();

            Assert.IsTrue(list.IsOfType(typeof(TestObject)));
        }

        [TestMethod]
        public void IsOfType_ShouldNotMatch() {
            List<string> list = new List<string>();

            Assert.IsFalse(list.IsOfType(typeof(TestObject)));
        }

        // --- Helpers ---
        private List<TestObject> GetTestObjects(int count = 3) {
            List<TestObject> testObjects = new();
            for (int i = 0; i < count; i++) {
                testObjects.Add(new() {
                    String = $"test{i}",
                    Boolean = false,
                    DateTime = new DateTime(2020, 1, 1),
                    Integer = i
                });
            }
            return testObjects;
        }
    }
}