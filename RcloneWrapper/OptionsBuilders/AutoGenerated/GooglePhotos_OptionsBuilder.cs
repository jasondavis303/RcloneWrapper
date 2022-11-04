using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Google Photos
    /// </summary>
    [FlagPrefix("gphotos")]
    public class GooglePhotos_OptionsBuilder : OAuth_OptionsBuilder
    {
        /// <summary>
        /// The encoding for the backend (default Slash,CrLf,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.CrLf | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Also view and download archived media
        /// </summary>
        [BoolFlag("include-archived")]
        public bool IncludeArchived { get; set; }


        /// <summary>
        /// Set to make the Google Photos backend read only
        /// </summary>
        [BoolFlag("read-only")]
        public bool ReadOnly { get; set; }


        /// <summary>
        /// Set to read the size of media items
        /// </summary>
        [BoolFlag("read-size")]
        public bool ReadSize { get; set; }


        /// <summary>
        /// Year limits the photos to be downloaded to those which are uploaded after the given year (default 2000)
        /// </summary>
        [UintFlag("start-year", 2000)]
        public uint? StartYear { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
