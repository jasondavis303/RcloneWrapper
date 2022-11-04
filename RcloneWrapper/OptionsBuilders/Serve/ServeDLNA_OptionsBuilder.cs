using RcloneWrapper.OptionsBuilders.Attributes;
using System;
using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders.Serve
{
    /// <summary>
    /// Serve remote:path over DLNA
    /// </summary>
    public class ServeDLNA_OptionsBuilder : VFS_OptionsBuilder
    {
        /// <summary>
        /// The ip:port or :port to bind the DLNA http server to (default ":7879")
        /// </summary>
        [StringFlag("addr", ":7879")]
        public string Addr { get; set; }

        /// <summary>
        /// The interval between SSDP announcements (default 12m0s)
        /// </summary>
        [TimeSpanFlag("announce-interval", "12m")]
        public TimeSpan? AnnounceInterval { get; set; }

        /// <summary>
        /// The interfaces to use for SSDP
        /// </summary>
        [RepeatingListFlag("interface")]
        public List<string> Interfaces { get; set; } = new();

        /// <summary>
        /// Enable trace logging of SOAP traffic
        /// </summary>
        [BoolFlag("log-trace")]
        public bool LogTrace { get; set; }

        /// <summary>
        /// Name of DLNA server
        /// </summary>
        [StringFlag("name")]
        public string Name { get; set; }


        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
