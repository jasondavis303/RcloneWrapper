using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// HiDrive
    /// </summary>
    [FlagPrefix("hidrive")]
    public class HiDrive_OptionsBuilder : OAuth_OptionsBuilder
    {
        public static class Endpoints
        {
            public const string Default = "https://api.hidrive.strato.com/2.1";

        }


        public enum ScopeAccesses
        {
            /// <summary>
            /// Read and write access to resources.
            /// </summary>
            [Description("rw")]
            Rw,

            /// <summary>
            /// Read-only access to resources.
            /// </summary>
            [Description("ro")]
            Ro,

        }


        public enum ScopeRoles
        {
            /// <summary>
            /// User-level access to management permissions. This will be sufficient in most cases.
            /// </summary>
            [Description("user")]
            User,

            /// <summary>
            /// Extensive access to management permissions.
            /// </summary>
            [Description("admin")]
            Admin,

            /// <summary>
            /// Full access to management permissions.
            /// </summary>
            [Description("owner")]
            Owner,

        }


        /// <summary>
        /// Chunksize for chunked uploads (default 48Mi)
        /// </summary>
        [SizeSuffixFlag("chunk-size", "48M")]
        public SizeSuffix ChunkSize { get; set; }


        /// <summary>
        /// Do not fetch number of objects in directories unless it is absolutely necessary
        /// </summary>
        [BoolFlag("disable-fetching-member-count")]
        public bool DisableFetchingMemberCount { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Endpoint for the service (default &quot;https://api.hidrive.strato.com/2.1&quot;)
        /// </summary>
        [StringFlag("endpoint", "https://api.hidrive.strato.com/2.1")]
        public string Endpoint { get; set; }


        /// <summary>
        /// The root/parent folder for all paths (default &quot;/&quot;)
        /// </summary>
        [StringFlag("root-prefix", "/")]
        public string RootPrefix { get; set; }


        /// <summary>
        /// Access permissions that rclone should use when requesting access from HiDrive (default &quot;rw&quot;)
        /// </summary>
        [SingleEnumFlag("scope-access", (int)ScopeAccesses.Rw)]
        public ScopeAccesses? ScopeAccess { get; set; }


        /// <summary>
        /// User-level that rclone should use when requesting access from HiDrive (default &quot;user&quot;)
        /// </summary>
        [SingleEnumFlag("scope-role", (int)ScopeRoles.User)]
        public ScopeRoles? ScopeRole { get; set; }


        /// <summary>
        /// Concurrency for chunked uploads (default 4)
        /// </summary>
        [UintFlag("upload-concurrency", 4, 1)]
        public uint? UploadConcurrency { get; set; }


        /// <summary>
        /// Cutoff/Threshold for chunked uploads (default 96Mi)
        /// </summary>
        [SizeSuffixFlag("upload-cutoff", "96M")]
        public SizeSuffix UploadCutoff { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
