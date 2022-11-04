using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Microsoft Azure Blob Storage
    /// </summary>
    [FlagPrefix("azureblob")]
    public class AzureBlob_OptionsBuilder : Base_OptionsBuilder
    {
        public enum AccessTiers
        {
            /// <summary>
            /// Default
            /// </summary>
            [Description("Default")]
            Default,

            [Description("hot")]
            Hot,

            [Description("cool")]
            Cool,

            [Description("archive")]
            Archive,

        }


        public enum PublicAccesses
        {
            /// <summary>
            /// The container and its blobs can be accessed only with an authorized request. It&#39;s a default value.
            /// </summary>
            [Description("")]
            Default,

            /// <summary>
            /// Blob data within this container can be read via anonymous request.
            /// </summary>
            [Description("blob")]
            Blob,

            /// <summary>
            /// Allow full public read access for container and blob data.
            /// </summary>
            [Description("container")]
            Container,

        }


        /// <summary>
        /// Access tier of blob: hot, cool or archive
        /// </summary>
        [SingleEnumFlag("access-tier", (int)AccessTiers.Default)]
        public AccessTiers? AccessTier { get; set; }


        /// <summary>
        /// Storage Account Name
        /// </summary>
        [StringFlag("account")]
        public string Account { get; set; }


        /// <summary>
        /// Delete archive tier blobs before overwriting
        /// </summary>
        [BoolFlag("archive-tier-delete")]
        public bool ArchiveTierDelete { get; set; }


        /// <summary>
        /// Upload chunk size (default 4Mi)
        /// </summary>
        [SizeSuffixFlag("chunk-size", "4M")]
        public SizeSuffix ChunkSize { get; set; }


        /// <summary>
        /// Don&#39;t store MD5 checksum with object metadata
        /// </summary>
        [BoolFlag("disable-checksum")]
        public bool DisableChecksum { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,BackSlash,Del,Ctl,RightPeriod,InvalidUtf8)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.BackSlash | EncodingFlags.Del | EncodingFlags.Ctl | EncodingFlags.RightPeriod | EncodingFlags.InvalidUtf8))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Endpoint for the service
        /// </summary>
        [StringFlag("endpoint")]
        public string Endpoint { get; set; }


        /// <summary>
        /// Storage Account Key
        /// </summary>
        [StringFlag("key")]
        public string Key { get; set; }


        /// <summary>
        /// Size of blob list (default 5000)
        /// </summary>
        [UintFlag("list-chunk", 5000, 1)]
        public uint? ListChunk { get; set; }


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
        /// Object ID of the user-assigned MSI to use, if any
        /// </summary>
        [StringFlag("msi-client-id")]
        public string MsiClientId { get; set; }


        /// <summary>
        /// Azure resource ID of the user-assigned MSI to use, if any
        /// </summary>
        [StringFlag("msi-mi-res-id")]
        public string MsiMiResId { get; set; }


        /// <summary>
        /// Object ID of the user-assigned MSI to use, if any
        /// </summary>
        [StringFlag("msi-object-id")]
        public string MsiObjectId { get; set; }


        /// <summary>
        /// If set, do not do HEAD before GET when getting objects
        /// </summary>
        [BoolFlag("no-head-object")]
        public bool NoHeadObject { get; set; }


        /// <summary>
        /// Public access level of a container: blob or container
        /// </summary>
        [SingleEnumFlag("public-access", (int)PublicAccesses.Default)]
        public PublicAccesses? PublicAccess { get; set; }


        /// <summary>
        /// SAS URL for container level access only
        /// </summary>
        [StringFlag("sas-url")]
        public string SasUrl { get; set; }


        /// <summary>
        /// Path to file containing credentials for use with a service principal
        /// </summary>
        [StringFlag("service-principal-file")]
        public string ServicePrincipalFile { get; set; }


        /// <summary>
        /// Concurrency for multipart uploads (default 16)
        /// </summary>
        [UintFlag("upload-concurrency", 16, 1)]
        public uint? UploadConcurrency { get; set; }


        /// <summary>
        /// Cutoff for switching to chunked upload (&lt;= 256 MiB) (deprecated)
        /// </summary>
        [StringFlag("upload-cutoff")]
        public string UploadCutoff { get; set; }


        /// <summary>
        /// Uses local storage emulator if provided as &#39;true&#39;
        /// </summary>
        [BoolFlag("use-emulator")]
        public bool UseEmulator { get; set; }


        /// <summary>
        /// Use a managed service identity to authenticate (only works in Azure)
        /// </summary>
        [BoolFlag("use-msi")]
        public bool UseMsi { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
