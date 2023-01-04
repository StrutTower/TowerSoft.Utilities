using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using TowerSoft.Utilities.Attributes;

namespace TowerSoft.Utilities {
    /// <summary>
    /// Utilities for working with enums
    /// </summary>
    public static class EnumUtilities {
        /// <summary>
        /// Returns the list of enum values sorted using the EnumOrderAttribute. Values without the attribute default to a value of 50.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static List<TEnum> EnumGetOrderedValues<TEnum>() {
            Type type = typeof(TEnum);

            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
            List<Tuple<int, TEnum>> orderedValues = new List<Tuple<int, TEnum>>();

            foreach (FieldInfo field in fields) {
                EnumOrderAttribute attr = field.GetCustomAttribute<EnumOrderAttribute>();
                if (attr == null) {
                    orderedValues.Add(new Tuple<int, TEnum>(50, (TEnum)field.GetValue(null)));
                } else {
                    orderedValues.Add(new Tuple<int, TEnum>(attr.OrderPriority, (TEnum)field.GetValue(null)));
                }
            }

            return orderedValues.OrderBy(x => x.Item1).ThenBy(x => x.Item2.ToString()).Select(x => x.Item2).ToList();
        }

        /// <summary>
        /// Returns the display name for the enum value if the DisplayAttribute is defined otherwise it returns the default ToString value.
        /// </summary>
        /// <param name="enumValue">Enum value to get the display name</param>
        /// <returns></returns>
        public static string GetEnumDisplayName(Enum enumValue) {
            Type type = enumValue.GetType();
            MemberInfo member = type.GetMember(enumValue.ToString())[0];
            DisplayAttribute attr = member.GetCustomAttribute<DisplayAttribute>();
            if (attr != null && !string.IsNullOrWhiteSpace(attr.Name)) {
                return attr.Name;
            }
            return enumValue.ToString();
        }
    }
}
