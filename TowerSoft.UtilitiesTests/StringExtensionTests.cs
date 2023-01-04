using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerSoft.Utilities;

namespace TowerSoft.UtilitiesTests {
    [TestClass]
    public class StringExtensionTests {
        [TestMethod]
        public void SafeTrim_TrailingSpaces_ShouldTrim() {
            string t = "  test  ";
            string? actual = t.SafeTrim();

            Assert.AreEqual("test", actual);
        }

        [TestMethod]
        public void SafeTrim_BlankString_ShouldReturnBlankString() {
            string? t = "";
            string? actual = t.SafeTrim();

            Assert.AreEqual("", actual);
        }

        [TestMethod]
        public void SafeTrim_WhiteSpace_ShouldReturnBlankString() {
            string? t = "   ";
            string? actual = t.SafeTrim();

            Assert.AreEqual("", actual);
        }

        [TestMethod]
        public void SafeTrim_NullString_ShouldReturnNull() {
            string? t = null;
            string? actual = t.SafeTrim();

            Assert.IsNull(actual);
        }
    }
}
