using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// QingCloud Object Storage
    /// </summary>
    [FlagPrefix("qingstor")]
    public class QingStor_OptionsBuilder : Base_OptionsBuilder
    {
        public enum Zones
        {
            /// <summary>
            /// The Beijing (China) Three Zone. Needs location constraint pek3a.
            /// </summary>
            [Description("pek3a")]
            Pek3a,

            /// <summary>
            /// The Shanghai (China) First Zone. Needs location constraint sh1a.
            /// </summary>
            [Description("sh1a")]
            Sh1a,

            /// <summary>
            /// The Guangdong (China) Second Zone. Needs location constraint gd2a.
            /// </summary>
            [Description("gd2a")]
            Gd2a,

        }


        /// <summary>
        /// QingStor Access Key ID
        /// </summary>
        [StringFlag("access-key-id")]
        public string AccessKeyId { get; set; }


        /// <summary>
        /// Chunk size to use for uploading (default 4Mi)
        /// </summary>
        [SizeSuffixFlag("chunk-size", "4M")]
        public SizeSuffix ChunkSize { get; set; }


        /// <summary>
        /// Number of connection retries (default 3)
        /// </summary>
        [UintFlag("connection-retries", 3)]
        public uint? ConnectionRetries { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,Ctl,InvalidUtf8)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.Ctl | EncodingFlags.InvalidUtf8))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Enter an endpoint URL to connection QingStor API
        /// </summary>
        [StringFlag("endpoint")]
        public string Endpoint { get; set; }


        /// <summary>
        /// Get QingStor credentials from runtime
        /// </summary>
        [BoolFlag("env-auth")]
        public bool EnvAuth { get; set; }


        /// <summary>
        /// QingStor Secret Access Key (password)
        /// </summary>
        [StringFlag("secret-access-key")]
        public string SecretAccessKey { get; set; }


        /// <summary>
        /// Concurrency for multipart uploads (default 1)
        /// </summary>
        [UintFlag("upload-concurrency", 1, 1)]
        public uint? UploadConcurrency { get; set; }


        /// <summary>
        /// Cutoff for switching to chunked upload (default 200Mi)
        /// </summary>
        [SizeSuffixFlag("upload-cutoff", "200M")]
        public SizeSuffix UploadCutoff { get; set; }


        /// <summary>
        /// Zone to connect to
        /// </summary>
        [SingleEnumFlag("zone", (int)Zones.Pek3a)]
        public Zones? Zone { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
