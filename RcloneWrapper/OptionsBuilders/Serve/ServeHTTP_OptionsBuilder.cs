using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;

namespace RcloneWrapper.OptionsBuilders.Serve
{
    /// <summary>
    /// Serve the remote over HTTP.
    /// </summary>
    public class ServeHTTP_OptionsBuilder : SecureServeCreds_OptionsBuilder
    {
        /// <summary>
        /// IPaddress:Port or :Port to bind server to (default "localhost:2121")
        /// </summary>
        [StringFlag("addr", "127.0.0.1:8080")]
        public string Addr { get; set; }

        /// <summary>
        /// Prefix for URLs - leave blank for root
        /// </summary>
        [StringFlag("baseurl")]
        public string BaseUrl { get; set; }

        /// <summary>
        /// Password hashing salt (default "dlPL2MqE"
        /// </summary>
        [StringFlag("salt", "dlPL2MqE")]
        public string Salt { get; set; }

        /// <summary>
        /// Maximum size of request header (default 4096)
        /// </summary>
        [UintFlag("max-header-bytes", 4096)]
        public uint? MaxHeaderBytes { get; set; }

        /// <summary>
        /// Timeout for server reading data (default 1h0m0s)
        /// </summary>
        [TimeSpanFlag("server-read-timeout", "1h")]
        public TimeSpan? ServerReadTimeout { get; set; }

        /// <summary>
        /// Timeout for server writing data (default 1h0m0s)
        /// </summary>
        [TimeSpanFlag("server-write-timeout", "1h")]
        public TimeSpan? ServerWriteTimeout { get; set; }

        /// <summary>
        /// User-specified template
        /// </summary>
        [StringFlag("template")]
        public string Template { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
