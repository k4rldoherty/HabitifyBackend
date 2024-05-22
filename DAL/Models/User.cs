namespace HabitifyBackend.DAL.Models
{
    public class User : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public ICollection<Habit> Habits { get; set; }
        public ICollection<HabitLog> HabitLogs { get; set; }
    }
}
