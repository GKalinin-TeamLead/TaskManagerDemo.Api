using Microsoft.EntityFrameworkCore;
using TaskManagerDemo.Core.Entities;
using TaskManagerDemo.Core.Interfaces;

namespace TaskManagerDemo.Data.Repositories;

public class ProjectRepository(AppDbContext dbContext) : EfRepository<ProjectEntity>(dbContext), IProjectRepository
{
    public async Task<ProjectEntity> GetProjectWithTasksAsync(int id)
    {
        var temp = _dbContext.Projects;
        return await temp.Include(proj => proj.Tasks).FirstOrDefaultAsync(p => p.Id == id);

    }
}