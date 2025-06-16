
using CalculoImposto.Api.Application.Interfaces;
using CalculoImposto.Api.Application.Services;
using CalculoImposto.Api.Domain.Interfaces;
using CalculoImposto.Api.Domain.Services;
using System.Reflection;

namespace CalculoImposto.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona serviços ao conteiner IoC. 
            builder.Services.AddScoped<ICalculoImpostosApplicationService, CalculoImpostosApplicationService>();
            builder.Services.AddScoped<ICalculoImpostoDomainService, CalculoImpostoDomainService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            var app = builder.Build();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "Documentação da API de Cálculo de Impostos";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Cálculo de Impostos v1");
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.DocumentTitle = "Documentação da API de Cálculo de Impostos";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Cálculo de Impostos v1");
                    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
