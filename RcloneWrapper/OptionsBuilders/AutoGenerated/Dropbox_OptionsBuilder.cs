using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Dropbox
    /// </summary>
    [FlagPrefix("dropbox")]
    public class Dropbox_OptionsBuilder : OAuth_OptionsBuilder
    {
        public enum BatchModes
        {
            /// <summary>
            /// Batch uploads and check completion (default)
            /// </summary>
            [Description("sync")]
            Sync,

            /// <summary>
            /// Batch upload and don&#39;t check completion
            /// </summary>
            [Description("async")]
            Async,

            /// <summary>
            /// No batching
            /// </summary>
            [Description("off")]
            Off,

        }


        /// <summary>
        /// Max time to wait for a batch to finish committing (default 10m0s)
        /// </summary>
        [TimeSpanFlag("batch-commit-timeout", "10m")]
        public TimeSpan? BatchCommitTimeout { get; set; }


        /// <summary>
        /// Upload file batching sync|async|off (default &quot;sync&quot;)
        /// </summary>
        [SingleEnumFlag("batch-mode", (int)BatchModes.Sync)]
        public BatchModes? BatchMode { get; set; }


        /// <summary>
        /// Max number of files in upload batch
        /// </summary>
        [UintFlag("batch-size", 0, 0, 1000)]
        public uint? BatchSize { get; set; }


        /// <summary>
        /// Max time to allow an idle upload batch before uploading (default 0s)
        /// </summary>
        [TimeSpanFlag("batch-timeout", "0s")]
        public TimeSpan? BatchTimeout { get; set; }


        /// <summary>
        /// Upload chunk size (&lt; 150Mi) (default 48Mi)
        /// </summary>
        [SizeSuffixFlag("chunk-size", "48M")]
        public SizeSuffix ChunkSize { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,BackSlash,Del,RightSpace,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.BackSlash | EncodingFlags.Del | EncodingFlags.RightSpace | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Impersonate this user when using a business account
        /// </summary>
        [StringFlag("impersonate")]
        public string Impersonate { get; set; }


        /// <summary>
        /// Instructs rclone to work on individual shared files
        /// </summary>
        [BoolFlag("shared-files")]
        public bool SharedFiles { get; set; }


        /// <summary>
        /// Instructs rclone to work on shared folders
        /// </summary>
        [BoolFlag("shared-folders")]
        public bool SharedFolders { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
