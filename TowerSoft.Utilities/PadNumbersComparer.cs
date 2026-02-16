using System.Text.RegularExpressions;

namespace TowerSoft.Utilities {
    /// <summary>
    /// Compares string while padding any numbers with extra zeros to the left
    /// </summary>
    public partial class PadNumbersComparer : IComparer<string> {
        /// <summary></summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(string x, string y) {
            string paddedX = DigitRegex().Replace(x, match => match.Value.PadLeft(10, '0'));
            string paddedY = DigitRegex().Replace(y, match => match.Value.PadLeft(10, '0'));

            return paddedX.CompareTo(paddedY);
        }

        [GeneratedRegex("[0-9]+")]
        private static partial Regex DigitRegex();
    }
}
