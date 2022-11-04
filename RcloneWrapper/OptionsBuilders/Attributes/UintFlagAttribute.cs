using System;
using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders.Attributes
{
    internal class UintFlagAttribute : FlagAttributeBase
    {
        private readonly uint? _defaultValue = null;
        private readonly uint _minValue = 0;
        private readonly uint _maxValue = uint.MaxValue;

        public UintFlagAttribute(string flag) : base(flag) { }


        public UintFlagAttribute(string flag, uint defaultValue, uint minValue = 0, uint maxValue = uint.MaxValue) : base(flag)
        {
            _defaultValue = defaultValue;
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public override void AddArg(List<string> args, string prefix, object val)
        {
            if (val == null)
                return;

            uint? uval = (uint?)val;

            if (uval == null)
                return;

            uval = Math.Min(_maxValue, Math.Max(_minValue, uval.Value));

            bool add = !_defaultValue.HasValue || uval != _defaultValue;
            if (add)
                args.Add($"--{prefix}{Flag} {uval}");
        }
    }
}
