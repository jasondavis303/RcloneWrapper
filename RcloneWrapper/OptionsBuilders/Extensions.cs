using RcloneWrapper.OptionsBuilders.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RcloneWrapper.OptionsBuilders
{
    internal static class Extensions
    {
        public static string ToRclone(this DateTime? val)
        {
            if (val == null)
                return null;

            return val.Value.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");
        }

        public static string ToRclone(this TimeSpan? val)
        {
            if (val == null)
                return null;

            var tsv = val.Value;

            int years = 0;
            while (tsv.Days >= 365)
            {
                years++;
                tsv = tsv.Subtract(TimeSpan.FromDays(365));
            }

            int weeks = 0;
            while (tsv.Days >= 7)
            {
                weeks++;
                tsv = tsv.Subtract(TimeSpan.FromDays(7));
            }

            string s = null;

            if (years > 0)
                s += $"{years}y";

            if (weeks > 0)
                s += $"{weeks}w";

            if (tsv.Days > 0)
                s += $"{tsv.Days}d";

            if (tsv.Hours > 0)
                s += $"{tsv.Hours}h";

            if (tsv.Minutes > 0)
                s += $"{tsv.Minutes}m";

            if (tsv.Seconds > 0)
                s += $"{tsv.Seconds}s";

            if (tsv.Milliseconds > 0)
                s += $"{tsv.Milliseconds}ms";

            if (string.IsNullOrWhiteSpace(s))
                s = "0s";

            return s;
        }

        internal static List<string> GetOptionsList(this IOptionsBuilder value)
        {
            var ret = new List<string>();

            string prefix = null;
            var classAttrs = ((FlagPrefixAttribute[])value.GetType().GetCustomAttributes(typeof(FlagPrefixAttribute), true));
            if (classAttrs != null && classAttrs.Length > 0)
                prefix = classAttrs.First().Prefix + "-";

            var properties = value.GetType()
                .GetProperties()
                .Where(prop => prop.IsDefined(typeof(FlagAttributeBase), false))
                .OrderBy(item => item.Name);

            foreach (var prop in properties)
            {
                string propPrefix = prefix;
                var noPrefixAttr = (NoPrefixAttribute[])prop.GetCustomAttributes(typeof(NoPrefixAttribute), true);
                if (noPrefixAttr != null && noPrefixAttr.Length > 0)
                    propPrefix = null;

                var flagAttr = ((FlagAttributeBase[])prop.GetCustomAttributes(typeof(FlagAttributeBase), true)).First();
                flagAttr.AddArg(ret, propPrefix, prop.GetValue(value));
            }

            if (value.CustomOptions != null)
                foreach (var kvp in value.CustomOptions)
                {
                    string cv = kvp.Key;
                    if (!string.IsNullOrWhiteSpace(kvp.Value))
                    {
                        if (kvp.Value == "false")
                            cv += "=false";
                        else
                            cv += ' ' + kvp.Value;
                    }
                    ret.Add(cv);
                }

            return ret;
        }

        internal static string GetOptionsString(this IOptionsBuilder value) => string.Join(' ', value.GetOptionsList());

        internal static IList<IList<string>> Permute(this string[] vals)
        {
            var list = new List<IList<string>>();
            return DoPermute(vals, 0, vals.Length - 1, list);
        }

        static IList<IList<string>> DoPermute(string[] vals, int start, int end, IList<IList<string>> list)
        {
            if (start == end)
            {
                // We have one of our possible n! solutions,
                // add it to the list.
                list.Add(new List<string>(vals));
            }
            else
            {
                for (var i = start; i <= end; i++)
                {
                    Swap(ref vals[start], ref vals[i]);
                    DoPermute(vals, start + 1, end, list);
                    Swap(ref vals[start], ref vals[i]);
                }
            }

            return list;
        }

        static void Swap(ref string a, ref string b) => (b, a) = (a, b);
    }
}