using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.ToTable("Schedules");

        builder.HasKey(s => s.ScheduleId);

        builder.Property(s => s.ClassSubjectId)
            .IsRequired();

        builder.Property(s => s.DayOfWeek)
            .IsRequired();

        builder.Property(s => s.Time)
            .IsRequired();

        builder.Property(s => s.TermId)
            .IsRequired();

        builder.Property(s => s.Room);

        builder.HasOne(s => s.ClassSubject)
            .WithMany(cs => cs.Schedules)
            .HasForeignKey(s => s.ClassSubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(s => s.Lessons)
            .WithOne(l => l.Schedule)
            .HasForeignKey(l => l.ScheduleId)
            .OnDelete(DeleteBehavior.ClientSetNull);

    }
}
