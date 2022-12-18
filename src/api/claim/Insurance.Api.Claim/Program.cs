using AutoMapper;
using Insurance.Repository.DbContexts;
using Insurance.Repository.Interface;
using Insurance.Repository.Service;
using Insurance.Service.Interface;
using Insurance.Service.Mapper;
using Insurance.Service.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClaimService, ClaimService>();
builder.Services.AddScoped<IClaimRepository, ClaimRepository>();
builder.Services.AddDbContext<InsuranceDbContext>(opt =>
{
    opt.UseInMemoryDatabase("InsuranceDb");
    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});


// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
