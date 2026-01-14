using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerDemo.Core.Entities;

namespace TaskManagerDemo.Data.Configuration;

public class ProjectConfiguration : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Description)
            .HasMaxLength(1000);

        builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        // Новые свойства
        builder.Property(p => p.Budget)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(p => p.Status)
            .IsRequired()
            .HasDefaultValue(ProjectStatus.Planned);

        builder.Property(p => p.ClientName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.TechnologyStack)
            .HasMaxLength(500);

        builder.Property(p => p.TeamSize)
            .IsRequired()
            .HasDefaultValue(1);

        // Индексы
        builder.HasIndex(p => p.Status);
        builder.HasIndex(p => p.ClientName);
        builder.HasIndex(p => p.CreatedAt);

        //TODO: Реализовать связь проекта с задачами

    }
}