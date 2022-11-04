using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Storj Decentralized Cloud Storage
    /// </summary>
    [FlagPrefix("storj")]
    public class Storj_OptionsBuilder : Base_OptionsBuilder
    {
        public static class SatelliteAddresses
        {
            public const string US_Central_1 = "us-central-1.storj.io";

            public const string Europe_West_1 = "europe-west-1.storj.io";

            public const string Asia_East_1 = "asia-east-1.storj.io";

        }


        public enum Providers
        {
            /// <summary>
            /// Use an existing access grant.
            /// </summary>
            [Description("existing")]
            Existing,

            /// <summary>
            /// Create a new access grant from satellite address, API key, and passphrase.
            /// </summary>
            [Description("new")]
            New,

        }


        /// <summary>
        /// Access grant
        /// </summary>
        [StringFlag("access-grant")]
        public string AccessGrant { get; set; }


        /// <summary>
        /// API key
        /// </summary>
        [StringFlag("api-key")]
        public string ApiKey { get; set; }


        /// <summary>
        /// Encryption passphrase
        /// </summary>
        [StringFlag("passphrase")]
        public string Passphrase { get; set; }


        /// <summary>
        /// Choose an authentication method (default &quot;existing&quot;)
        /// </summary>
        [SingleEnumFlag("provider", (int)Providers.Existing)]
        public Providers? Provider { get; set; }


        /// <summary>
        /// Satellite address (default &quot;us-central-1.storj.io&quot;)
        /// </summary>
        [StringFlag("satellite-address", "us-central-1.storj.io")]
        public string SatelliteAddress { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
