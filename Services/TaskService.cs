using AutoMapper;
using Entities.DTO;
using Entities.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<TaskItemDto>? tasksList, string? errorMessage)> GetAllTasks()
        {
            var (tasks, errorMessage) = await _taskRepository.GetAllTasks();
            if (tasks == null)
                return (null, errorMessage);

            var taskDtos = _mapper.Map<IEnumerable<TaskItemDto>>(tasks);
            return (taskDtos, null);
        }

        public async Task<(TaskItemDto? taskItem, string? errorMessage)> GetTaskById(int id)
        {
            var (task, errorMessage) = await _taskRepository.GetTaskById(id);
            if (task == null)
                return (null, errorMessage);

            var taskDto = _mapper.Map<TaskItemDto>(task);
            return (taskDto, null);
        }

        public async Task<(TaskItemDto taskItem, string errorMessage)> AddTask(TaskItemDto taskDto)
        {
            var task = _mapper.Map<TaskItem>(taskDto);
            var (addedTask, errorMessage) = await _taskRepository.AddTask(task);
            if (addedTask == null)
                return (taskDto, errorMessage);

            var addedTaskDto = _mapper.Map<TaskItemDto>(addedTask);
            return (addedTaskDto, null);
        }

        public async Task<(TaskItemDto taskItem, string errorMessage)> UpdateTask(TaskItemDto taskDto)
        {
            var task = _mapper.Map<TaskItem>(taskDto);
            var (updatedTask, errorMessage) = await _taskRepository.UpdateTask(task);
            if (updatedTask == null)
                return (taskDto, errorMessage);

            var updatedTaskDto = _mapper.Map<TaskItemDto>(updatedTask);
            return (updatedTaskDto, null);
        }

        public async Task<(bool isSuccess, string? errorMessage)> DeleteTask(int id)
        {
            return await _taskRepository.DeleteTask(id);
        }
    }
}
