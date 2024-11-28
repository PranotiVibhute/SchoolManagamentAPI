using Microsoft.EntityFrameworkCore;
using WebApiAssiment3;
using WebApiAssiment3.Context;
using WebApiAssiment3.Interface;
using WebApiAssiment3.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IStudent, StudentService>(); 
builder.Services.AddScoped<ITeacher, TeacherService>();
builder.Services.AddScoped<IClass, ClassService>();
builder.Services.AddScoped<ISubject,Subjectservice>();
builder.Services.AddScoped<IUser, UserService>();

builder.Services.AddDbContext<SchoolManagementDbContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();//3 register to Dbset

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
