using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerSoft.Utilities;
using TowerSoft.Utilities.Enums;

namespace TowerSoft.UtilitiesTests {
    [TestClass]
    public class ByteInfoTests {
        [TestMethod]
        public void ByteInfoFromKilobytes_Binary() {
            ByteInfo bytes = ByteInfo.FromKilobytes(2);

            Assert.AreEqual(2048, bytes.Length);
        }

        [TestMethod]
        public void ByteInfoFromKilobytes_Decimal() {
            ByteInfo bytes = ByteInfo.FromKilobytes(2, DataUnitConversion.Decimal);

            Assert.AreEqual(2000, bytes.Length);
        }

        [TestMethod]
        public void ByteInfoFromMegabytes_Binary() {
            ByteInfo bytes = ByteInfo.FromMegabytes(2);

            Assert.AreEqual(2097152, bytes.Length);
        }

        [TestMethod]
        public void ByteInfoFromMegabytes_Decimal() {
            ByteInfo bytes = ByteInfo.FromMegabytes(2, DataUnitConversion.Decimal);

            Assert.AreEqual(2000000, bytes.Length);
        }

        [TestMethod]
        public void ByteInfoFromGigabytes_Binary() {
            ByteInfo bytes = ByteInfo.FromGigabytes(2);

            Assert.AreEqual(2147483648, bytes.Length);
        }

        [TestMethod]
        public void ByteInfoFromGigabytes_Decimal() {
            ByteInfo bytes = ByteInfo.FromGigabytes(2, DataUnitConversion.Decimal);
            Assert.AreEqual(2000000000, bytes.Length);
        }

        [TestMethod]
        public void ByteInfoFromTerabytes_Binary() {
            ByteInfo bytes = ByteInfo.FromTerabytes(2);

            Assert.AreEqual(1099511627776 * 2, bytes.Length);
        }

        [TestMethod]
        public void ByteInfoFromTerabytes_Decimal() {
            ByteInfo bytes = ByteInfo.FromTerabytes(2, DataUnitConversion.Decimal);
            Assert.AreEqual(2000000000000, bytes.Length);
        }

        [TestMethod]
        public void ByteInfoFromPetabytes_Binary() {
            ByteInfo bytes = ByteInfo.FromPetabytes(2);

            Assert.AreEqual(1125899906842624 * 2, bytes.Length);
        }

        [TestMethod]
        public void ByteInfoFromPetabytes_Decimal() {
            ByteInfo bytes = ByteInfo.FromPetabytes(2, DataUnitConversion.Decimal);
            Assert.AreEqual(2000000000000000, bytes.Length);
        }

        //public override string ToString() {

        //    //return base.ToString();
        //}
    }
}
