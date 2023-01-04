using System;

namespace TowerSoft.Utilities.Attributes {
    /// <summary>
    /// Used to determine the order of an enum value when using EnumUtilities.EnumGetOrderedValues method.
    /// </summary>
    public class EnumOrderAttribute : Attribute {
        /// <summary>
        /// Used to determine the order of an enum value when using EnumUtilities.EnumGetOrderedValues method.
        /// </summary>
        /// <param name="orderPriority">Order priority for the value. Default is 50 for values without this attribute.</param>
        public EnumOrderAttribute(int orderPriority) {
            OrderPriority = orderPriority;
        }

        /// <summary>
        /// Order priority for the value. Default is 50 for values without this attribute.
        /// </summary>
        public int OrderPriority { get; }
    }
}
