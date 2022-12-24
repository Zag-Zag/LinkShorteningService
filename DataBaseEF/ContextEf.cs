using DataBaseEf.Extension;
using DataBaseEf.Model;
using Microsoft.EntityFrameworkCore;

namespace DataBaseEf;

public partial class ContextEf : DbContext
{
    /*public ContextEf()
    {
        Database.EnsureCreated();

        //var optionsBuilder = new DbContextOptionsBuilder<ContextEf>();

        //var options = optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;")
                .Options;
    }*/

    public ContextEf(DbContextOptions<ContextEf> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<LinkStatistic> LinkStatistics { get; set; }

    public virtual DbSet<LinkStorage> LinkStorages { get; set; }

    public virtual DbSet<StatisticsProperty> StatisticsProperties { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LinkShorteningDB;Trusted_Connection=True;"
            , options => options.EnableRetryOnFailure());*/

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        OnModelCreatingPartial(
            modelBuilder
                .AddTableLinkStatistic()
                .AddTableLinkStorage()
                .AddTableStatisticsProperty());
    
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
