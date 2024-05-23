using HabitifyBackend.DAL.Models;
using HabitifyBackend.Dto;

namespace HabitifyBackend.DAL.Interfaces
{
    public interface IHabitRepository
    {
        bool HabitExists(int id);
        Task<ICollection<Habit>> GetHabitsAsync(string userID);
        Task<Habit> GetHabitAsync(int id, string userId);
        Task<bool> CreateHabitAsync(Habit h);
        bool UpdateHabit(int id, HabitDto newH);
        bool DeleteHabit(int id);
    }
}
