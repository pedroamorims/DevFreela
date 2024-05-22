using FreelApp.Application.Commands.CreateProject;
using FreelApp.Application.Queries.GetAllProjects;
using FreelApp.Application.Queries.GetAllSkills;
using FreelApp.Application.Services.Implementations;
using FreelApp.Application.Services.Interfaces;
using FreelApp.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FreelAppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("FreelAppCs"))
    );

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(CreateProjectCommand).Assembly, 
    typeof(GetAllProjectsQuery).Assembly,
    typeof(GetAllSkillsQuery).Assembly,
    typeof(DeleteProjectCommand).Assembly


));

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

app.Run();
