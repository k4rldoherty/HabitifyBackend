namespace HabitifyBackend.DAL.Models
{
    public class HabitLog
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int HabitId { get; set; }
        public string Comment { get; set; }
        public DateTime CompletionTime { get; set; }
        public User User { get; set; }
        public Habit Habit { get; set; }
    }
}
