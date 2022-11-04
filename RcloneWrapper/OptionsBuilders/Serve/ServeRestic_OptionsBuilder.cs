using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;

namespace RcloneWrapper.OptionsBuilders.Serve
{
    public class ServeRestic_OptionsBuilder : SecureServeCreds_OptionsBuilder
    {
        /// <summary>
        /// IPaddress:Port or :Port to bind server to (default "localhost:8080")
        /// </summary>
        [StringFlag("addr", "localhost:8080")]
        public string Addr { get; set; }

        /// <summary>
        /// Disallow deletion of repository data
        /// </summary>
        [BoolFlag("append-only")]
        public bool AppendOnly { get; set; }

        /// <summary>
        /// Prefix for URLs - leave blank for root
        /// </summary>
        [StringFlag("baseurl")]
        public string BaseUrl { get; set; }

        /// <summary>
        /// Cache listed objects (default true)
        /// </summary>
        [BoolFlag("cache-objects", true)]
        public bool CacheObjects { get; set; } = true;

        /// <summary>
        /// Maximum size of request header (default 4096)
        /// </summary>
        [UintFlag("max-header-bytes", 4096)]
        public uint? MaxHeaderBytes { get; set; }

        /// <summary>
        /// Users can only access their private repo
        /// </summary>
        [BoolFlag("private-repose")]
        public bool PrivateRepose { get; set; }

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
        /// Run an HTTP2 server on stdin/stdout
        /// </summary>
        [BoolFlag("stdio")]
        public bool Stdio { get; set; }

        /// <summary>
        /// User-specified template
        /// </summary>
        [StringFlag("template")]
        public string Template { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
