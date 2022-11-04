using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;

namespace RcloneWrapper.OptionsBuilders
{
    [FlagPrefix("rc")]
    public class RC_OptionsBuilder : Base_OptionsBuilder
    {
        /// <summary>
        /// Enable the remote control server
        /// </summary>
        [NoPrefix]
        [BoolFlag("rc")]
        public bool Rc { get; set; }

        /// <summary>
        /// IPaddress:Port or :Port to bind server to (default "localhost:5572")
        /// </summary>
        [StringFlag("rc-addr", "localhost:5572")]
        public string Addr { get; set; }

        /// <summary>
        /// Set the allowed origin for CORS
        /// </summary>
        [StringFlag("rc-allow-origin")]
        public string AllowOrigin { get; set; }

        /// <summary>
        /// Prefix for URLs - leave blank for root
        /// </summary>
        [StringFlag("rc-baseurl")]
        public string BaseUrl { get; set; }

        /// <summary>
        /// SSL PEM key (concatenation of certificate and CA certificate)
        /// </summary>
        [StringFlag("rc-cert")]
        public string Cert { get; set; }

        /// <summary>
        /// Client certificate authority to verify clients with
        /// </summary>
        [StringFlag("rc-client-ca")]
        public string ClientCa { get; set; }

        /// <summary>
        /// Enable prometheus metrics on /metrics
        /// </summary>
        [BoolFlag("rc-enable-metrics")]
        public bool EnableMetrics { get; set; }

        /// <summary>
        /// Path to local files to serve on the HTTP server
        /// </summary>
        [StringFlag("rc-files")]
        public string Files { get; set; }

        /// <summary>
        /// htpasswd file - if not provided no authentication is done
        /// </summary>
        [StringFlag("rc-htpasswd")]
        public string HtPasswd { get; set; }

        /// <summary>
        /// Expire finished async jobs older than this value (default 1m0s)
        /// </summary>
        [TimeSpanFlag("rc-job-expire-duration", "1m")]
        public TimeSpan? JobExpireDuration { get; set; }

        /// <summary>
        /// Interval to check for expired async jobs (default 10s)
        /// </summary>
        [TimeSpanFlag("rc-job-expire-interval", "10s")]
        public TimeSpan? JobExpireInterval { get; set; }

        /// <summary>
        /// SSL PEM Private key
        /// </summary>
        [StringFlag("rc-key")]
        public string Key { get; set; }

        /// <summary>
        /// Maximum size of request header (default 4096)
        /// </summary>
        [UintFlag("rc-max-header-bytes", 4096)]
        public uint? MaxHeaderBytes { get; set; }


        /// <summary>
        /// Minimum TLS version that is acceptable (default "tls1.0")
        /// </summary>
        [MinTLSFlag("min-tls-version", 1.0)]
        public double? MinTlsVersion { get; set; }

        /// <summary>
        /// Don't require auth for certain methods
        /// </summary>
        [BoolFlag("rc-no-auth")]
        public bool NoAuth { get; set; }

        /// <summary>
        /// Password for authentication
        /// </summary>
        [StringFlag("rc-pass")]
        public string Pass { get; set; }

        /// <summary>
        /// Realm for authentication (default "rclone")
        /// </summary>
        [StringFlag("rc-realm", "rclone")]
        public string Realm { get; set; }

        /// <summary>
        /// Enable the serving of remote objects
        /// </summary>
        [BoolFlag("rc-serve")]
        public bool Serve { get; set; }

        /// <summary>
        /// Timeout for server reading data (default 1h0m0s)
        /// </summary>
        [TimeSpanFlag("rc-server-read-timeout", "1h")]
        public TimeSpan? ServerReadTimeout { get; set; }

        /// <summary>
        /// Timeout for server writing data (default 1h0m0s)
        /// </summary>
        [TimeSpanFlag("rc-server-write-timeout", "1h")]
        public TimeSpan? ServerWriteTimeout { get; set; }

        /// <summary>
        /// User-specified template
        /// </summary>
        [StringFlag("rc-template")]
        public string Template { get; set; }

        /// <summary>
        /// User name for authentication
        /// </summary>
        [StringFlag("rc-user")]
        public string User { get; set; }

        /// <summary>
        /// URL to fetch the releases for webgui (default "https://api.github.com/repos/rclone/rclone-webui-react/releases/latest")
        /// </summary>
        [StringFlag("rc-web-fetch-url", "https://api.github.com/repos/rclone/rclone-webui-react/releases/latest")]
        public string WebFetchUrl { get; set; }

        /// <summary>
        /// Launch WebGUI on localhost
        /// </summary>
        [BoolFlag("rc-web-gui")]
        public bool WebGui { get; set; }

        /// <summary>
        /// Force update to latest version of web gui
        /// </summary>
        [BoolFlag("rc-web-gui-force-update")]
        public bool WebGuiForceUpdate { get; set; }

        /// <summary>
        /// Don't open the browser automatically
        /// </summary>
        [BoolFlag("rc-web-gui-no-open-browser")]
        public bool WebGuiNoOpenBrowser { get; set; }

        /// <summary>
        /// Check and update to latest version of web gui
        /// </summary>
        [BoolFlag("rc-web-gui-update")]
        public bool WebGuiUpdate { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
