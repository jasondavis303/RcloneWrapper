using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Akamai NetStorage
    /// </summary>
    [FlagPrefix("netstorage")]
    public class NetStorage_OptionsBuilder : Base_OptionsBuilder
    {
        public enum Protocols
        {
            /// <summary>
            /// HTTP protocol
            /// </summary>
            [Description("http")]
            HTTP,

            /// <summary>
            /// HTTPS protocol
            /// </summary>
            [Description("https")]
            HTTPS,

        }


        /// <summary>
        /// Set the NetStorage account name
        /// </summary>
        [StringFlag("account")]
        public string Account { get; set; }


        /// <summary>
        /// Domain+path of NetStorage host to connect to
        /// </summary>
        [StringFlag("host")]
        public string Host { get; set; }


        /// <summary>
        /// Select between HTTP or HTTPS protocol (default &quot;https&quot;)
        /// </summary>
        [SingleEnumFlag("protocol", (int)Protocols.HTTPS)]
        public Protocols? Protocol { get; set; }


        /// <summary>
        /// Set the NetStorage account secret/G2O key for authentication (obscured)
        /// </summary>
        [StringFlag("secret")]
        public string Secret { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
