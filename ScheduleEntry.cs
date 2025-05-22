namespace LessonTable_CRUD_API
{
    public class ScheduleEntry
    {
        public int Id { get; set; }
        public string DayOfWeek { get; set; } = null!; // например, "Понедельник"
        public TimeSpan Time { get; set; }              // время занятия
        public string Subject { get; set; } = null!;
        public string Classroom { get; set; } = null!;
    }

}
