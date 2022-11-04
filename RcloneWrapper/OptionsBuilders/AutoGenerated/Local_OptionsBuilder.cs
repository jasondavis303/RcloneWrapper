using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Local Disk
    /// </summary>
    [FlagPrefix("local")]
    public class Local_OptionsBuilder : Base_OptionsBuilder
    {
        /// <summary>
        /// Force the filesystem to report itself as case insensitive
        /// </summary>
        [BoolFlag("case-insensitive")]
        public bool CaseInsensitive { get; set; }


        /// <summary>
        /// Force the filesystem to report itself as case sensitive
        /// </summary>
        [BoolFlag("case-sensitive")]
        public bool CaseSensitive { get; set; }


        /// <summary>
        /// Follow symlinks and copy the pointed to item
        /// </summary>
        [NoPrefix]
        [BoolFlag("copy-links")]
        public bool CopyLinks { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,LtGt,DoubleQuote,Colon,Question,Asterisk,Pipe,BackSlash,Ctl,RightSpace,RightPeriod,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.LtGt | EncodingFlags.DoubleQuote | EncodingFlags.Colon | EncodingFlags.Question | EncodingFlags.Asterisk | EncodingFlags.Pipe | EncodingFlags.BackSlash | EncodingFlags.Ctl | EncodingFlags.RightSpace | EncodingFlags.RightPeriod | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Translate symlinks to/from regular files with a &#39;.rclonelink&#39; extension
        /// </summary>
        [NoPrefix]
        [BoolFlag("links")]
        public bool Links { get; set; }


        /// <summary>
        /// Don&#39;t check to see if the files change during upload
        /// </summary>
        [BoolFlag("no-check-updated")]
        public bool NoCheckUpdated { get; set; }


        /// <summary>
        /// Disable preallocation of disk space for transferred files
        /// </summary>
        [BoolFlag("no-preallocate")]
        public bool NoPreallocate { get; set; }


        /// <summary>
        /// Disable setting modtime
        /// </summary>
        [BoolFlag("no-set-modtime")]
        public bool NoSetModtime { get; set; }


        /// <summary>
        /// Disable sparse files for multi-thread downloads
        /// </summary>
        [BoolFlag("no-sparse")]
        public bool NoSparse { get; set; }


        /// <summary>
        /// Disable UNC (long path names) conversion on Windows
        /// </summary>
        [BoolFlag("nounc")]
        public bool Nounc { get; set; }


        /// <summary>
        /// Don&#39;t cross filesystem boundaries (unix/macOS only)
        /// </summary>
        [NoPrefix]
        [BoolFlag("one-file-system")]
        public bool OneFileSystem { get; set; }


        /// <summary>
        /// Don&#39;t warn about skipped symlinks
        /// </summary>
        [NoPrefix]
        [BoolFlag("skip-links")]
        public bool SkipLinks { get; set; }


        /// <summary>
        /// Apply unicode NFC normalization to paths and filenames
        /// </summary>
        [BoolFlag("unicode-normalization")]
        public bool UnicodeNormalization { get; set; }


        /// <summary>
        /// Assume the Stat size of links is zero (and read them instead) (deprecated)
        /// </summary>
        [BoolFlag("zero-size-links")]
        public bool ZeroSizeLinks { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
