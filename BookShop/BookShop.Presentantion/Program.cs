using BookShop.Application.Publications.Commands.CreatePublication;
using BookShop.Application.Repositories;
using BookShop.Infrastructure;
using BookShop.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


builder.Services.AddMediatR(typeof(CreatePublicationCommand));

// Data repositories
builder.Services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

// Auto Mapper
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseAuthorization();

app.MapControllers();

app.Run();
