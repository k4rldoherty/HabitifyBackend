using HabitifyBackend.Models;

namespace HabitifyBackend.Interfaces
{
    public interface IHabitRepository
    {
        bool HabitExists(int id);
        Task<ICollection<Habit>> GetHabits();
        Habit GetHabit(int id);
        Task<bool> CreateHabit(Habit h);
        bool UpdateHabit(Habit h);
        bool DeleteHabit(int id);
    }
}
