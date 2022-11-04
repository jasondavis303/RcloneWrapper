using System;

namespace RcloneWrapper.OptionsBuilders.Attributes
{
    public class FlagPrefixAttribute : Attribute
    {
        public FlagPrefixAttribute(string prefix) => Prefix = prefix;

        public string Prefix { get; }
    }
}
