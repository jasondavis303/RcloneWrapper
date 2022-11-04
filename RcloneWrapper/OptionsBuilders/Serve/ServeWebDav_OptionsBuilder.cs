using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;

namespace RcloneWrapper.OptionsBuilders.Serve
{
    /// <summary>
    /// Serve the remote over WebDav
    /// </summary>
    public class ServeWebDav_OptionsBuilder : SecureServeCreds_OptionsBuilder
    {
        /// <summary>
        /// IPaddress:Port or :Port to bind server to (default "localhost:8080")
        /// </summary>
        [StringFlag("addr", "localhost:8080")]
        public string Addr { get; set; }

        /// <summary>
        /// A program to use to create the backend from the auth
        /// </summary>
        [StringFlag("auth-proxy")]
        public string AuthProxy { get; set; }


        /// <summary>
        /// Prefix for URLs - leave blank for root
        /// </summary>
        [StringFlag("baseurl")]
        public string BaseUrl { get; set; }

        /// <summary>
        /// Disable HTML directory list on GET request for a directory
        /// </summary>
        [BoolFlag("disable-dir-list")]
        public bool DisableDirList { get; set; }

        /// <summary>
        /// Which hash to use for the ETag, or auto or blank for off
        /// </summary>
        [StringFlag("etag-hash", "off")]
        public string EtagHash { get; set; }

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
