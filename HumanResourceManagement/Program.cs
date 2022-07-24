using HumanResourceManagement.AuthenticationUtils;
using HumanResourceManagement.Data;
using HumanResourceManagement.Interfaces;
using HumanResourceManagement.Repository;
using HumanResourceManagement.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<HrOperationsService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<HomeService>();
builder.Services.AddTransient<IEmployeeReposistory, EmployeeReposistory>();
builder.Services.AddSingleton<IJwtTokenManager, JwtTokenManager>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:key"]);
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
