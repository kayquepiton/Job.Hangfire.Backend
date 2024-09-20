using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Job.Hangfire.Backend.Domain.Entities;

namespace Job.Hangfire.Backend.Infra.Data.Configurations;

public class EmailEntityConfiguration : IEntityTypeConfiguration<EmailEntity>
{
    public void Configure(EntityTypeBuilder<EmailEntity> builder)
    {
        builder.ToTable("Emails");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Recipient)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Subject)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Body)
            .IsRequired();

        builder.Property(e => e.Status)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.Property(e => e.SentAt);

        builder.Property(e => e.ErrorMessage)
            .HasMaxLength(500);
    }
}
