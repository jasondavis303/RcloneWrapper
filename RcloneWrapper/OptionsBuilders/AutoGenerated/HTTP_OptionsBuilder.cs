using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// HTTP
    /// </summary>
    [FlagPrefix("http")]
    public class HTTP_OptionsBuilder : Base_OptionsBuilder
    {
        /// <summary>
        /// Set HTTP headers for all transactions
        /// </summary>
        [CommaSeparatedListFlag("headers")]
        public List<string> Headers { get; set; } = new();


        /// <summary>
        /// Don&#39;t use HEAD requests
        /// </summary>
        [BoolFlag("no-head")]
        public bool NoHead { get; set; }


        /// <summary>
        /// Set this if the site doesn&#39;t end directories with /
        /// </summary>
        [BoolFlag("no-slash")]
        public bool NoSlash { get; set; }


        /// <summary>
        /// URL of HTTP host to connect to
        /// </summary>
        [StringFlag("url")]
        public string Url { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
