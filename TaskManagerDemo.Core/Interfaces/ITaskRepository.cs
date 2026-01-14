using TaskManagerDemo.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManagerDemo.Core.Interfaces
{
    // TODO: Создать интерфейс ITaskItemRepository
    // 1. Наследовать от IRepository<TaskItem>
    // 2. Добавить метод GetIncompleteItemsByProjectAsync(int projectId)
    
    public interface ITaskEntityRepository : IRepository<TaskEntity>
    {
        //Интерфейс должен описывать функционал получения задач по проекту
    }
}