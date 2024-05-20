using HabitifyBackend.Dto;
using HabitifyBackend.Models;

namespace HabitifyBackend.Interfaces
{
    public interface IHabitRepository
    {
        bool HabitExists(int id);
        Task<ICollection<Habit>> GetHabits();
        Habit GetHabit(int id);
        Task<bool> CreateHabit(Habit h);
        bool UpdateHabit(int id, HabitDto newH);
        bool DeleteHabit(int id);
    }
}
