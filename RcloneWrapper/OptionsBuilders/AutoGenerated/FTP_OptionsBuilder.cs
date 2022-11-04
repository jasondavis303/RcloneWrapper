using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// FTP
    /// </summary>
    [FlagPrefix("ftp")]
    public class FTP_OptionsBuilder : Base_OptionsBuilder
    {
        /// <summary>
        /// Allow asking for FTP password when needed
        /// </summary>
        [BoolFlag("ask-password")]
        public bool AskPassword { get; set; }


        /// <summary>
        /// Maximum time to wait for a response to close (default 1m0s)
        /// </summary>
        [TimeSpanFlag("close-timeout", "1m")]
        public TimeSpan? CloseTimeout { get; set; }


        /// <summary>
        /// Maximum number of FTP simultaneous connections, 0 for unlimited
        /// </summary>
        [UintFlag("concurrency", 0, 1)]
        public uint? Concurrency { get; set; }


        /// <summary>
        /// Disable using EPSV even if server advertises support
        /// </summary>
        [BoolFlag("disable-epsv")]
        public bool DisableEpsv { get; set; }


        /// <summary>
        /// Disable using MLSD even if server advertises support
        /// </summary>
        [BoolFlag("disable-mlsd")]
        public bool DisableMlsd { get; set; }


        /// <summary>
        /// Disable TLS 1.3 (workaround for FTP servers with buggy TLS)
        /// </summary>
        [BoolFlag("disable-tls13")]
        public bool DisableTls13 { get; set; }


        /// <summary>
        /// Disable using UTF-8 even if server advertises support
        /// </summary>
        [BoolFlag("disable-utf8")]
        public bool DisableUtf8 { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,Del,Ctl,RightSpace,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.Del | EncodingFlags.Ctl | EncodingFlags.RightSpace | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Use Explicit FTPS (FTP over TLS)
        /// </summary>
        [BoolFlag("explicit-tls")]
        public bool ExplicitTls { get; set; }


        /// <summary>
        /// Use LIST -a to force listing of hidden files and folders. This will disable the use of MLSD
        /// </summary>
        [BoolFlag("force-list-hidden")]
        public bool ForceListHidden { get; set; }


        /// <summary>
        /// FTP host to connect to
        /// </summary>
        [StringFlag("host")]
        public string Host { get; set; }


        /// <summary>
        /// Max time before closing idle connections (default 1m0s)
        /// </summary>
        [TimeSpanFlag("idle-timeout", "1m")]
        public TimeSpan? IdleTimeout { get; set; }


        /// <summary>
        /// Do not verify the TLS certificate of the server
        /// </summary>
        [BoolFlag("no-check-certificate")]
        public bool NoCheckCertificate { get; set; }


        /// <summary>
        /// FTP password (obscured)
        /// </summary>
        [StringFlag("pass")]
        public string Pass { get; set; }


        /// <summary>
        /// FTP port number (default 21)
        /// </summary>
        [UintFlag("port", 21, 0, 65536)]
        public uint? Port { get; set; }


        /// <summary>
        /// Maximum time to wait for data connection closing status (default 1m0s)
        /// </summary>
        [TimeSpanFlag("shut-timeout", "1m")]
        public TimeSpan? ShutTimeout { get; set; }


        /// <summary>
        /// Use Implicit FTPS (FTP over TLS)
        /// </summary>
        [BoolFlag("tls")]
        public bool Tls { get; set; }


        /// <summary>
        /// Size of TLS session cache for all control and data connections (default 32)
        /// </summary>
        [UintFlag("tls-cache-size", 32, 1)]
        public uint? TlsCacheSize { get; set; }


        /// <summary>
        /// FTP username (default &quot;$USER&quot;)
        /// </summary>
        [StringFlag("user", "$USER")]
        public string User { get; set; }


        /// <summary>
        /// Use MDTM to set modification time (VsFtpd quirk)
        /// </summary>
        [BoolFlag("writing-mdtm")]
        public bool WritingMdtm { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
