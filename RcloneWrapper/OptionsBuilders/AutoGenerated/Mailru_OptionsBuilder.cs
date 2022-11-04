using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Mail.ru Cloud
    /// </summary>
    [FlagPrefix("mailru")]
    public class Mailru_OptionsBuilder : Base_OptionsBuilder
    {
        /// <summary>
        /// What should copy do if file checksum is mismatched or invalid (default true)
        /// </summary>
        [BoolFlag("check-hash", true)]
        public bool CheckHash { get; set; } = true;


        /// <summary>
        /// The encoding for the backend (default Slash,LtGt,DoubleQuote,Colon,Question,Asterisk,Pipe,BackSlash,Del,Ctl,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.LtGt | EncodingFlags.DoubleQuote | EncodingFlags.Colon | EncodingFlags.Question | EncodingFlags.Asterisk | EncodingFlags.Pipe | EncodingFlags.BackSlash | EncodingFlags.Del | EncodingFlags.Ctl | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Password (obscured)
        /// </summary>
        [StringFlag("pass")]
        public string Pass { get; set; }


        /// <summary>
        /// Skip full upload if there is another file with same data hash (default true)
        /// </summary>
        [BoolFlag("speedup-enable", true)]
        public bool SpeedupEnable { get; set; } = true;


        /// <summary>
        /// Comma separated list of file name patterns eligible for speedup (put by hash) (default &quot;*.mkv,*.avi,*.mp4,*.mp3,*.zip,*.gz,*.rar,*.pdf&quot;)
        /// </summary>
        [CommaSeparatedListFlag("speedup-file-patterns", "*.mkv", "*.avi", "*.mp4", "*.mp3", "*.zip", "*.gz", "*.rar", "*.pdf", PermuteDefaultValues = true)]
        public List<string> SpeedupFilePatterns { get; set; } = new();


        /// <summary>
        /// This option allows you to disable speedup (put by hash) for large files (default 3Gi)
        /// </summary>
        [SizeSuffixFlag("speedup-max-disk", "3G")]
        public SizeSuffix SpeedupMaxDisk { get; set; }


        /// <summary>
        /// Files larger than the size given below will always be hashed on disk (default 32Mi)
        /// </summary>
        [SizeSuffixFlag("speedup-max-memory", "32M")]
        public SizeSuffix SpeedupMaxMemory { get; set; }


        /// <summary>
        /// User name (usually email)
        /// </summary>
        [StringFlag("user")]
        public string User { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
