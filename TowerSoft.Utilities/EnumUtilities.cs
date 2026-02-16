using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using TowerSoft.Utilities.Attributes;

namespace TowerSoft.Utilities {
    /// <summary>
    /// Utilities for working with enums
    /// </summary>
    public static class EnumUtilities {
        /// <summary>
        /// Returns the display name for the enum value if the DisplayAttribute is defined otherwise it returns the default ToString value.
        /// </summary>
        /// <param name="enumValue">Enum value to get the display name</param>
        public static string GetEnumDisplayName(Enum enumValue) {
            Type type = enumValue.GetType();
            MemberInfo member = type.GetMember(enumValue.ToString())[0];
            DisplayAttribute attr = member.GetCustomAttribute<DisplayAttribute>();
            if (attr != null && !string.IsNullOrWhiteSpace(attr.Name)) {
                return attr.Name;
            }
            return enumValue.ToString();
        }

        /// <summary>
        /// Returns the value of the DescriptionAttribute if defined. Returns an empty string if the attribute was not found.
        /// </summary>
        /// <param name="value">Enum value</param>
        public static string GetEnumDescription(Enum value) {
            Type type = value.GetType();
            MemberInfo[] member = type.GetMember(value.ToString());

            if (member.SafeAny() && member.First().IsDefined(typeof(DescriptionAttribute))) {
                DescriptionAttribute attr = member.First().GetCustomAttribute<DescriptionAttribute>();
                if (!string.IsNullOrWhiteSpace(attr.Description)) 
                    return attr.Description;
            }
            return string.Empty;
        }

        /// <summary>
        /// Returns the list of enum values sorted using the EnumOrderAttribute. Values without the attribute default to a value of 50.
        /// </summary>
        /// <typeparam name="TEnum">Enum type</typeparam>
        public static List<TEnum> EnumGetOrderedValues<TEnum>() {
            Type type = typeof(TEnum);

            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
            List<Tuple<int, TEnum>> orderedValues = [];

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
    }
}
