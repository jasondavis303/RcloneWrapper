using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// SMB / CIFS
    /// </summary>
    [FlagPrefix("smb")]
    public class Smb_OptionsBuilder : Base_OptionsBuilder
    {
        /// <summary>
        /// Whether the server is configured to be case-insensitive (default true)
        /// </summary>
        [BoolFlag("case-insensitive", true)]
        public bool CaseInsensitive { get; set; } = true;


        /// <summary>
        /// Domain name for NTLM authentication (default &quot;WORKGROUP&quot;)
        /// </summary>
        [StringFlag("domain", "WORKGROUP")]
        public string Domain { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,LtGt,DoubleQuote,Colon,Question,Asterisk,Pipe,BackSlash,Ctl,RightSpace,RightPeriod,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.LtGt | EncodingFlags.DoubleQuote | EncodingFlags.Colon | EncodingFlags.Question | EncodingFlags.Asterisk | EncodingFlags.Pipe | EncodingFlags.BackSlash | EncodingFlags.Ctl | EncodingFlags.RightSpace | EncodingFlags.RightPeriod | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Hide special shares (e.g. print$) which users aren&#39;t supposed to access (default true)
        /// </summary>
        [BoolFlag("hide-special-share", true)]
        public bool HideSpecialShare { get; set; } = true;


        /// <summary>
        /// SMB server hostname to connect to
        /// </summary>
        [StringFlag("host")]
        public string Host { get; set; }


        /// <summary>
        /// Max time before closing idle connections (default 1m0s)
        /// </summary>
        [TimeSpanFlag("idle-timeout", "1m")]
        public TimeSpan? IdleTimeout { get; set; }


        /// <summary>
        /// SMB password (obscured)
        /// </summary>
        [StringFlag("pass")]
        public string Pass { get; set; }


        /// <summary>
        /// SMB port number (default 445)
        /// </summary>
        [UintFlag("port", 445, 0, 65536)]
        public uint? Port { get; set; }


        /// <summary>
        /// SMB username (default &quot;$USER&quot;)
        /// </summary>
        [StringFlag("user", "$USER")]
        public string User { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
