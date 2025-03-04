using Entities.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string _jsonFilePath;
        public TaskRepository(IConfiguration configuration)
        {
            _jsonFilePath = configuration["JsonFilePath"];
        }

        private async Task<(List<TaskItem> tasks, string? errorMessage)> ReadTasksFromFile()
        {
            try
            {
                if (!File.Exists(_jsonFilePath))
                    return (new List<TaskItem>(), "The data source was not found");

                var jsonData = await File.ReadAllTextAsync(_jsonFilePath);
                var tasks = JsonSerializer.Deserialize<List<TaskItem>>(jsonData) ?? new List<TaskItem>();
                return (tasks, null);
            }
            catch (Exception ex)
            {
                return (new List<TaskItem>(), ex.Message);
            }
        }

        private async Task<string?> WriteTasksToFile(List<TaskItem> tasks)
        {
            try
            {
                var updatedJsonData = JsonSerializer.Serialize(tasks);
                await File.WriteAllTextAsync(_jsonFilePath, updatedJsonData);
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<(IEnumerable<TaskItem>? tasksList, string? errorMessage)> GetAllTasks()
        {
            var (tasks, errorMessage) = await ReadTasksFromFile();
            return (tasks, errorMessage);
        }

        public async Task<(TaskItem? taskItem, string? errorMessage)> GetTaskById(int id)
        {
            var (tasks, errorMessage) = await ReadTasksFromFile();
            if (errorMessage != null)
                return (null, errorMessage);

            var task = tasks.FirstOrDefault(t => t.id == id);
            return (task, task == null ? "Task not found" : null);
        }

        public async Task<(TaskItem taskItem, string errorMessage)> AddTask(TaskItem task)
        {
            var (tasks, errorMessage) = await ReadTasksFromFile();
            if (errorMessage != null)
                return (task, errorMessage);

            task.id = tasks.Any() ? tasks.Max(t => t.id) + 1 : 1;
            tasks.Add(task);

            errorMessage = await WriteTasksToFile(tasks);
            return (task, errorMessage);
        }

        public async Task<(TaskItem taskItem, string errorMessage)> UpdateTask(TaskItem task)
        {
            var (tasks, errorMessage) = await ReadTasksFromFile();
            if (errorMessage != null)
                return (task, errorMessage);

            var existingTask = tasks.FirstOrDefault(t => t.id == task.id);
            if (existingTask == null)
                return (task, "Task not found");

            existingTask.title = task.title;
            existingTask.description = task.description;
            existingTask.priority = task.priority;
            existingTask.dueDate = task.dueDate;
            existingTask.status = task.status;

            errorMessage = await WriteTasksToFile(tasks);
            return (existingTask, errorMessage);
        }

        public async Task<(bool isSuccess, string? errorMessage)> DeleteTask(int id)
        {
            var (tasks, errorMessage) = await ReadTasksFromFile();
            if (errorMessage != null)
                return (false, errorMessage);

            var taskToRemove = tasks.FirstOrDefault(t => t.id == id);
            if (taskToRemove == null)
                return (false, "Task not found");

            tasks.Remove(taskToRemove);

            errorMessage = await WriteTasksToFile(tasks);
            return (errorMessage == null, errorMessage);
        }
    }
}
