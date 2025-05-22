namespace LessonTable_CRUD_API
{
    using Microsoft.EntityFrameworkCore;

    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options) { }

        public DbSet<ScheduleEntry> ScheduleEntries { get; set; } = null!;
    }
}
