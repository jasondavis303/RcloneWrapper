using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Union merges the contents of several upstream fs
    /// </summary>
    [FlagPrefix("union")]
    public class Union_OptionsBuilder : Base_OptionsBuilder
    {
        public enum Policies
        {
            /// <summary>
            /// Search category: same as ExistingPath_All. Action category: same as ExistingPath_All. Create category: act on all upstreams.
            /// </summary>
            [Description("all")]
            All,

            /// <summary>
            /// Search category: Given this order configured, act on the first one found where the relative path exists. Action category: apply to all found. Create category: act on all upstreams where the relative path exists.
            /// </summary>
            [Description("epall")]
            ExistingPath_All,

            /// <summary>
            /// Act on the first one found, by the time upstreams reply, where the relative path exists.
            /// </summary>
            [Description("epff")]
            ExistingPath_FirstFound,

            /// <summary>
            /// Of all the upstreams on which the relative path exists choose the one with the least free space.
            /// </summary>
            [Description("eplfs")]
            ExistingPath_LeastFreeSpace,

            /// <summary>
            /// Of all the upstreams on which the relative path exists choose the one with the least used space.
            /// </summary>
            [Description("eplus")]
            ExistingPath_LeastUsedSpae,

            /// <summary>
            /// Of all the upstreams on which the relative path exists choose the one with the least number of objects.
            /// </summary>
            [Description("eplno")]
            ExistingPath_LeastNumberOfObjects,

            /// <summary>
            /// Of all the upstreams on which the relative path exists choose the one with the most free space.
            /// </summary>
            [Description("epmfs")]
            ExistingPath_MostFreeSpace,

            /// <summary>
            /// Calls ExistingPath_All and then randomizes. Returns only one upstream.
            /// </summary>
            [Description("eprand")]
            ExistingPath_Random,

            /// <summary>
            /// Search category: same as ExistingPath_FirstFound. Action category: same as ExistingPath_FirstFound. Create category: Act on the first one found by the time upstreams reply.
            /// </summary>
            [Description("ff")]
            FirstFound,

            /// <summary>
            /// Search category: same as ExistingPath_LeastFreeSpace. Action category: same as ExistingPath_LeastFreeSpace. Create category: Pick the upstream with the least available free space.
            /// </summary>
            [Description("lfs")]
            LeastFreeSpace,

            /// <summary>
            /// Search category: same as ExistingPath_LeastUsedSpae. Action category: same as ExistingPath_LeastUsedSpae. Create category: Pick the upstream with the least used space.
            /// </summary>
            [Description("lus")]
            LeastUsedSpace,

            /// <summary>
            /// Search category: same as ExistingPath_LeastNumberOfObjects. Action category: same as ExistingPath_LeastNumberOfObjects. Create category: Pick the upstream with the least number of objects.
            /// </summary>
            [Description("lno")]
            LeastNumberOfObjects,

            /// <summary>
            /// Search category: same as ExistingPath_MostFreeSpace. Action category: same as ExistingPath_MostFreeSpace. Create category: Pick the upstream with the most available free space.
            /// </summary>
            [Description("mfs")]
            MostFreeSpace,

            /// <summary>
            /// Pick the file / directory with the largest mtime.
            /// </summary>
            [Description("newest")]
            Newest,

            /// <summary>
            /// Calls All and then randomizes. Returns only one upstream.
            /// </summary>
            [Description("rand")]
            Random,

        }


        /// <summary>
        /// Policy to choose upstream on ACTION category (default &quot;epall&quot;)
        /// </summary>
        [SingleEnumFlag("action-policy", (int)Policies.ExistingPath_All)]
        public Policies? ActionPolicy { get; set; }


        /// <summary>
        /// Cache time of usage and free space (in seconds) (default 120)
        /// </summary>
        [UintFlag("cache-time", 120)]
        public uint? CacheTime { get; set; }


        /// <summary>
        /// Policy to choose upstream on CREATE category (default &quot;epmfs&quot;)
        /// </summary>
        [SingleEnumFlag("create-policy", (int)Policies.ExistingPath_MostFreeSpace)]
        public Policies? CreatePolicy { get; set; }


        /// <summary>
        /// Minimum viable free space for lfs/eplfs policies (default 1Gi)
        /// </summary>
        [SizeSuffixFlag("min-free-space", "1G")]
        public SizeSuffix MinFreeSpace { get; set; }


        /// <summary>
        /// Policy to choose upstream on SEARCH category (default &quot;ff&quot;)
        /// </summary>
        [SingleEnumFlag("search-policy", (int)Policies.FirstFound)]
        public Policies? SearchPolicy { get; set; }


        /// <summary>
        /// List of space separated upstreams
        /// </summary>
        [StringFlag("upstreams")]
        public string Upstreams { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
