using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Enterprise File Fabric
    /// </summary>
    [FlagPrefix("filefabric")]
    public class FileFabric_OptionsBuilder : Base_OptionsBuilder
    {
        public static class Urls
        {
            public const string StorageMadeEasyUS = "https://storagemadeeasy.com";

            public const string StorageMadeEasyEU = "https://eu.storagemadeeasy.com";

        }


        /// <summary>
        /// The encoding for the backend (default Slash,Del,Ctl,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.Del | EncodingFlags.Ctl | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Permanent Authentication Token
        /// </summary>
        [StringFlag("permanent-token")]
        public string PermanentToken { get; set; }


        /// <summary>
        /// ID of the root folder
        /// </summary>
        [StringFlag("root-folder-id")]
        public string RootFolderId { get; set; }


        /// <summary>
        /// Session Token
        /// </summary>
        [StringFlag("token")]
        public string Token { get; set; }


        /// <summary>
        /// Token expiry time
        /// </summary>
        [StringFlag("token-expiry")]
        public string TokenExpiry { get; set; }


        /// <summary>
        /// URL of the Enterprise File Fabric to connect to
        /// </summary>
        [StringFlag("url")]
        public string Url { get; set; }


        /// <summary>
        /// Version read from the file fabric
        /// </summary>
        [StringFlag("version")]
        public string Version { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
