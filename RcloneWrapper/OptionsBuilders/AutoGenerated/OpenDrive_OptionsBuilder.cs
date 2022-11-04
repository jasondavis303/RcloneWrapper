using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// OpenDrive
    /// </summary>
    [FlagPrefix("opendrive")]
    public class OpenDrive_OptionsBuilder : Base_OptionsBuilder
    {
        /// <summary>
        /// Files will be uploaded in chunks this size (default 10Mi)
        /// </summary>
        [SizeSuffixFlag("chunk-size", "10M")]
        public SizeSuffix ChunkSize { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,LtGt,DoubleQuote,Colon,Question,Asterisk,Pipe,BackSlash,LeftSpace,LeftCrLfHtVt,RightSpace,RightCrLfHtVt,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.LtGt | EncodingFlags.DoubleQuote | EncodingFlags.Colon | EncodingFlags.Question | EncodingFlags.Asterisk | EncodingFlags.Pipe | EncodingFlags.BackSlash | EncodingFlags.LeftSpace | EncodingFlags.LeftCrLfHtVt | EncodingFlags.RightSpace | EncodingFlags.RightCrLfHtVt | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Password (obscured)
        /// </summary>
        [StringFlag("password")]
        public string Password { get; set; }


        /// <summary>
        /// Username
        /// </summary>
        [StringFlag("username")]
        public string Username { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
