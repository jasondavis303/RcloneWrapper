using System;
using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal abstract class FlagAttributeBase : Attribute
    {
        public FlagAttributeBase(string flag) => Flag = flag;

        protected string Flag { get; }

        public abstract void AddArg(List<string> args, string prefix, object val);
    }
}
