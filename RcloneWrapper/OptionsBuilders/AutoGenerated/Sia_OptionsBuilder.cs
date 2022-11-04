using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Sia Decentralized Cloud
    /// </summary>
    [FlagPrefix("sia")]
    public class Sia_OptionsBuilder : Base_OptionsBuilder
    {
        public static class ApiUrls
        {
            public const string Default = "http://127.0.0.1:9980";

        }


        public static class UserAgents
        {
            public const string Default = "Sia-Agent";

        }


        /// <summary>
        /// Sia Daemon API Password (obscured)
        /// </summary>
        [StringFlag("api-password")]
        public string ApiPassword { get; set; }


        /// <summary>
        /// Sia daemon API URL, like http://sia.daemon.host:9980 (default &quot;http://127.0.0.1:9980&quot;)
        /// </summary>
        [StringFlag("api-url", "http://127.0.0.1:9980")]
        public string ApiUrl { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,Question,Hash,Percent,Del,Ctl,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.Question | EncodingFlags.Hash | EncodingFlags.Percent | EncodingFlags.Del | EncodingFlags.Ctl | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Siad User Agent (default &quot;Sia-Agent&quot;)
        /// </summary>
        [StringFlag("user-agent", "Sia-Agent")]
        public string UserAgent { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
