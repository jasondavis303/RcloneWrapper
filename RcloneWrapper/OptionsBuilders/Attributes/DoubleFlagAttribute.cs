using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders.Attributes
{
    internal class DoubleFlagAttribute : FlagAttributeBase
    {
        private readonly double _defaultValue;

        public DoubleFlagAttribute(string flag, double defaultValue = -1) : base(flag) => _defaultValue = defaultValue;

        public override void AddArg(List<string> args, string prefix, object val)
        {
            if (val == null)
                return;

            double? dval = (double?)val;
            if (dval != null && dval >= 0 && dval != _defaultValue)
                args.Add($"--{prefix}{Flag} {dval}");
        }
    }
}
