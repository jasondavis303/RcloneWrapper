using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders.Attributes
{
    internal class MinTLSFlagAttribute : FlagAttributeBase
    {
        private readonly double _defaultValue;

        public MinTLSFlagAttribute(string flag, double defaultValue = 1.0) : base(flag) => _defaultValue = defaultValue;


        public override void AddArg(List<string> args, string prefix, object val)
        {
            if (val == null)
                return;

            double? dval = (double?)val;
            if (dval == null)
                return;

            if (dval <= 0)
                return;

            if (dval == _defaultValue)
                return;

            args.Add($"--rc-min-tls-version tls{dval}");
        }
    }
}
