using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Amazon Drive
    /// </summary>
    [FlagPrefix("acd")]
    public class AmazonCloudDrive_OptionsBuilder : OAuth_OptionsBuilder
    {
        /// <summary>
        /// The encoding for the backend (default Slash,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Files &gt;= this size will be downloaded via their tempLink (default 9Gi)
        /// </summary>
        [SizeSuffixFlag("templink-threshold", "9G")]
        public SizeSuffix TemplinkThreshold { get; set; }


        /// <summary>
        /// Additional time per GiB to wait after a failed complete upload to see if it appears (default 3m0s)
        /// </summary>
        [TimeSpanFlag("upload-wait-per-gb", "3m")]
        public TimeSpan? UploadWaitPerGb { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
