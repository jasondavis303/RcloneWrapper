using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// 1Fichier
    /// </summary>
    [FlagPrefix("fichier")]
    public class Fichier_OptionsBuilder : Base_OptionsBuilder
    {
        /// <summary>
        /// Your API Key, get it from https://1fichier.com/console/params.pl
        /// </summary>
        [StringFlag("api-key")]
        public string ApiKey { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,LtGt,DoubleQuote,SingleQuote,BackQuote,Dollar,BackSlash,Del,Ctl,LeftSpace,RightSpace,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.LtGt | EncodingFlags.DoubleQuote | EncodingFlags.SingleQuote | EncodingFlags.BackQuote | EncodingFlags.Dollar | EncodingFlags.BackSlash | EncodingFlags.Del | EncodingFlags.Ctl | EncodingFlags.LeftSpace | EncodingFlags.RightSpace | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// If you want to download a shared file that is password protected, add this parameter (obscured)
        /// </summary>
        [StringFlag("file-password")]
        public string FilePassword { get; set; }


        /// <summary>
        /// If you want to list the files in a shared folder that is password protected, add this parameter (obscured)
        /// </summary>
        [StringFlag("folder-password")]
        public string FolderPassword { get; set; }


        /// <summary>
        /// If you want to download a shared folder, add this parameter
        /// </summary>
        [StringFlag("shared-folder")]
        public string SharedFolder { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
