using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Google Cloud Storage (this is not Google Drive)
    /// </summary>
    [FlagPrefix("gcs")]
    public class GoogleCloudStorage_OptionsBuilder : OAuth_OptionsBuilder
    {
        public enum BucketAcls
        {
            /// <summary>
            /// Project team owners get OWNER access. All Authenticated Users get READER access.
            /// </summary>
            [Description("authenticatedRead")]
            AuthenticatedRead,

            /// <summary>
            /// Project team owners get OWNER access. Default if left blank.
            /// </summary>
            [Description("private")]
            Private,

            /// <summary>
            /// Project team members get access according to their roles.
            /// </summary>
            [Description("projectPrivate")]
            ProjectPrivate,

            /// <summary>
            /// Project team owners get OWNER access. All Users get READER access.
            /// </summary>
            [Description("publicRead")]
            PublicRead,

            /// <summary>
            /// Project team owners get OWNER access. All Users get WRITER access.
            /// </summary>
            [Description("publicReadWrite")]
            PublicReadWrite,

        }


        public enum Locations
        {
            /// <summary>
            /// Empty for default location (US)
            /// </summary>
            [Description("")]
            Default,

            /// <summary>
            /// Multi-regional location for Asia
            /// </summary>
            [Description("asia")]
            Asia,

            /// <summary>
            /// Multi-regional location for Europe
            /// </summary>
            [Description("eu")]
            EU,

            /// <summary>
            /// Multi-regional location for United States
            /// </summary>
            [Description("us")]
            US,

            /// <summary>
            /// Taiwan
            /// </summary>
            [Description("asia-east1")]
            Asia_East1,

            /// <summary>
            /// Hong Kong
            /// </summary>
            [Description("asia-east2")]
            Asia_East2,

            /// <summary>
            /// Tokyo
            /// </summary>
            [Description("asia-northeast1")]
            Asia_NorthEast1,

            /// <summary>
            /// Osaka
            /// </summary>
            [Description("asia-northeast2")]
            Asia_NorthEast2,

            /// <summary>
            /// Seoul
            /// </summary>
            [Description("asia-northeast3")]
            Asia_NorthEast3,

            /// <summary>
            /// Mumbai
            /// </summary>
            [Description("asia-south1")]
            Asia_South1,

            /// <summary>
            /// Delhi
            /// </summary>
            [Description("asia-south2")]
            Asia_South2,

            /// <summary>
            /// Singapore
            /// </summary>
            [Description("asia-southeast1")]
            Asia_SouthEast1,

            /// <summary>
            /// Jakarta
            /// </summary>
            [Description("asia-southeast2")]
            Asia_SouthEast2,

            /// <summary>
            /// Sydney
            /// </summary>
            [Description("australia-southeast1")]
            Australia_SouthEast1,

            /// <summary>
            /// Melbourne
            /// </summary>
            [Description("australia-southeast2")]
            Australia_SouthEast2,

            /// <summary>
            /// Finland
            /// </summary>
            [Description("europe-north1")]
            Europe_North1,

            /// <summary>
            /// Belgium
            /// </summary>
            [Description("europe-west1")]
            Europe_West1,

            /// <summary>
            /// London
            /// </summary>
            [Description("europe-west2")]
            Europe_West2,

            /// <summary>
            /// Frankfurt
            /// </summary>
            [Description("europe-west3")]
            Europe_West3,

            /// <summary>
            /// Netherlands
            /// </summary>
            [Description("europe-west4")]
            Europe_West4,

            /// <summary>
            /// Z&#252;rich
            /// </summary>
            [Description("europe-west6")]
            Europe_West6,

            /// <summary>
            /// Warsaw
            /// </summary>
            [Description("europe-central2")]
            Europe_Central2,

            /// <summary>
            /// Iowa
            /// </summary>
            [Description("us-central1")]
            Us_Central1,

            /// <summary>
            /// South Carolina
            /// </summary>
            [Description("us-east1")]
            Us_East1,

            /// <summary>
            /// Northern Virginia
            /// </summary>
            [Description("us-east4")]
            Us_East4,

            /// <summary>
            /// Oregon
            /// </summary>
            [Description("us-west1")]
            Us_West1,

            /// <summary>
            /// California
            /// </summary>
            [Description("us-west2")]
            Us_West2,

            /// <summary>
            /// Salt Lake City
            /// </summary>
            [Description("us-west3")]
            Us_West3,

            /// <summary>
            /// Las Vegas
            /// </summary>
            [Description("us-west4")]
            Us_West4,

            /// <summary>
            /// Montr&#233;al
            /// </summary>
            [Description("northamerica-northeast1")]
            Northamerica_NorthEast1,

            /// <summary>
            /// Toronto
            /// </summary>
            [Description("northamerica-northeast2")]
            Northamerica_NorthEast2,

            /// <summary>
            /// S&#227;o Paulo
            /// </summary>
            [Description("southamerica-east1")]
            Southamerica_East1,

            /// <summary>
            /// Santiago
            /// </summary>
            [Description("southamerica-west1")]
            Southamerica_West1,

            /// <summary>
            /// Dual region: asia-northeast1 and asia-northeast2.
            /// </summary>
            [Description("asia1")]
            Asia1,

            /// <summary>
            /// Dual region: europe-north1 and europe-west4.
            /// </summary>
            [Description("eur4")]
            Eur4,

            /// <summary>
            /// Dual region: us-central1 and us-east1.
            /// </summary>
            [Description("nam4")]
            Nam4,

        }


        public enum ObjectAcls
        {
            /// <summary>
            /// Object owner gets OWNER access. All Authenticated Users get READER access.
            /// </summary>
            [Description("authenticatedRead")]
            AuthenticatedRead,

            /// <summary>
            /// Object owner gets OWNER access. Project team owners get OWNER access.
            /// </summary>
            [Description("bucketOwnerFullControl")]
            BucketOwnerFullControl,

            /// <summary>
            /// Object owner gets OWNER access. Project team owners get READER access.
            /// </summary>
            [Description("bucketOwnerRead")]
            BucketOwnerRead,

            /// <summary>
            /// Object owner gets OWNER access. Default if left blank.
            /// </summary>
            [Description("private")]
            Private,

            /// <summary>
            /// Object owner gets OWNER access. Project team members get access according to their roles.
            /// </summary>
            [Description("projectPrivate")]
            ProjectPrivate,

            /// <summary>
            /// Object owner gets OWNER access. All Users get READER access.
            /// </summary>
            [Description("publicRead")]
            PublicRead,

        }


        public enum StorageClasses
        {
            /// <summary>
            /// Default
            /// </summary>
            [Description("")]
            Default,

            /// <summary>
            /// Multi-regional storage class
            /// </summary>
            [Description("MULTI_REGIONAL")]
            Multi_Regional,

            /// <summary>
            /// Regional storage class
            /// </summary>
            [Description("REGIONAL")]
            Regional,

            /// <summary>
            /// Nearline storage class
            /// </summary>
            [Description("NEARLINE")]
            Nearline,

            /// <summary>
            /// Coldline storage class
            /// </summary>
            [Description("COLDLINE")]
            Coldline,

            /// <summary>
            /// Archive storage class
            /// </summary>
            [Description("ARCHIVE")]
            Archive,

            /// <summary>
            /// Durable reduced availability storage class
            /// </summary>
            [Description("DURABLE_REDUCED_AVAILABILITY")]
            Durable_Reduced_Availability,

        }


        /// <summary>
        /// Access public buckets and objects without credentials
        /// </summary>
        [BoolFlag("anonymous")]
        public bool Anonymous { get; set; }


        /// <summary>
        /// Access Control List for new buckets
        /// </summary>
        [SingleEnumFlag("bucket-acl", (int)BucketAcls.Private)]
        public BucketAcls? BucketAcl { get; set; }


        /// <summary>
        /// Access checks should use bucket-level IAM policies
        /// </summary>
        [BoolFlag("bucket-policy-only")]
        public bool BucketPolicyOnly { get; set; }


        /// <summary>
        /// If set this will decompress gzip encoded objects
        /// </summary>
        [BoolFlag("decompress")]
        public bool Decompress { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,CrLf,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.CrLf | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Endpoint for the service
        /// </summary>
        [StringFlag("endpoint")]
        public string Endpoint { get; set; }


        /// <summary>
        /// Location for the newly created buckets
        /// </summary>
        [SingleEnumFlag("location", (int)Locations.Default)]
        public Locations? Location { get; set; }


        /// <summary>
        /// If set, don&#39;t attempt to check the bucket exists or create it
        /// </summary>
        [BoolFlag("no-check-bucket")]
        public bool NoCheckBucket { get; set; }


        /// <summary>
        /// Access Control List for new objects
        /// </summary>
        [SingleEnumFlag("object-acl", (int)ObjectAcls.Private)]
        public ObjectAcls? ObjectAcl { get; set; }


        /// <summary>
        /// Project number
        /// </summary>
        [StringFlag("project-number")]
        public string ProjectNumber { get; set; }


        /// <summary>
        /// Service Account Credentials JSON file path
        /// </summary>
        [StringFlag("service-account-file")]
        public string ServiceAccountFile { get; set; }


        /// <summary>
        /// The storage class to use when storing objects in Google Cloud Storage
        /// </summary>
        [SingleEnumFlag("storage-class", (int)StorageClasses.Default)]
        public StorageClasses? StorageClass { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
