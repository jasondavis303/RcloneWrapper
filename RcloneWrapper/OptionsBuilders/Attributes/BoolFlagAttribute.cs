using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders.Attributes
{
    internal class BoolFlagAttribute : FlagAttributeBase
    {
        private readonly bool _defaultValue;

        public BoolFlagAttribute(string flag, bool defaultValue = false) : base(flag) => _defaultValue = defaultValue;

        public override void AddArg(List<string> args, string prefix, object val)
        {
            if (val == null)
                return;

            bool bval = (bool)val;
            if (bval != _defaultValue)
            {
                if (bval)
                    args.Add($"--{prefix}{Flag}");
                else
                    args.Add($"--{prefix}{Flag}=false");
            }
        }
    }
}
