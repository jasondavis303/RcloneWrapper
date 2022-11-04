using RcloneWrapper.OptionsBuilders.Attributes;

namespace RcloneWrapper.OptionsBuilders.BaseClasses
{
    public abstract class SecureServeCA_OptionsBuilder : SecureServe_OptionsBuilder
    {
        /// <summary>
        /// Client certificate authority to verify clients with
        /// </summary>
        [StringFlag("client-ca")]
        public string ClientCA { get; set; }

    }
}
