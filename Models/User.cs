namespace HabitifyBackend.Models
{
    public class User : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public ICollection<Habit> Habits { get; set; }
    }
}
