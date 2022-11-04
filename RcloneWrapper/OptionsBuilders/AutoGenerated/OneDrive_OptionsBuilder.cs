using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.Collections.Generic;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Microsoft OneDrive
    /// </summary>
    [FlagPrefix("onedrive")]
    public class OneDrive_OptionsBuilder : OAuth_OptionsBuilder
    {
        public enum LinkScopes
        {
            /// <summary>
            /// Anyone with the link has access, without needing to sign in. This may include people outside of your organization. Anonymous link support may be disabled by an administrator.
            /// </summary>
            [Description("anonymous")]
            Anonymous,

            /// <summary>
            /// Anyone signed into your organization (tenant) can use the link to get access. Only available in OneDrive for Business and SharePoint.
            /// </summary>
            [Description("organization")]
            Organization,

        }


        public enum LinkTypes
        {
            /// <summary>
            /// Creates a read-only link to the item.
            /// </summary>
            [Description("view")]
            View,

            /// <summary>
            /// Creates a read-write link to the item.
            /// </summary>
            [Description("edit")]
            Edit,

            /// <summary>
            /// Creates an embeddable link to the item.
            /// </summary>
            [Description("embed")]
            Embed,

        }


        public enum Regions
        {
            /// <summary>
            /// Microsoft Cloud Global
            /// </summary>
            [Description("global")]
            Global,

            /// <summary>
            /// Microsoft Cloud for US Government
            /// </summary>
            [Description("us")]
            US,

            /// <summary>
            /// Microsoft Cloud Germany
            /// </summary>
            [Description("de")]
            DE,

            /// <summary>
            /// Azure and Office 365 operated by Vnet Group in China
            /// </summary>
            [Description("cn")]
            CN,

        }


        /// <summary>
        /// Set scopes to be requested by rclone (default Files.Read Files.ReadWrite Files.Read.All Files.ReadWrite.All Sites.Read.All offline_access)
        /// </summary>
        [CommaSeparatedListFlag("access-scopes", Separator = ' ')]
        public List<string> AccessScopes { get; set; } = new();


        /// <summary>
        /// Chunk size to upload files with - must be multiple of 320k (327,680 bytes) (default 10Mi)
        /// </summary>
        [SizeSuffixFlag("chunk-size", "10M")]
        public SizeSuffix ChunkSize { get; set; }


        /// <summary>
        /// The ID of the drive to use
        /// </summary>
        [StringFlag("drive-id")]
        public string DriveId { get; set; }


        /// <summary>
        /// The type of the drive (personal | business | documentLibrary)
        /// </summary>
        [StringFlag("drive-type")]
        public string DriveType { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,LtGt,DoubleQuote,Colon,Question,Asterisk,Pipe,BackSlash,Del,Ctl,LeftSpace,LeftTilde,RightSpace,RightPeriod,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.LtGt | EncodingFlags.DoubleQuote | EncodingFlags.Colon | EncodingFlags.Question | EncodingFlags.Asterisk | EncodingFlags.Pipe | EncodingFlags.BackSlash | EncodingFlags.Del | EncodingFlags.Ctl | EncodingFlags.LeftSpace | EncodingFlags.LeftTilde | EncodingFlags.RightSpace | EncodingFlags.RightPeriod | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Set to make OneNote files show up in directory listings
        /// </summary>
        [BoolFlag("expose-onenote-files")]
        public bool ExposeOnenoteFiles { get; set; }


        /// <summary>
        /// Set the password for links created by the link command
        /// </summary>
        [StringFlag("link-password")]
        public string LinkPassword { get; set; }


        /// <summary>
        /// Set the scope of the links created by the link command (default &quot;anonymous&quot;)
        /// </summary>
        [SingleEnumFlag("link-scope", (int)LinkScopes.Anonymous)]
        public LinkScopes? LinkScope { get; set; }


        /// <summary>
        /// Set the type of the links created by the link command (default &quot;view&quot;)
        /// </summary>
        [SingleEnumFlag("link-type", (int)LinkTypes.View)]
        public LinkTypes? LinkType { get; set; }


        /// <summary>
        /// Size of listing chunk (default 1000)
        /// </summary>
        [UintFlag("list-chunk", 1000, 1)]
        public uint? ListChunk { get; set; }


        /// <summary>
        /// Remove all versions on modifying operations
        /// </summary>
        [BoolFlag("no-versions")]
        public bool NoVersions { get; set; }


        /// <summary>
        /// Choose national cloud region for OneDrive (default &quot;global&quot;)
        /// </summary>
        [SingleEnumFlag("region", (int)Regions.Global)]
        public Regions? Region { get; set; }


        /// <summary>
        /// ID of the root folder
        /// </summary>
        [StringFlag("root-folder-id")]
        public string RootFolderId { get; set; }


        /// <summary>
        /// Allow server-side operations (e.g. copy) to work across different onedrive configs
        /// </summary>
        [BoolFlag("server-side-across-configs")]
        public bool ServerSideAcrossConfigs { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
