using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Jottacloud
    /// </summary>
    [FlagPrefix("jottacloud")]
    public class Jottacloud_OptionsBuilder : Base_OptionsBuilder
    {
        /// <summary>
        /// The encoding for the backend (default Slash,LtGt,DoubleQuote,Colon,Question,Asterisk,Pipe,Del,Ctl,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.LtGt | EncodingFlags.DoubleQuote | EncodingFlags.Colon | EncodingFlags.Question | EncodingFlags.Asterisk | EncodingFlags.Pipe | EncodingFlags.Del | EncodingFlags.Ctl | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Delete files permanently rather than putting them into the trash
        /// </summary>
        [BoolFlag("hard-delete")]
        public bool HardDelete { get; set; }


        /// <summary>
        /// Files bigger than this will be cached on disk to calculate the MD5 if required (default 10Mi)
        /// </summary>
        [SizeSuffixFlag("md5-memory-limit", "10M")]
        public SizeSuffix Md5MemoryLimit { get; set; }


        /// <summary>
        /// Avoid server side versioning by deleting files and recreating files instead of overwriting them
        /// </summary>
        [BoolFlag("no-versions")]
        public bool NoVersions { get; set; }


        /// <summary>
        /// Only show files that are in the trash
        /// </summary>
        [BoolFlag("trashed-only")]
        public bool TrashedOnly { get; set; }


        /// <summary>
        /// Files bigger than this can be resumed if the upload fail&#39;s (default 10Mi)
        /// </summary>
        [SizeSuffixFlag("upload-resume-limit", "10M")]
        public SizeSuffix UploadResumeLimit { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
