using AutoMapper;
using HabitifyBackend.Dto;
using HabitifyBackend.Models;

namespace HabitifyBackend.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Habit, HabitDto>().ReverseMap();
        }
    }
}
