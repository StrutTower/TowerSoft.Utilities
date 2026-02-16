using System.ComponentModel.DataAnnotations;

namespace TowerSoft.Utilities.Enums {
    /// <summary>
    /// Data storage unit types
    /// </summary>
    public enum DataStorageUnit {
        /// <summary>
        /// Byte unit
        /// </summary>
        [Display(Name = "Byte", ShortName = "B", GroupName = "Bytes")]
        Byte,
        /// <summary>
        /// Kilobyte unit. Binary/base 2 = 1024 bytes, Decimal/base 10 = 1000 bytes
        /// </summary>
        [Display(Name = "Kilobyte", ShortName = "KB", GroupName = "Kilobytes")]
        Kilobyte,
        /// <summary>
        /// Megabyte unit. Binary/base 2 = 1,048,576 bytes, Decimal/base 10 = 1,000,000 bytes
        /// </summary>
        [Display(Name = "Megabyte", ShortName = "MB", GroupName = "Megabytes")]
        Megabyte,
        /// <summary>
        /// Gigabyte unit. Binary/base 2 = 1,073,741,824 bytes, Decimal/base 10 = 1,000,000,000 bytes
        /// </summary>
        [Display(Name = "Gigabyte", ShortName = "GB", GroupName = "Gigabytes")]
        Gigabyte,
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Terabyte", ShortName = "TB", GroupName = "Terabytes")]
        Terabyte,
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Petabyte", ShortName = "PB", GroupName = "Petabytes")]
        Petabyte,
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Exabyte", ShortName = "EB", GroupName = "Exabytes")]
        Exabyte
    }
}
