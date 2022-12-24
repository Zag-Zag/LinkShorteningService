using AbstractDependencies.Models;

namespace DataBaseEf.Model;

public partial class StatisticsProperty : BaseEntityModel
{
    public string Name { get; set; } = null!;

    public virtual ICollection<LinkStatistic> LinkStatistics { get; } = new List<LinkStatistic>();
}
