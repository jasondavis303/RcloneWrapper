using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders.Serve
{
    /// <summary>
    /// Serve remote:path over FTP.
    /// </summary>
    public class ServeFTP_OptionsBuilder : SecureServe_OptionsBuilder
    {
        /// <summary>
        /// IPaddress:Port or :Port to bind server to (default "localhost:2121")
        /// </summary>
        [StringFlag("addr", "localhost:2121")]
        public string Addr { get; set; }

        /// <summary>
        /// User name for authentication (default "anonymous")
        /// </summary>
        [StringFlag("user", "anonymous")]
        public string User { get; set; }

        /// <summary>
        /// Password for authentication (empty value allow every password)
        /// </summary>
        [StringFlag("pass")]
        public string Pass { get; set; }

        /// <summary>
        /// A program to use to create the backend from the auth
        /// </summary>
        [StringFlag("auth-proxy")]
        public string AuthProxy { get; set; }

        /// <summary>
        /// Public IP address to advertise for passive connections
        /// </summary>
        [StringFlag("public-ip")]
        public string PublicIP { get; set; }

        /// <summary>
        /// Passive port range to use (default "30000-32000")
        /// </summary>
        [StringFlag("passive-port")]
        public string PassivePort { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
