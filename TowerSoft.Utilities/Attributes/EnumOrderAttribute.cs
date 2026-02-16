namespace TowerSoft.Utilities.Attributes {
    /// <summary>
    /// Used to determine the order of an enum value when using EnumUtilities.EnumGetOrderedValues method.
    /// </summary>
    /// <remarks>
    /// Used to determine the order of an enum value when using EnumUtilities.EnumGetOrderedValues method.
    /// </remarks>
    /// <param name="orderPriority">Order priority for the value. Default is 50 for values without this attribute.</param>
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumOrderAttribute(int orderPriority) : Attribute {

        /// <summary>
        /// Order priority for the value. Default is 50 for values without this attribute.
        /// </summary>
        public int OrderPriority { get; } = orderPriority;
    }
}
