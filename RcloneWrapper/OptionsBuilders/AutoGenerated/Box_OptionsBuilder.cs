using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Box
    /// </summary>
    [FlagPrefix("box")]
    public class Box_OptionsBuilder : OAuth_OptionsBuilder
    {
        public enum BoxSubTypes
        {
            /// <summary>
            /// Rclone should act on behalf of a user.
            /// </summary>
            [Description("user")]
            User,

            /// <summary>
            /// Rclone should act on behalf of a service account.
            /// </summary>
            [Description("enterprise")]
            Enterprise,

        }


        /// <summary>
        /// Box App Primary Access Token
        /// </summary>
        [StringFlag("access-token")]
        public string AccessToken { get; set; }


        /// <summary>
        /// Box App config.json location
        /// </summary>
        [StringFlag("box-config-file")]
        public string BoxConfigFile { get; set; }


        /// <summary>
        /// (default &quot;user&quot;)
        /// </summary>
        [SingleEnumFlag("box-sub-type", (int)BoxSubTypes.User)]
        public BoxSubTypes? BoxSubType { get; set; }


        /// <summary>
        /// Max number of times to try committing a multipart file (default 100)
        /// </summary>
        [UintFlag("commit-retries", 100)]
        public uint? CommitRetries { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,BackSlash,Del,Ctl,RightSpace,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.BackSlash | EncodingFlags.Del | EncodingFlags.Ctl | EncodingFlags.RightSpace | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Size of listing chunk 1-1000 (default 1000)
        /// </summary>
        [UintFlag("list-chunk", 1000, 1, 1000)]
        public uint? ListChunk { get; set; }


        /// <summary>
        /// Only show items owned by the login (email address) passed in
        /// </summary>
        [StringFlag("owned-by")]
        public string OwnedBy { get; set; }


        /// <summary>
        /// Fill in for rclone to use a non root folder as its starting point
        /// </summary>
        [StringFlag("root-folder-id", "0")]
        public string RootFolderId { get; set; }


        /// <summary>
        /// Cutoff for switching to multipart upload (&gt;= 50 MiB) (default 50Mi)
        /// </summary>
        [SizeSuffixFlag("upload-cutoff", "50M")]
        public SizeSuffix UploadCutoff { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
