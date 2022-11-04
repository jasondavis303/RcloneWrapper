using RcloneWrapper.OptionsBuilders.Attributes;
using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders.Serve
{
    /// <summary>
    /// Serve the remote over SFTP.
    /// </summary>
    public class ServeSFTP_OptionsBuilder : VFS_OptionsBuilder
    {
        /// <summary>
        /// IPaddress:Port or :Port to bind server to (default "localhost:2022")
        /// </summary>
        [StringFlag("addr", "localhost:2022")]
        public string Addr { get; set; }

        /// <summary>
        /// A program to use to create the backend from the auth
        /// </summary>
        [StringFlag("auth-proxy")]
        public string AuthProxy { get; set; }

        /// <summary>
        /// Authorized keys file (default "~/.ssh/authorized_keys")
        /// </summary>
        [StringFlag("authorized-keys", "~/.ssh/authorized_keys")]
        public string AuthorizedKeys { get; set; }

        /// <summary>
        /// SSH private host key file (Can be multi-valued, leave blank to auto generate)
        /// </summary>
        [CommaSeparatedListFlag("key", Separator = ' ')]
        public List<string> Key { get; set; } = new();

        /// <summary>
        /// Allow connections with no authentication if set
        /// </summary>
        [BoolFlag("no-auth")]
        public bool NoAuth { get; set; }

        /// <summary>
        /// Password for authentication
        /// </summary>
        [StringFlag("pass")]
        public string Pass { get; set; }

        /// <summary>
        /// Run an sftp server on stdin/stdout
        /// </summary>
        [BoolFlag("stdio")]
        public bool Stdio { get; set; }

        /// <summary>
        /// User name for authentication
        /// </summary>
        [StringFlag("user")]
        public string User { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
