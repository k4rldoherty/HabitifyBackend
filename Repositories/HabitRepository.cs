using HabitifyBackend.Data;
using HabitifyBackend.Interfaces;
using HabitifyBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HabitifyBackend.Repositories
{
    public class HabitRepository : IHabitRepository
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        public HabitRepository(DataContext dataContext, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _dataContext = dataContext;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        private async Task<User> GetUserAsync()
        {
            return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        }

        public async Task<bool> CreateHabit(Habit h)
        {
            var user = await GetUserAsync();
            if (user == null) return false;
            h.UserId = user.Id;

            await _dataContext.Habits.AddAsync(h);

            return await _dataContext.SaveChangesAsync() > 0;
        }

        public bool DeleteHabit(int id)
        {
            throw new NotImplementedException();
        }

        public Habit GetHabit(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Habit>> GetHabits()
        {
            var user = await GetUserAsync();
            if(user == null) return new List<Habit>();
            return await _dataContext.Habits.Where(h => h.UserId == user.Id).ToListAsync();
        }

        public bool HabitExists(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateHabit(Habit h)
        {
            throw new NotImplementedException();
        }
    }
}
