
using CalculoImposto.Api.Application.Interfaces;
using CalculoImposto.Api.Application.Services;
using CalculoImposto.Api.Domain.Interfaces;
using CalculoImposto.Api.Domain.Services;

namespace CalculoImposto.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<ICalculoImpostosApplicationService, CalculoImpostosApplicationService>();
            builder.Services.AddScoped<ICalculoImpostoDomainService, CalculoImpostoDomainService>();


            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
