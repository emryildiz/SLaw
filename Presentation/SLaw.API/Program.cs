using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Prometheus;
using Serilog;
using Serilog.Core;
using SLaw.API;
using SLaw.API.Middlewares;
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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer("Admin", options =>
                              {
                                  options.TokenValidationParameters = new()
                                  {
                                      ValidateAudience = true,
                                      ValidateIssuer = true,
                                      ValidateLifetime = true,
                                      ValidateIssuerSigningKey = true,

                                      ValidAudience = builder.Configuration["Token:Audience"],
                                      ValidIssuer = builder.Configuration["Token:Issuer"],
                                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"] ?? string.Empty)),
                                      LifetimeValidator = (_, expires, _, _) => expires != null && expires > DateTime.UtcNow,

                                      NameClaimType = ClaimTypes.Name
                                  };
                              });

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

SLawDbContext context = app.Services.GetRequiredService<SLawDbContext>();
context.Database.Migrate();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpMetrics();

app.UseSerilogRequestLogging();
app.UseHttpLogging();
app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseAuthorization();
//TODO METRICS
app.MapMetrics();
app.MapControllers();

app.UseCors();

DataGenerator.Generate(app.Services.GetService<SLawDbContext>());

app.Run();
