using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerDemo.Core.Entities;

namespace TaskManager.Data.Config;

// TODO: Создать конфигурацию для TaskItem
// 1. Реализовать IEntityTypeConfiguration<TaskItem>
// 2. Настроить таблицу, поля, связи и индексы
public class TaskItemConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
    }
}