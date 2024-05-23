using FreelApp.Application.Commands.CreateProject;
using FreelApp.Application.Services.Implementations;
using FreelApp.Application.Services.Interfaces;
using FreelApp.Core.Repositories;
using FreelApp.Infraestructure.Persistence;
using FreelApp.Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FreelApp.Application.Validators;
using FreelApp.Api.Filters;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateProjectCommandValidator>());




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FreelAppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("FreelAppCs"))
    );

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateProjectCommand).Assembly));

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
