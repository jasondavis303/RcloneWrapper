using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Uptobox
    /// </summary>
    [FlagPrefix("uptobox")]
    public class Uptobox_OptionsBuilder : Base_OptionsBuilder
    {
        /// <summary>
        /// Your access token
        /// </summary>
        [StringFlag("access-token")]
        public string AccessToken { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,LtGt,DoubleQuote,BackQuote,Del,Ctl,LeftSpace,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.LtGt | EncodingFlags.DoubleQuote | EncodingFlags.BackQuote | EncodingFlags.Del | EncodingFlags.Ctl | EncodingFlags.LeftSpace | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
