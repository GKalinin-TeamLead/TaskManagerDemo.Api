using AutoMapper;
using TaskManagerDemo.Core.Entities;
using TaskManagerDemo.Core.Interfaces;
using TaskManagerDemo.Shared.Dtos;

namespace TaskManagerDemo.Core.Services;

public class ProjectService(IProjectRepository projectRepository, IMapper mapper) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
    {
        var projects = await _projectRepository.GetAllAsync();
        var projectDtos = _mapper.Map<IEnumerable<ProjectDto>>(projects);

        // ƒобавл€ем количество задач дл€ каждого проекта
        foreach (var projectDto in projectDtos)
        {
            var project = projects.FirstOrDefault(p => p.Id == projectDto.Id);
            if (project != null)
            {
                projectDto.TaskCount = project.Tasks?.Count ?? 0;
            }
        }

        return projectDtos;
    }

    public async Task<ProjectDto> GetProjectByIdAsync(int id)
    {
        var project = await _projectRepository.GetProjectWithTasksAsync(id);
        if (project == null)
            return null;

        var projectDto = _mapper.Map<ProjectDto>(project);
        projectDto.TaskCount = project.Tasks?.Count ?? 0;

        return projectDto;
    }

    public async Task<IEnumerable<ProjectDto>> GetActiveProjectsAsync()
    {
        var projects = await _projectRepository.FindAsync(p => p.Status == ProjectStatus.Active);
        return _mapper.Map<IEnumerable<ProjectDto>>(projects);
    }

    public async Task<IEnumerable<ProjectDto>> GetProjectsByClientAsync(string clientName)
    {
        var projects = await _projectRepository.FindAsync(p => p.ClientName == clientName);
        return _mapper.Map<IEnumerable<ProjectDto>>(projects);
    }
}
