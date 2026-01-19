using Microsoft.EntityFrameworkCore;
using TaskManagerDemo.Core.Entities;
using TaskManagerDemo.Core.Interfaces;

namespace TaskManagerDemo.Data.Repositories;

public class ProjectRepository(AppDbContext dbContext) : EfRepository<ProjectEntity>(dbContext), IProjectRepository
{
    public IEnumerable<ProjectEntity> GetAllProjects()
    {
        return  dbContext.Projects.ToList();
    }

    public ProjectEntity GetProjectWithTasksAsync(int id)
    {
        throw new NotImplementedException();
    }
}