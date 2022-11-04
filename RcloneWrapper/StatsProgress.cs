using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RcloneWrapper
{
    public class StatsProgress : IEquatable<StatsProgress>
    {
        internal StatsProgress(string raw)
        {
            Raw = raw;
            try
            {
                var parts = raw.Split(',').Select(item => item.Trim()).ToList();

                //Size
                var subParts = parts[0].Split('/').Select(item => item.Trim()).ToList();
                if (subParts.Count > 1)
                {
                    SizeCompleted = subParts[0];
                    SizeTotal = subParts[1];
                }

                //Percent
                if (int.TryParse(parts[1].Trim('%'), out int percent))
                    PercentCompleted = percent;

                //Speed
                Speed = parts[2];

                //ETA
                string subEta = parts[3];
                int xfrPos = subEta.IndexOf(" (xfr");
                if (xfrPos > 0)
                {
                    subEta = subEta[..xfrPos].Trim();

                    subParts = parts[3][(xfrPos + 6)..^1].Split('/').ToList();
                    if (int.TryParse(subParts[0], out int i))
                        Transfered = i;
                    if (int.TryParse(subParts[1], out i))
                        TotalTransfers = i;
                }
                
                parts = subEta.Split(' ').ToList();
                ETA = parts[1];

                //Other data
                if (parts.Count > 2)
                    OtherData = string.Join(' ', parts.Skip(2));

                IsValid = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        internal bool IsValid { get; }

        public string Raw { get; }

        public string SizeCompleted { get; }

        public string SizeTotal { get; }

        public int PercentCompleted { get; }

        public string Speed { get; }

        public string ETA { get; }

        public int Transfered { get; } = -1;

        public int TotalTransfers { get; } = -1;

        public string OtherData { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as StatsProgress);
        }

        public bool Equals(StatsProgress other)
        {
            return other is not null &&
                   Raw == other.Raw;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Raw);
        }

        public override string ToString() => Raw;

        public static bool operator ==(StatsProgress left, StatsProgress right)
        {
            return EqualityComparer<StatsProgress>.Default.Equals(left, right);
        }

        public static bool operator !=(StatsProgress left, StatsProgress right)
        {
            return !(left == right);
        }

        public static bool operator >(StatsProgress left, StatsProgress right)
        {
            return left.PercentCompleted > right.PercentCompleted;
        }

        public static bool operator <(StatsProgress left, StatsProgress right)
        {
            return left.PercentCompleted < right.PercentCompleted;
        }
    }
}
