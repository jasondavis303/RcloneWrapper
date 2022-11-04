using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Internet Archive
    /// </summary>
    [FlagPrefix("internetarchive")]
    public class InternetArchive_OptionsBuilder : Base_OptionsBuilder
    {
        public static class Endpoints
        {
            public const string Default = "https://s3.us.archive.org";

        }


        public static class FrontEndpoints
        {
            public const string Default = "https://archive.org";

        }


        /// <summary>
        /// IAS3 Access Key
        /// </summary>
        [StringFlag("access-key-id")]
        public string AccessKeyId { get; set; }


        /// <summary>
        /// Don&#39;t ask the server to test against MD5 checksum calculated by rclone (default true)
        /// </summary>
        [BoolFlag("disable-checksum", true)]
        public bool DisableChecksum { get; set; } = true;


        /// <summary>
        /// The encoding for the backend (default Slash,LtGt,CrLf,Del,Ctl,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.LtGt | EncodingFlags.CrLf | EncodingFlags.Del | EncodingFlags.Ctl | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// IAS3 Endpoint (default &quot;https://s3.us.archive.org&quot;)
        /// </summary>
        [StringFlag("endpoint", "https://s3.us.archive.org")]
        public string Endpoint { get; set; }


        /// <summary>
        /// Host of InternetArchive Frontend (default &quot;https://archive.org&quot;)
        /// </summary>
        [StringFlag("front-endpoint", "https://archive.org")]
        public string FrontEndpoint { get; set; }


        /// <summary>
        /// IAS3 Secret Key (password)
        /// </summary>
        [StringFlag("secret-access-key")]
        public string SecretAccessKey { get; set; }


        /// <summary>
        /// Timeout for waiting the server&#39;s processing tasks (specifically archive and book_op) to finish (default 0s)
        /// </summary>
        [TimeSpanFlag("wait-archive", "0s")]
        public TimeSpan? WaitArchive { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
