using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Citrix Sharefile
    /// </summary>
    [FlagPrefix("sharefile")]
    public class ShareFile_OptionsBuilder : Base_OptionsBuilder
    {
        public static class RootFolderIds
        {
            public const string Personal_Folders = "";

            public const string Favorites_Folder = "favorites";

            public const string Shared_Folders = "allshared";

            public const string Individual_Connectors = "connectors";

            public const string All = "top";

        }


        /// <summary>
        /// Upload chunk size (default 64Mi)
        /// </summary>
        [SizeSuffixFlag("chunk-size", "64M")]
        public SizeSuffix ChunkSize { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,LtGt,DoubleQuote,Colon,Question,Asterisk,Pipe,BackSlash,Ctl,LeftSpace,LeftPeriod,RightSpace,RightPeriod,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.LtGt | EncodingFlags.DoubleQuote | EncodingFlags.Colon | EncodingFlags.Question | EncodingFlags.Asterisk | EncodingFlags.Pipe | EncodingFlags.BackSlash | EncodingFlags.Ctl | EncodingFlags.LeftSpace | EncodingFlags.LeftPeriod | EncodingFlags.RightSpace | EncodingFlags.RightPeriod | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Endpoint for API calls
        /// </summary>
        [StringFlag("endpoint")]
        public string Endpoint { get; set; }


        /// <summary>
        /// ID of the root folder
        /// </summary>
        [StringFlag("root-folder-id")]
        public string RootFolderId { get; set; }


        /// <summary>
        /// Cutoff for switching to multipart upload (default 128Mi)
        /// </summary>
        [SizeSuffixFlag("upload-cutoff", "128M")]
        public SizeSuffix UploadCutoff { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
