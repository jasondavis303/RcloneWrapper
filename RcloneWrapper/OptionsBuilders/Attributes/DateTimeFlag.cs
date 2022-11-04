using System;
using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders.Attributes
{
    internal class DateTimeFlag : FlagAttributeBase
    {
        public DateTimeFlag(string flag) : base(flag) { }

        public override void AddArg(List<string> args, string prefix, object val)
        {
            if (val == null)
                return;

            var dt = val as DateTime?;
            if (dt == null)
                return;

            string s = dt.ToRclone();
            args.Add($"--{prefix}{Flag} {s}");
        }
    }
}
