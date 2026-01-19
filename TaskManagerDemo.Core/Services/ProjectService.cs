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

        return projectDtos;
    }

    public Task<ProjectDto> GetProjectByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
