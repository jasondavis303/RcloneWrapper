using System;
using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders.Attributes
{
    internal class TimeSpanFlag : FlagAttributeBase
    {
        private readonly string _defaultValue = null;

        public TimeSpanFlag(string flag, string defaultValue = null) : base(flag)
        {
            if (!string.IsNullOrWhiteSpace(defaultValue))
                _defaultValue = defaultValue;
        }

        public override void AddArg(List<string> args, string prefix, object val)
        {
            if (val == null)
                return;

            var ts = val as TimeSpan?;
            if (ts == null)
                return;

            string s = ts.ToRclone();
            if (s == _defaultValue)
                return;

            args.Add($"--{prefix}{Flag} {s}");
        }
    }
}
