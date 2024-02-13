using System.Collections.Generic;
using TowerSoft.Utilities.Helpers;

namespace TowerSoft.Utilities {
    /// <summary>
    /// Comparer for all properties on an object. Compare and CompareIgnore attributes can be used to filter properties
    /// </summary>
    /// <typeparam name="T">Object type to compare</typeparam>
    public class AllPropertyComparer<T> : IEqualityComparer<T> {
        private readonly PropertyReflectionHelper propertyReflectionHelper;
        readonly IList<string> keyProperties = new List<string>();

        /// <summary>
        /// Comparer for all properties on an object. Compare and CompareIgnore attributes can be used to filter properties
        /// </summary>
        /// <param name="useCompareFields">
        /// If true, will only compare fields with the CompareFieldAttribute. 
        /// If false, will compare all fields except those with the CompareIgnoreFieldAttribute
        /// </param>
        public AllPropertyComparer(bool useCompareFields = false) {
            propertyReflectionHelper = new PropertyReflectionHelper();
            keyProperties = propertyReflectionHelper.GetPropertyNames<T>(useCompareFields);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(T x, T y) {
            if (x is null || y is null)
                return false;

            foreach (string propertyName in keyProperties) {
                object xValue = propertyReflectionHelper.GetPropertyValue(propertyName, x);
                object yValue = propertyReflectionHelper.GetPropertyValue(propertyName, y);

                if (xValue == null && yValue == null)
                    return true;
                else if (xValue == null && yValue != null)
                    return false;
                else if (xValue != null && yValue == null)
                    return false;
                else if (!xValue.Equals(yValue))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(T obj) {
            int hash = 17;
            foreach (string propertyName in keyProperties) {
                var value = propertyReflectionHelper.GetPropertyValue(propertyName, obj);
                if (value == null) {
                    hash = hash * 23 + "".GetHashCode();
                } else {
                    hash = hash * 23 + value.GetHashCode();
                }
            }
            return hash;
        }
    }
}
