using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace RcloneWrapper.OptionsBuilders.Attributes
{
    internal class MultiEnumFlagAttribute : FlagAttributeBase
    {
        private readonly int _defaultValue;

        public MultiEnumFlagAttribute(string flag, int defaultValue = 0) : base(flag) => _defaultValue = defaultValue;

        public char Separator { get; set; } = ',';

        public override void AddArg(List<string> args, string prefix, object val)
        {
            if (val == null)
                return;

            if (val is not Enum eVal)
                return;

            if ((int)val == _defaultValue)
                return;

            var lst = new List<string>();
            foreach (Enum candidate in Enum.GetValues(val.GetType()))
                if (eVal.HasFlag(candidate))
                {
                    string s = candidate.ToString();
                    MemberInfo[] memberInfo = val.GetType().GetMember(s);
                    if (memberInfo != null && memberInfo.Length > 0)
                    {
                        object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                        if (attrs != null && attrs.Length > 0)
                            s = ((DescriptionAttribute)attrs[0]).Description;
                    }
                    lst.Add(s);
                }


            if (lst.Count > 0)
                args.Add($"--{prefix}{Flag} {string.Join(Separator, lst)}");
        }
    }
}
