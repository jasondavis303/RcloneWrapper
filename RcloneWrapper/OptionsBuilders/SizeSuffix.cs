using System;
using System.ComponentModel;
using System.Linq;

namespace RcloneWrapper.OptionsBuilders
{
    public class SizeSuffix
    {
        public enum SizeSuffixOptions
        {
            [Description("B")]
            Byte,

            [Description("K")]
            KiB,

            [Description("M")]
            MiB,

            [Description("G")]
            GiB,

            [Description("T")]
            TiB,

            [Description("P")]
            PiB
        }


        private double _value { get; set; }

        public SizeSuffix() { }

        public SizeSuffix(double value, SizeSuffixOptions option = SizeSuffixOptions.KiB)
        {
            Value = value;
            Option = option;
        }

        public double Value
        {
            get => _value;
            set
            {
                if (value < 0)
                    throw new Exception("Value must be >= 0");
                _value = value;
            }
        }

        /// <summary>
        /// Options which use SIZE use KiB (multiples of 1024 bytes) by default
        /// </summary>
        public SizeSuffixOptions Option { get; set; } = SizeSuffixOptions.KiB;

        public string ToRclone() => $"{_value}{Option.ToString().ToUpper().First()}";

        public override string ToString() => ToRclone();

        public static string GetSizeString(double value, SizeSuffixOptions option = SizeSuffixOptions.KiB) => new SizeSuffix(value, option).ToRclone();
    }
}
