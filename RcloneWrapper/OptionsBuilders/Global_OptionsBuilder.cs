using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    public class Global_OptionsBuilder : Base_OptionsBuilder
    {
        public enum CutoffModes
        {
            [Description("HARD")]
            Hard,

            [Description("SOFT")]
            Soft,

            [Description("CAUTIOUS")]
            Cautious
        }


        [Flags]
        public enum DumpFlags
        {
            [Description("none")]
            None = 1,

            [Description("headers")]
            Headers = 2,

            [Description("bodies")]
            Bodies = 4,

            [Description("requests")]
            Requests = 8,

            [Description("responses")]
            Responses = 16,

            [Description("auth")]
            Auth = 32,

            [Description("filters")]
            Filters = 64,

            [Description("goroutines")]
            GoRoutines = 128,

            [Description("openfiles")]
            OpenFiles = 256
        }


        public enum LogLevels
        {
            [Description("DEBUG")]
            Debug,

            [Description("INFO")]
            Info,

            [Description("NOTICE")]
            Notice,

            [Description("ERROR")]
            Error
        }


        public enum StatsUnits
        {
            [Description("bits")]
            Bits,

            [Description("bytes")]
            Bytes
        }


        public enum SyncDeleteOptions
        {
            /// <summary>
            /// When synchronizing, delete files on destination after transferring (default)
            /// </summary>
            After,

            /// <summary>
            /// When synchronizing, delete files on destination before transferring
            /// </summary>
            Before,

            /// <summary>
            /// When synchronizing, delete files during transfer
            /// </summary>
            During
        }


        public enum SysLogFacilities
        {

            [Description("KERN")]
            Kern,

            [Description("USER")]
            User,

            [Description("MAIL")]
            Mail,

            [Description("DAEMON")]
            Daemon,

            [Description("AUTH")]
            Auth,

            [Description("SYSLOG")]
            Syslog,

            [Description("LPR")]
            Lpr,

            [Description("NEWS")]
            News,

            [Description("UUCP")]
            Uucp,

            [Description("CRON")]
            Cron,

            [Description("AUTHPRIV")]
            AuthPriv,

            [Description("FTP")]
            Ftp,

            [Description("NTP")]
            Ntp,

            [Description("SECURITY")]
            Security,

            [Description("CONSOLE")]
            Console,

            [Description("SOLARISCRON")]
            SolarisCron,

            [Description("LOCAL0")]
            Local0,

            [Description("LOCAL1")]
            Local1,

            [Description("LOCAL2")]
            Local2,

            [Description("LOCAL3")]
            Local3,

            [Description("LOCAL4")]
            Local4,

            [Description("LOCAL5")]
            Local5,

            [Description("LOCAL6")]
            Local6,

            [Description("LOCAL7")]
            Local7
        }


        public enum TrackRenamesStrategies
        {
            [Description("hash")]
            Hash,

            [Description("modtime")]
            Modtime,

            [Description("leaf")]
            Leaf
        }


        /// <summary>
        /// Allow prompt for password for encrypted configuration (default true)
        /// </summary>
        [BoolFlag("ask-password")]
        public bool AskPassword { get; set; }

        /// <summary>
        /// If enabled, do not request console confirmation
        /// </summary>
        [BoolFlag("auto-confirm")]
        public bool AutoConfirm { get; set; }

        /// <summary>
        /// Make backups into hierarchy based in DIR
        /// </summary>
        [StringFlag("backup-dir")]
        public string BackupDir { get; set; }

        /// <summary>
        /// Local address to bind to for outgoing connections, IPv4, IPv6 or name
        /// </summary>
        [StringFlag("bind")]
        public string Bind { get; set; }

        /// <summary>
        /// In memory buffer size when reading files for each --transfer (default 16Mi)
        /// </summary>
        [SizeSuffixFlag("buffer-size", "16M")]
        public SizeSuffix BufferSize { get; set; }

        /// <summary>
        /// Bandwidth limit per second
        /// </summary>
        [SizeSuffixFlag("bwlimit")]
        public SizeSuffix BwLimit { get; set; }

        /// <summary>
        /// Bandwidth limit per file
        /// </summary>
        [SizeSuffixFlag("bwlimit-file")]
        public SizeSuffix BwLimitFile { get; set; }

        /// <summary>
        /// CA certificate used to verify servers
        /// </summary>
        [StringFlag("ca-cert")]
        public string CaCert { get; set; }

        /// <summary>
        /// Directory rclone will use for caching (default "$HOME/.cache/rclone")
        /// </summary>
        [StringFlag("cache-dir")]
        public string CacheDir { get; set; }

        /// <summary>
        /// Do all the checks before starting transfers
        /// </summary>
        [BoolFlag("check-first")]
        public bool CheckFirst { get; set; }

        /// <summary>
        /// Number of checkers to run in parallel (default 8)
        /// </summary>
        [UintFlag("checkers", 8, 1)]
        public uint? Checkers { get; set; }

        /// <summary>
        /// Skip based on checksum (if available) & size, not mod-time & size
        /// </summary>
        [BoolFlag("checksum")]
        public bool Checksum { get; set; }

        /// <summary>
        /// Client SSL certificate (PEM) for mutual TLS auth
        /// </summary>
        [StringFlag("client-cert")]
        public string ClientCert { get; set; }

        /// <summary>
        /// Client SSL private key (PEM) for mutual TLS auth
        /// </summary>
        [StringFlag("client-key")]
        public string ClientKey { get; set; }

        /// <summary>
        /// Include additional server-side paths during comparison
        /// </summary>
        [CommaSeparatedListFlag("compare-dest")]
        public List<string> CompareDest { get; set; } = new();

        /// <summary>
        /// Config file (default "$HOME/.config/rclone/rclone.conf")
        /// </summary>
        [StringFlag("config", "$HOME/.config/rclone/rclone.conf")]
        public string Config { get; set; }

        /// <summary>
        /// Connect timeout (default 1m0s)
        /// </summary>
        [TimeSpanFlag("contimeout")]
        public TimeSpan? ConTimeout { get; set; }

        /// <summary>
        /// Implies <see cref="CompareDest"/> but also copies files from paths into destination
        /// </summary>
        [CommaSeparatedListFlag("copy-dest")]
        public List<string> CopyDest { get; set; } = new();

        /// <summary>
        /// Write cpu profile to file
        /// </summary>
        [StringFlag("cpuprofile")]
        public string CpuProfile { get; set; }

        /// <summary>
        /// Mode to stop transfers when reaching the max transfer limit (default <see cref="CutoffModes.Hard"/>)
        /// </summary>
        [SingleEnumFlag("cutoff-mode", (int)CutoffModes.Hard)]
        public CutoffModes? CutoffMode { get; set; }


        /// <summary>
        /// When synchronizing, when to delete files on destination (default <see cref="SyncDeleteOptions.After"/>)
        /// </summary>        
        public SyncDeleteOptions? DeleteOptions { get; set; }


        /// <summary>
        /// Delete files on dest excluded from sync
        /// </summary>
        [BoolFlag("delete-excluded")]
        public bool DeleteExcluded { get; set; }

        /// <summary>
        /// Disable a list of features (use --disable help to see a list)
        /// </summary>
        [CommaSeparatedListFlag("disable")]
        public List<string> Disable { get; set; } = new();

        /// <summary>
        /// Disable HTTP keep-alives and use each connection once.
        /// </summary>
        [BoolFlag("disable-http-keep-alives")]
        public bool DisableHttpKeepAlives { get; set; }

        /// <summary>
        /// Disable HTTP/2 in the global transport
        /// </summary>
        [BoolFlag("disable-http2")]
        public bool DisableHttp2 { get; set; }

        /// <summary>
        /// Do a trial run with no permanent changes
        /// </summary>
        [BoolFlag("dry-run")]
        public bool DryRun { get; set; }

        /// <summary>
        /// Set DSCP value to connections, value or name, e.g. CS1, LE, DF, AF21
        /// </summary>
        [StringFlag("dscp")]
        public string DSCP { get; set; }

        /// <summary>
        /// List of items to dump from
        /// </summary>
        [MultiEnumFlag("dump")]
        public DumpFlags? Dump { get; set; }

        /// <summary>
        /// Dump HTTP headers and bodies - may contain sensitive info
        /// </summary>
        [BoolFlag("dump-bodies")]
        public bool DumpBodies { get; set; }

        /// <summary>
        /// Dump HTTP headers - may contain sensitive info
        /// </summary>
        [BoolFlag("dump-headers")]
        public bool DumpHeaders { get; set; }

        /// <summary>
        /// Sets exit code 9 if no files are transferred, useful in scripts
        /// </summary>
        [BoolFlag("error-on-no-transfer")]
        public bool ErrorOnNoTransfer { get; set; }

        /// <summary>
        /// Exclude files matching pattern
        /// </summary>
        [RepeatingListFlag("exclude")]
        public List<string> Exclude { get; set; } = new();

        /// <summary>
        /// Read exclude patterns from file (use - to read from stdin)
        /// </summary>
        [RepeatingListFlag("exclude-from")]
        public List<string> ExcludeFrom { get; set; } = new();

        /// <summary>
        /// Exclude directories if filename is present
        /// </summary>
        [RepeatingListFlag("exclude-if-present")]
        public List<string> ExcludeIfPresent { get; set; } = new();

        /// <summary>
        /// Timeout when using expect / 100-continue in HTTP (default 1s)
        /// </summary>
        [TimeSpanFlag("expect-continue-timeout", "1s")]
        public TimeSpan? ExpectContinueTimeout { get; set; }


        /// <summary>
        /// Use recursive list if available; uses more memory but fewer transactions
        /// </summary>
        [BoolFlag("fast-list")]
        public bool FastList { get; set; }

        /// <summary>
        /// Read list of source-file names from file (use - to read from stdin)
        /// </summary>
        [RepeatingListFlag("files-from")]
        public List<string> FilesFrom { get; set; } = new();

        /// <summary>
        /// Read list of source-file names from file without any processing of lines (use - to read from stdin)
        /// </summary>
        [RepeatingListFlag("files-from-raw")]
        public List<string> FilesFromRaw { get; set; } = new();

        /// <summary>
        /// Add a file-filtering rule
        /// </summary>
        [RepeatingListFlag("filter")]
        public List<string> Filter { get; set; } = new();

        /// <summary>
        /// Read filtering patterns from a file (use - to read from stdin)
        /// </summary>
        [RepeatingListFlag("filter-from")]
        public List<string> FilterFrom { get; set; } = new();

        /// <summary>
        /// Cache remotes for this long (0 to disable caching) (default 5m0s)
        /// </summary>
        [TimeSpanFlag("fs-cache-expire-duration", "5m")]
        public TimeSpan? FsCacheExpireDuration { get; set; }


        /// <summary>
        /// Interval to check for expired remotes (default 1m0s)
        /// </summary>
        [TimeSpanFlag("fs-cache-expire-interval", "1m")]
        public TimeSpan? FsCacheExpireInterval { get; set; }


        /// <summary>
        /// Set HTTP header for all transactions
        /// </summary>
        [RepeatingListFlag("header")]
        public List<string> Header { get; set; } = new();

        /// <summary>
        /// Set HTTP header for download transactions
        /// </summary>
        [RepeatingListFlag("header-download")]
        public List<string> HeaderDownload { get; set; } = new();

        /// <summary>
        /// Set HTTP header for upload transactions
        /// </summary>
        [RepeatingListFlag("header-upload")]
        public List<string> HeaderUpload { get; set; } = new();

        /// <summary>
        /// Print numbers in a human-readable format, sizes with suffix Ki|Mi|Gi|Ti|Pi
        /// </summary>
        [BoolFlag("human-readable")]
        public bool HumanReadable { get; set; }

        /// <summary>
        /// Ignore case in filters (case insensitive)
        /// </summary>
        [BoolFlag("ignore-case")]
        public bool IgnoreCase { get; set; }

        /// <summary>
        /// Ignore case when synchronizing
        /// </summary>
        [BoolFlag("ignore-case-sync")]
        public bool IgnoreCaseSync { get; set; }

        /// <summary>
        /// Skip post copy check of checksums
        /// </summary>
        [BoolFlag("ignore-checksum")]
        public bool IgnoreChecksum { get; set; }

        /// <summary>
        /// Delete even if there are I/O errors
        /// </summary>
        [BoolFlag("ignore-errors")]
        public bool IgnoreErrors { get; set; }

        /// <summary>
        /// Skip all files that exist on destination
        /// </summary>
        [BoolFlag("ignore-existing")]
        public bool IgnoreExisting { get; set; }


        /// <summary>
        /// Ignore size when skipping use mod-time or checksum
        /// </summary>
        [BoolFlag("ignore-size")]
        public bool IgnoreSize { get; set; }

        /// <summary>
        /// Don't skip files that match size and time - transfer all files
        /// </summary>
        [BoolFlag("ignore-times")]
        public bool IgnoreTimes { get; set; }

        /// <summary>
        /// Do not modify files, fail if existing files have been modified
        /// </summary>
        [BoolFlag("immutable")]
        public bool Immutable { get; set; }

        /// <summary>
        /// Include files matching pattern
        /// </summary>
        [RepeatingListFlag("include")]
        public List<string> Include { get; set; } = new();


        /// <summary>
        /// Read include patterns from file (use - to read from stdin)
        /// </summary>
        [RepeatingListFlag("include-from")]
        public List<string> IncludeFrom { get; set; } = new();

        /// <summary>
        /// Enable interactive mode
        /// </summary>
        [BoolFlag("interactive")]
        public bool Interactive { get; set; }

        /// <summary>
        /// Maximum time to keep key-value database locked by process (default 1s)
        /// </summary>
        [TimeSpanFlag("kv-lock-time", "1s")]
        public TimeSpan? KvLockTime { get; set; }

        /// <summary>
        /// Log everything to this file
        /// </summary>
        [StringFlag("log-file")]
        public string LogFile { get; set; }

        /// <summary>
        /// List of log format options (default "date,time")
        /// </summary>
        [CommaSeparatedListFlag("log-format")]
        public List<string> LogFormat { get; set; } = new();

        /// <summary>
        /// Log level (default "<see cref="LogLevels.Notice"/>")
        /// </summary>
        [SingleEnumFlag("log-level", (int)LogLevels.Notice)]
        public LogLevels? LogLevel { get; set; }

        /// <summary>
        /// Activate systemd integration for the logger
        /// </summary>
        [BoolFlag("log-systemd")]
        public bool LogSystemD { get; set; }

        /// <summary>
        /// Number of low level retries to do (default 10)
        /// </summary>
        [UintFlag("low-level-retries", 10)]
        public uint? LowLevelRetries { get; set; }

        /// <summary>
        /// Only transfer files younger than this in s or suffix ms|s|m|h|d|w|M|y (default off)
        /// </summary>
        [TimeSpanFlag("max-age")]
        public TimeSpan? MaxAge { get; set; }


        /// <summary>
        /// Maximum number of objects in sync or check backlog (default 10000)
        /// </summary>
        [UintFlag("max-backlog", 10000)]
        public uint? MaxBacklog { get; set; }

        /// <summary>
        /// When synchronizing, limit the number of deletes (default -1)
        /// </summary>
        [IntFlag("max-delete", -1, -1, int.MaxValue)]
        public int? MaxDelete { get; set; }

        /// <summary>
        /// If set limits the recursion depth to this (default -1)
        /// </summary>
        [IntFlag("max-depth", -1, -1, int.MaxValue)]
        public int? MaxDepth { get; set; }

        /// <summary>
        /// Maximum duration rclone will transfer data for
        /// </summary>
        [TimeSpanFlag("max-duration")]
        public TimeSpan? MaxDuration { get; set; }

        /// <summary>
        /// Only transfer files smaller than this in KiB or suffix B|K|M|G|T|P (default off)
        /// </summary>
        [SizeSuffixFlag("max-size")]
        public SizeSuffix MaxSize { get; set; }

        /// <summary>
        /// Maximum number of stats groups to keep in memory, on max oldest is discarded (default 1000)
        /// </summary>
        [UintFlag("max-stats-groups", 1000)]
        public uint? MaxStatsGroups { get; set; }

        /// <summary>
        /// Maximum size of data to transfer (default off)
        /// </summary>
        [SizeSuffixFlag("max-transfer")]
        public SizeSuffix MaxTransfer { get; set; }

        /// <summary>
        /// Write memory profile to file
        /// </summary>
        [StringFlag("memprofile")]
        public string MemProfile { get; set; }

        /// <summary>
        /// If set, preserve metadata when copying objects
        /// </summary>
        [BoolFlag("metadata")]
        public bool Metadata { get; set; }

        /// <summary>
        /// Add metadata key=value when uploading
        /// </summary>
        public List<KeyValuePair<string, string>> MetadataSet { get; set; } = new();

        /// <summary>
        /// Only transfer files older than this in s or suffix ms|s|m|h|d|w|M|y (default off)
        /// </summary>
        [TimeSpanFlag("min-age")]
        public TimeSpan? MinAge { get; set; }

        /// <summary>
        /// Only transfer files bigger than this in KiB or suffix B|K|M|G|T|P (default off)
        /// </summary>
        [SizeSuffixFlag("min-size")]
        public SizeSuffix MinSize { get; set; }

        /// <summary>
        /// Max time diff to be considered the same (default 1ns)
        /// </summary>
        [TimeSpanFlag("modify-window", "1ns")]
        public TimeSpan? ModifyWindow { get; set; }

        /// <summary>
        /// Use multi-thread downloads for files above this size (default 250Mi)
        /// </summary>
        [SizeSuffixFlag("multi-thread-cutoff", "250M")]
        public SizeSuffix MultiThreadCutoff { get; set; }

        /// <summary>
        /// Max number of streams to use for multi-thread downloads (default 4)
        /// </summary>
        [UintFlag("multi-thread-streams", 4, 1)]
        public uint? MultiThreadStreams { get; set; }

        /// <summary>
        /// Do not verify the server SSL certificate (insecure)
        /// </summary>
        [BoolFlag("no-check-certificate")]
        public bool NoCheckCertificate { get; set; }


        /// <summary>
        /// Don't check the destination, copy regardless
        /// </summary>
        [BoolFlag("no-check-dest")]
        public bool NoCheckDest { get; set; }

        /// <summary>
        /// Hide console window (supported on Windows only)
        /// </summary>
        [BoolFlag("no-console")]
        public bool NoConsole { get; set; }

        /// <summary>
        /// Don't set Accept-Encoding: gzip
        /// </summary>
        [BoolFlag("no-gzip-encoding")]
        public bool NoGzipEncoding { get; set; }

        /// <summary>
        /// Don't traverse destination file system on copy
        /// </summary>
        [BoolFlag("no-traverse")]
        public bool NoTraverse { get; set; }

        /// <summary>
        /// Don't normalize unicode characters in filenames
        /// </summary>
        [BoolFlag("no-unicode-normalization")]
        public bool NoUnicodeNormalization { get; set; }

        /// <summary>
        /// Don't update destination mod-time if files identical
        /// </summary>
        [BoolFlag("no-update-modtime")]
        public bool NoUpdateModtime { get; set; }

        /// <summary>
        /// Don't cross filesystem boundaries (unix/macOS only)
        /// </summary>
        [BoolFlag("one-file-system")]
        public bool OneFileSystem { get; set; }

        /// <summary>
        /// Instructions on how to order the transfers, e.g. 'size,descending'
        /// </summary>
        [StringFlag("order-by")]
        public string OrderBy { get; set; }

        /// <summary>
        /// Command for supplying password for encrypted configuration. 
        /// The argument to this should be a command with a space separated list of arguments. 
        /// If one of the arguments has a space in then enclose it in ", 
        /// if you want a literal " in an argument then enclose the argument in " and double the ". 
        /// See https://godoc.org/encoding/csv for more info.
        /// </summary>
        [StringFlag("password-command")]
        public string PasswordCommand { get; set; }

        /// <summary>
        /// Show progress during transfer
        /// </summary>
        [BoolFlag("progress")]
        public bool Progress { get; set; }

        /// <summary>
        /// Show progress on the terminal title (requires <see cref="Progress"/>)
        /// </summary>
        [StringFlag("progress-terminal-title")]
        public string ProgressTerminalTitle { get; set; }


        /// <summary>
        /// Print as little stuff as possible
        /// </summary>
        [BoolFlag("quiet")]
        public bool Quiet { get; set; }

        /// <summary>
        /// Refresh the modtime of remote files
        /// </summary>
        [BoolFlag("refresh-times")]
        public bool RefreshTimes { get; set; }

        /// <summary>
        /// Retry operations this many times if they fail (default 3)
        /// </summary>
        [UintFlag("retries", 3)]
        public uint? Retries { get; set; }

        /// <summary>
        /// Interval between retrying operations if they fail, e.g. 500ms, 60s, 5m (0 to disable)
        /// </summary>
        [TimeSpanFlag("retries-sleep")]
        public TimeSpan? RetriesSleep { get; set; }

        /// <summary>
        /// Allow server-side operations (e.g. copy) to work across different configs
        /// </summary>
        [BoolFlag("server-side-across-configs")]
        public bool ServerSideAcrossConfigs { get; set; }

        /// <summary>
        /// Skip based on size only, not mod-time or checksum
        /// </summary>
        [BoolFlag("size-only")]
        public bool SizeOnly { get; set; }

        /// <summary>
        /// Interval between printing stats, e.g. 500ms, 60s, 5m (0 to disable) (default 1m0s)
        /// </summary>
        [TimeSpanFlag("stats", "1m")]
        public TimeSpan? Stats { get; set; }


        /// <summary>
        /// Max file name length in stats (0 for no limit) (default 45)
        /// </summary>
        [UintFlag("stats-file-name-length", 45)]
        public uint? StatsFilenameLength { get; set; }

        /// <summary>
        /// Log level to show <see cref="Stats"/> output (default "<see cref="LogLevels.Info"/>")
        /// </summary>
        [SingleEnumFlag("stats-log-level")]
        public LogLevels? StatsLogLevel { get; set; }

        /// <summary>
        /// Make the stats fit on one line
        /// </summary>
        [BoolFlag("stats-one-line")]
        public bool StatsOneLine { get; set; }

        /// <summary>
        /// Enable <see cref="StatsOneLine"/> and add current date/time prefix
        /// </summary>
        [BoolFlag("stats-one-line-date")]
        public bool StatsOneLineDate { get; set; }

        /// <summary>
        /// Enable <see cref="StatsOneLineDate"/> and use custom formatted date: Enclose date string in double quotes ("), see https://golang.org/pkg/time/#Time.Format
        /// </summary>
        [StringFlag("stats-one-line-date-format")]
        public string StatsOneLineDateFormat { get; set; }

        /// <summary>
        /// Show data rate in stats as either 'bits' or 'bytes' per second (default "<see cref="StatsUnits.Bytes"/>")
        /// </summary>
        [SingleEnumFlag("stats-unit", (int)StatsUnits.Bytes)]
        public StatsUnits? StatsUnit { get; set; }

        /// <summary>
        /// Cutoff for switching to chunked upload if file size is unknown, upload starts after reaching cutoff or when file ends (default 100Ki)
        /// </summary>
        [SizeSuffixFlag("streaming-upload-cutoff", "100K")]
        public SizeSuffix StreamingUploadCutoff { get; set; }

        /// <summary>
        /// Suffix to add to changed files
        /// </summary>
        [StringFlag("suffix")]
        public string Suffix { get; set; }

        /// <summary>
        /// Preserve the extension when using <see cref="Suffix"/>
        /// </summary>
        [BoolFlag("suffix-keep-extension")]
        public bool SuffixKeepExtension { get; set; }

        /// <summary>
        /// Use Syslog for logging
        /// </summary>
        [BoolFlag("syslog")]
        public bool Syslog { get; set; }

        /// <summary>
        /// Facility for syslog, e.g. KERN,USER,... (default "DAEMON")
        /// </summary>
        [SingleEnumFlag("syslog-facility", (int)SysLogFacilities.Daemon)]
        public SysLogFacilities? SyslogFacility { get; set; }



        /// <summary>
        /// Directory rclone will use for temporary files (default "/tmp")
        /// </summary>
        [StringFlag("temp-dir", "/tmp")]
        public string TempDir { get; set; }

        /// <summary>
        /// IO idle timeout (default 5m0s)
        /// </summary>
        [TimeSpanFlag("timeout", "5m")]
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Limit HTTP transactions per second to this
        /// </summary>
        [DoubleFlag("tpslimit")]
        public double? TpsLimit { get; set; }

        /// <summary>
        /// Max burst of transactions for --tpslimit (default 1)
        /// </summary>
        [UintFlag("tpslimit-burst", 1)]
        public uint? TpsLimitBurst { get; set; }

        /// <summary>
        /// When synchronizing, track file renames and do a server-side move if possible
        /// </summary>
        [BoolFlag("track-renames")]
        public bool TrackRenames { get; set; }

        /// <summary>
        /// Strategies to use when synchronizing using track-renames (default "<see cref="TrackRenamesStrategies.Hash"/>")
        /// </summary>
        [SingleEnumFlag("track-renames-strategy", (int)TrackRenamesStrategies.Hash)]
        public TrackRenamesStrategies? TrackRenamesStrategy { get; set; }

        /// <summary>
        /// Number of file transfers to run in parallel (default 4)
        /// </summary>
        [UintFlag("transfers", 4, 1)]
        public uint? Transfers { get; set; }

        /// <summary>
        /// Skip files that are newer on the destination
        /// </summary>
        [BoolFlag("update")]
        public bool Update { get; set; }

        /// <summary>
        /// Enable session cookiejar
        /// </summary>
        [BoolFlag("use-cookies")]
        public bool UseCookies { get; set; }

        /// <summary>
        /// Use json log format
        /// </summary>
        [BoolFlag("use-json-log")]
        public bool UseJsonLog { get; set; }

        /// <summary>
        /// Use mmap allocator (see docs)
        /// </summary>
        [BoolFlag("use-mmap")]
        public bool UseMmap { get; set; }

        /// <summary>
        /// Use server modified time instead of object metadata
        /// </summary>
        [BoolFlag("use-server-modtime")]
        public bool UseServerModTime { get; set; }

        /// <summary>
        /// Set the user-agent to a specified string (default "rclone/v&lt;version&gt;")
        /// </summary>
        [StringFlag("user-agent")]
        public string UserAgent { get; set; }

        /// <summary>
        /// Print lots more stuff (repeat for more)
        /// </summary>
        public uint? Verbose { get; set; }





        public override string BuildArgs()
        {
            var args = this.GetOptionsList();

            if (DeleteOptions != null)
                switch (DeleteOptions.Value)
                {
                    case SyncDeleteOptions.After:
                        break;

                    case SyncDeleteOptions.Before:
                        args.Add("--delete-before");
                        break;

                    case SyncDeleteOptions.During:
                        args.Add("--delete-during");
                        break;

                    default:
                        throw new Exception("Invalid value for SyncDeleteOptions");
                }


            if (MetadataSet != null)
                foreach (var kvp in MetadataSet)
                    args.Add($"--metadata-set {kvp.Key}={kvp.Value}");


            if (Verbose != null && Verbose > 0)
                args.Add("-" + new string('v', Math.Min((int)Verbose.Value, 2)));


            return string.Join(' ', args); ;
        }




        /// <summary>
        /// Sets the <see cref="BackupDir"/> to <paramref name="backupDir"/>, sets <see cref="Suffix"/> to <see cref="DateTime.UtcNow"/>.ToString("_yyyy-MM-dd-hh-mm-ss"), and sets <see cref="SuffixKeepExtension"/> to true
        /// </summary>
        /// <param name="backupDir"></param>
        public void SetupTimestampBackup(string backupDir)
        {
            BackupDir = backupDir;
            Suffix = DateTime.UtcNow.ToString("_yyyy-MM-dd-hh-mm-ss");
            SuffixKeepExtension = true;
        }

        /// <summary>
        /// Sets <see cref="Progress"/>, <see cref="StatsOneLine"/>, and <see cref="Quiet"/> to true, and sets <see cref="Verbose"/> to null
        /// </summary>
        public void SetProgressForWrapper()
        {
            Progress = true;
            StatsOneLine = true;
            Quiet = true;
            Verbose = null;
        }


        public override string ToString() => BuildArgs();
    }
}
