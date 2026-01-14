using Microsoft.EntityFrameworkCore;
using TaskManagerDemo.Core.Entities;
using TaskManagerDemo.Data.Configuration;
namespace TaskManagerDemo.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        // TODO: Добавить конфигурацию для TaskItem
        // modelBuilder.ApplyConfiguration(new TaskItemConfiguration());
    }
}