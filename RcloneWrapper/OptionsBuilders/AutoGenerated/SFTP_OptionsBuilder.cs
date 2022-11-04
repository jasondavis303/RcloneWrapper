using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// SSH/SFTP
    /// </summary>
    [FlagPrefix("sftp")]
    public class SFTP_OptionsBuilder : Base_OptionsBuilder
    {
        public static class KnownHostsFiles
        {
            public const string Default = "~/.ssh/known_hosts";

        }


        public static class Subsystems
        {
            public const string Default = "sftp";

        }


        public enum ShellTypes
        {
            /// <summary>
            /// Default
            /// </summary>
            [Description("Default")]
            Default,

            /// <summary>
            /// No shell access
            /// </summary>
            [Description("none")]
            None,

            /// <summary>
            /// Unix shell
            /// </summary>
            [Description("unix")]
            Unix,

            /// <summary>
            /// PowerShell
            /// </summary>
            [Description("powershell")]
            Powershell,

            /// <summary>
            /// Windows Command Prompt
            /// </summary>
            [Description("cmd")]
            Cmd,

        }


        /// <summary>
        /// Allow asking for SFTP password when needed
        /// </summary>
        [BoolFlag("ask-password")]
        public bool AskPassword { get; set; }


        /// <summary>
        /// Upload and download chunk size (default 32Ki)
        /// </summary>
        [SizeSuffixFlag("chunk-size", "32K")]
        public SizeSuffix ChunkSize { get; set; }


        /// <summary>
        /// The maximum number of outstanding requests for one file (default 64)
        /// </summary>
        [UintFlag("concurrency", 64, 1)]
        public uint? Concurrency { get; set; }


        /// <summary>
        /// If set don&#39;t use concurrent reads
        /// </summary>
        [BoolFlag("disable-concurrent-reads")]
        public bool DisableConcurrentReads { get; set; }


        /// <summary>
        /// If set don&#39;t use concurrent writes
        /// </summary>
        [BoolFlag("disable-concurrent-writes")]
        public bool DisableConcurrentWrites { get; set; }


        /// <summary>
        /// Disable the execution of SSH commands to determine if remote file hashing is available
        /// </summary>
        [BoolFlag("disable-hashcheck")]
        public bool DisableHashcheck { get; set; }


        /// <summary>
        /// SSH host to connect to
        /// </summary>
        [StringFlag("host")]
        public string Host { get; set; }


        /// <summary>
        /// Max time before closing idle connections (default 1m0s)
        /// </summary>
        [TimeSpanFlag("idle-timeout", "1m")]
        public TimeSpan? IdleTimeout { get; set; }


        /// <summary>
        /// Path to PEM-encoded private key file
        /// </summary>
        [StringFlag("key-file")]
        public string KeyFile { get; set; }


        /// <summary>
        /// The passphrase to decrypt the PEM-encoded private key file (obscured)
        /// </summary>
        [StringFlag("key-file-pass")]
        public string KeyFilePass { get; set; }


        /// <summary>
        /// Raw PEM-encoded private key
        /// </summary>
        [StringFlag("key-pem")]
        public string KeyPem { get; set; }


        /// <summary>
        /// When set forces the usage of the ssh-agent
        /// </summary>
        [BoolFlag("key-use-agent")]
        public bool KeyUseAgent { get; set; }


        /// <summary>
        /// Optional path to known_hosts file
        /// </summary>
        [StringFlag("known-hosts-file", "~/.ssh/known_hosts")]
        public string KnownHostsFile { get; set; }


        /// <summary>
        /// The command used to read md5 hashes
        /// </summary>
        [StringFlag("md5sum-command")]
        public string Md5sumCommand { get; set; }


        /// <summary>
        /// SSH password, leave blank to use ssh-agent (obscured)
        /// </summary>
        [StringFlag("pass")]
        public string Pass { get; set; }


        /// <summary>
        /// Override path used by SSH shell commands
        /// </summary>
        [StringFlag("path-override")]
        public string PathOverride { get; set; }


        /// <summary>
        /// SSH port number (default 22)
        /// </summary>
        [UintFlag("port", 22, 0, 65536)]
        public uint? Port { get; set; }


        /// <summary>
        /// Optional path to public key file
        /// </summary>
        [StringFlag("pubkey-file")]
        public string PubkeyFile { get; set; }


        /// <summary>
        /// Specifies the path or command to run a sftp server on the remote host
        /// </summary>
        [StringFlag("server-command")]
        public string ServerCommand { get; set; }


        /// <summary>
        /// Environment variables to pass to sftp and commands
        /// </summary>
        [CommaSeparatedListFlag("set-env", Separator = ' ')]
        public Dictionary<string, string> SetEnv { get; set; } = new();


        /// <summary>
        /// Set the modified time on the remote if set (default true)
        /// </summary>
        [BoolFlag("set-modtime", true)]
        public bool SetModtime { get; set; } = true;


        /// <summary>
        /// The command used to read sha1 hashes
        /// </summary>
        [StringFlag("sha1sum-command")]
        public string Sha1sumCommand { get; set; }


        /// <summary>
        /// The type of SSH shell on remote server, if any
        /// </summary>
        [SingleEnumFlag("shell-type", (int)ShellTypes.Default)]
        public ShellTypes? ShellType { get; set; }


        /// <summary>
        /// Set to skip any symlinks and any other non regular files
        /// </summary>
        [BoolFlag("skip-links")]
        public bool SkipLinks { get; set; }


        /// <summary>
        /// Specifies the SSH2 subsystem on the remote host (default &quot;sftp&quot;)
        /// </summary>
        [StringFlag("subsystem", "sftp")]
        public string Subsystem { get; set; }


        /// <summary>
        /// If set use fstat instead of stat
        /// </summary>
        [BoolFlag("use-fstat")]
        public bool UseFstat { get; set; }


        /// <summary>
        /// Enable the use of insecure ciphers and key exchange methods
        /// </summary>
        [BoolFlag("use-insecure-cipher")]
        public bool UseInsecureCipher { get; set; }


        /// <summary>
        /// SSH username (default &quot;$USER&quot;)
        /// </summary>
        [StringFlag("user", "$USER")]
        public string User { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
