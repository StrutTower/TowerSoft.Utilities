using Microsoft.VisualStudio.TestTools.UnitTesting;
using TowerSoft.Utilities.Extensions;

namespace TowerSoft.UtilitiesTests {
    [TestClass]
    public class TimeSpanExtensionsTests {
        #region LongString Basic
        [TestMethod]
        public void ToLongString_Days_Plural() {
            TimeSpan timeSpan = TimeSpan.Parse("52.4:34:56");
            Assert.AreEqual("52 days, 4 hours, 34 minutes, 56 seconds", timeSpan.ToLongString());
        }

        [TestMethod]
        public void ToLongString_Days_Singular() {
            TimeSpan timeSpan = TimeSpan.Parse("1.1:1:1");
            Assert.AreEqual("1 day, 1 hour, 1 minute, 1 second", timeSpan.ToLongString());
        }

        [TestMethod]
        public void ToLongString_Hours_Plural() {
            TimeSpan timeSpan = TimeSpan.Parse("4:34:56");
            Assert.AreEqual("4 hours, 34 minutes, 56 seconds", timeSpan.ToLongString());
        }

        [TestMethod]
        public void ToLongString_Hours_Singular() {
            TimeSpan timeSpan = TimeSpan.Parse("1:1:1");
            Assert.AreEqual("1 hour, 1 minute, 1 second", timeSpan.ToLongString());
        }

        [TestMethod]
        public void ToLongString_Minutes_Plural() {
            TimeSpan timeSpan = TimeSpan.FromMinutes(34).Add(TimeSpan.FromSeconds(56));
            Assert.AreEqual("34 minutes, 56 seconds", timeSpan.ToLongString());
        }

        [TestMethod]
        public void ToLongString_Minutes_Singular() {
            TimeSpan timeSpan = TimeSpan.FromMinutes(1).Add(TimeSpan.FromSeconds(1));
            Assert.AreEqual("1 minute, 1 second", timeSpan.ToLongString());
        }

        [TestMethod]
        public void ToLongString_Seconds_Plural() {
            TimeSpan timeSpan = TimeSpan.FromSeconds(56);
            Assert.AreEqual("56 seconds", timeSpan.ToLongString());
        }

        [TestMethod]
        public void ToLongString_Seconds_Singular() {
            TimeSpan timeSpan = TimeSpan.FromSeconds(1);
            Assert.AreEqual("1 second", timeSpan.ToLongString());
        }

        [TestMethod]
        public void ToLongString_ZeroSeconds() {
            TimeSpan timeSpan = TimeSpan.FromSeconds(0);
            Assert.AreEqual("0 seconds", timeSpan.ToLongString());
        }
        #endregion

        #region LongString with missing parts
        [TestMethod]
        public void ToLongString_DaysWithOutTime_Plural() {
            TimeSpan timeSpan = TimeSpan.FromDays(3);
            Assert.AreEqual("3 days", timeSpan.ToLongString());
        }

        [TestMethod]
        public void ToLongString_DaysWithOutTime_Singular() {
            TimeSpan timeSpan = TimeSpan.FromDays(1);
            Assert.AreEqual("1 day", timeSpan.ToLongString());
        }

        [TestMethod]
        public void ToLongString_HoursWithOutSeconds_Plural() {
            TimeSpan timeSpan = TimeSpan.FromHours(3).Add(TimeSpan.FromMinutes(30));
            Assert.AreEqual("3 hours, 30 minutes", timeSpan.ToLongString());
        }

        [TestMethod]
        public void ToLongString_HoursWithOutSeconds_Singular() {
            TimeSpan timeSpan = TimeSpan.FromDays(1).Add(TimeSpan.FromMinutes(1));
            Assert.AreEqual("1 day, 1 minute", timeSpan.ToLongString());
        }
        #endregion


        #region ShortString Basic
        [TestMethod]
        public void ToShortString_Days_Plural() {
            TimeSpan timeSpan = TimeSpan.Parse("52.4:34:56");
            Assert.AreEqual("52d, 4h, 34m, 56s", timeSpan.ToShortString());
        }

        [TestMethod]
        public void ToShortString_Days_Singular() {
            TimeSpan timeSpan = TimeSpan.Parse("1.1:1:1");
            Assert.AreEqual("1d, 1h, 1m, 1s", timeSpan.ToShortString());
        }

        [TestMethod]
        public void ToShortString_Hours_Plural() {
            TimeSpan timeSpan = TimeSpan.Parse("4:34:56");
            Assert.AreEqual("4h, 34m, 56s", timeSpan.ToShortString());
        }

        [TestMethod]
        public void ToShortString_Hours_Singular() {
            TimeSpan timeSpan = TimeSpan.Parse("1:1:1");
            Assert.AreEqual("1h, 1m, 1s", timeSpan.ToShortString());
        }

        [TestMethod]
        public void ToShortString_Minutes_Plural() {
            TimeSpan timeSpan = TimeSpan.FromMinutes(34).Add(TimeSpan.FromSeconds(56));
            Assert.AreEqual("34m, 56s", timeSpan.ToShortString());
        }

        [TestMethod]
        public void ToShortString_Minutes_Singular() {
            TimeSpan timeSpan = TimeSpan.FromMinutes(1).Add(TimeSpan.FromSeconds(1));
            Assert.AreEqual("1m, 1s", timeSpan.ToShortString());
        }

        [TestMethod]
        public void ToShortString_Seconds_Plural() {
            TimeSpan timeSpan = TimeSpan.FromSeconds(56);
            Assert.AreEqual("56s", timeSpan.ToShortString());
        }

        [TestMethod]
        public void ToShortString_Seconds_Singular() {
            TimeSpan timeSpan = TimeSpan.FromSeconds(1);
            Assert.AreEqual("1s", timeSpan.ToShortString());
        }

        [TestMethod]
        public void ToShortString_ZeroSeconds() {
            TimeSpan timeSpan = TimeSpan.FromSeconds(0);
            Assert.AreEqual("0s", timeSpan.ToShortString());
        }
        #endregion

        #region ShortString with missing parts
        [TestMethod]
        public void ToShortString_DaysWithOutTime_Plural() {
            TimeSpan timeSpan = TimeSpan.FromDays(3);
            Assert.AreEqual("3d", timeSpan.ToShortString());
        }

        [TestMethod]
        public void ToShortString_DaysWithOutTime_Singular() {
            TimeSpan timeSpan = TimeSpan.FromDays(1);
            Assert.AreEqual("1d", timeSpan.ToShortString());
        }

        [TestMethod]
        public void ToShortString_HoursWithOutSeconds_Plural() {
            TimeSpan timeSpan = TimeSpan.FromHours(3).Add(TimeSpan.FromMinutes(30));
            Assert.AreEqual("3h, 30m", timeSpan.ToShortString());
        }

        [TestMethod]
        public void ToShortString_HoursWithOutSeconds_Singular() {
            TimeSpan timeSpan = TimeSpan.FromDays(1).Add(TimeSpan.FromMinutes(1));
            Assert.AreEqual("1d, 1m", timeSpan.ToShortString());
        }
        #endregion


        #region RoundedString
        [TestMethod]
        public void ToRoundedString_Years_Plural() {
            TimeSpan timeSpan = TimeSpan.Parse("52.4:34:56").Add(TimeSpan.FromDays(1100));
            Assert.AreEqual("3 years ago", timeSpan.ToRoundedString());
        }

        [TestMethod]
        public void ToRoundedString_Years_Singular() {
            TimeSpan timeSpan = TimeSpan.Parse("52.4:34:56").Add(TimeSpan.FromDays(365));
            Assert.AreEqual("1 year ago", timeSpan.ToRoundedString());
        }

        [TestMethod]
        public void ToRoundedString_Days_Plural() {
            TimeSpan timeSpan = TimeSpan.Parse("52.4:34:56");
            Assert.AreEqual("52 days ago", timeSpan.ToRoundedString());
        }

        [TestMethod]
        public void ToRoundedString_Days_Singular() {
            TimeSpan timeSpan = TimeSpan.Parse("1.1:1:1");
            Assert.AreEqual("1 day ago", timeSpan.ToRoundedString());
        }

        [TestMethod]
        public void ToRoundedString_Hours_Plural() {
            TimeSpan timeSpan = TimeSpan.Parse("4:34:56");
            Assert.AreEqual("4 hours ago", timeSpan.ToRoundedString());
        }

        [TestMethod]
        public void ToRoundedString_Hours_Singular() {
            TimeSpan timeSpan = TimeSpan.Parse("1:1:1");
            Assert.AreEqual("1 hour ago", timeSpan.ToRoundedString());
        }

        [TestMethod]
        public void ToRoundedString_Minutes_Plural() {
            TimeSpan timeSpan = TimeSpan.FromMinutes(34).Add(TimeSpan.FromSeconds(56));
            Assert.AreEqual("34 minutes ago", timeSpan.ToRoundedString());
        }

        [TestMethod]
        public void ToRoundedString_Minutes_Singular() {
            TimeSpan timeSpan = TimeSpan.FromMinutes(1).Add(TimeSpan.FromSeconds(1));
            Assert.AreEqual("1 minute ago", timeSpan.ToRoundedString());
        }

        [TestMethod]
        public void ToRoundedString_Seconds_Plural() {
            TimeSpan timeSpan = TimeSpan.FromSeconds(56);
            Assert.AreEqual("56 seconds ago", timeSpan.ToRoundedString());
        }

        [TestMethod]
        public void ToRoundedString_Seconds_Singular() {
            TimeSpan timeSpan = TimeSpan.FromSeconds(5);
            Assert.AreEqual("Right now", timeSpan.ToRoundedString());
        }

        [TestMethod]
        public void ToRoundedString_ZeroSeconds() {
            TimeSpan timeSpan = TimeSpan.FromSeconds(0);
            Assert.AreEqual("Right now", timeSpan.ToRoundedString());
        }
        #endregion
    }
}
