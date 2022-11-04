using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders.Attributes
{
    internal class SizeSuffixFlagAttribute : FlagAttributeBase
    {
        private readonly string _defaultValues;

        public SizeSuffixFlagAttribute(string flag, string defaultValue = null) : base(flag) => _defaultValues = defaultValue;

        public override void AddArg(List<string> args, string prefix, object val)
        {
            if (val == null)
                return;

            SizeSuffix ss = (SizeSuffix)val;

            string sval = ss.ToString();
            if (sval != _defaultValues)
                args.Add($"--{prefix}{Flag} {sval}");
        }
    }
}
