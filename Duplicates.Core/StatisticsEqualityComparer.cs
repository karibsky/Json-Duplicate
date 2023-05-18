using System.Collections.Generic;
using Duplicates.Data.Entities;

namespace Duplicates.Core
{
    public class StatisticsEqualityComparer : IEqualityComparer<Statistic>
    {
        public bool Equals(Statistic x, Statistic y)
        {
            return x?.RecId == y?.RecId && x?.Timestamp == y?.Timestamp;
        }

        public int GetHashCode(Statistic obj)
        {
            return obj.RecId.GetHashCode () ^ obj.Timestamp.GetHashCode();
        }
    }
}