using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Google Drive
    /// </summary>
    [FlagPrefix("drive")]
    public class GoogleDrive_OptionsBuilder : OAuth_OptionsBuilder
    {
        public enum Scopes
        {
            /// <summary>
            /// Full access all files, excluding Application Data Folder.
            /// </summary>
            [Description("drive")]
            Drive,

            /// <summary>
            /// Read-only access to file metadata and file contents.
            /// </summary>
            [Description("drive.readonly")]
            Drive_Readonly,

            /// <summary>
            /// Access to files created by rclone only. These are visible in the drive website. File authorization is revoked when the user deauthorizes the app.
            /// </summary>
            [Description("drive.file")]
            Drive_File,

            /// <summary>
            /// Allows read and write access to the Application Data folder. This is not visible in the drive website.
            /// </summary>
            [Description("drive.appfolder")]
            Drive_Appfolder,

            /// <summary>
            /// Allows read-only access to file metadata but does not allow any access to read or download file content.
            /// </summary>
            [Description("drive.metadata.readonly")]
            Drive_Metadata_Readonly,

        }


        /// <summary>
        /// Set to allow files which return cannotDownloadAbusiveFile to be downloaded
        /// </summary>
        [BoolFlag("acknowledge-abuse")]
        public bool AcknowledgeAbuse { get; set; }


        /// <summary>
        /// Allow the filetype to change when uploading Google docs
        /// </summary>
        [BoolFlag("allow-import-name-change")]
        public bool AllowImportNameChange { get; set; }


        /// <summary>
        /// Only consider files owned by the authenticated user
        /// </summary>
        [BoolFlag("auth-owner-only")]
        public bool AuthOwnerOnly { get; set; }


        /// <summary>
        /// Upload chunk size (default 8Mi)
        /// </summary>
        [SizeSuffixFlag("chunk-size", "8M")]
        public SizeSuffix ChunkSize { get; set; }


        /// <summary>
        /// Server side copy contents of shortcuts instead of the shortcut
        /// </summary>
        [BoolFlag("copy-shortcut-content")]
        public bool CopyShortcutContent { get; set; }


        /// <summary>
        /// Disable drive using http2 (default true)
        /// </summary>
        [BoolFlag("disable-http2", true)]
        public bool DisableHttp2 { get; set; } = true;


        /// <summary>
        /// The encoding for the backend (default InvalidUtf8)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.InvalidUtf8))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Comma separated list of preferred formats for downloading Google docs (default &quot;docx,xlsx,pptx,svg&quot;)
        /// </summary>
        [CommaSeparatedListFlag("export-formats", "docx", "xlsx", "pptx", "svg", PermuteDefaultValues = true)]
        public List<string> ExportFormats { get; set; } = new();


        /// <summary>
        /// Impersonate this user when using a service account
        /// </summary>
        [StringFlag("impersonate")]
        public string Impersonate { get; set; }


        /// <summary>
        /// Comma separated list of preferred formats for uploading Google docs
        /// </summary>
        [StringFlag("import-formats")]
        public string ImportFormats { get; set; }


        /// <summary>
        /// Keep new head revision of each file forever
        /// </summary>
        [BoolFlag("keep-revision-forever")]
        public bool KeepRevisionForever { get; set; }


        /// <summary>
        /// Size of listing chunk 100-1000, 0 to disable (default 1000)
        /// </summary>
        [UintFlag("list-chunk", 1000, 100, 1000)]
        public uint? ListChunk { get; set; }


        /// <summary>
        /// Number of API calls to allow without sleeping (default 100)
        /// </summary>
        [UintFlag("pacer-burst", 100)]
        public uint? PacerBurst { get; set; }


        /// <summary>
        /// Minimum time to sleep between API calls (default 100ms)
        /// </summary>
        [TimeSpanFlag("pacer-min-sleep", "100ms")]
        public TimeSpan? PacerMinSleep { get; set; }


        /// <summary>
        /// Resource key for accessing a link-shared file
        /// </summary>
        [StringFlag("resource-key")]
        public string ResourceKey { get; set; }


        /// <summary>
        /// ID of the root folder
        /// </summary>
        [StringFlag("root-folder-id")]
        public string RootFolderId { get; set; }


        /// <summary>
        /// Scope that rclone should use when requesting access from drive
        /// </summary>
        [SingleEnumFlag("scope", (int)Scopes.Drive)]
        public Scopes? Scope { get; set; }


        /// <summary>
        /// Allow server-side operations (e.g. copy) to work across different drive configs
        /// </summary>
        [BoolFlag("server-side-across-configs")]
        public bool ServerSideAcrossConfigs { get; set; }


        /// <summary>
        /// Service Account Credentials JSON file path
        /// </summary>
        [StringFlag("service-account-file")]
        public string ServiceAccountFile { get; set; }


        /// <summary>
        /// Only show files that are shared with me
        /// </summary>
        [BoolFlag("shared-with-me")]
        public bool SharedWithMe { get; set; }


        /// <summary>
        /// Skip MD5 checksum on Google photos and videos only
        /// </summary>
        [BoolFlag("skip-checksum-gphotos")]
        public bool SkipChecksumGphotos { get; set; }


        /// <summary>
        /// If set skip dangling shortcut files
        /// </summary>
        [BoolFlag("skip-dangling-shortcuts")]
        public bool SkipDanglingShortcuts { get; set; }


        /// <summary>
        /// Skip google documents in all listings
        /// </summary>
        [BoolFlag("skip-gdocs")]
        public bool SkipGdocs { get; set; }


        /// <summary>
        /// If set skip shortcut files
        /// </summary>
        [BoolFlag("skip-shortcuts")]
        public bool SkipShortcuts { get; set; }


        /// <summary>
        /// Only show files that are starred
        /// </summary>
        [BoolFlag("starred-only")]
        public bool StarredOnly { get; set; }


        /// <summary>
        /// Make download limit errors be fatal
        /// </summary>
        [BoolFlag("stop-on-download-limit")]
        public bool StopOnDownloadLimit { get; set; }


        /// <summary>
        /// Make upload limit errors be fatal
        /// </summary>
        [BoolFlag("stop-on-upload-limit")]
        public bool StopOnUploadLimit { get; set; }


        /// <summary>
        /// Only show files that are in the trash
        /// </summary>
        [BoolFlag("trashed-only")]
        public bool TrashedOnly { get; set; }


        /// <summary>
        /// Cutoff for switching to chunked upload (default 8Mi)
        /// </summary>
        [SizeSuffixFlag("upload-cutoff", "8M")]
        public SizeSuffix UploadCutoff { get; set; }


        /// <summary>
        /// Send files to the trash instead of deleting permanently (default true)
        /// </summary>
        [BoolFlag("use-trash", true)]
        public bool UseTrash { get; set; } = true;


        /// <summary>
        /// If Object&#39;s are greater, use drive v2 API to download (default off)
        /// </summary>
        [SizeSuffixFlag("v2-download-min-size")]
        public SizeSuffix V2DownloadMinSize { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
