using DataBaseEf.Extension;
using DataBaseEf.Model;
using Microsoft.EntityFrameworkCore;

namespace DataBaseEf;

public partial class ContextEf : DbContext
{
    public ContextEf(DbContextOptions<ContextEf> options)
        : base(options) => Database.EnsureCreated();

    public virtual DbSet<LinkStatistic> LinkStatistics { get; set; }
    public virtual DbSet<LinkStorage> LinkStorages { get; set; }
    public virtual DbSet<StatisticsProperty> StatisticsProperties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder
            .AddTableLinkStatistic()
            .AddTableLinkStorage()
            .AddTableStatisticsProperty();
}