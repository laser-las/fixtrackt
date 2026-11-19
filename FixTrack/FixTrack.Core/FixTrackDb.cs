using Microsoft.EntityFrameworkCore;

namespace FixTrack.Core;

public class FixTrackDb : DbContext
{
    public DbSet<Issue> Issues => Set<Issue>();

    protected override void OnConfiguring(
        DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=fixtrack.db");

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Issue>().HasKey(i => i.Id);

        modelBuilder.Entity<Issue>()
            .Property(i => i.Title)
            .IsRequired();

        modelBuilder.Entity<Issue>()
            .Property(i => i.Status)
            .IsRequired();
    }
}
