using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// In memory object storage system.
    /// </summary>
    [FlagPrefix("memory")]
    public class Memory_OptionsBuilder : Base_OptionsBuilder
    {

        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
