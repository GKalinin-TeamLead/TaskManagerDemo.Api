using System;
using System.Collections.Generic;

namespace TaskManagerDemo.Core.Entities;

/// <summary>
/// Сущность проекта
/// </summary>
public class ProjectEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal Budget { get; set; }
    public ProjectStatus Status { get; set; }
    public string ClientName { get; set; }
    public string TechnologyStack { get; set; }
    public DateTime? Deadline { get; set; }
    public int TeamSize { get; set; }

}
