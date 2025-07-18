using microservizio.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace microservizio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<IstatContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("IstatConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
             app.UseSwagger();
             app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}