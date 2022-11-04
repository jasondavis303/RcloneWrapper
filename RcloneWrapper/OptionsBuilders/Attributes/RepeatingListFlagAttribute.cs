using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders.Attributes
{
    internal class RepeatingListFlagAttribute : FlagAttributeBase
    {
        public RepeatingListFlagAttribute(string flag) : base(flag) { }

        public override void AddArg(List<string> args, string prefix, object val)
        {
            if (val == null)
                return;

            if (val is not List<string> lst || lst.Count == 0)
                return;

            foreach (string s in lst)
                args.Add($"--{prefix}{Flag} {s}");
        }
    }
}
