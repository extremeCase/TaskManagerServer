using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITaskService
    {
        Task<(IEnumerable<TaskItemDto>? tasksList, string? errorMessage)> GetAllTasks();
        Task<(TaskItemDto? taskItem, string? errorMessage)> GetTaskById(int id);
        Task<(TaskItemDto taskItem, string errorMessage)> AddTask(TaskItemDto task);
        Task<(TaskItemDto taskItem, string errorMessage)> UpdateTask(TaskItemDto task);
        Task<(bool isSuccess, string? errorMessage)> DeleteTask(int id);
    }
}
