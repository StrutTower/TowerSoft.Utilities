using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerSoft.Utilities.Attributes;

namespace TowerSoft.UtilitiesTests.Models {
public enum TestEnum {
    [Display(Name = "Value 1")]
    Value1 = 1,
    [Display(Name = "Value 2")]
    Value2,
    Value3,
    [EnumOrder(52)]
    Value5,
    [EnumOrder(53)]
    Value6,
    [EnumOrder(51)]
    Value4,
}
}
