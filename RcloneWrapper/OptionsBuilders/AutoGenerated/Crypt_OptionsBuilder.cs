using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Encrypt/Decrypt a remote
    /// </summary>
    [FlagPrefix("crypt")]
    public class Crypt_OptionsBuilder : Base_OptionsBuilder
    {
        public enum FilenameEncodings
        {
            /// <summary>
            /// Encode using base32. Suitable for all remote.
            /// </summary>
            [Description("base32")]
            Base32,

            /// <summary>
            /// Encode using base64. Suitable for case sensitive remote.
            /// </summary>
            [Description("base64")]
            Base64,

            /// <summary>
            /// Encode using base32768. Suitable if your remote counts UTF-16 or Unicode codepoint instead of UTF-8 byte length. (Eg. Onedrive)
            /// </summary>
            [Description("base32768")]
            Base32768,

        }


        public enum FilenameEncryptions
        {
            /// <summary>
            /// Encrypt the filenames. See the docs for the details.
            /// </summary>
            [Description("standard")]
            Standard,

            /// <summary>
            /// Very simple filename obfuscation.
            /// </summary>
            [Description("obfuscate")]
            Obfuscate,

            /// <summary>
            /// Don&#39;t encrypt the file names. Adds a &quot;.bin&quot; extension only.
            /// </summary>
            [Description("off")]
            Off,

        }


        /// <summary>
        /// Option to either encrypt directory names or leave them intact (default true)
        /// </summary>
        [BoolFlag("directory-name-encryption", true)]
        public bool DirectoryNameEncryption { get; set; } = true;


        /// <summary>
        /// How to encode the encrypted filename to text string (default &quot;base32&quot;)
        /// </summary>
        [SingleEnumFlag("filename-encoding", (int)FilenameEncodings.Base32)]
        public FilenameEncodings? FilenameEncoding { get; set; }


        /// <summary>
        /// How to encrypt the filenames (default &quot;standard&quot;)
        /// </summary>
        [SingleEnumFlag("filename-encryption", (int)FilenameEncryptions.Standard)]
        public FilenameEncryptions? FilenameEncryption { get; set; }


        /// <summary>
        /// Option to either encrypt file data or leave it unencrypted
        /// </summary>
        [BoolFlag("no-data-encryption")]
        public bool NoDataEncryption { get; set; }


        /// <summary>
        /// Password or pass phrase for encryption (obscured)
        /// </summary>
        [StringFlag("password")]
        public string Password { get; set; }


        /// <summary>
        /// Password or pass phrase for salt (obscured)
        /// </summary>
        [StringFlag("password2")]
        public string Password2 { get; set; }


        /// <summary>
        /// Remote to encrypt/decrypt
        /// </summary>
        [StringFlag("remote")]
        public string Remote { get; set; }


        /// <summary>
        /// Allow server-side operations (e.g. copy) to work across different crypt configs
        /// </summary>
        [BoolFlag("server-side-across-configs")]
        public bool ServerSideAcrossConfigs { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
