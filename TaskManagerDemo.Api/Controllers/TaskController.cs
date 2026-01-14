using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagerDemo.Core.Interfaces;

namespace TaskManagerDemo.API.Controllers;

// TODO: Создать контроллер TaskItemsController
// 1. Добавить маршрут api/projects/{projectId}/tasks
// 2. Реализовать GET метод для получения задач по projectId

[ApiController]
[Route("api/[controller]")]
public class TaskItemsController : ControllerBase
{
}