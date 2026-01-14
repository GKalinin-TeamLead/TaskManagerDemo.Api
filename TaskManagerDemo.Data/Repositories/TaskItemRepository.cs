using TaskManagerDemo.Core.Entities;
using TaskManagerDemo.Core.Interfaces;

namespace TaskManagerDemo.Data.Repositories;

// TODO: Реализовать репозиторий TaskItemRepository
// 1. Наследовать от EfRepository<TaskItem>
// 2. Реализовать интерфейс ITaskItemRepository
// 3. Написать метод GetIncompleteItemsByProjectAsync с LINQ / transact запросом
public class TaskItemRepository(AppDbContext dbContext) : EfRepository<TaskEntity>(dbContext), ITaskEntityRepository
{
    public async Task<IEnumerable<TaskEntity>> GetIncompleteItemsByProjectAsync(int projectId)
    {
        // Написать запрос, который возвращает все незавершенные задачи
        // для указанного проекта, отсортированные по CreatedDate
        return [];
    }
}