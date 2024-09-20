using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Job.Hangfire.Backend.Domain.Entities;

namespace Job.Hangfire.Backend.Infra.Data.Configurations;

public class EmailLogEntityConfiguration : IEntityTypeConfiguration<EmailLogEntity>
{
    public void Configure(EntityTypeBuilder<EmailLogEntity> builder)
    {
        builder.ToTable("EmailLogs");

        builder.HasKey(el => el.Id);

        builder.Property(el => el.EmailId)
            .IsRequired();

        builder.Property(el => el.LoggedAt)
            .IsRequired();

        builder.Property(el => el.Message)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(el => el.ErrorMessage)
            .HasMaxLength(500);

        builder.HasOne<EmailEntity>()
            .WithMany()
            .HasForeignKey(el => el.EmailId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
