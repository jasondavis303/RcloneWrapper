using System;
using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders.Attributes
{
    internal class IntFlagAttribute : FlagAttributeBase
    {
        private readonly int? _defaultValue = null;
        private readonly int _minVal = -1;
        private readonly int _maxVal = int.MaxValue;

        public IntFlagAttribute(string flag) : base(flag) { }

        public IntFlagAttribute(string flag, int defaultValue, int minVal = -1, int maxVal = int.MaxValue) : base(flag)
        {
            _minVal = minVal;
            _maxVal = maxVal;
            _defaultValue = defaultValue;
        }

        public override void AddArg(List<string> args, string prefix, object val)
        {
            if (val == null)
                return;

            int? ival = (int?)val;
            if (ival != null)
            {
                int ival2 = Math.Min(Math.Max(ival.Value, _minVal), _maxVal);
                if (ival2 == _defaultValue)
                    return;
                args.Add($"--{prefix}{Flag} {ival2}");
            }
        }
    }
}
