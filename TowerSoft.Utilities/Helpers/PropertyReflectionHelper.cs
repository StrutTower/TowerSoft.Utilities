using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TowerSoft.Utilities.Attributes;

namespace TowerSoft.Utilities.Helpers {
    internal class PropertyReflectionHelper {
        public IList<string> GetPropertyNames<T>(bool useCompareFields = false) {
            IList<string> propertyNames = new List<string>();
            IEnumerable<PropertyInfo> propertyInfos = typeof(T).GetProperties(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.NonPublic |
                BindingFlags.Default |
                BindingFlags.Instance).ToList();
            if (useCompareFields) {
                propertyInfos = propertyInfos
                    .Where(prop => Attribute.IsDefined(prop, typeof(CompareFieldAttribute))
                        && !Attribute.IsDefined(prop, typeof(CompareIgnoreFieldAttribute))
                        && !prop.SetMethod.IsVirtual);
            }
            if (propertyInfos.ToList().Count > 0) {
                foreach (PropertyInfo propertyInfo in propertyInfos) {
                    if (propertyInfo.SetMethod != null && !propertyInfo.SetMethod.IsVirtual
                        && !Attribute.IsDefined(propertyInfo, typeof(CompareIgnoreFieldAttribute))) {
                        propertyNames.Add(propertyInfo.Name);
                    }
                }
            }
            return propertyNames;
        }

        public object GetPropertyValue<T>(string propName, T src) {
            return src.GetType().GetProperty(propName).GetValue(src);
        }
    }
}
