using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// OpenStack Swift (Rackspace Cloud Files, Memset Memstore, OVH)
    /// </summary>
    [FlagPrefix("swift")]
    public class Swift_OptionsBuilder : Base_OptionsBuilder
    {
        public static class Auths
        {
            public const string Rackspace_US = "https://auth.api.rackspacecloud.com/v1.0";

            public const string Rackspace_UK = "https://lon.auth.api.rackspacecloud.com/v1.0";

            public const string Rackspace_V2 = "https://identity.api.rackspacecloud.com/v2.0";

            public const string Memset_Memstore_UK = "https://auth.storage.memset.com/v1.0";

            public const string Memset_Memstore_UK_V2 = "https://auth.storage.memset.com/v2.0";

            public const string OVH = "https://auth.cloud.ovh.net/v3";

        }


        public static class StoragePolicies
        {
            public const string Default = "";

            public const string OVH_Public_Cloud_Storage = "pcs";

            public const string OVH_Public_Cloud_Archive = "pca";

        }


        public enum EndpointTypes
        {
            /// <summary>
            /// Public (default, choose this if not sure)
            /// </summary>
            [Description("public")]
            Public,

            /// <summary>
            /// Internal (use internal service net)
            /// </summary>
            [Description("internal")]
            Internal,

            /// <summary>
            /// Admin
            /// </summary>
            [Description("admin")]
            Admin,

        }


        /// <summary>
        /// Application Credential ID (OS_APPLICATION_CREDENTIAL_ID)
        /// </summary>
        [StringFlag("application-credential-id")]
        public string ApplicationCredentialId { get; set; }


        /// <summary>
        /// Application Credential Name (OS_APPLICATION_CREDENTIAL_NAME)
        /// </summary>
        [StringFlag("application-credential-name")]
        public string ApplicationCredentialName { get; set; }


        /// <summary>
        /// Application Credential Secret (OS_APPLICATION_CREDENTIAL_SECRET)
        /// </summary>
        [StringFlag("application-credential-secret")]
        public string ApplicationCredentialSecret { get; set; }


        /// <summary>
        /// Authentication URL for server (OS_AUTH_URL)
        /// </summary>
        [StringFlag("auth")]
        public string Auth { get; set; }


        /// <summary>
        /// Auth Token from alternate authentication - optional (OS_AUTH_TOKEN)
        /// </summary>
        [StringFlag("auth-token")]
        public string AuthToken { get; set; }


        /// <summary>
        /// AuthVersion - optional - set to (1,2,3) if your auth URL has no version (ST_AUTH_VERSION)
        /// </summary>
        [UintFlag("port", 3, 1, 3)]
        public uint? AuthVersion { get; set; }


        /// <summary>
        /// Above this size files will be chunked into a _segments container (default 5Gi)
        /// </summary>
        [SizeSuffixFlag("chunk-size", "5G")]
        public SizeSuffix ChunkSize { get; set; }


        /// <summary>
        /// User domain - optional (v3 auth) (OS_USER_DOMAIN_NAME)
        /// </summary>
        [StringFlag("domain")]
        public string Domain { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,InvalidUtf8)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.InvalidUtf8))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Endpoint type to choose from the service catalogue (OS_ENDPOINT_TYPE) (default &quot;public&quot;)
        /// </summary>
        [SingleEnumFlag("endpoint-type", (int)EndpointTypes.Public)]
        public EndpointTypes? EndpointType { get; set; }


        /// <summary>
        /// Get swift credentials from environment variables in standard OpenStack form
        /// </summary>
        [BoolFlag("env-auth")]
        public bool EnvAuth { get; set; }


        /// <summary>
        /// API key or password (OS_PASSWORD)
        /// </summary>
        [StringFlag("key")]
        public string Key { get; set; }


        /// <summary>
        /// If true avoid calling abort upload on a failure
        /// </summary>
        [BoolFlag("leave-parts-on-error")]
        public bool LeavePartsOnError { get; set; }


        /// <summary>
        /// Don&#39;t chunk files during streaming upload
        /// </summary>
        [BoolFlag("no-chunk")]
        public bool NoChunk { get; set; }


        /// <summary>
        /// Disable support for static and dynamic large objects
        /// </summary>
        [BoolFlag("no-large-objects")]
        public bool NoLargeObjects { get; set; }


        /// <summary>
        /// Region name - optional (OS_REGION_NAME)
        /// </summary>
        [StringFlag("region")]
        public string Region { get; set; }


        /// <summary>
        /// The storage policy to use when creating a new container
        /// </summary>
        [StringFlag("storage-policy")]
        public string StoragePolicy { get; set; }


        /// <summary>
        /// Storage URL - optional (OS_STORAGE_URL)
        /// </summary>
        [StringFlag("storage-url")]
        public string StorageUrl { get; set; }


        /// <summary>
        /// Tenant name - optional for v1 auth, this or tenant_id required otherwise (OS_TENANT_NAME or OS_PROJECT_NAME)
        /// </summary>
        [StringFlag("tenant")]
        public string Tenant { get; set; }


        /// <summary>
        /// Tenant domain - optional (v3 auth) (OS_PROJECT_DOMAIN_NAME)
        /// </summary>
        [StringFlag("tenant-domain")]
        public string TenantDomain { get; set; }


        /// <summary>
        /// Tenant ID - optional for v1 auth, this or tenant required otherwise (OS_TENANT_ID)
        /// </summary>
        [StringFlag("tenant-id")]
        public string TenantId { get; set; }


        /// <summary>
        /// User name to log in (OS_USERNAME)
        /// </summary>
        [StringFlag("user")]
        public string User { get; set; }


        /// <summary>
        /// User ID to log in - optional - most swift systems use user and leave this blank (v3 auth) (OS_USER_ID)
        /// </summary>
        [StringFlag("user-id")]
        public string UserId { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
