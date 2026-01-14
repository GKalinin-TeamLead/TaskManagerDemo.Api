using TaskManagerDemo.Core.Entities;
using System.Threading.Tasks;

namespace TaskManagerDemo.Core.Interfaces;

public interface IProjectRepository : IRepository<ProjectEntity>
{
    Task<ProjectEntity> GetProjectWithTasksAsync(int id);
}