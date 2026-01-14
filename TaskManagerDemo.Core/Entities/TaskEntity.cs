using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerDemo.Core.Entities
{
    // TODO: Дописать класс TaskItem
    // 1. Добавить необходимые свойства (Id, Title, Description, Status, ProjectId)
    // 2. Добавить навигационное свойство к Project
    // 3. Добавить enum для статуса (можно вынести в Shared/Enums)
    public class TaskEntity
    {
        [Key]
        public int Id { get; set; }
    }
}