using Microsoft.EntityFrameworkCore;
using Job.Hangfire.Backend.Domain.Entities;

namespace Job.Hangfire.Backend.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<EmailEntity> Emails { get; set; }
    public DbSet<EmailLogEntity> EmailLogs { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
