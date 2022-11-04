using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    public class VFS_OptionsBuilder : Base_OptionsBuilder
    {
        public enum VFSCacheModes
        {
            /// <summary>
            /// In this mode (the default) the cache will read directly from the remote and write directly to the remote without caching anything on disk.
            /// </summary>
            [Description("off")]
            Off,

            /// <summary>
            /// This is very similar to "off" except that files opened for read AND write will be buffered to disk. This means that files opened for write will be a lot more compatible, but uses the minimal disk space.
            /// </summary>
            [Description("minimal")]
            Minimal,

            /// <summary>
            /// In this mode files opened for read only are still read directly from the remote, write only and read/write files are buffered to disk first.
            /// </summary>
            [Description("writes")]
            Writes,

            /// <summary>
            /// In this mode all reads and writes are buffered to and from disk. When data is read from the remote this is buffered to disk as well.
            /// </summary>
            [Description("full")]
            Full
        }

        /// <summary>
        /// Allow mounting over a non-empty directory (not supported on Windows)
        /// </summary>
        [BoolFlag("allow-non-empty")]
        public bool AllowNonEmpty { get; set; }

        /// <summary>
        /// Allow access to other users (not supported on Windows)
        /// </summary>
        [BoolFlag("allow-other")]
        public bool AllowOther { get; set; }

        /// <summary>
        /// Allow access to root user (not supported on Windows)
        /// </summary>
        [BoolFlag("allow-root")]
        public bool AllowRoot { get; set; }

        /// <summary>
        /// Use asynchronous reads (not supported on Windows) (default true)
        /// </summary>
        [BoolFlag("async-read", true)]
        public bool AsyncRead { get; set; } = true;

        /// <summary>
        /// Time for which file/directory attributes are cached (default 1s)
        /// </summary>
        [TimeSpanFlag("attr-timeout", "1s")]
        public TimeSpan? AttrTimeout { get; set; }

        /// <summary>
        /// Run mount in background and exit parent process (as background output is suppressed, use --log-file with --log-format=pid,... to monitor) (not supported on Windows)
        /// </summary>
        [BoolFlag("daemon")]
        public bool Daemon { get; set; }

        /// <summary>
        /// Time limit for rclone to respond to kernel (not supported on Windows)
        /// </summary>
        [TimeSpanFlag("daemon-timeout")]
        public TimeSpan? DaemonTimeout { get; set; }

        /// <summary>
        /// Time to wait for ready mount from daemon (maximum time on Linux, constant sleep time on OSX/BSD) (not supported on Windows) (default 1m0s)
        /// </summary>
        [TimeSpanFlag("daemon-wait", "1m")]
        public TimeSpan? DaemonWait { get; set; }

        /// <summary>
        /// Debug the FUSE internals - needs -v
        /// </summary>
        [BoolFlag("debug-fuse")]
        public bool DebugFuse { get; set; }

        /// <summary>
        /// Makes kernel enforce access control based on the file mode (not supported on Windows)
        /// </summary>
        [BoolFlag("default-permissions")]
        public bool DefaultPermissions { get; set; }

        /// <summary>
        /// Set the device name - default is remote:path
        /// </summary>
        [StringFlag("devname")]
        public string DevName { get; set; }

        /// <summary>
        /// Time to cache directory entries for (default 5m0s)
        /// </summary>
        [TimeSpanFlag("dir-cache-time", "5m")]
        public TimeSpan? DirCacheTime { get; set; }

        /// <summary>
        /// Directory permissions (default 0777)
        /// </summary>
        [StringFlag("dir-perms", "0777")]
        public string DirPerms { get; set; }

        /// <summary>
        /// File permissions (default 0666)
        /// </summary>
        [StringFlag("file-perms", "0666")]
        public string FilePerms { get; set; }

        /// <summary>
        /// Flags or arguments to be passed direct to libfuse/WinFsp
        /// </summary>
        [RepeatingListFlag("fuse-flag")]
        public List<string> FuseFlags { get; set; }

        /// <summary>
        /// Override the gid field set by the filesystem (not supported on Windows) (default 1000)
        /// </summary>
        [UintFlag("gid", 1000)]
        public uint? Gid { get; set; }

        /// <summary>
        /// The number of bytes that can be prefetched for sequential reads (not supported on Windows) (default 128Ki)
        /// </summary>
        [SizeSuffixFlag("max-read-ahead", "128K")]
        public SizeSuffix MaxReadAhead { get; set; }

        /// <summary>
        /// Mount as remote network drive, instead of fixed disk drive (supported on Windows only)
        /// </summary>
        [BoolFlag("network-mode")]
        public bool NetworkMode { get; set; }

        /// <summary>
        /// Don't compare checksums on up/download
        /// </summary>
        [BoolFlag("no-checksum")]
        public bool NoChecksum { get; set; }

        /// <summary>
        /// Don't read/write the modification time (can speed things up)
        /// </summary>
        [BoolFlag("no-modtime")]
        public bool NoModtime { get; set; }

        /// <summary>
        /// Don't allow seeking in files
        /// </summary>
        [BoolFlag("no-seek")]
        public bool NoSeek { get; set; }

        /// <summary>
        /// Ignore Apple Double (._) and .DS_Store files (supported on OSX only) (default true)
        /// </summary>
        [BoolFlag("noappledouble", true)]
        public bool NoAppleDouble { get; set; } = true;

        /// <summary>
        /// Ignore all "com.apple.*" extended attributes (supported on OSX only)
        /// </summary>
        [BoolFlag("noapplexattr")]
        public bool NoAppleXAttr { get; set; }

        /// <summary>
        /// Option for libfuse/WinFsp (repeat if required)
        /// </summary>
        [RepeatingListFlag("option")]
        public List<string> Options { get; set; }

        /// <summary>
        /// Time to wait between polling for changes, must be smaller than dir-cache-time and only on supported remotes (set 0 to disable) (default 1m0s)
        /// </summary>
        [TimeSpanFlag("poll-interval", "1m")]
        public TimeSpan? PollInterval { get; set; }

        /// <summary>
        /// Only allow read-only access
        /// </summary>
        [BoolFlag("read-only")]
        public bool ReadOnly { get; set; }

        /// <summary>
        /// Override the uid field set by the filesystem (not supported on Windows) (default 1000)
        /// </summary>
        [UintFlag("uid", 1000)]
        public uint? Uid { get; set; }

        /// <summary>
        /// Override the permission bits set by the filesystem (not supported on Windows) (default 2)
        /// </summary>
        [IntFlag("umask", 2, int.MinValue)]
        public int? Umask { get; set; }

        /// <summary>
        /// Max age of objects in the cache (default 1h0m0s)
        /// </summary>
        [TimeSpanFlag("vfs-cache-max-age", "1h")]
        public TimeSpan? VFSCacheMaxAge { get; set; }

        /// <summary>
        /// Max total size of objects in the cache (default off)
        /// </summary>
        [SizeSuffixFlag("vfs-cache-max-size")]
        public SizeSuffix VFSCacheMaxSize { get; set; }

        /// <summary>
        /// Cache mode off|minimal|writes|full (default off)
        /// </summary>
        [SingleEnumFlag("vfs-cache-mode", (int)VFSCacheModes.Off)]
        public VFSCacheModes? VFSCacheMode { get; set; }

        /// <summary>
        /// Interval to poll the cache for stale objects (default 1m0s)
        /// </summary>
        [TimeSpanFlag("vfs-cache-poll-interval", "1m")]
        public TimeSpan? VFSCacheCachePollInterval { get; set; }

        /// <summary>
        /// If a file name not found, find a case insensitive match
        /// </summary>
        [BoolFlag("vfs-case-insensitive")]
        public bool VFSCaseInsensitive { get; set; }

        /// <summary>
        /// Specify the total space of disk (default off)
        /// </summary>
        [SizeSuffixFlag("vfs-disk-space-total-size")]
        public SizeSuffix VFSDiskSpaceTotalSize { get; set; }

        /// <summary>
        /// Use fast (less accurate) fingerprints for change detection
        /// </summary>
        [BoolFlag("vfs-fast-fingerprint")]
        public bool VFSFastFingerprint { get; set; }

        /// <summary>
        /// Extra read ahead over --buffer-size when using cache-mode full
        /// </summary>
        [SizeSuffixFlag("vfs-read-ahead")]
        public SizeSuffix VFSReadAhead { get; set; }

        /// <summary>
        /// Read the source objects in chunks (default 128Mi)
        /// </summary>
        [SizeSuffixFlag("vfs-read-chunk-size", "128M")]
        public SizeSuffix VFSReadChunkSize { get; set; }

        /// <summary>
        /// If greater than --vfs-read-chunk-size, double the chunk size after each chunk read, until the limit is reached ('off' is unlimited) (default off)
        /// </summary>
        [SizeSuffixFlag("vfs-read-chunk-size-limit")]
        public SizeSuffix VFSReadChunkSizeLimit { get; set; }

        /// <summary>
        /// Time to wait for in-sequence read before seeking (default 20ms)
        /// </summary>
        [TimeSpanFlag("vfs-read-wait", "20ms")]
        public TimeSpan? VFSReadWait { get; set; }

        /// <summary>
        /// Use the rclone size algorithm for Used size
        /// </summary>
        [BoolFlag("vfs-used-is-size")]
        public bool VFSUsedIsSize { get; set; }

        /// <summary>
        /// Time to writeback files after last use when using cache (default 5s)
        /// </summary>
        [TimeSpanFlag("vfs-write-back", "5s")]
        public TimeSpan? VFSWriteBack { get; set; }

        /// <summary>
        /// Time to wait for in-sequence write before giving error (default 1s)
        /// </summary>
        [TimeSpanFlag("vfs-write-wait", "1s")]
        public TimeSpan? VFSWriteWait { get; set; }

        /// <summary>
        /// Set the volume name (supported on Windows and OSX only)
        /// </summary>
        [StringFlag("volname")]
        public string VolName { get; set; }

        /// <summary>
        /// Makes kernel buffer writes before sending them to rclone (without this, writethrough caching is used) (not supported on Windows)
        /// </summary>
        [BoolFlag("write-back-cache")]
        public bool WriteBackCache { get; set; }


        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
