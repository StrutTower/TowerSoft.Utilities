using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TowerSoft.Utilities.Attributes;

namespace TowerSoft.UtilitiesTests.Models {
    public enum TestEnum {
        [Display(Name = "Value 1")]
        Value1 = 1,
        [Display(Name = "Value 2")]
        [Description("Value 2 Description")]
        Value2,
        Value3,
        [EnumOrder(52)]
        [Description("Value 5 Description")]
        Value5,
        [EnumOrder(53)]
        Value6,
        [EnumOrder(51)]
        Value4,
    }
}
