using System.Net.Mime;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;
using SLaw.Application;
using SLaw.Infrastructure;
using SLaw.Infrastructure.Services.Storage.Local;
using SLaw.Persistence;
using SLaw.Persistence.Contexts;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SLawDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("SLawDb")), ServiceLifetime.Singleton);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices();

builder.Services.AddStorage<LocalStorage>();

Logger logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/slaw.log", rollingInterval: RollingInterval.Day, shared: true)
                .WriteTo.Seq(builder.Configuration["Seq:ServerURL"] ?? string.Empty)
                .Enrich.FromLogContext()
                .MinimumLevel.Information()
                .CreateLogger();

builder.Host.UseSerilog(logger);

builder.Services.AddHttpLogging(logging =>
                                {
                                    logging.LoggingFields = HttpLoggingFields.All;
                                    logging.RequestHeaders.Add("sec-ch-ua");
                                    logging.MediaTypeOptions.AddText(MediaTypeNames.Application.Json);
                                    logging.RequestBodyLogLimit  = 4096;
                                    logging.ResponseBodyLogLimit = 4096;
                                });

builder.Services.AddCors(x => x.AddDefaultPolicy(y => y.AllowAnyHeader()
                                                       .AllowAnyMethod()
                                                       .AllowAnyOrigin()));


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
