using System.Collections.Generic;
using System.Linq;

namespace RcloneWrapper.OptionsBuilders.Attributes
{
    internal class CommaSeparatedListFlagAttribute : FlagAttributeBase
    {
        private readonly List<string> _defaultValues = new();

        public CommaSeparatedListFlagAttribute(string flag, params string[] defaultValues) : base(flag)
        {
            foreach (string defVal in defaultValues)
                if (!string.IsNullOrWhiteSpace(defVal))
                    _defaultValues.Add(defVal);
        }

        public bool PermuteDefaultValues { get; set; }

        public char Separator { get; set; } = ',';

        public override void AddArg(List<string> args, string prefix, object val)
        {
            if (val == null)
                return;

            string strVal = null;
            if (val is List<string> lst)
            {
                if (lst.Count == 0)
                    return;

                strVal = string.Join(Separator, lst.Distinct());
            }
            else if (val is Dictionary<string, string> dict)
            {
                if (dict.Count == 0)
                    return;

                strVal = string.Join(Separator, dict.Select(item => $"{item.Key}={item.Value}").Distinct());
            }
            else
            {
                return;
            }

            var defValues = _defaultValues.ToList();
            if (PermuteDefaultValues)
            {
                defValues.Clear();
                var p = _defaultValues.ToArray().Permute();
                foreach (var subLst in p)
                    defValues.Add(string.Join(Separator, subLst));
            }

            foreach (var defVal in defValues)
                if (strVal == defVal)
                    return;

            args.Add($"--{prefix}{Flag} {strVal}");
        }
    }
}
