using RcloneWrapper.OptionsBuilders.Attributes;

namespace RcloneWrapper.OptionsBuilders.BaseClasses
{
    public abstract class OAuth_OptionsBuilder : Base_OptionsBuilder
    {
        /// <summary>
        /// Auth server URL
        /// </summary>
        [StringFlag("auth-url")]
        public string AuthUrl { get; set; }

        /// <summary>
        /// OAuth Client Id
        /// </summary>
        [StringFlag("client-id")]
        public string ClientId { get; set; }

        /// <summary>
        /// OAuth Client Secret
        /// </summary>
        [StringFlag("client-secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// OAuth Access Token as a JSON blob
        /// </summary>
        [StringFlag("token")]
        public string Token { get; set; }

        /// <summary>
        /// Token server url
        /// </summary>
        [StringFlag("token-url")]
        public string TokenUrl { get; set; }
    }
}
