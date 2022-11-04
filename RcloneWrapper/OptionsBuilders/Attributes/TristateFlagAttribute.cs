using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders.Attributes
{
    internal class TristateFlagAttribute : FlagAttributeBase
    {
        private readonly bool? _defaultValue;

        public TristateFlagAttribute(string flag) : base(flag) { }

        public TristateFlagAttribute(string flag, bool defaultValue) : base(flag) => _defaultValue = defaultValue;

        public override void AddArg(List<string> args, string prefix, object val)
        {
            bool? bval = (bool?)val;
            string sval = bval.HasValue ? bval.Value.ToString().ToLower() : "unset";
            string dval = _defaultValue.HasValue ? _defaultValue.Value.ToString().ToLower() : "unset";

            if (sval != dval)
                args.Add($"--{prefix}{Flag}={sval}");
        }
    }
}
