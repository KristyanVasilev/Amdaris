using BookShop.Application.Publications.Commands.CreatePublication;
using BookShop.Application.Repositories;
using BookShop.Domain;
using BookShop.Infrastructure;
using BookShop.Infrastructure.Repositories;
using BookShop.Presentantion;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

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

app.UseExceptionHandler(
    options =>
    {
        options.Run(
            async contex =>
            {
                contex.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var ex = contex.Features.Get<IExceptionHandlerFeature>();
                if (ex != null)
                {
                    await contex.Response.WriteAsync(ex.Error.Message);
                }
            });
    });

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
