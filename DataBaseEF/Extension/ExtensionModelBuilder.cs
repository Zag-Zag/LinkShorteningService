using DataBaseEf.Model;
using Microsoft.EntityFrameworkCore;

namespace DataBaseEf.Extension;

internal static class ExtensionModelBuilder
{
    internal static ModelBuilder AddTableLinkStatistic(this ModelBuilder builder) =>
        builder.Entity<LinkStatistic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.LinkStatistics");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Link).WithMany(p => p.LinkStatistics)
                .HasForeignKey(d => d.LinkId)
                .HasConstraintName("FK_dbo.LinkStatistics_dbo.LinkStorages_LinkId");

            entity.HasOne(d => d.Property).WithMany(p => p.LinkStatistics)
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("FK_dbo.LinkStatistics_dbo.StatisticsProperties_PropertyId");
        });
    internal static ModelBuilder AddTableLinkStorage(this ModelBuilder builder) =>
        builder.Entity<LinkStorage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.LinkStorages");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LinkKey).HasMaxLength(500);
            entity.Property(e => e.LinkValue).HasMaxLength(2048);
        });
    internal static ModelBuilder AddTableStatisticsProperty(this ModelBuilder builder) =>
        builder.Entity<StatisticsProperty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.StatisticsProperties");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(100);
        });
}
