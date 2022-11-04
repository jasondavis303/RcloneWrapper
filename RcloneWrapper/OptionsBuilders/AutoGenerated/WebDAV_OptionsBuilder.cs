using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.Collections.Generic;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// WebDAV
    /// </summary>
    [FlagPrefix("webdav")]
    public class WebDAV_OptionsBuilder : Base_OptionsBuilder
    {
        public enum Vendors
        {
            /// <summary>
            /// Nextcloud
            /// </summary>
            [Description("nextcloud")]
            Nextcloud,

            /// <summary>
            /// Owncloud
            /// </summary>
            [Description("owncloud")]
            Owncloud,

            /// <summary>
            /// Sharepoint Online, authenticated by Microsoft account
            /// </summary>
            [Description("sharepoint")]
            Sharepoint,

            /// <summary>
            /// Sharepoint with NTLM authentication, usually self-hosted or on-premises
            /// </summary>
            [Description("sharepoint-ntlm")]
            Sharepoint_Ntlm,

            /// <summary>
            /// Other site/service or software
            /// </summary>
            [Description("other")]
            Other,

        }


        /// <summary>
        /// Bearer token instead of user/pass (e.g. a Macaroon)
        /// </summary>
        [StringFlag("bearer-token")]
        public string BearerToken { get; set; }


        /// <summary>
        /// Command to run to get a bearer token
        /// </summary>
        [StringFlag("bearer-token-command")]
        public string BearerTokenCommand { get; set; }


        /// <summary>
        /// The encoding for the backend
        /// </summary>
        [StringFlag("encoding")]
        public string Encoding { get; set; }


        /// <summary>
        /// Set HTTP headers for all transactions
        /// </summary>
        [CommaSeparatedListFlag("headers")]
        public List<string> Headers { get; set; } = new();


        /// <summary>
        /// Password (obscured)
        /// </summary>
        [StringFlag("pass")]
        public string Pass { get; set; }


        /// <summary>
        /// URL of http host to connect to
        /// </summary>
        [StringFlag("url")]
        public string Url { get; set; }


        /// <summary>
        /// User name
        /// </summary>
        [StringFlag("user")]
        public string User { get; set; }


        /// <summary>
        /// Name of the WebDAV site/service/software you are using
        /// </summary>
        [SingleEnumFlag("vendor", (int)Vendors.Sharepoint)]
        public Vendors? Vendor { get; set; }



        public override string BuildArgs()
        {
            var ret = this.GetOptionsList();

            if (CustomOptions != null)
                foreach (var kvp in CustomOptions)
                {
                    string cv = kvp.Key;
                    if (!string.IsNullOrWhiteSpace(kvp.Value))
                    {
                        if (kvp.Value == "false")
                            cv += "=false";
                        else
                            cv += ' ' + kvp.Value;
                    }
                    ret.Add(cv);
                }

            return string.Join(' ', ret);
        }

        public override string ToString() => BuildArgs();
    }
}
