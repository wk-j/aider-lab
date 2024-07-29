using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyApp.Data;
using Serilog;
using System.Reflection;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigureLogging();

            try
            {
                Log.Information("Starting web application");

                var builder = WebApplication.CreateBuilder(args);
                ConfigureServices(builder);

                var app = builder.Build();
                ConfigureMiddleware(app);

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void ConfigureLogging()
        {

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/myapp-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            // AddSerilog to the logging pipeline
            builder.Host.UseSerilog();

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            ConfigureSwagger(builder.Services);
            ConfigureDatabase(builder.Services, builder.Configuration);
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyApp API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        private static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }

        private static void ConfigureMiddleware(WebApplication app)
        {
            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyApp API v1"));
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
