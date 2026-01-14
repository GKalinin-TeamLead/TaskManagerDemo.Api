namespace TaskManagerDemo.Core.Entities;

public enum ProjectStatus
{
    Planned = 0,     // Запланирован
    Active = 1,      // В работе
    OnHold = 2,      // На паузе
    Completed = 3,   // Завершен
    Cancelled = 4    // Отменен
}