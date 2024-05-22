using HabitifyBackend.DAL.Data;
using HabitifyBackend.DAL.Interfaces;
using HabitifyBackend.DAL.Models;
using HabitifyBackend.Dto;
using Microsoft.AspNetCore.Identity;

namespace HabitifyBackend.DAL.Repositories
{
    public class HabitLogRepository : IHabitLogRepository
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        public HabitLogRepository(
            DataContext dataContext,
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager
            )
        {
            _dataContext = dataContext;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<User> GetUserAsync()
        {
            return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        }

        public async Task<bool> CreateHabitLog(HabitLogDto habitLogDto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteHabitLog(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<HabitLogGetDto>> GetAllHabitLogs()
        {
            throw new NotImplementedException();
        }

        public HabitLogDto GetHabitLog(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<HabitLogGetDto>> GetHabitLogsForHabitForDay(int habitId, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<HabitLogGetDto>> GetHabitLogsForHabitForWeek(int habitId, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public bool HabitLogExists(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateHabitLog(int id, HabitLogDto habitLogDto)
        {
            throw new NotImplementedException();
        }
    }
}
