using AutoMapper;
using Entities.DTO;
using Entities.Models;

namespace Entities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskItem, TaskItemDto>().ReverseMap();
        }
    }
}
