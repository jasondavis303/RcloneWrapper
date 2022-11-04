using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Sugarsync
    /// </summary>
    [FlagPrefix("sugarsync")]
    public class Sugarsync_OptionsBuilder : Base_OptionsBuilder
    {
        /// <summary>
        /// Sugarsync Access Key ID
        /// </summary>
        [StringFlag("access-key-id")]
        public string AccessKeyId { get; set; }


        /// <summary>
        /// Sugarsync App ID
        /// </summary>
        [StringFlag("app-id")]
        public string AppId { get; set; }


        /// <summary>
        /// Sugarsync authorization
        /// </summary>
        [StringFlag("authorization")]
        public string Authorization { get; set; }


        /// <summary>
        /// Sugarsync authorization expiry
        /// </summary>
        [StringFlag("authorization-expiry")]
        public string AuthorizationExpiry { get; set; }


        /// <summary>
        /// Sugarsync deleted folder id
        /// </summary>
        [StringFlag("deleted-id")]
        public string DeletedId { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,Ctl,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.Ctl | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Permanently delete files if true
        /// </summary>
        [BoolFlag("hard-delete")]
        public bool HardDelete { get; set; }


        /// <summary>
        /// Sugarsync Private Access Key
        /// </summary>
        [StringFlag("private-access-key")]
        public string PrivateAccessKey { get; set; }


        /// <summary>
        /// Sugarsync refresh token
        /// </summary>
        [StringFlag("refresh-token")]
        public string RefreshToken { get; set; }


        /// <summary>
        /// Sugarsync root id
        /// </summary>
        [StringFlag("root-id")]
        public string RootId { get; set; }


        /// <summary>
        /// Sugarsync user
        /// </summary>
        [StringFlag("user")]
        public string User { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
