using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Combine several remotes into one
    /// </summary>
    [FlagPrefix("combine")]
    public class Combine_OptionsBuilder : Base_OptionsBuilder
    {
        /// <summary>
        /// Upstreams for combining
        /// </summary>
        [CommaSeparatedListFlag("upstreams", Separator = ' ')]
        public List<string> Upstreams { get; set; } = new();



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
