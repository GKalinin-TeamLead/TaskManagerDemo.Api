using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TaskManagerDemo.Api;
using TaskManagerDemo.API.Helpers;
using TaskManagerDemo.Core.Interfaces;
using TaskManagerDemo.Core.Services;
using TaskManagerDemo.Data;
using TaskManagerDemo.Data.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TaskManagerDemo.API;

public class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;

    /// <summary>
    /// Стандартный  Asp .net метод 
    /// Выполняет настройку сервисов
    /// </summary>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        
        #region Repositories
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped<IProjectRepository, ProjectRepository>();
        // TODO: Зарегистрировать репозитории для задач

        services.AddScoped<IProjectService, ProjectService>();
        // TODO:  Зарегистрировать сервисы для задач
        #endregion Repositories
        #region Mapper
        services.AddAutoMapper(typeof(Program));
        #endregion Mapper
        #region Swagger
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Task Manager API",
                Version = "v1",
                Description = "Демонстрационный проект API"
            });
        });
        #endregion Swagger
        #region Cors
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
        });

        #endregion Cors
    }

    /// <summary>
    /// Стандартный  Asp .net метод 
    /// Выполняет настройку хоста, применяет cors политики
    /// </summary>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Manager API v1");
                c.RoutePrefix = "swagger";
            });
        }
        else
        {
            app.UseExceptionHandler("/error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                context.Response.Redirect("/swagger");
            });
        });
        InitializeDatabase(app);
    }

    /// <summary>
    /// Инициализация БД / применение миграции
    /// </summary>
    private static void InitializeDatabase(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<AppDbContext>();
            context.Database.EnsureCreated();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Startup>>();
            logger.LogError(ex, "Произошла ошибка при инициализации базы данных");
        }
    }
}