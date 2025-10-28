using Microsoft.EntityFrameworkCore;
using Todo.Interfaces.Repositories;
using Todo.Persistence.Data;
using Todo.Persistence.Repositories;
using Todo.UseCases.MemberUseCases;
using Todo.UseCases.SubTaskUseCases;
using Todo.UseCases.TaskUseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("InitConnection")));

builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<ITaskInfoRepository, TaskRepository>();
builder.Services.AddScoped<ISubTaskInfoRepository, SubTaskRepository>();
builder.Services.AddScoped<CreateMember>();
builder.Services.AddScoped<GetMembers>();
builder.Services.AddScoped<CreateTask>();
builder.Services.AddScoped<GetTasks>();
builder.Services.AddScoped<CreateSubTask>();
builder.Services.AddScoped<SetDueDate>();

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
