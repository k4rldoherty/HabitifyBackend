using HabitifyBackend.DAL.Models;
using HabitifyBackend.Dto;

namespace HabitifyBackend.BLL.Interfaces
{
    public interface IHabitService
    {
        // Habit Related Functions
        Task<ICollection<HabitGetDto>> GetHabitsAsync();
        Task<HabitGetDto> GetHabitAsync(int id);
        Task<bool> CreateHabitAsync(HabitDto habit);
    }
}
