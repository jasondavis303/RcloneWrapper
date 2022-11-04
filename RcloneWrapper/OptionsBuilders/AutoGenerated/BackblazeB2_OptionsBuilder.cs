using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Backblaze B2
    /// </summary>
    [FlagPrefix("b2")]
    public class BackblazeB2_OptionsBuilder : Base_OptionsBuilder
    {
        /// <summary>
        /// Account ID or Application Key ID
        /// </summary>
        [StringFlag("account")]
        public string Account { get; set; }


        /// <summary>
        /// Upload chunk size (default 96Mi)
        /// </summary>
        [SizeSuffixFlag("chunk-size", "96M")]
        public SizeSuffix ChunkSize { get; set; }


        /// <summary>
        /// Cutoff for switching to multipart copy (default 4Gi)
        /// </summary>
        [SizeSuffixFlag("copy-cutoff", "4G")]
        public SizeSuffix CopyCutoff { get; set; }


        /// <summary>
        /// Disable checksums for large (&gt; upload cutoff) files
        /// </summary>
        [BoolFlag("disable-checksum")]
        public bool DisableChecksum { get; set; }


        /// <summary>
        /// Time before the authorization token will expire in s or suffix ms|s|m|h|d (default 1w)
        /// </summary>
        [TimeSpanFlag("download-auth-duration", "1w")]
        public TimeSpan? DownloadAuthDuration { get; set; }


        /// <summary>
        /// Custom endpoint for downloads
        /// </summary>
        [StringFlag("download-url")]
        public string DownloadUrl { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,BackSlash,Del,Ctl,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.BackSlash | EncodingFlags.Del | EncodingFlags.Ctl | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Endpoint for the service
        /// </summary>
        [StringFlag("endpoint")]
        public string Endpoint { get; set; }


        /// <summary>
        /// Permanently delete files on remote removal, otherwise hide files
        /// </summary>
        [BoolFlag("hard-delete")]
        public bool HardDelete { get; set; }


        /// <summary>
        /// Application Key
        /// </summary>
        [StringFlag("key")]
        public string Key { get; set; }


        /// <summary>
        /// How often internal memory buffer pools will be flushed (default 1m0s)
        /// </summary>
        [TimeSpanFlag("memory-pool-flush-time", "1m")]
        public TimeSpan? MemoryPoolFlushTime { get; set; }


        /// <summary>
        /// Whether to use mmap buffers in internal memory pool
        /// </summary>
        [BoolFlag("memory-pool-use-mmap")]
        public bool MemoryPoolUseMmap { get; set; }


        /// <summary>
        /// Cutoff for switching to chunked upload (default 200Mi)
        /// </summary>
        [SizeSuffixFlag("upload-cutoff", "200M")]
        public SizeSuffix UploadCutoff { get; set; }


        /// <summary>
        /// Show file versions as they were at the specified time (default off)
        /// </summary>
        [DateTimeFlag("version-at")]
        public DateTime? VersionAt { get; set; }


        /// <summary>
        /// Include old versions in directory listings
        /// </summary>
        [BoolFlag("versions")]
        public bool Versions { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
