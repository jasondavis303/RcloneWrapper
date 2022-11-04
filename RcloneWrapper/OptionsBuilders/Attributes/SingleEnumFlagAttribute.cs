using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace RcloneWrapper.OptionsBuilders.Attributes
{
    internal class SingleEnumFlagAttribute : FlagAttributeBase
    {
        private int? _defaultValue;

        public SingleEnumFlagAttribute(string flag) : base(flag) { }

        public SingleEnumFlagAttribute(string flag, int defaultValue = 0) : base(flag) => _defaultValue = defaultValue;

        public override void AddArg(List<string> args, string prefix, object val)
        {
            if (val == null)
                return;

            var iVal = (int)val;

            foreach (int candidate in Enum.GetValues(val.GetType()))
                if (iVal == candidate)
                {
                    bool add = !_defaultValue.HasValue || iVal != _defaultValue;
                    if (add)
                    {
                        string s = val.ToString();

                        MemberInfo[] memberInfo = val.GetType().GetMember(s);
                        if (memberInfo != null && memberInfo.Length > 0)
                        {
                            object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                            if (attrs != null && attrs.Length > 0)
                                s = ((DescriptionAttribute)attrs[0]).Description;
                        }


                        args.Add($"--{prefix}{Flag} {s}");
                    }
                    return;
                }

            throw new Exception("Invalid value");
        }

    }
}
