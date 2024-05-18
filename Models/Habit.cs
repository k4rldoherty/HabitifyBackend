using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HabitifyBackend.Models
{
    public class Habit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Frequency { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
