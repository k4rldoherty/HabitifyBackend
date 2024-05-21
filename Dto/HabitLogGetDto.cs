namespace HabitifyBackend.Dto
{
    public class HabitLogGetDto
    {
        public int Id { get; set; }
        public int HabitId { get; set; }
        public string Comment { get; set; }
        public DateTime CompletionTime { get; set; }
    }
}
