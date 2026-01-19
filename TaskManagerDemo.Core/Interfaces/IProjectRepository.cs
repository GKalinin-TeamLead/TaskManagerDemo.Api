using TaskManagerDemo.Core.Entities;
using System.Threading.Tasks;

namespace TaskManagerDemo.Core.Interfaces;

public interface IProjectRepository : IRepository<ProjectEntity>
{
    IEnumerable<ProjectEntity> GetAllProjects();
    ProjectEntity GetProjectWithTasksAsync(int id);
}