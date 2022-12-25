using DataBaseEf.Model;
using Microsoft.EntityFrameworkCore;

namespace DataBaseEf.Extension;

internal static class ExtensionModelBuilder
{
    internal static ModelBuilder AddTableLinkStorage(this ModelBuilder builder) =>
        builder.Entity<LinkStorage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.LinkStorages");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LinkKey).HasMaxLength(500);
            entity.Property(e => e.LinkValue).HasMaxLength(2048);
        });
}
