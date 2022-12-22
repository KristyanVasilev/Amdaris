using BookShop.Application.Interfaces;
using BookShop.Application.Publications.Commands.CreatePublication;
using BookShop.Application.Repositories;
using BookShop.Domain;
using BookShop.Infrastructure;
using BookShop.Infrastructure.Repositories;
using BookShop.Infrastructure.ThirdPartyServices.AzureServices;
using BookShop.Presentantion;
using BookShop.Presentantion.Filters;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add GlobalExceptionFilter
builder.Services.AddControllers( cfg =>
{
    cfg.Filters.Add(typeof(GlobalExceptionFilter));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Db context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

//Add ThirdPartyServices
builder.Services.AddThirdPartyServices(builder.Configuration);

//AddUserIdentity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddMediatR(typeof(CreatePublicationCommand));

// Data repositories
builder.Services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

// AutoMapper
builder.Services.AddAutoMapper(typeof(AssemblyMarketPresentatio));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
