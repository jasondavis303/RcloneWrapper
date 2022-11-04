using System;

namespace RcloneWrapper.OptionsBuilders.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NoPrefixAttribute : Attribute
    {
    }
}
