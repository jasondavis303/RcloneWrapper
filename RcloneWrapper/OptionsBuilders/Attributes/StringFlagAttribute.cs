using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders.Attributes
{
    internal class StringFlagAttribute : FlagAttributeBase
    {
        private readonly string _defaultValue = null;

        public StringFlagAttribute(string flag, string defaultValue = null) : base(flag)
        {
            if (!string.IsNullOrWhiteSpace(defaultValue))
                _defaultValue = defaultValue;
        }

        public override void AddArg(List<string> args, string prefix, object val)
        {
            if (val == null)
                return;

            string sval = (string)val;

            if (string.IsNullOrWhiteSpace(sval))
                return;

            if (sval == _defaultValue)
                return;

            args.Add($"--{prefix}{Flag} {sval}");
        }
    }
}
