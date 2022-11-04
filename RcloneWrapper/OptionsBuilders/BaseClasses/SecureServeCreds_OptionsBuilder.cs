using RcloneWrapper.OptionsBuilders.Attributes;

namespace RcloneWrapper.OptionsBuilders.BaseClasses
{
    public abstract class SecureServeCreds_OptionsBuilder : SecureServeCA_OptionsBuilder
    {
        /// <summary>
        /// A htpasswd file - if not provided no authentication is done
        /// </summary>
        [StringFlag("htpasswd")]
        public string Htpasswd { get; set; }

        /// <summary>
        /// User name for authentication
        /// </summary>
        [StringFlag("user")]
        public string User { get; set; }

        /// <summary>
        /// Password for authentication
        /// </summary>
        [StringFlag("pass")]
        public string Pass { get; set; }

        /// <summary>
        /// Realm for authentication
        /// </summary>
        [StringFlag("realm")]
        public string Realm { get; set; }

        /// <summary>
        /// Minimum TLS version that is acceptable (default "tls1.0")
        /// </summary>
        [MinTLSFlag("min-tls-version", 1.0)]
        public double? MinTLSVersion { get; set; }
    }
}
