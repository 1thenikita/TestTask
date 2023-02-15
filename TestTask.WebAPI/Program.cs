using Microsoft.EntityFrameworkCore;
using TestTask.WebAPI;

var builder = WebApplication.CreateBuilder(args);

// TODO: edit this connection string
builder.Services.AddDbContext<DBContext>(options =>
    options.UseNpgsql("Host=srv2.kaboom.pro;Database=testtask;Username=testtask;Password=testtask"));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var context= app.Services.CreateScope().ServiceProvider.GetService<DBContext>();
context.Database.EnsureCreated();


app.Run();