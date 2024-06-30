using InterRapiStudy.Context;
using InterRapiStudy.Dtos;
using InterRapiStudy.Mappers;
using InterRapiStudy.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<InterRapiStudyDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<ISubjectService, SubjectService>();
builder.Services.AddTransient<ITeacherService, TeacherService>();
builder.Services.AddTransient<IProgramService, ProgramService>();
builder.Services.AddTransient<IProgramSubjectService, ProgramSubjectService>();

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
