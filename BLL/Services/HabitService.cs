using HabitifyBackend.DAL.Data;
using HabitifyBackend.DAL.Interfaces;
using HabitifyBackend.BLL.Interfaces;
using HabitifyBackend.DAL.Models;
using HabitifyBackend.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace HabitifyBackend.BLL.Services
{
    public class HabitService : IHabitService
    {
        private readonly DataContext _dataContext;
        private readonly IHabitRepository _habitRepository;
        private readonly IHabitLogRepository _habitLogRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        public HabitService(
            DataContext dataContext,
            IHabitRepository habitRepository,
            IHabitLogRepository habitLogRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager
            )
        {
            _dataContext = dataContext;
            _habitRepository = habitRepository;
            _habitLogRepository = habitLogRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        private async Task<User> GetUserAsync()
        {
            return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        }

        public async Task<ICollection<HabitGetDto>> GetHabitsAsync()
        {
            var user = await GetUserAsync();
            if (user == null) return new List<HabitGetDto>();
            var habitsList = await _habitRepository.GetHabitsAsync(user.Id);
            return _mapper.Map<List<HabitGetDto>>(habitsList);
        }

        public async Task<HabitGetDto> GetHabitAsync(int id)
        {
            var user = await GetUserAsync();
            if (user == null) return null;
            Habit habit = await _habitRepository.GetHabitAsync(id, user.Id);

            return _mapper.Map<HabitGetDto>(habit);
        }

        public async Task<bool> CreateHabitAsync(HabitDto habitDto)
        {
            var user = await GetUserAsync();
            Habit habit = new Habit()
            {
                UserId = user.Id,
                Name = habitDto.Name,
                Description = habitDto.Description,
                Frequency = habitDto.Frequency,
                User = user
                // No HabitLogs Yet as new entry
            };

            return await _habitRepository.CreateHabitAsync(habit);
        }
    }
}
