using System.Collections.Generic;
using System.Linq;
using Duplicates.Core;
using Duplicates.Data.Entities;

namespace Duplicates.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        public IEnumerable<Statistic> GetStatisticsWithoutDuplicate(IEnumerable<Statistic> collection)
        {
            return collection.Distinct(new StatisticsEqualityComparer());
        }
    }
}