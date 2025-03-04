using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ITaskRepository
    {
        Task<(IEnumerable<TaskItem>? tasksList, string? errorMessage)> GetAllTasks();
        Task<(TaskItem? taskItem, string? errorMessage)> GetTaskById(int id);
        Task<(TaskItem taskItem, string errorMessage)> AddTask(TaskItem task);
        Task<(TaskItem taskItem, string errorMessage)> UpdateTask(TaskItem task);
        Task<(bool isSuccess, string? errorMessage)> DeleteTask(int id);
    }
}
