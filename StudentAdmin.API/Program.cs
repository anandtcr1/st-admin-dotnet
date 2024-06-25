using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAdmin.API.Profiles.Nationalities;
using StudentAdmin.API.Profiles.Students;
using StudentAdmin.Application.Contracts.Nationalities;
using StudentAdmin.Application.Contracts.Students;
using StudentAdmin.Application.Nationalities;
using StudentAdmin.Application.Students;
using StudentAdmin.Domain;
using StudentAdmin.Domain.Nationalities;
using StudentAdmin.Domain.Students;
using StudentAdmin.EntityFramework.EntityFrameworkCore;
using StudentAdmin.EntityFramework.Migrations;
using StudentAdmin.EntityFramework.Nationalities;
using StudentAdmin.EntityFramework.Students;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("schoolAdminConnectionString")));
builder.Services.AddScoped<IStudentAppService, StudentAppService>();
builder.Services.AddScoped<IFamilyMemberAppService, FamilyMemberAppService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IFamilyMemberRepository, FamilyMemberRepository>();
builder.Services.AddScoped<INationalityAppService, NationalityAppService>();
builder.Services.AddScoped<INationalityRepository, NationalityRepository>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new StudentProfile());
    mc.AddProfile(new FamilyMemberProfile());
    mc.AddProfile(new NationalityProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddCors(o => o.AddPolicy("default", builder =>
{
    builder.WithOrigins("http://localhost:5173")
       .AllowAnyMethod()
       .AllowCredentials()
        .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
