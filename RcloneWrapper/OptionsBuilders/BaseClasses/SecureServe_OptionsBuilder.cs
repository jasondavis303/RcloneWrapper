using RcloneWrapper.OptionsBuilders.Attributes;

namespace RcloneWrapper.OptionsBuilders.BaseClasses
{
    public abstract class SecureServe_OptionsBuilder : VFS_OptionsBuilder
    {
        /// <summary>
        /// TLS PEM key (concatenation of certificate and CA certificate)
        /// </summary>
        [StringFlag("cert")]
        public string Cert { get; set; }

        /// <summary>
        /// TLS PEM Private key
        /// </summary>
        [StringFlag("key")]
        public string Key { get; set; }
    }
}
