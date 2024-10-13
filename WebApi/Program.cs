
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Helpers.Models;
using WebApi.Interfaces;
using WebApi.Services;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ISetService, SetService>();
            builder.Services.AddScoped<IPlayerService, PlayerService>();
            builder.Services.AddScoped<IGameService, GameService>();

            builder.Services.AddDbContext<TheBlackbookContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TheBlackbookDatabase")));

            var errorMessages = new List<ErrorMessage>();

            // Adjust the file path to reflect the "Content" folder
            var filePath = Path.Combine(AppContext.BaseDirectory, "Content");

            var configurationRoot = new ConfigurationBuilder()
                .SetBasePath(filePath)
                .AddJsonFile("ErrorMessages.json", optional: false, reloadOnChange: false)
                .Build();

            // Load key-value pairs directly without specifying a section
            errorMessages = configurationRoot.GetSection("errorMessages").Get<List<ErrorMessage>>();



            // Pass error messages to ErrorMessages
            if (errorMessages != null)
                ErrorMessagesCache.LoadMessages(errorMessages);


            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //using (var scope = app.Services.CreateScope())
            //{
            //    var dbContext = scope.ServiceProvider.GetRequiredService<TheBlackbookContext>();
            //    dbContext.Database.EnsureCreated();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}