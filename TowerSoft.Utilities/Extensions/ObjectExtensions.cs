namespace TowerSoft.Utilities {
    /// <summary>
    /// Extensions for all objects
    /// </summary>
    public static class ObjectExtensions {
        /// <summary>
        /// Finds all string properties on this object and runs the SafeTrim method of them. Does not search recursively.
        /// </summary>
        /// <param name="obj"></param>
        public static void TrimProperties(this object obj) {
            if (obj == null) return;
            Type type = obj.GetType();

            foreach (System.Reflection.PropertyInfo prop in type.GetProperties()) {
                if (prop.PropertyType == typeof(string)) {
                    string value = (string)prop.GetValue(obj);
                    prop.SetValue(obj, value.SafeTrim());
                }
            }
        }

        /// <summary>
        /// Check all properties on the object for blank strings and converts them to null
        /// </summary>
        /// <param name="obj"></param>
        public static void NullOutEmptyStrings(this object obj) {
            foreach (System.Reflection.PropertyInfo prop in obj.GetType().GetProperties()) {
                Type type = prop.PropertyType;

                if (type != typeof(string) || !prop.CanWrite || !prop.CanRead || prop.SetMethod.IsVirtual)
                    continue;

                object objProp = prop.GetValue(obj);

                if (objProp == null) continue;

                string str = objProp.ToString();

                if (!string.IsNullOrWhiteSpace(str)) continue;

                prop.SetValue(obj, null);
            }
        }

        /// <summary>
        /// Returns true if this list is a List object
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool IsGenericList(this object o) {
            Type type = o.GetType();
            return (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>)));
        }
    }
}
