using HabitifyBackend.Dto;

namespace HabitifyBackend.Interfaces
{
    public interface IHabitLogRepository
    {
        bool HabitLogExists(int id);
        Task<bool> CreateHabitLog(HabitLogDto habitLogDto);
        bool DeleteHabitLog(int id);
        bool UpdateHabitLog(int id, HabitLogDto habitLogDto);
        // Different Types of GET functions that may be used
        Task<ICollection<HabitLogGetDto>> GetAllHabitLogs();
        HabitLogDto GetHabitLog(int id);
        Task<ICollection<HabitLogGetDto>> GetHabitLogsForHabitForWeek(int habitId, DateTime start, DateTime end);
        Task<ICollection<HabitLogGetDto>> GetHabitLogsForHabitForDay(int habitId, DateTime start, DateTime end);

    }
}
