using LessonTable_CRUD_API;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Добавляем DbContext MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    "server=localhost;port=3306;database=schedule_db;user=root;password=root";

builder.Services.AddDbContext<ScheduleContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
