namespace TowerSoft.Utilities {
    /// <summary>
    /// Helper methods for URIs
    /// </summary>
    public class UriHelper {
        /// <summary>
        /// Combines parts of a URL similar to System.IO.Path.Combine except for URLs.
        /// </summary>
        /// <param name="parts">Parts of the URL that will be separated by forward slashes.</param>
        public static Uri CombinePath(params object[] parts) {
            string url = string.Empty;

            for (int i = 0; i < parts.Length; i++) {
                string part = parts[i].ToString();

                if (i > 0 && !part.StartsWith('/')) {
                    part = "/" + part;
                }

                if (part.EndsWith('/')) {
                    part = part[..^1];
                }

                url += part;
            }
            return new Uri(url, UriKind.RelativeOrAbsolute);
        }
    }
}
