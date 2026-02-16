using System.Collections.Specialized;

namespace TowerSoft.Utilities {
    /// <summary>URI Extensions Methods</summary>
    public static class UriExtensions {
        /// <summary>
        /// Add a query string parameter to the URI
        /// </summary>
        /// <param name="uri">URI</param>
        /// <param name="key">Name of the query parameter</param>
        /// <param name="value">Value of the query parameter. The value will be taken from the ToString() method.</param>
        /// <returns>The modified URI</returns>
        public static Uri AddQuery(this Uri uri, string key, object value) {
            string[] parts = uri.ToString().Split('?', 2);

            string url = parts[0];
            string query = parts.Length > 1 ? parts[1] : null;
            NameValueCollection collection = GetExistingQueryString(query);

            // Add the new value to the collection
            if (value == null)
                collection.Add(key, null);
            else
                collection.Add(key, value.ToString());

            string queryString = BuildQueryString(collection);
            if (!string.IsNullOrWhiteSpace(queryString))
                return new Uri($"{url}?{queryString}", UriKind.RelativeOrAbsolute);
            return new Uri(url, UriKind.RelativeOrAbsolute);
        }

        /// <summary>
        /// Removes a query string parameter from the URI
        /// </summary>
        /// <param name="uri">URI</param>
        /// <param name="key">Name of the query parameter to remove</param>
        /// <returns>The modified URI</returns>
        public static Uri RemoveQuery(this Uri uri, string key) {
            string[] parts = uri.ToString().Split('?', 2);

            string url = parts[0];
            string query = parts.Length > 1 ? parts[1] : null;
            NameValueCollection collection = GetExistingQueryString(query);

            // Remove the key and it's value from the collection
            collection.Remove(key);

            string queryString = BuildQueryString(collection);

            if (!string.IsNullOrWhiteSpace(queryString))
                return new Uri($"{url}?{queryString}", UriKind.RelativeOrAbsolute);
            return new Uri(url, UriKind.RelativeOrAbsolute);
        }

        private static NameValueCollection GetExistingQueryString(string queryString) {
            NameValueCollection collection = [];

            if (!string.IsNullOrWhiteSpace(queryString)) {
                foreach (string queryPart in queryString.Split('&', StringSplitOptions.RemoveEmptyEntries)) {
                    string[] keyValue = queryPart.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    if (keyValue.Length > 1)
                        collection.Add(keyValue[0], keyValue[1]);
                    else
                        collection.Add(keyValue[0], null);
                }
            }

            return collection;
        }

        private static string BuildQueryString(NameValueCollection collection) {
            List<string> output = [];
            foreach (string keyName in collection.AllKeys) {
                string value = collection[keyName];
                if (value == null)
                    output.Add(keyName + "=");
                else
                    output.Add(keyName + "=" + collection[keyName]);
            }

            return string.Join("&", output);
        }
    }
}
