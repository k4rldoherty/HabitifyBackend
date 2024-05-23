using HabitifyBackend.DAL.Data;
using HabitifyBackend.DAL.Interfaces;
using HabitifyBackend.DAL.Models;
using HabitifyBackend.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HabitifyBackend.DAL.Repositories
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

        public async Task<ICollection<Habit>> GetHabitsAsync(string userId)
        {
            return await _dataContext.Habits.Where(h => h.UserId == userId).ToListAsync();
        }

        public async Task<Habit> GetHabitAsync(int id, string userId)
        {
            // Possibly add in check to see if habit belongs to a user, but shouldn't
            // be an issue as user will only ever see their habits.
            var habit = await _dataContext.Habits.Where(h => h.UserId == userId).Where(h => h.Id == id).FirstOrDefaultAsync();

            if (habit == null) return null;

            return habit;
        }

        public async Task<bool> CreateHabitAsync(Habit h)
        {
            await _dataContext.Habits.AddAsync(h);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        // Consider adding a soft delete functionality
        // Change from bool to int and return status codes ?? instead of just true or false
        public bool DeleteHabit(int id)
        {
            if (!HabitExists(id)) return false;

            var habit = _dataContext.Habits.Where(h => h.Id == id).First();

            _dataContext.Habits.Remove(habit);

            return _dataContext.SaveChanges() > 0;
        }

        public bool HabitExists(int id)
        {
            return _dataContext.Habits.Where(h => h.Id == id).Count() > 0;
        }

        public bool UpdateHabit(int id, HabitDto h)
        {
            var habit = _dataContext.Habits.Where(h => h.Id == id).FirstOrDefault();

            if (habit == null) return false;

            habit.Name = h.Name;
            habit.Description = h.Description;
            habit.Frequency = h.Frequency;

            return _dataContext.SaveChanges() > 0;
        }
    }
}
