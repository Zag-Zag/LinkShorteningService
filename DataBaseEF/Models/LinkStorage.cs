using AbstractDependencies.Models;

namespace DataBaseEf.Model;

public partial class LinkStorage : BaseEntityModel
{
    public string LinkValue { get; set; } = null!;
    public string LinkKey { get; set; } = null!;

    public virtual ICollection<LinkStatistic> LinkStatistics { get; } = new List<LinkStatistic>();
}
