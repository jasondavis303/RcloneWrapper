using System;
using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders.BaseClasses
{
    public abstract class Base_OptionsBuilder : IOptionsBuilder
    {
        public Dictionary<string, string> CustomOptions { get; set; } = new();

        public void AddCustomOption(string flag, string value)
        {
            CustomOptions ??= new();
            CustomOptions.Add(flag, value);
        }

        public void AddCustomOption(string flag, SizeSuffix sizeSuffix)
        {
            if (sizeSuffix != null)
                AddCustomOption(flag, sizeSuffix.ToRclone());
        }

        public void AddCustomOption(string flag, int? value)
        {
            if (value != null)
                AddCustomOption(flag, value.Value.ToString());
        }

        public void AddCustomOption(string flag, uint? value)
        {
            if (value != null)
                AddCustomOption(flag, value.Value.ToString());
        }

        public void AddCustomOption(string flag, bool value, bool defaultValue = false)
        {
            if (value != defaultValue)
            {
                if (value == false)
                    AddCustomOption(flag, "false");
                else
                    AddCustomOption(flag, string.Empty);
            }
        }

        public void AddCustomOption(string flag, bool? value, bool? defaultValue = null)
        {
            if (value != defaultValue)
            {
                if (value == null)
                    AddCustomOption(flag, "unset");
                else if (value == false)
                    AddCustomOption(flag, "false");
                else
                    AddCustomOption(flag, string.Empty);
            }
        }

        public void AddCustomOption(string flag, TimeSpan? value)
        {
            if (value != null)
                AddCustomOption(flag, value.ToRclone());
        }

        public abstract string BuildArgs();
    }
}
