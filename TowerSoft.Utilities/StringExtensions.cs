namespace TowerSoft.Utilities {
    /// <summary>
    /// Extensions for strings
    /// </summary>
    public static class StringExtensions {
        /// <summary>
        /// Properly null checks the string before running the Trim method on the string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string? SafeTrim(this string? str) {
            if (str == null) return null;
            return str.Trim();
        }
    }
}
