using System.ComponentModel.DataAnnotations;
using System.Reflection;
using TowerSoft.Utilities.Enums;

namespace TowerSoft.Utilities {
    public class ByteInfo {
        private readonly long bytes;
        private readonly DataUnitConversion defaultUnitConversion;

        internal static long ByteToKilobyteBinary = 1024;
        internal static long ByteToKilobyteDecimal = 1000;

        internal static long ByteToMegabyteBinary = 1048576;
        internal static long ByteToMegabyteDecimal = 1000000;

        internal static long ByteToGigabyteBinary = 1073741824;
        internal static long ByteToGigabyteDecimal = 1000000000;

        internal static long ByteToTerabyteBinary = 1099511627776;
        internal static long ByteToTerabyteDecimal = 1000000000000;

        internal static long ByteToPetabyteBinary = 1125899906842624;
        internal static long ByteToPetabyteDecimal = 1000000000000000;

        internal static long ByteToExabyteBinary = 1125899906842624 * 1024;
        internal static long ByteToExabyteDecimal = 1000000000000000000;

        public ByteInfo(long bytes) {
            this.bytes = bytes;
            defaultUnitConversion = DataUnitConversion.Binary;
        }

        public ByteInfo(long bytes, DataUnitConversion defaultUnitConversion = DataUnitConversion.Binary) {
            this.bytes = bytes;
            this.defaultUnitConversion = defaultUnitConversion;
        }

        public long Length {
            get => bytes;
        }

        public DataUnitConversion DefaultUnitConversion {
            get => defaultUnitConversion;
        }

        public static ByteInfo FromKilobytes(long kilobytes, DataUnitConversion conversion = DataUnitConversion.Binary) {

            if (conversion == DataUnitConversion.Decimal)
                return new ByteInfo(kilobytes * ByteToKilobyteDecimal, conversion);
            return new ByteInfo(kilobytes * ByteToKilobyteBinary, conversion);
        }

        public static ByteInfo FromMegabytes(long megabytes, DataUnitConversion conversion = DataUnitConversion.Binary) {
            if (conversion == DataUnitConversion.Decimal)
                return new ByteInfo(megabytes * ByteToMegabyteDecimal, conversion);
            return new ByteInfo(megabytes * ByteToMegabyteBinary, conversion);
        }

        public static ByteInfo FromGigabytes(long gigabytes, DataUnitConversion conversion = DataUnitConversion.Binary) {
            if (conversion == DataUnitConversion.Decimal)
                return new ByteInfo(gigabytes * ByteToGigabyteDecimal, conversion);
            return new ByteInfo(gigabytes * ByteToGigabyteBinary, conversion);
        }

        public static ByteInfo FromTerabytes(long terabytes, DataUnitConversion conversion = DataUnitConversion.Binary) {
            if (conversion == DataUnitConversion.Decimal)
                return new ByteInfo(terabytes * ByteToTerabyteDecimal, conversion);
            return new ByteInfo(terabytes * ByteToTerabyteBinary, conversion);
        }

        public static ByteInfo FromPetabytes(long petabytes, DataUnitConversion conversion = DataUnitConversion.Binary) {
            if (conversion == DataUnitConversion.Decimal)
                return new ByteInfo(petabytes * ByteToPetabyteDecimal, conversion);
            return new ByteInfo(petabytes * ByteToPetabyteBinary, conversion);
        }

        public override string ToString() {
            var byteConversion = GetOutputStorageUnit(defaultUnitConversion, out DataStorageUnit storageUnit);
            double size = Length / byteConversion;
            return Math.Round(size, 1) + " " + GetEnumShortName(storageUnit);
        }

        public string ToString(DataUnitConversion? conversion = null) {
            var conversion2 = conversion ?? defaultUnitConversion;
            var byteConversion = GetOutputStorageUnit(conversion2, out DataStorageUnit storageUnit);
            double size = Length / byteConversion;
            return Math.Round(size, 1) + " " + GetEnumShortName(storageUnit);
        }

        public string ToString(DataStorageUnit dataStorageUnit, DataUnitConversion? conversion = null) {
            var conversion2 = conversion ?? defaultUnitConversion;
            return "";
        }

        private long GetOutputStorageUnit(DataUnitConversion conversion,
            out DataStorageUnit storageUnit) {
            if (conversion == DataUnitConversion.Binary) {
                if (Length >= ByteToExabyteBinary) {
                    storageUnit = DataStorageUnit.Exabyte;
                    return ByteToExabyteBinary;
                } else if (Length >= ByteToPetabyteBinary) {
                    storageUnit = DataStorageUnit.Petabyte;
                    return ByteToPetabyteBinary;
                } else if (Length >= ByteToTerabyteBinary) {
                    storageUnit = DataStorageUnit.Terabyte;
                    return ByteToTerabyteBinary;
                } else if (Length >= ByteToGigabyteBinary) {
                    storageUnit = DataStorageUnit.Gigabyte;
                    return ByteToGigabyteBinary;
                } else if (Length >= ByteToMegabyteBinary) {
                    storageUnit = DataStorageUnit.Megabyte;
                    return ByteToMegabyteBinary;
                } else if (Length >= ByteToKilobyteBinary) {
                    storageUnit = DataStorageUnit.Kilobyte;
                    return ByteToKilobyteBinary;
                } else {
                    storageUnit = DataStorageUnit.Byte;
                    return 1;
                }
            } else {
                if (Length >= ByteToExabyteDecimal) {
                    storageUnit = DataStorageUnit.Exabyte;
                    return ByteToExabyteDecimal;
                } else if (Length >= ByteToPetabyteDecimal) {
                    storageUnit = DataStorageUnit.Petabyte;
                    return ByteToPetabyteDecimal;
                } else if (Length >= ByteToTerabyteDecimal) {
                    storageUnit = DataStorageUnit.Terabyte;
                    return ByteToTerabyteDecimal;
                } else if (Length >= ByteToGigabyteDecimal) {
                    storageUnit = DataStorageUnit.Gigabyte;
                    return ByteToGigabyteDecimal;
                } else if (Length >= ByteToMegabyteDecimal) {
                    storageUnit = DataStorageUnit.Megabyte;
                    return ByteToMegabyteDecimal;
                } else if (Length >= ByteToKilobyteDecimal) {
                    storageUnit = DataStorageUnit.Kilobyte;
                    return ByteToKilobyteDecimal;
                } else {
                    storageUnit = DataStorageUnit.Byte;
                    return 1;
                }
            }
        }

        private string GetEnumShortName(Enum enumValue) {
            Type type = enumValue.GetType();
            MemberInfo member = type.GetMember(enumValue.ToString())[0];
            DisplayAttribute attr = member.GetCustomAttribute<DisplayAttribute>();
            if (attr != null && !string.IsNullOrWhiteSpace(attr.ShortName)) {
                return attr.ShortName;
            }
            return enumValue.ToString();
        }
    }
}
