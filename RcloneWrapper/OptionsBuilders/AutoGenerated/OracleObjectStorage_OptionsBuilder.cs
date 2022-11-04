using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Oracle Cloud Infrastructure Object Storage
    /// </summary>
    [FlagPrefix("oos")]
    public class OracleObjectStorage_OptionsBuilder : Base_OptionsBuilder
    {
        public enum Providers
        {
            /// <summary>
            /// automatically pickup the credentials from runtime(env), first one to provide auth wins
            /// </summary>
            [Description("env_auth")]
            Env_Auth,

            /// <summary>
            /// use an OCI user and an API key for authentication. you’ll need to put in a config file your tenancy OCID, user OCID, region, the path, fingerprint to an API key. https://docs.oracle.com/en-us/iaas/Content/API/Concepts/sdkconfig.htm
            /// </summary>
            [Description("user_principal_auth")]
            User_Principal_Auth,

            /// <summary>
            /// use instance principals to authorize an instance to make API calls.  each instance has its own identity, and authenticates using the certificates that are read from instance metadata.  https://docs.oracle.com/en-us/iaas/Content/Identity/Tasks/callingservicesfrominstances.htm
            /// </summary>
            [Description("instance_principal_auth")]
            Instance_Principal_Auth,

            /// <summary>
            /// use resource principals to make API calls
            /// </summary>
            [Description("resource_principal_auth")]
            Resource_Principal_Auth,

            /// <summary>
            /// no credentials needed, this is typically for reading public buckets
            /// </summary>
            [Description("no_auth")]
            No_Auth,

        }


        /// <summary>
        /// Chunk size to use for uploading (default 5Mi)
        /// </summary>
        [SizeSuffixFlag("chunk-size", "5M")]
        public SizeSuffix ChunkSize { get; set; }


        /// <summary>
        /// Object storage compartment OCID
        /// </summary>
        [StringFlag("compartment")]
        public string Compartment { get; set; }


        /// <summary>
        /// Path to OCI config file (default &quot;~/.oci/config&quot;)
        /// </summary>
        [StringFlag("config-file", "~/.oci/config")]
        public string ConfigFile { get; set; }


        /// <summary>
        /// Profile name inside the oci config file (default &quot;Default&quot;)
        /// </summary>
        [StringFlag("config-profile", "Default")]
        public string ConfigProfile { get; set; }


        /// <summary>
        /// Cutoff for switching to multipart copy (default 4.656Gi)
        /// </summary>
        [SizeSuffixFlag("copy-cutoff", "4.656G")]
        public SizeSuffix CopyCutoff { get; set; }


        /// <summary>
        /// Timeout for copy (default 1m0s)
        /// </summary>
        [TimeSpanFlag("copy-timeout", "1m")]
        public TimeSpan? CopyTimeout { get; set; }


        /// <summary>
        /// Don&#39;t store MD5 checksum with object metadata
        /// </summary>
        [BoolFlag("disable-checksum")]
        public bool DisableChecksum { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Endpoint for Object storage API
        /// </summary>
        [StringFlag("endpoint")]
        public string Endpoint { get; set; }


        /// <summary>
        /// If true avoid calling abort upload on a failure, leaving all successfully uploaded parts on S3 for manual recovery
        /// </summary>
        [BoolFlag("leave-parts-on-error")]
        public bool LeavePartsOnError { get; set; }


        /// <summary>
        /// Object storage namespace
        /// </summary>
        [StringFlag("namespace")]
        public string Namespace { get; set; }


        /// <summary>
        /// If set, don&#39;t attempt to check the bucket exists or create it
        /// </summary>
        [BoolFlag("no-check-bucket")]
        public bool NoCheckBucket { get; set; }


        /// <summary>
        /// Choose your Auth Provider (default &quot;env_auth&quot;)
        /// </summary>
        [SingleEnumFlag("provider", (int)Providers.Env_Auth)]
        public Providers? Provider { get; set; }


        /// <summary>
        /// Object storage Region
        /// </summary>
        [StringFlag("region")]
        public string Region { get; set; }


        /// <summary>
        /// Concurrency for multipart uploads (default 10)
        /// </summary>
        [UintFlag("upload-concurrency", 10, 1)]
        public uint? UploadConcurrency { get; set; }


        /// <summary>
        /// Cutoff for switching to chunked upload (default 200Mi)
        /// </summary>
        [SizeSuffixFlag("upload-cutoff", "200M")]
        public SizeSuffix UploadCutoff { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
