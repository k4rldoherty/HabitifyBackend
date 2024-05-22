using AutoMapper;
using HabitifyBackend.DAL.Models;
using HabitifyBackend.Dto;

namespace HabitifyBackend.Dto.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Habit, HabitDto>().ReverseMap();
            CreateMap<Habit, HabitGetDto>().ReverseMap();
            CreateMap<HabitLog, HabitLogDto>().ReverseMap();
            CreateMap<HabitLog, HabitLogGetDto>().ReverseMap();
        }
    }
}
