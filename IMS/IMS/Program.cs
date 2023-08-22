using IMS.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IMSDbContextConnection") ?? throw new InvalidOperationException("Connection string 'IMSDbContextConnection' not found.");


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();

builder.Services.AddDbContext<IMSDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:IMSDbContextConnection"]);
});

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

DbInitializer.Seed(app);

app.Run();
