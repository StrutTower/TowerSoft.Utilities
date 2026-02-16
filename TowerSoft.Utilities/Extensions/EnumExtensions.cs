namespace TowerSoft.Utilities {
    /// <summary>
    /// Extension methods for Enums
    /// </summary>
    public static class EnumExtensions {
        /// <summary>
        /// Checks if the num is any of the supplied values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">Enum to test</param>
        /// <param name="values">Values to test against</param>
        public static bool IsAny<T>(this T value, params T[] values) where T : Enum {
            return values.Contains(value);
        }
    }
}
