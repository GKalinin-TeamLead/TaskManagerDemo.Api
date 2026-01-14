using TaskManagerDemo.Core.Entities;

namespace TaskManagerDemo.Shared.Dtos;


public class ProjectDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal Budget { get; set; }
    public ProjectStatus Status { get; set; }
    public string StatusText => GetStatusText();
    public string ClientName { get; set; }
    public string TechnologyStack { get; set; }
    public DateTime? Deadline { get; set; }
    public int TeamSize { get; set; }
    public bool IsOverdue => Deadline.HasValue && Deadline < DateTime.Now;
    public int TaskCount { get; set; }

    private string GetStatusText() => Status switch
    {
       ProjectStatus.Planned => "Запланирован",
       ProjectStatus.Active => "В работе",
       ProjectStatus.OnHold => "На паузе",
       ProjectStatus.Completed => "Завершен",
       ProjectStatus.Cancelled => "Отменен",
       _ => "Неизвестно"
    };
}
