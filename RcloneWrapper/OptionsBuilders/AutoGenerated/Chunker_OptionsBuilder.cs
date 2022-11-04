using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Transparently chunk/split large files
    /// </summary>
    [FlagPrefix("chunker")]
    public class Chunker_OptionsBuilder : Base_OptionsBuilder
    {
        public enum HashTypes
        {
            /// <summary>
            /// Pass any hash supported by wrapped remote for non-chunked files. Return nothing otherwise.
            /// </summary>
            [Description("none")]
            None,

            /// <summary>
            /// MD5 for composite files.
            /// </summary>
            [Description("md5")]
            MD5,

            /// <summary>
            /// SHA1 for composite files.
            /// </summary>
            [Description("sha1")]
            SHA1,

            /// <summary>
            /// MD5 for all files.
            /// </summary>
            [Description("md5all")]
            MD5_All,

            /// <summary>
            /// SHA1 for all files.
            /// </summary>
            [Description("sha1all")]
            SHA1_All,

            /// <summary>
            /// Copying a file to chunker will request MD5 from the source. Falling back to SHA1 if unsupported.
            /// </summary>
            [Description("md5quick")]
            MD5_Quick,

            /// <summary>
            /// Similar to &quot;md5quick&quot; but prefers SHA1 over MD5.
            /// </summary>
            [Description("sha1quick")]
            SHA1_Quick,

        }


        /// <summary>
        /// Files larger than chunk size will be split in chunks (default 2Gi)
        /// </summary>
        [SizeSuffixFlag("chunk-size", "2G")]
        public SizeSuffix ChunkSize { get; set; }


        /// <summary>
        /// Choose how chunker should handle files with missing or invalid chunks
        /// </summary>
        [BoolFlag("fail-hard")]
        public bool FailHard { get; set; }


        /// <summary>
        /// Choose how chunker handles hash sums (default &quot;md5&quot;)
        /// </summary>
        [SingleEnumFlag("hash-type", (int)HashTypes.MD5)]
        public HashTypes? HashType { get; set; }


        /// <summary>
        /// Remote to chunk/unchunk
        /// </summary>
        [StringFlag("remote")]
        public string Remote { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
