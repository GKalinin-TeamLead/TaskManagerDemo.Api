using TaskManagerDemo.Shared.Dtos;
namespace TaskManagerDemo.Core.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
    Task<ProjectDto> GetProjectByIdAsync(int id);
}