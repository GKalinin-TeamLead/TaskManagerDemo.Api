using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TaskManagerDemo.Core.Interfaces;

namespace TaskManagerDemo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectService.GetAllProjectsAsync();
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);
        if (project == null)
            return NotFound($"Проект с ID {id} не найден");

        return Ok(project);
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetActiveProjects()
    {
        var projects = await _projectService.GetActiveProjectsAsync();
        return Ok(projects);
    }

    [HttpGet("client/{clientName}")]
    public async Task<IActionResult> GetByClient(string clientName)
    {
        var projects = await _projectService.GetProjectsByClientAsync(clientName);
        return Ok(projects);
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var allProjects = await _projectService.GetAllProjectsAsync();

        var stats = new
        {
            TotalProjects = allProjects.Count(),
            ActiveProjects = allProjects.Count(p => p.Status == Core.Entities.ProjectStatus.Active),
            CompletedProjects = allProjects.Count(p => p.Status == Core.Entities.ProjectStatus.Completed),
            TotalBudget = allProjects.Sum(p => p.Budget),
            AverageTeamSize = allProjects.Average(p => p.TeamSize),
            OverdueProjects = allProjects.Count(p => p.IsOverdue)
        };

        return Ok(stats);
    }
}