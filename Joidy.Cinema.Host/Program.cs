using CyberCube.Rewards.Host.Jobs;
using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.SqlServer;
using Hellang.Middleware.ProblemDetails;
using Joidy.Cinema.Application;
using Joidy.Cinema.DataLayer;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FluentValidation;
using Joidy.Cinema.Dtos.Request.Movie;
using Joidy.Cinema.Host.Validation.Movie;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("JoidyCinemaConnection");

builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddDbContext<JoidyCinemaContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<DbContext>(sp => sp.GetRequiredService<JoidyCinemaContext>());

builder.Services.AddProblemDetails(options => { options.IncludeExceptionDetails = (context, exception) => false; })
    .AddJoidyProblemDetailsFactory();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationLayer();

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddHangfire(config =>
    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(
            connectionString,
            new SqlServerStorageOptions
            {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true,
                UsePageLocksOnDequeue = true,
                DisableGlobalLocks = true,
                PrepareSchemaIfNecessary = true
            }));

builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireServer();

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    StatsPollingInterval = 5,
    DashboardTitle = "Reward service Hangfire dashboard",
});

JobScheduler.SetupSchedule();

app.UseProblemDetails();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();