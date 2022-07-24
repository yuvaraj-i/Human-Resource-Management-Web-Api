using HumanResourceManagement.Data;
using HumanResourceManagement.Interfaces;
using HumanResourceManagement.Repository;
using HumanResourceManagement.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<HrOperationsService>();
builder.Services.AddTransient<IEmployeeReposistory, EmployeeReposistory>();

builder.Services.AddDbContextPool<ManagementContext>(options =>
{
    var connString = builder.Configuration.GetConnectionString("Default");
    options.UseMySql(connString, ServerVersion.AutoDetect(connString));
});

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
