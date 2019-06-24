using System.Collections.Generic;
using AutoMapper;
using shecodes.tasks.models;

namespace shecodes.tasks.dtos
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<TaskDtoForPost, TaskItem>();
            CreateMap<TaskItem, TaskItemDtoForGet>();
           
        }
    }
}