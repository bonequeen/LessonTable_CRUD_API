namespace LessonTable_CRUD_API
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Text.Json;

    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleContext _context;

        public ScheduleController(ScheduleContext context)
        {
            _context = context;
        }

        // GET api/schedule
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleEntry>>> GetAll()
        {
            return await _context.ScheduleEntries.ToListAsync();
        }

        // GET api/schedule/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleEntry>> Get(int id)
        {
            var entry = await _context.ScheduleEntries.FindAsync(id);
            if (entry == null) return NotFound();
            return entry;
        }

        // POST api/schedule
        [HttpPost]
        public async Task<ActionResult<ScheduleEntry>> Create(ScheduleEntry entry)
        {
            _context.ScheduleEntries.Add(entry);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = entry.Id }, entry);
        }

        // DELETE api/schedule/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entry = await _context.ScheduleEntries.FindAsync(id);
            if (entry == null) return NotFound();

            _context.ScheduleEntries.Remove(entry);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST api/schedule/savefile
        [HttpPost("savefile")]
        public async Task<IActionResult> SaveToFile()
        {
            var allEntries = await _context.ScheduleEntries.ToListAsync();
            var json = JsonSerializer.Serialize(allEntries, new JsonSerializerOptions { WriteIndented = true });

            var filePath = Path.Combine(Environment.CurrentDirectory, "schedule_backup.json");
            await System.IO.File.WriteAllTextAsync(filePath, json);

            return Ok(new { message = "Расписание сохранено в файл", path = filePath });
        }
    }

}
