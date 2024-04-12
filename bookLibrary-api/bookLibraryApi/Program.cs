using bookLibraryApi.Services;
using EFCoreExample;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var origin = "localhost";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: origin,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                      });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("LibCs");
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DatabaseManagementService.MigrationInitialisation(app);
DatabaseManagementService.Seed(app);

app.UseAuthorization();

app.MapControllers();

app.UseCors(origin);

app.Run();
