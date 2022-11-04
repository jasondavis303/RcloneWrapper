using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Alias for an existing remote
    /// </summary>
    [FlagPrefix("alias")]
    public class Alias_OptionsBuilder : Base_OptionsBuilder
    {
        /// <summary>
        /// Remote or path to alias
        /// </summary>
        [StringFlag("remote")]
        public string Remote { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
