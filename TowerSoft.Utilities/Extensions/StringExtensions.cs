using System.Text.RegularExpressions;

namespace TowerSoft.Utilities {

    /// <summary>
    /// Extensions for strings
    /// </summary>
    public static partial class StringExtensions {

        [GeneratedRegex(@"(?<!^)(?=[A-Z])")]
        private static partial Regex CamelCaseSplitRegex();

        [GeneratedRegex("[a-zA-Z]*")]
        private static partial Regex TitleCaseRegex();

        /// <summary>
        /// Properly null checks the string before running the Trim method on the string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SafeTrim(this string str) {
            if (str == null) return null;
            return str.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="joinWord"></param>
        /// <returns></returns>
        public static string GrammarJoin(this IEnumerable<string> list, string joinWord) {
            if (!list.SafeAny()) return string.Empty;

            int count = list.Count();
            if (count == 1)
                return list.First().ToString();
            if (count == 2)
                return $"{list.First()} {joinWord} {list.Last()}";
            return string.Join(", ", list.SkipLast(1)) + $", {joinWord} {list.Last()}";
        }

        /// <summary>
        /// Splits a string by capital letter and adds spaces. Example "TestObject = "Test Object"
        /// </summary>
        /// <param name="source">Original title case string</param>
        /// <returns></returns>
        public static string SplitCamelCase(this string source) {
            string[] list;
            string output = null;

            list = CamelCaseSplitRegex().Split(source);

            if (list != null) {
                foreach (string s in list) {
                    output += s + " ";
                }
                output = output[..^1];
            }
            return output;
        }

        /// <summary>
        /// Convert the input to proper title casing. Divides the input by spaces, hyphens, and forward slashes<br/>
        /// Default lowercase words: for, and, nor, but, or, yet, so
        /// </summary>
        /// <param name="input">string to convert</param>
        /// <returns></returns>
        public static string ToTitleCase(this string input) {
            return ToTitleCase(input, null, ["for", "and", "nor", "but", "or", "yet", "so"]);
        }

        /// <summary>
        /// Convert the input to proper title casing. Divides the input by spaces, hyphens, and forward slashes.<br/>
        /// Default lowercase words: for, and, nor, but, or, yet, so
        /// </summary>
        /// <param name="input">string to convert</param>
        /// <param name="uppercaseList">List of wars to convert to all uppercase letters</param>
        /// <returns></returns>
        public static string ToTitleCase(this string input, IEnumerable<string> uppercaseList) {
            return ToTitleCase(input, uppercaseList, ["for", "and", "nor", "but", "or", "yet", "so"]);
        }

        /// <summary>
        /// Convert the input to proper title casing. Divides the input by spaces, hyphens, and forward slashes
        /// </summary>
        /// <param name="input">string to convert</param>
        /// <param name="uppercaseList">List of wars to convert to all uppercase letters</param>
        /// <param name="lowercaseList">List of wars to convert to all lowercase letters</param>
        /// <returns>Title cased string</returns>
        public static string ToTitleCase(this string input, IEnumerable<string> uppercaseList, IEnumerable<string> lowercaseList) {
            if (uppercaseList != null)
                uppercaseList = uppercaseList.Select(x => x.ToUpper());
            if (lowercaseList != null)
                lowercaseList = lowercaseList.Select(x => x.ToLower());

            string output = TitleCaseRegex().Replace(input, delegate (Match match) {
                if (uppercaseList != null && uppercaseList.Contains(match.Value.ToUpper())) {
                    return match.Value.ToUpper();
                } else if (lowercaseList != null && lowercaseList.Contains(match.Value.ToLower()) && match.Index != 0) {
                    return match.Value.ToLower();
                } else {
                    if (match.Value.Length > 1)
                        return char.ToUpper(match.Value[0]) + match.Value[1..].ToLower();
                    else if (match.Value.Length == 1)
                        return char.ToUpper(match.Value[0]).ToString();
                    else
                        return string.Empty;
                }
            });
            return output;
        }
    }
}
