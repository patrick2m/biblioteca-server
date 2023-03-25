using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using biblioteca_server.Data;

namespace biblioteca_server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection") ?? throw new InvalidOperationException("Connection string 'biblioteca_serverContext' not found.")));

            var corsPolicy = "MinhaPoliticaCORS";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "MinhaPoliticaCORS",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5173");
                    });
            });
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors(corsPolicy);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}