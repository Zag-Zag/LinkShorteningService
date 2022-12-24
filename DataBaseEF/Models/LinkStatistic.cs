using AbstractDependencies.Models;

namespace DataBaseEf.Model;

public class LinkStatistic : BaseEntityModel
{
    public Guid LinkId { get; set; }
    public Guid PropertyId { get; set; }
    public int Value { get; set; }
    public DateTime Date { get; set; }

    public virtual LinkStorage Link { get; set; } = null!;
    public virtual StatisticsProperty Property { get; set; } = null!;
}
