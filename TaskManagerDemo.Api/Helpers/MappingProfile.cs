using AutoMapper;
using TaskManagerDemo.Core.Entities;
using TaskManagerDemo.Shared.Dtos;
namespace TaskManagerDemo.API.Helpers;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProjectEntity, ProjectDto>();
        // TODO: Добавить маппинг для TaskItem -> TaskItemDto
    }
}